using System;
using System.IO;
using System.Reflection;
using CefSharp;
using System.Text;
using System.Threading.Tasks;

namespace DuoLogin
{
    public class LocalSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public const string SchemeName = "local";
        public LoginForm parentForm { get; set; }

        private void ProcessSigResponse(string response)
        {
            var sig = Uri.UnescapeDataString(response);
            var username = Duo.Web.VerifyResponse(Global.IntegrationKey, Global.SecretKey, Global.RandomKey, sig);
            Task.Run(() =>
            {
                parentForm.Invoke(new Action(() =>
                {
                    parentForm.LoggedIn(username != null);
                }));
            });
        }     

        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var url = new Uri(request.Url);
            var path = url.PathAndQuery.Replace('/', '.');
            if (path.EndsWith(".cgi")) // Not really, but meh.
            {
                foreach (var element in request.PostData.Elements)
                {
                    var body = element.GetBody("UTF-8");
                    var line = body.Split(new char[] { '=' }, 2);
                    if (line[0] == "sig_response")
                        ProcessSigResponse(line[1]);
                }
                return null;
            }
            Stream file = assembly.GetManifestResourceStream("DuoLogin.web"+path);
            if (file != null)
            {
                if (path.EndsWith("html"))
                {
                    var reader = new StreamReader(file, Encoding.UTF8);
                    var text = reader.ReadToEnd();
                    text = text.Replace("%%ApiHostname%%", Global.ApiHostname);
                    text = text.Replace("%%SigRequest%%", Global.SigRequest);
                    return ResourceHandler.FromString(text, Path.GetExtension(path));
                }
                else
                    return ResourceHandler.FromStream(file, Path.GetExtension(path));
            } 
            else
                return null;
        }
    }
}
