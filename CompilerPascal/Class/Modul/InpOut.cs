using CompilerPascal.ControlUser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerPascal.Class
{
    public class InpOut
    {
        public Dictionary<int, List<ErrorPosition>> ErrorPositions { get; private set; }
        public string[] ProgramFile { get; private set; }
        public string[] MassErrors { get; private set; }
        public TextPosition posNow { get; private set; }
        public StreamWriter StreamWriter { get; private set; }
        public char ch { get; private set; }
        public string Line { get; private set; }
        public int NumError { get; private set; }
        private int numErrorInLine;
        public bool ErrorOverflow { get; private set; }
        public bool EndOfFile { get; private set; }
        public bool EndOfLine { get; private set; }
        private int currNumError = 1;
        private int lastLineError;


        // для интерфейса
        public object Parent { private get; set; }

        public InpOut(string[] programFile, string[] massErrors, StreamWriter streamWriter)
        {
            posNow = new TextPosition()
            {
                PosInLine = 1,
                LineNumber = 1
            };
            ProgramFile = programFile;
            MassErrors = massErrors;
            Line = ProgramFile[posNow.LineNumber - 1];
            ch = Line[0];
            StreamWriter = streamWriter;
            ErrorPositions = new Dictionary<int, List<ErrorPosition>>();
            NumError = 0;
            numErrorInLine = 0;
            ErrorOverflow = false;
            EndOfFile = false;
            iitializeErrorPos();
            lastLineError = 1;
            numErrorInLine = 0;
        }

        private void PrintLineInterface(string line)
        {
            if (Parent != null)
            {
                if (Parent is MainWorkPlace)
                {
                    ((MainWorkPlace)Parent).PrintLine(line + "\n");
                }
            }
        }

        private void PrintLine()
        {
            var numberLine = "  " + (posNow.LineNumber / 10 != 0 ? "" : "0") + posNow.LineNumber + "    ";
            StreamWriter.WriteLine(numberLine + Line);
            PrintLineInterface(numberLine + Line);
        }


        private void ReadNextLine()
        {
            if (posNow.LineNumber - 1 != ProgramFile.Length)
            {
                Line = ProgramFile[posNow.LineNumber - 1];
                EndOfLine = true;
            }
            else
            {
                Line = "";
                EndOfFile = true;
            }

        }

        private void iitializeErrorPos()
        {
            int errMsg, linNum, posInLine;
            numErrorInLine = 0;

            for (int i = 0; i < MassErrors.Length; i++)
            {
                errMsg = linNum = posInLine = 0;
                if (ErrorOverflow)
                    break;
                else
                {
                    var stSplit = MassErrors[i].Split(' ');
                    if (int.TryParse(stSplit[0], out linNum) && int.TryParse(stSplit[1], out posInLine) && int.TryParse(stSplit[2], out errMsg))
                    {
                        if (numErrorInLine == Constants.CountErrorInLine)
                            ErrorOverflow = true;
                        else
                        {
                            error(errMsg, new TextPosition() { LineNumber = linNum, PosInLine = posInLine });
                        }
                    }
                }
            }
        }
        public void ListErrors()
        {
            if (ErrorPositions.ContainsKey(posNow.LineNumber))
            {
                var list = ErrorPositions[posNow.LineNumber];
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        PrintError(i);
                        currNumError++;
                    }
                }
            }        
        }

        public void error(int code, TextPosition textPosition)
        {
            if (numErrorInLine == Constants.CountErrorInLine )
                ErrorOverflow = true;
            else
            {
                if (textPosition.LineNumber == lastLineError)
                {
                    numErrorInLine++;
                }
                else
                {
                    lastLineError = posNow.LineNumber;
                    numErrorInLine = 1;
                }
                   
                NumError++;
                if (!ErrorPositions.ContainsKey(textPosition.LineNumber))
                    ErrorPositions.Add(textPosition.LineNumber, new List<ErrorPosition>()
                    { new ErrorPosition()
                        {
                            ErrCode = code,
                            Line = textPosition.LineNumber,
                            PosInLine = textPosition.PosInLine
                        }
                    });
                else
                    ErrorPositions[textPosition.LineNumber].Add(new ErrorPosition()
                    {
                        ErrCode = code,
                        Line = textPosition.LineNumber,
                        PosInLine = textPosition.PosInLine
                    });
            }
                
          
            
        }

        private void PrintError(int selNumError)
        {
            var stBuild = new StringBuilder();
            stBuild.Append("**");
            if (NumError / 10 == 0)
                stBuild.Append("0" + currNumError);
            else
                stBuild.Append(currNumError);
            stBuild.Append("**");
            
           // rezultNumber.Text += stBuild.ToString() + "\n";
            //stBuild.Clear();
            stBuild.Append(" ");

            for (int i = 0; i < ErrorPositions[posNow.LineNumber][selNumError].PosInLine && i < Line.Length; i++)
            {
                stBuild.Append(" ");
            }

            stBuild.Append("^ ошибка код "+ ErrorPositions[posNow.LineNumber][selNumError].ErrCode);
            StreamWriter.WriteLine(stBuild.ToString());
            PrintLineInterface(stBuild.ToString());
            //rezult.Text += stBuild.ToString()+ "\n";
            stBuild.Clear();
            stBuild.Append("****** ");
           
            //rezultNumber.Text += stBuild.ToString() + "\n";
            //stBuild.Clear();
            if (!Constants.DictMessages.ContainsKey(ErrorPositions[posNow.LineNumber][selNumError].ErrCode))
                stBuild.Append(" имя не описано");
            else
                stBuild.Append(Constants.DictMessages[ErrorPositions[posNow.LineNumber][selNumError].ErrCode]);

            StreamWriter.WriteLine(stBuild.ToString());
            PrintLineInterface(stBuild.ToString());
            //rezult.Text += stBuild.ToString() + "\n";
        }

        public void NextChar()
        {
            if (posNow.PosInLine == Line.Length)
            {
                PrintLine();
                ListErrors();
                posNow.LineNumber++;
                posNow.PosInLine = 1;
                ReadNextLine();
            }
            else
                posNow.PosInLine++;
            if(!EndOfFile)
                ch = Line[posNow.PosInLine-1];
        }
    }
}
