Public Class Form1

    Private _client As DropNetClient


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        '////////////////////////////////////////////////////
        '// NOTE: This key is a Development only key setup for this sample and will not work for you
        '// MAKE SURE YOU CHANGE IT OR IT WONT WORK!
        '////////////////////////////////////////////////////
        _client = New DropNetClient("y0mm6cm3psurvi7", "zfeijf4xbzdi072")

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        Dim authorizeUrl = _client.GetTokenAndBuildUrl("http://www.google.com.au")

        loginBrowser.Navigate(authorizeUrl)

    End Sub


    Private Sub loginBrowser_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles loginBrowser.Navigating

        If e.Url.Host.Contains("google") Then
            _client.GetAccessTokenAsync(AddressOf AccessToken_Success, AddressOf AccessToken_Fail)
        End If

    End Sub

    Private Sub AccessToken_Success(userLogin As DropNet.Models.UserLogin)

        'Save the Token and Secret we get here to save future logins
        _client.GetMetaDataAsync("/", AddressOf GetMetadata_Success, AddressOf AccessToken_Fail)
    End Sub

    Private Sub AccessToken_Fail(ex As DropNet.Exceptions.DropboxException)

        Dim message As String = ex.Message
        If TypeOf ex Is DropNet.Exceptions.DropboxRestException Then
            Dim restEx = CType(ex, DropNet.Exceptions.DropboxRestException)
            message = restEx.Response.Content
        End If

        MessageBox.Show(message)
    End Sub

    Private Sub GetMetadata_Success(response As DropNet.Models.MetaData)
        MessageBox.Show(String.Format("{1} items found", Environment.NewLine, response.Contents.Count))
    End Sub


End Class
