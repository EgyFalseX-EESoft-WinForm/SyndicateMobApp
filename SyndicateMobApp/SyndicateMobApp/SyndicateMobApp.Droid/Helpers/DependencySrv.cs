using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SyndicateMobApp.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SyndicateMobApp.Droid.Helpers.DependencySrv))]
namespace SyndicateMobApp.Droid.Helpers
{
    public class DependencySrv : IDependencySrv
    {
        public DependencySrv() { }
        public double GetAppVersion()
        {
            double.TryParse(Application.Context.ApplicationContext.PackageManager.GetPackageInfo(Application.Context.ApplicationContext.PackageName, 0).VersionName, out double version);
            return version;
        }
    }
}