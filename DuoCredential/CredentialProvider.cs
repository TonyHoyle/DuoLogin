using CredentialProviders;
using System;

namespace DuoCredential
{
    public class CredentialProvider : ICredentialProvider
    {
        public void SetUsageScenario(_CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, uint dwFlags)
        {
            throw new NotImplementedException();
        }

        public void SetSerialization(ref _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs)
        {
            throw new NotImplementedException();
        }

        public void Advise(ICredentialProviderEvents pcpe, uint upAdviseContext)
        {
            throw new NotImplementedException();
        }

        public void UnAdvise()
        {
            throw new NotImplementedException();
        }

        public void GetFieldDescriptorCount(out uint pdwCount)
        {
            throw new NotImplementedException();
        }

        public void GetFieldDescriptorAt(uint dwIndex, IntPtr ppcpfd)
        {
            throw new NotImplementedException();
        }

        public void GetCredentialCount(out uint pdwCount, out uint pdwDefault, out int pbAutoLogonWithDefault)
        {
            throw new NotImplementedException();
        }

        public void GetCredentialAt(uint dwIndex, out ICredentialProviderCredential ppcpc)
        {
            throw new NotImplementedException();
        }
    }
}
