namespace FireSync.Settings
{
    public class JWTSettings
    {
        public string Key { get; set; }
        public string RefreshTokenKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
        public double RefreshTokenDurationInDays { get; set; }
    }
}
