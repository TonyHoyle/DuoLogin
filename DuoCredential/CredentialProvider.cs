using System;
using System.Runtime.InteropServices;
using CredentialProviders;
using Microsoft.VisualStudio;

namespace DuoCredential
{
    public class CredentialProvider : ICredentialProvider, ICustomQueryInterface
    {
        private ICredentialProvider _rootProvider;
        private readonly Guid IID_ICredentialProvider = typeof(ICredentialProvider).GUID;

        public void SetUsageScenario(_CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, uint dwFlags)
        {
            try
            {
                _rootProvider = new PasswordCredentialProvider();
            }
            catch(Exception)
            {
                _rootProvider = new V1PasswordCredentialProvider();
            }
            _rootProvider.SetUsageScenario(cpus, dwFlags);
        }

        public void SetSerialization(ref _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs)
        {
            _rootProvider.SetSerialization(pcpcs);
        }

        public void Advise(ICredentialProviderEvents pcpe, uint upAdviseContext)
        {
            _rootProvider.Advise(pcpe, upAdviseContext);
        }

        public void UnAdvise()
        {
            _rootProvider.UnAdvise();
        }

        public void GetFieldDescriptorCount(out uint pdwCount)
        {
            _rootProvider.GetFieldDescriptorCount(out pdwCount);
        }

        public void GetFieldDescriptorAt(uint dwIndex, IntPtr ppcpfd)
        {
            _rootProvider.GetFieldDescriptorAt(dwIndex, ppcpfd);
        }

        public void GetCredentialCount(out uint pdwCount, out uint pdwDefault, out int pbAutoLogonWithDefault)
        {
            _rootProvider.GetCredentialCount(out pdwCount, out pdwDefault, out pbAutoLogonWithDefault);
        }

        public void GetCredentialAt(uint dwIndex, out ICredentialProviderCredential ppcpc)
        {
            ICredentialProviderCredential cred;
            _rootProvider.GetCredentialAt(dwIndex, out cred);

            if (cred != null)
                ppcpc = new CredentialProviderCredential(cred);
            else
                ppcpc = null;
        }

        public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
        {
            // The shell will ask us for a bunch of interfaces, not all of which are actually documented.
            // We want to just return the default implementation for those cases.
            if (iid == VSConstants.IID_IUnknown || iid == IID_ICredentialProvider)
            {
                ppv = IntPtr.Zero;
                return CustomQueryInterfaceResult.NotHandled;
            }

            if (Marshal.QueryInterface(Marshal.GetIUnknownForObject(_rootProvider), ref iid, out ppv) == VSConstants.S_OK)
                return CustomQueryInterfaceResult.Handled;
            return CustomQueryInterfaceResult.Failed;
        }
    }
}
