using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace DuoLogin
{
    public partial class LoginForm : Form
    {
        private readonly ChromiumWebBrowser browser;

        public LoginForm()
        {
            InitializeComponent();

            Global.SigRequest = Duo.Web.SignRequest(Global.IntegrationKey, Global.SecretKey, Global.RandomKey, Environment.UserDomainName + @"\" + Environment.UserName);

            browser = new ChromiumWebBrowser("local://Web/Index.html");
            browser.MenuHandler = new MenuHandler();
            browser.LifeSpanHandler = new LifeSpanHandler();
            browser.LoadHandler = new LoadHandler();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(browser);
        }

        public void LoggedIn(bool success)
        {
            if (!success)
                browser.Load("local://Web/Index.html");
            else
                this.Close();
        }
    }

    internal class LoadHandler : ILoadHandler
    {
        public void OnFrameLoadEnd(IWebBrowser browserControl, FrameLoadEndEventArgs frameLoadEndArgs)
        {
        }

        public void OnFrameLoadStart(IWebBrowser browserControl, FrameLoadStartEventArgs frameLoadStartArgs)
        {
        }

        public void OnLoadError(IWebBrowser browserControl, LoadErrorEventArgs loadErrorArgs)
        {
        }

        public void OnLoadingStateChange(IWebBrowser browserControl, LoadingStateChangedEventArgs loadingStateChangedArgs)
        {
        }
    }

    internal class LifeSpanHandler : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return true;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            return false;
        }
    }

    internal class MenuHandler : IContextMenuHandler
    {
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            model.Clear();
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return false;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    };
}
