﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DropNet.Models;

namespace DropNet.Samples.WinForms
{
    public partial class Form1 : Form
    {
        private DropNetClient _client;
        private UserLogin _userLogin;

        public Form1()
        {
            InitializeComponent();

            ////////////////////////////////////////////////////
            // NOTE: This key is a Development only key setup for this sample and will not work for you
            // MAKE SURE YOU CHANGE IT OR IT WONT WORK!
            ////////////////////////////////////////////////////
            _client = new DropNetClient("y0mm6cm3psurvi7", "zfeijf4xbzdi072");

            //Set the UseSandbox for app folder access
            _client.UseSandbox = true;

            //NOTE: If user Token and Secret are stored from previous login session:
            //DropNetClient.UserLogin = new Models.UserLogin { Token = "TokenFromStorage", Secret = "SecretFromStorage" };
        }

        private void btn_LoginEmbed_Click(object sender, EventArgs e)
        {
            var authorizeUrl = _client.GetTokenAndBuildUrl("http://www.google.com.au");
            
            brwLogin.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(brwLogin_DocumentCompleted);
            brwLogin.Navigate(authorizeUrl);


            //Async

            ////Get the Request Token then load the browser
            //_client.GetTokenAsync((userLogin) =>
            //    {
            //        //Dont need to do anything here with userLogin if we keep the same instance of DropNetClient

            //        //Now generate the url for the user to authorize the app
            //        var tokenUrl = _client.BuildAuthorizeUrl("http://www.google.com.au"); //Use your own callback Url here

            //        brwLogin.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(brwLogin_DocumentCompleted);
            //        brwLogin.Navigate(tokenUrl);
            //    },
            //    (error) =>
            //    {
            //        //Some sort of error
            //        MessageBox.Show(error.Response.Content);
            //    });
        }

        private void brwLogin_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.Host.Contains("google"))
            {
                //Callback url reached, user has completed authorization

                //Now convert the request token into an access token
                _client.GetAccessTokenAsync((userLogin) =>
                    {
                        //Save the Token and Secret we get here to save future logins
                        _userLogin = userLogin;

                        Invoke((MethodInvoker)delegate
                        {
                            brwLogin.Visible = false;
                        });

                        LoadContents();
                    },
                    (error) =>
                    {
                        //Some sort of error
                        var restError = error as DropNet.Exceptions.DropboxRestException;
                        if (restError != null)
                        {
                            MessageBox.Show(restError.Response.Content);
                        }
                        else
                        {
                            MessageBox.Show(error.Message);
                        }
                    });
            }
        }

        private void LoadContents()
        {
            _client.GetMetaDataAsync("/", (response) =>
            {
                //TODO - something better here to show the contents?
                MessageBox.Show(string.Format("{1} folders found {0}{2} files found", Environment.NewLine, response.Contents.Count(c => c.Is_Dir), response.Contents.Count(c => !c.Is_Dir)));
            },
            (error) =>
            {
                MessageBox.Show(error.Message);
            });
        }

    }
}
