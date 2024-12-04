using MD1;

namespace MD2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            dm = new DataManager();
        }
        public static DataManager dm { get; set; }
    }
}
