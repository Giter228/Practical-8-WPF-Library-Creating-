using System;
using System.Collections.Generic;
using System.Windows;
using De_Serialization_Lib;


namespace Resource_Dictionary_WPF_Practical_8
{
    /// <summary>
    /// Логика взаимодействия для De_Serialization_Window.xaml
    /// </summary>
    public partial class De_Serialization_Window : Window
    {
        public static string way = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string message;
        public De_Serialization_Window()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Name_TXT.Text) || string.IsNullOrEmpty(Surname_TXT.Text) || string.IsNullOrEmpty(Group_TXT.Text))
            {
                MessageBox.Show("Не все поля заполнены");
                return;
            }
            Students st = new Students();
            st.Name = Name_TXT.Text;
            st.Surname = Surname_TXT.Text;
            st.Group = Group_TXT.Text;

            De_Serealize.Serialize(new List<Students>() { st }, way);
            if (App.Language == "RU") message = "Сериализация прошла успешно!";
            else message = "Serialization was successful!";
            MessageBox.Show(message);

            Name_TXT.Text = null;
            Surname_TXT.Text = null;
            Group_TXT.Text = null;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<Students> students = new List<Students>();
            students = De_Serealize.Deserialize<Students>(way);
            if (students.Count == 0)
            {
                if (App.Language == "RU") message = "Файл пустой!";
                else message = "File is empty!";
                MessageBox.Show(message);
                return;
            }

            Name_TXT.Text = students[0].Name;
            Surname_TXT.Text = students[0].Surname;
            Group_TXT.Text = students[0].Group;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow w = new MainWindow();
            w.Show();
            Close();
        }
    }
}
