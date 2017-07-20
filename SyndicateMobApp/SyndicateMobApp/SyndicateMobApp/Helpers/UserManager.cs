namespace SyndicateMobApp.Helpers
{
    public static class UserManager
    {
        public static bool Authenticated { get; set; }
        public static Services.LoginContrect CurrentUser { get; set; }

    }

}
