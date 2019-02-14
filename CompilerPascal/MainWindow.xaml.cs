using CompilerPascal.Class;
using System;
using System.Collections.Generic;
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
        private Dictionary<int, string> errorMessage;
        private List<ErrorPosition> errorPositions;

        public MainWindow()
        {
            InitializeComponent();
            errorPositions = new List<ErrorPosition>();
            initializeErrMsg();
        }

        private void initializeErrMsg()
        {
            errorMessage = new Dictionary<int, string>();
            var st = new string[]
            {
                "ошибка в простом типе","должно идти имя","должно быть служебное слово PROGRAM","должен идти символ  ')'","должен идти символ  ':'","запрещенный символ","ошибка в списке параметров","должно идти  OF","должен идти символ  '('","ошибка в типе",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
                "","","","","","","","","","","","",
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void error(int code, TextPosition textPosition)
        {

        }
    }
}
