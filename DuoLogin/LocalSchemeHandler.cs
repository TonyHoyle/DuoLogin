using System;
using System.IO;
using System.Reflection;
using CefSharp;

namespace DuoLogin
{
    public class LocalSchemeHandlerFactory : ISchemeHandlerFactory
    {
        public const string SchemeName = "local";

        public IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var url = new Uri(request.Url);
            var path = url.PathAndQuery.Replace('/', '.');
            Stream file = assembly.GetManifestResourceStream("DuoLogin.web"+path);
            if (file != null)
                return ResourceHandler.FromStream(file);
            else
                return null;
        }
    }
}
