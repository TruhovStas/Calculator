namespace Calculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Current.UserAppTheme = AppTheme.Dark;
        }
        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);

            const int newWidth = 500;
            const int newHeight = 650;

            window.Width = newWidth;
            window.Height = newHeight;

            return window;
        }
    }
}
