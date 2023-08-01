namespace BookStore.Core.Utilities.Settings
{
    //Options pattern
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public  string Audience { get; set; }
        public  string Key { get; set; }
        public  int Expire { get; set; }
    }
}
