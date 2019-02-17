using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;

namespace SyndicateMobApp.ViewModels
{
    public class ReprintMemberVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        string _id = "";
        RePrintResonContrect _type = null;
        private ObservableCollection<RePrintResonContrect> _dataList;
        private RelayCommand _executeCommand;
        private bool _isLoading;

        public ReprintMemberVm(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _dataList = new ObservableCollection<RePrintResonContrect>();
            LoadData();
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
        public RePrintResonContrect Type
        {
            set
            {
                if (_type != value)
                {
                    _type = value;
                    // Perhaps the login button must be enabled/disabled.
                    _executeCommand.RaiseCanExecuteChanged();
                    RaisePropertyChanged();

                }
            }

            get { return _type; }
        }
        public ObservableCollection<RePrintResonContrect> DataList
        {
            set
            {
                _dataList = value;
                RaisePropertyChanged();
            }

            get { return _dataList; }
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
        private async void LoadData()
        {
            ISyndicateService srv = ServiceLocator.Current.GetInstance<ISyndicateService>();
            DataList = await srv.GetRePrintResonAsync();
        }
        public bool ValidInput()
        {
            if (IsLoading)
                return false;
            if (_id == string.Empty || _type == null)
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
                string confirmation = $"هل انت متأكد لاضافة طلب اعادة طباعة للعضو {Environment.NewLine + member.MMashatName}  ?";
                if (await ServiceLocator.Current.GetInstance<IDialogService>().ShowMessage(confirmation, "تأكيد", "موافق", "الغـــاء", null) == false)
                {
                    IsLoading = false;
                    return;
                }

                string result = await srv.GetReprintMemberAsync(_id, UserManager.CurrentUser.user_id.ToString(), _type.Reprintresonid.ToString());
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
