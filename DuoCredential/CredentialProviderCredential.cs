using System;
using CredentialProviders;

namespace DuoCredential
{
    class CredentialProviderCredential : ICredentialProviderCredential
    {
        public void Advise(ICredentialProviderCredentialEvents pcpce)
        {
            throw new NotImplementedException();
        }

        public void UnAdvise()
        {
            throw new NotImplementedException();
        }

        public void SetSelected(out int pbAutoLogon)
        {
            throw new NotImplementedException();
        }

        public void SetDeselected()
        {
            throw new NotImplementedException();
        }

        public void GetFieldState(uint dwFieldID, out _CREDENTIAL_PROVIDER_FIELD_STATE pcpfs, out _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE pcpfis)
        {
            throw new NotImplementedException();
        }

        public void GetStringValue(uint dwFieldID, out string ppsz)
        {
            throw new NotImplementedException();
        }

        public void GetBitmapValue(uint dwFieldID, IntPtr phbmp)
        {
            throw new NotImplementedException();
        }

        public void GetCheckboxValue(uint dwFieldID, out int pbChecked, out string ppszLabel)
        {
            throw new NotImplementedException();
        }

        public void GetSubmitButtonValue(uint dwFieldID, out uint pdwAdjacentTo)
        {
            throw new NotImplementedException();
        }

        public void GetComboBoxValueCount(uint dwFieldID, out uint pcItems, out uint pdwSelectedItem)
        {
            throw new NotImplementedException();
        }

        public void GetComboBoxValueAt(uint dwFieldID, uint dwItem, out string ppszItem)
        {
            throw new NotImplementedException();
        }

        public void SetStringValue(uint dwFieldID, string psz)
        {
            throw new NotImplementedException();
        }

        public void SetCheckboxValue(uint dwFieldID, int bChecked)
        {
            throw new NotImplementedException();
        }

        public void SetComboBoxSelectedValue(uint dwFieldID, uint dwSelectedItem)
        {
            throw new NotImplementedException();
        }

        public void CommandLinkClicked(uint dwFieldID)
        {
            throw new NotImplementedException();
        }

        public void GetSerialization(out _CREDENTIAL_PROVIDER_GET_SERIALIZATION_RESPONSE pcpgsr, out _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs, out string ppszOptionalStatusText, out _CREDENTIAL_PROVIDER_STATUS_ICON pcpsiOptionalStatusIcon)
        {
            throw new NotImplementedException();
        }

        public void ReportResult(int ntsStatus, int ntsSubstatus, out string ppszOptionalStatusText, out _CREDENTIAL_PROVIDER_STATUS_ICON pcpsiOptionalStatusIcon)
        {
            throw new NotImplementedException();
        }
    }
}
