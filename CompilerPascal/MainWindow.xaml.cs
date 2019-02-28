using CompilerPascal.Class;
using CompilerPascal.Class.Modul;
using CompilerPascal.ControlUser;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CompilerPascal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            createTabItem("Project 1", "Program.txt", "Rezult.txt");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWorkPlace)((TabItem)tabControl.SelectedItem).Content).printNewFile();
        }

        private void createTabItem(string nameProject,string nameFile, string nameFileRezult)
        {
            var tabItem = new TabItem();
            tabItem.Content = new MainWorkPlace(nameFile,nameFileRezult);
            tabItem.Header = nameProject;
            tabControl.Items.Add(tabItem);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                createTabItem(openFileDialog.FileName.Split('\\')[openFileDialog.FileName.Split('\\').Count()-2], openFileDialog.FileNames[1].Split('\\').Last(), openFileDialog.FileNames[0].Split('\\').Last());
            }
        }
    }
}
