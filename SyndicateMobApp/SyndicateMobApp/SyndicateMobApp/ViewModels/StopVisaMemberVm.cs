﻿using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;

namespace SyndicateMobApp.ViewModels
{
    public class StopVisaMemberVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        string _id = "";
        private RelayCommand _executeCommand;
        private bool _isLoading;

        public StopVisaMemberVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        // Public properties
        public string Id
        {
            set
            {
                if (_id != value)
                {
                    _id = value;
                    // Perhaps the login button must be enabled/disabled.
                    _executeCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();

                }
            }

            get { return _id; }
        }

        public string Logo => "logo.png";
        public RelayCommand ExecuteCommand => _executeCommand ?? (_executeCommand = new RelayCommand(Execute, ValidInput));

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                _executeCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }
        // Functions
        public bool ValidInput()
        {
            if (IsLoading)
                return false;
            if (_id == string.Empty)
                return false;
            return true;
        }
        public async void Execute()
        {
            IsLoading = true;
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            try
            {
                LoginMemberContrect member = await srv.LoginMemberAsync(_id);
                if (member == null)
                {
                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowError("رقم فيزا خطــــاء", "لم نتمكن من الوصول للفيزا", "موافق", null);
                    IsLoading = false;
                    return;
                }
                string confirmation = $"هل انت متأكد الايقاف للعضو {Environment.NewLine + member.MMashatName}  ?";
                if (await ServiceLocator.Current.GetInstance<IDialogService>().ShowMessage(confirmation, "تأكيد", "موافق", "الغـــاء", null) == false)
                {
                    IsLoading = false;
                    return;
                }

                string result = await srv.GetStopVisaMemberAsync(_id, UserManager.CurrentUser.user_id.ToString());
                if (result == null)
                {
                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowError("خطــــاء في الاستجابة", "لم نتمكن من الاتصال", "موافق", null);
                    IsLoading = false;
                    return;
                }
                await ServiceLocator.Current.GetInstance<IDialogService>().ShowMessage(result, "نتيــجة العمليــــة", "موافق", null);
            }
            catch (Exception ex)
            {
                await ServiceLocator.Current.GetInstance<IDialogService>().ShowError(ex.Message, "خطــــاء", "موافق", null);
            }
            IsLoading = false;
        }

    }
}
