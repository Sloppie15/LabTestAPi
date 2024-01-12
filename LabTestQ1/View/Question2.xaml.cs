using LabTestQ1.ViewModels;

namespace LabTestQ1.View
{
    public partial class Question2 : ContentPage
    {
        public Question2(RegistrationViewModel viewModel)
        {
            InitializeComponent();
            BindingContext= viewModel;
        }
    }
}
