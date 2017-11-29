using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SyndicateMobApp.Helpers;
using SyndicateMobApp.Services;

namespace SyndicateMobApp.ViewModels
{
    public class MemberAmanatVm : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        string _id = "";
        private RelayCommand _executeCommand;
        private bool _isLoading;

        public MemberAmanatVm(INavigationService navigationService)
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
                MemberInfoContrect member = await srv.GetMemberInfoAsync(_id);
                if (member == null)
                {
                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowError("رقم عضو خطــــاء", "لم نتمكن من الوصول للعضو", "موافق", null);
                    IsLoading = false;
                    return;
                }
                string confirmation = $"هل انت متأكد ارسال طلب الامانات للعضو {Environment.NewLine + member.Name}  ?";
                if (await ServiceLocator.Current.GetInstance<IDialogService>()
                        .ShowMessage(confirmation, "تأكيد", "موافق", "الغـــاء", null) == false)
                {
                    IsLoading = false;
                    return;
                }

                string message = await srv.GetInsertMemberAmanatAsync(_id);
                if (message == "1")
                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowError("نجحت العملية", "تم اضافة الطلب", "موافق", null);
                else
                    await ServiceLocator.Current.GetInstance<IDialogService>().ShowError(message, "لم نتمكن من اضافة الطلب", "موافق", null);
            }
            catch (System.Exception ex)
            {
                // Handle error when login
                await ServiceLocator.Current.GetInstance<IDialogService>().ShowError(ex.Message, "خطــــاء", "موافق", null);
            }
            IsLoading = false;
        }

    }
}
