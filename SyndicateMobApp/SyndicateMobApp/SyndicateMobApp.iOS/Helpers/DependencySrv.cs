using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SyndicateMobApp.Interfaces;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(SyndicateMobApp.iOS.Helpers.DependencySrv))]
namespace SyndicateMobApp.iOS.Helpers
{
    public class DependencySrv : IDependencySrv
    {
        public DependencySrv() { }
        public double GetAppVersion()
        {
            NSObject ver = NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"];
            double.TryParse(ver.ToString().Replace(".", ""), out double version);
            return version;
        }
    }
}