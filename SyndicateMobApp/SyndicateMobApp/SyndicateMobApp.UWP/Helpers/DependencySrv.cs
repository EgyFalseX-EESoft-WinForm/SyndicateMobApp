using SyndicateMobApp.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SyndicateMobApp.UWP.Helpers.DependencySrv))]
namespace SyndicateMobApp.UWP.Helpers
{
    public class DependencySrv : IDependencySrv
    {
        public DependencySrv() { }
        public double GetAppVersion()
        {
            string versionString = Windows.ApplicationModel.Package.Current.Id.Version.Major.ToString()
                + Windows.ApplicationModel.Package.Current.Id.Version.Minor.ToString()
                + Windows.ApplicationModel.Package.Current.Id.Version.Build.ToString()
                + Windows.ApplicationModel.Package.Current.Id.Version.Revision.ToString();
            double.TryParse(versionString, out double version);
            return version;
        }
    }
}