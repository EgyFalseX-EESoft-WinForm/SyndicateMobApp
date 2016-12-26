using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using SyndicateMobApp.Extensions;
using SyndicateMobApp.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SyndicateMobApp.Controls
{
    public class ExtendedMap : Map
    {
        private readonly ObservableCollection<IMapModel> _items = new ObservableCollection<IMapModel>();
        public delegate void ItemChangedEventhandler(IMapModel sender, EventArgs e); public event ItemChangedEventhandler ItemChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ExtendedMap() 
        {
        }
        public ExtendedMap(MapSpan region) : base(region)
        {
            LastMoveToRegion = region;
        }

        public static readonly BindableProperty SelectedPinProperty = BindableProperty.Create<ExtendedMap, ExtendedPin>(x => x.SelectedPin, null);

        public ExtendedPin SelectedPin
        {
            get { return (ExtendedPin)base.GetValue(SelectedPinProperty); }
            set { base.SetValue(SelectedPinProperty, value); }
        }

        public ICommand ShowDetailCommand { get; set; }

        public ICommand LoadCustomersCommand { get; set; }

        private MapSpan _visibleRegion;

        public MapSpan LastMoveToRegion { get; private set; }

        public new MapSpan VisibleRegion
        {
            get { return _visibleRegion; }
            set
            {
                if (_visibleRegion == value)
                {
                    return;
                }
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                OnPropertyChanging("VisibleRegion");
                _visibleRegion = value;
                OnPropertyChanged("VisibleRegion");
            }
        }

        public ObservableCollection<IMapModel> Items
        {
            get { return _items; }
        }
        public void ViewModel_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            _items.Clear();
            foreach (var item in e.NewItems)
                _items.Add((IMapModel)item);
            CollectionChanged?.Invoke(sender, e);
        }
        public void UpdatePins(IEnumerable<IMapModel> items)
        {
            Pins.Clear();
            Items.Clear();
            foreach (var item in items)
            {
                Items.Add(item);
                Pins.Add(item.AsPin());
            }
        }

        public void OnItemChanged(IMapModel mod, EventArgs e)
        {
            ItemChanged?.Invoke(mod, e);
        }
    }
}
