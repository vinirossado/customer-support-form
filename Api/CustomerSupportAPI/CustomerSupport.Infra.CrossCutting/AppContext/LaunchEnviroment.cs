namespace CustomerSupport.Infra.CrossCutting.Common.AppContext
{
    public class LaunchEnvironment
    {
        #region Properties
        public static string AllowedOrigins => Environment.GetEnvironmentVariable("ALLOWED_ORIGINS");
        public static string DbConnection => Environment.GetEnvironmentVariable("Filename=CustumerSupport.db");

        #endregion Properties

        #region Constructors
        public LaunchEnvironment() { }

        #endregion Constructors

    }
}
