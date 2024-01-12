using LabTestQ1.View;
namespace LabTestQ1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Question1), typeof(Question1));
            Routing.RegisterRoute(nameof(Question2), typeof(Question2));
            Routing.RegisterRoute(nameof(Question3), typeof(Question3));
        }
    }
}