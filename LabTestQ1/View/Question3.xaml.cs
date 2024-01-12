using LabTestQ1.ViewModels;
namespace LabTestQ1.View
{
    public partial class Question3 : ContentPage
    {
        public Question3(Question3ViewModel viewModel)
        {
            InitializeComponent();
            BindingContext= viewModel;
        }
    }
}
