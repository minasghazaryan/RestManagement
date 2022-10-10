namespace RestManagement.Shared.Config
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public int Expires { get; set; }
    }
}
