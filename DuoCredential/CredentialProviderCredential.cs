using System;
using System.Runtime.InteropServices;
using CredentialProviders;
using Microsoft.VisualStudio;

namespace DuoCredential
{
    class CredentialProviderCredential : ICredentialProviderCredential, ICredentialProviderCredential2, ICustomQueryInterface
    {
        private readonly ICredentialProviderCredential _rootCredential;
        private readonly ICredentialProviderCredential2 _rootCredential2;
        private readonly Guid IID_ICredentialProviderCredential = typeof(ICredentialProviderCredential).GUID;
        private readonly Guid IID_ICredentialProviderCredential2 = typeof(ICredentialProviderCredential2).GUID;

        public CredentialProviderCredential(ICredentialProviderCredential rootCredential)
        {
            _rootCredential = rootCredential;
            if (_rootCredential is ICredentialProviderCredential2)
                _rootCredential2 = _rootCredential as ICredentialProviderCredential2;
        }

        public void Advise(ICredentialProviderCredentialEvents pcpce)
        {
            _rootCredential.Advise(pcpce);
        }

        public void UnAdvise()
        {
            _rootCredential.UnAdvise();
        }

        public void SetSelected(out int pbAutoLogon)
        {
            _rootCredential.SetSelected(out pbAutoLogon);
        }

        public void SetDeselected()
        {
            _rootCredential.SetDeselected();
        }

        public void GetFieldState(uint dwFieldID, out _CREDENTIAL_PROVIDER_FIELD_STATE pcpfs, out _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE pcpfis)
        {
            _rootCredential.GetFieldState(dwFieldID, out pcpfs, out pcpfis);
        }

        public void GetStringValue(uint dwFieldID, out string ppsz)
        {
            _rootCredential.GetStringValue(dwFieldID, out ppsz);
        }

        public void GetBitmapValue(uint dwFieldID, IntPtr phbmp)
        {
            _rootCredential.GetBitmapValue(dwFieldID, phbmp);
        }

        public void GetCheckboxValue(uint dwFieldID, out int pbChecked, out string ppszLabel)
        {
            _rootCredential.GetCheckboxValue(dwFieldID, out pbChecked, out ppszLabel);
        }

        public void GetSubmitButtonValue(uint dwFieldID, out uint pdwAdjacentTo)
        {
            _rootCredential.GetSubmitButtonValue(dwFieldID, out pdwAdjacentTo);
        }

        public void GetComboBoxValueCount(uint dwFieldID, out uint pcItems, out uint pdwSelectedItem)
        {
            _rootCredential.GetComboBoxValueCount(dwFieldID, out pcItems, out pdwSelectedItem);
        }

        public void GetComboBoxValueAt(uint dwFieldID, uint dwItem, out string ppszItem)
        {
            _rootCredential.GetComboBoxValueAt(dwFieldID, dwItem, out ppszItem);
        }

        public void SetStringValue(uint dwFieldID, string psz)
        {
            _rootCredential.SetStringValue(dwFieldID, psz);
        }

        public void SetCheckboxValue(uint dwFieldID, int bChecked)
        {
            _rootCredential.SetCheckboxValue(dwFieldID, bChecked);
        }

        public void SetComboBoxSelectedValue(uint dwFieldID, uint dwSelectedItem)
        {
            _rootCredential.SetComboBoxSelectedValue(dwFieldID, dwSelectedItem);
        }

        public void CommandLinkClicked(uint dwFieldID)
        {
            _rootCredential.CommandLinkClicked(dwFieldID);
        }

        public void GetSerialization(out _CREDENTIAL_PROVIDER_GET_SERIALIZATION_RESPONSE pcpgsr, out _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs, out string ppszOptionalStatusText, out _CREDENTIAL_PROVIDER_STATUS_ICON pcpsiOptionalStatusIcon)
        {
            _rootCredential.GetSerialization(out pcpgsr, out pcpcs, out ppszOptionalStatusText, out pcpsiOptionalStatusIcon);
        }

        public void ReportResult(int ntsStatus, int ntsSubstatus, out string ppszOptionalStatusText, out _CREDENTIAL_PROVIDER_STATUS_ICON pcpsiOptionalStatusIcon)
        {
            _rootCredential.ReportResult(ntsStatus, ntsSubstatus, out ppszOptionalStatusText, out pcpsiOptionalStatusIcon);
        }

        public void GetUserSid(out string sid)
        {
            // We can't get here unless called via the ICredentialProviderCredential2 interface
            _rootCredential2.GetUserSid(out sid);
        }

        public CustomQueryInterfaceResult GetInterface(ref Guid iid, out IntPtr ppv)
        {
            // The shell will ask us for a bunch of interfaces, not all of which are actually documented.
            // We want to just return the default implementation for those cases.
            ppv = IntPtr.Zero;
            if(iid == IID_ICredentialProviderCredential2)
            {
                if (_rootCredential2 != null) return CustomQueryInterfaceResult.NotHandled;
                else return CustomQueryInterfaceResult.Failed;
            }
            if (iid == VSConstants.IID_IUnknown || iid == IID_ICredentialProviderCredential)
                  return CustomQueryInterfaceResult.NotHandled;

            if (Marshal.QueryInterface(Marshal.GetIUnknownForObject(_rootCredential), ref iid, out ppv) == VSConstants.S_OK)
                return CustomQueryInterfaceResult.Handled;
            return CustomQueryInterfaceResult.Failed;
        }
    }
}
