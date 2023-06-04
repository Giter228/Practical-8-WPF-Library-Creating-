using System;
using System.IO;
using System.Windows;

namespace Resource_Dictionary_WPF_Practical_8
{
    public partial class App : Application
    {
        static string DesktopLink = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        static string ToSaveThemeLink = $"{DesktopLink}\\savedTheme.txt";
        static string ToSaveLanguageLink = $"{DesktopLink}\\savedLanguage.txt";
        private static string theme;
        public static string Theme
        {
            get { return theme; }
            set 
            { 
                theme = value;
                var dict = new ResourceDictionary { Source = new Uri($"pack://application:,,,/ThemesLib;component/Themes/{value}.xaml", UriKind.Absolute)};

                Current.Resources.MergedDictionaries.RemoveAt(0);
                Current.Resources.MergedDictionaries.Insert(0, dict);

                File.WriteAllText(ToSaveThemeLink, value);
            }
        }

        private static string language;
        public static string Language
        {
            get { return language; }
            set 
            { 
                language = value;
                var dict = new ResourceDictionary { Source = new Uri($"pack://application:,,,/LocalizeLib;component/Themes/{value}_Dictionary.xaml", UriKind.Absolute)};
                
                Current.Resources.MergedDictionaries.RemoveAt(1);
                Current.Resources.MergedDictionaries.Insert(1, dict);

                File.WriteAllText(ToSaveLanguageLink, value);
            }
        }
        
        public App()
        {
            InitializeComponent();
            CheckThemeAndLanguage();
        }
        private void CheckThemeAndLanguage()
        {
            if (File.Exists(ToSaveThemeLink)) Theme = File.ReadAllText(ToSaveThemeLink);
            if (File.Exists(ToSaveLanguageLink)) Language = File.ReadAllText(ToSaveLanguageLink);
        }
    }
}
