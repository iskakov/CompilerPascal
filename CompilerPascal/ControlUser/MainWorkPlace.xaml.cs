using CompilerPascal.Class;
using CompilerPascal.Class.Modul;
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

namespace CompilerPascal.ControlUser
{
    /// <summary>
    /// Логика взаимодействия для MainWorkPlace.xaml
    /// </summary>
    public partial class MainWorkPlace : UserControl
    {
        InpOut modulInpOut;
        LexAnalyz lexAnalyz;

        private string nameFile;
        private string nameFileRezult;

        public MainWorkPlace(string nameFile, string nameFileRezult)
        {
            InitializeComponent();
           this.nameFile = nameFile;
            this.nameFileRezult = nameFileRezult;
            initializeFileProgram();
        }

        private void initializeFileProgram()
        {
            string lineRead = "";
            beginName.Text = nameFile;
            using (var streamReader = new StreamReader("\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile\\" + nameFile, System.Text.Encoding.Default))
            {
                int i = 1;

                while ((lineRead = streamReader.ReadLine()) != null)
                {
                    beginNumber.Text += i + "\n\n";
                    begin.AppendText(lineRead + "\n");
                    i++;
                }
            }

            using (var streamReader = new StreamReader("\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile\\Error.txt", System.Text.Encoding.Default))
            {
                RTB.AppendText(streamReader.ReadToEnd());
            }
        }

        private void deleteSymbol(string[] stMass)
        {
            for (int i = 0; i < stMass.Length; i++)
            {
                if (stMass[i][stMass[i].Length - 1] == '\r')
                    stMass[i] = stMass[i].Remove(stMass[i].Length - 1);
            }
        }

        public void printNewFile()
        {
            rezultNumber.Text = "";
            rezult.Text = "";
            var st = new TextRange(begin.Document.ContentStart, begin.Document.ContentEnd).Text;
            st = st.Remove(st.Length - 3);
            var stMass = st.Split('\n');
            deleteSymbol(stMass);
            var st2 = new TextRange(RTB.Document.ContentStart, RTB.Document.ContentEnd).Text;
            //st2 = st2.Remove(st2.Length - 2);
            var stMass2 = st2.Split('\n');

           // deleteSymbol(stMass2);
            rezultName.Text = nameFileRezult;
            using (var streamWriter = new StreamWriter("\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile\\" + nameFileRezult, false))
            {
                modulInpOut = new InpOut(stMass, stMass2, streamWriter);
                modulInpOut.Parent = this;
                lexAnalyz = new LexAnalyz(modulInpOut, "Listing.txt");

                while (!modulInpOut.EndOfFile)
                {
                    lexAnalyz.NextSum();
                }
                if (lexAnalyz.IsComm)
                {
                    modulInpOut.error(86, modulInpOut.posNow);
                    modulInpOut.ListErrors();
                }
                streamWriter.WriteLine("Кoмпиляция окончена: ошибок - " + modulInpOut.NumError + "!");
                rezult.Text += "Кoмпиляция окончена: ошибок - " + modulInpOut.NumError + "!" + "\n";
            }
        }

        public void PrintLine(string line)
        {
            rezult.Text += line;
        }

        
    }
}
