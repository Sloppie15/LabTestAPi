using System;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LabTestQ1.ViewModels
{
    public class RegistrationViewModel : ObservableObject
    {
        private string _phoneNumber;
        private string _password;
        private bool _termsAccepted;
        private bool _isInvalidPhoneNumber;
        private bool _isInvalidPassword;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                SetProperty(ref _phoneNumber, value);
                OnPropertyChanged(nameof(IsFormValid));
                IsInvalidPhoneNumber = !IsValidPhoneNumber(value);
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                OnPropertyChanged(nameof(IsFormValid));
                IsInvalidPassword = !IsValidPassword(value);
            }
        }

        public bool TermsAccepted
        {
            get => _termsAccepted;
            set
            {
                SetProperty(ref _termsAccepted, value);
                OnPropertyChanged(nameof(IsFormValid));
            }
        }

        public ICommand ToggleTermsCommand => new RelayCommand(ToggleTerms);
        public ICommand RegisterCommand => new RelayCommand(Register, () => IsFormValid);

        public bool IsInvalidPhoneNumber
        {
            get => _isInvalidPhoneNumber;
            set => SetProperty(ref _isInvalidPhoneNumber, value);
        }

        public bool IsInvalidPassword
        {
            get => _isInvalidPassword;
            set => SetProperty(ref _isInvalidPassword, value);
        }

        public bool IsFormValid => !IsInvalidPhoneNumber && !IsInvalidPassword && Password?.Length >= 6;

        private void ToggleTerms()
        {
            TermsAccepted = !TermsAccepted;
        }

        private void Register()
        {
            // Implement your registration logic here
        }

        private bool IsValidPhoneNumber(string number)
        {
            return !string.IsNullOrWhiteSpace(number) && number.Length == 10 && long.TryParse(number, out _);
        }

        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length >= 6;
        }
    }
}
