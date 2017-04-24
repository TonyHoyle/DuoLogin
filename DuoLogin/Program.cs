using System;
using System.Windows.Forms;
using CefSharp;

namespace DuoLogin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Cef.EnableHighDPISupport();
            var settings = new CefSettings();
            settings.RegisterScheme(new CefCustomScheme
            {
                SchemeName = LocalSchemeHandlerFactory.SchemeName,
                SchemeHandlerFactory = new LocalSchemeHandlerFactory()
            });
            Cef.Initialize(settings);
            Application.Run(new LoginForm());
        }
    }
}
