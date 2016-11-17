using System;
using GalaSoft.MvvmLight;

namespace SyndicateMobApp.Helpers
{
    public class MasterPageItem : ViewModelBase
    {
        private int _id;
        public int Id
        {
            set
            {
                _id = value;
                RaisePropertyChanged();
            }

            get { return _id; }
        }

        private string _title;
        public string Title {
            set
            {
                _title = value;
                RaisePropertyChanged();
            }

            get { return _title; }
        }

        private string _iconSource;
        public string IconSource {
            set
            {
                _iconSource = value;
                RaisePropertyChanged();
            }

            get { return _iconSource; }
        }

        private string _pageKey;
        public string PageKey {
            set
            {
                _pageKey = value;
                RaisePropertyChanged();
            }

            get { return _pageKey; }
        }

        private bool _visible;
        public bool Visible {
            set
            {
                _visible = value;
                RaisePropertyChanged();
            }

            get { return _visible; }
        }

    }
}