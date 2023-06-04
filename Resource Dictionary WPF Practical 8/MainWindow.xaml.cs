using System.Windows;

namespace Resource_Dictionary_WPF_Practical_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThemesWindow w = new ThemesWindow();
            w.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            De_Serialization_Window w = new De_Serialization_Window();
            w.Show();
            Close();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            App.Language = "RU";
            ReloadWindow();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            App.Language = "EN";
            ReloadWindow();
        }
        private void ReloadWindow()
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
    }
}
