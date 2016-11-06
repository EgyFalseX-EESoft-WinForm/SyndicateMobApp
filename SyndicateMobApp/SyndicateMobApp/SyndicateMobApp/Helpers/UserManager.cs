namespace SyndicateMobApp.Helpers
{
    public static class UserManager
    {
        public static int Id { get; set; } = 0;
        public static Types.UserType Type { get; set; }

        public static Services.LoginMemberContrect Member { get; set; }
        public static Services.LoginWarasaContrect Warasa { get; set; }

    }

}
