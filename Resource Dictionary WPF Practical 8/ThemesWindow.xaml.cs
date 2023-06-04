using System.Windows;
using System.Windows.Controls;

namespace Resource_Dictionary_WPF_Practical_8
{
    /// <summary>
    /// Логика взаимодействия для ThemesWindow.xaml
    /// </summary>
    public partial class ThemesWindow : Window
    {
        public ThemesWindow()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selected = ListBox.SelectedIndex;

            switch (selected)
            {
                case 0:
                    App.Theme = "PurpleTheme";
                    break;
                case 1:
                   App.Theme = "SpringTheme";
                    break;
                case 2:
                    App.Theme = "AutumnTheme";
                    break;
                case 3:
                    App.Theme = "SummerTheme";
                    break;
                case 4:
                    App.Theme = "WinterTheme";
                    break;

                default:
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
    }
}
