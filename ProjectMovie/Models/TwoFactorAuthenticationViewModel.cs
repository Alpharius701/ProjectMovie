namespace ProjectMovie.Models
{
    public class TwoFactorAuthenticationViewModel
    {
        public bool Is2faEnabled { get; set; }
        public int RecoveryCodesLeft { get; set; }
        public bool HasAuthenticator { get; set; }
        public bool IsMachineRemembered { get; set; }
    }
}
