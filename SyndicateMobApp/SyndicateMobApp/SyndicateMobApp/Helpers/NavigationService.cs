﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace SyndicateMobApp.Helpers
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationPage _navigation;

        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = _navigation.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public void GoBack()
        {
            _navigation.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }
        public void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    Type type = _pagesByKey[pageKey];
                    ConstructorInfo constructor = null;
                    object[] parameters = null;

                    if (parameter == null)
                    {
                        constructor =
                            type.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1 && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[]
                        {
                            parameter
                        };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException("No suitable constructor found for page " + pageKey);
                    }

                    //List<Page> existingPages = _navigation.Navigation.NavigationStack.ToList();
                    //foreach (Page pageItem in existingPages)
                    //    _navigation.Navigation.RemovePage(pageItem);

                    Page page = constructor.Invoke(parameters) as Page;
                    _navigation.PushAsync(page);

                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }
            }
        }
        public void NavigateTo(string pageKey, bool clearPageStack)
        {
            NavigateTo(pageKey, null, clearPageStack);
        }
        public void NavigateTo(string pageKey, object parameter, bool clearPageStack)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    Type type = _pagesByKey[pageKey];
                    ConstructorInfo constructor = null;
                    object[] parameters = null;

                    if (parameter == null)
                    {
                        constructor =
                            type.GetTypeInfo().DeclaredConstructors.FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1 && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[]
                        {
                            parameter
                        };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException("No suitable constructor found for page " + pageKey);
                    }

                    Page page = constructor.Invoke(parameters) as Page;
                    //clear stack pages before puch
                    //if (clearPageStack)
                    //{
                    //    List<Page> existingPages = _navigation.Navigation.NavigationStack.ToList();
                    //    foreach (Page pageItem in existingPages)
                    //        _navigation.Navigation.RemovePage(pageItem);
                    //}

                    _navigation.PushAsync(page);
                    
                }
				else
				{
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
				}
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public void Initialize(NavigationPage navigation)
        {
            _navigation = navigation;
        }
    }
}