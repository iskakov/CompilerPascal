using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerPascal.Class.Modul
{
    public class LexAnalyz
    {
        int symbol;
        private TextPosition textPosition;
        private InpOut inpOut;
       private string nameFileListing;
        public bool IsComm { get; private set; } = false;
        private bool isError = false;
        private bool isMinus = false;

        int num_int;
        float num_float;
        char one_symbol;
        string name;
        int nameLength;

        

        public LexAnalyz(InpOut inpOut, string nameFileListing)
        {
            this.inpOut = inpOut;
            this.nameFileListing = nameFileListing;
            textPosition = new TextPosition()
            {
                LineNumber = 1,
                PosInLine = 1
            };
            using (var streamWriter = new StreamWriter("\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile\\" + nameFileListing, false))
            {
            }
        }

        public void NextSum()
        {
            while (inpOut.ch == ' ')
                inpOut.NextChar();
            if (textPosition.LineNumber != inpOut.posNow.LineNumber)
            {
                if(!IsComm)
                printinFile(false);
             
            }
            textPosition.LineNumber = inpOut.posNow.LineNumber;
            textPosition.PosInLine = inpOut.posNow.PosInLine;
            scanSymbol();
        }

       

        private void printinFile(bool p)
        {
            if (!IsComm && !isError)
            {
                using (var streamWriter = new StreamWriter("\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile\\" + nameFileListing, true))
                {
                    if (p)
                        streamWriter.Write(symbol.ToString() + " ");
                    else
                        streamWriter.WriteLine();
                }
                isError = false;
            }
            else
            {
                
                if (!p && !isError)
                {
                    using (var streamWriter = new StreamWriter("\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile\\" + nameFileListing, true))
                    {
                            streamWriter.WriteLine();
                    }
                }
                if (isError)
                    isError = false;
            }
                
                
        }

        private void scanSymbol()
        {
            switch (inpOut.ch)
            {
                case '*':
                    inpOut.NextChar();
                    if (inpOut.ch == ')')
                    {
                        symbol = Constants.rcomment;
                        IsComm = false;
                        inpOut.NextChar();
                    }
                    else
                        symbol = Constants.star;
                    break;
                case '/':
                    symbol = Constants.slash;
                    inpOut.NextChar();
                    break;
                case '=':
                    inpOut.NextChar();
                    if (inpOut.ch == '>')
                    {
                        symbol = Constants.greaterequal;
                        inpOut.NextChar();
                    }
                    else
                        symbol = Constants.equal;
                    break;
                case ',':
                    symbol = Constants.comma;
                    inpOut.NextChar();
                    break;
                case ';':
                    symbol = Constants.semicolon;
                    inpOut.NextChar();
                    break;
                case ':':
                    inpOut.NextChar();
                    if (inpOut.ch == '=')
                    {
                        symbol = Constants.assign;
                        inpOut.NextChar();
                    }
                    else
                        symbol = Constants.colon;
                    break;
                case '.':
                    inpOut.NextChar();
                    if (inpOut.ch == '.')
                    {
                        symbol = Constants.twopoints;
                        inpOut.NextChar();
                    }
                    else
                        symbol = Constants.point;
                    break;
                case '^':
                    symbol = Constants.arrow;
                    inpOut.NextChar();
                    break;
                case '(':
                    inpOut.NextChar();
                    if (inpOut.ch == '*')
                    {
                        symbol = Constants.lcomment;
                        using (var streamWriter = new StreamWriter("\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile\\" + nameFileListing, true))
                        {
                            streamWriter.Write(symbol.ToString() + " ");
                        }
                        IsComm = true;
                        inpOut.NextChar();
                    }
                    else
                        symbol = Constants.leftpar;
                    break;
                case ')':
                    symbol = Constants.rightpar;
                    inpOut.NextChar();
                    break;
                case '[':
                    symbol = Constants.lbracket;
                    inpOut.NextChar();
                    break;
                case ']':
                    symbol = Constants.rbracket;
                    inpOut.NextChar();
                    break;
                case '{':
                    symbol = Constants.flpar;
                    using (var streamWriter = new StreamWriter("\\\\Mac\\Home\\Desktop\\Универ\\Методы трансляции\\CompilerPascal\\CompilerPascal\\TextFile\\" + nameFileListing, true))
                    {
                        streamWriter.Write(symbol.ToString() + " ");
                    }
                    IsComm = true;
                    inpOut.NextChar();
                    break;
                case '}':
                    symbol = Constants.frpar;
                    IsComm = false;
                    inpOut.NextChar();
                    break;
                case '<':
                    inpOut.NextChar();
                    if (inpOut.ch == '=')
                    {
                        symbol = Constants.laterequal;
                        inpOut.NextChar();
                    }
                    else
                    {
                        if (inpOut.ch == '>')
                        {
                            symbol = Constants.latergreater;
                            inpOut.NextChar();
                        }
                        else
                            symbol = Constants.later;
                    }
                    break;
                case '>':
                    symbol = Constants.greater;
                    inpOut.NextChar();
                    break;
                case '-':
                    symbol = Constants.minus;
                    isMinus = true;
                    inpOut.NextChar();
                    break;
                case '+':
                    symbol = Constants.plus;
                    inpOut.NextChar();
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    num_int = 0;
                    var tp = textPosition;
                    while (inpOut.ch >= '0' && inpOut.ch <= '9')
                    {
                        int digit = inpOut.ch - '0';
                        if (num_int < Constants.MaxInt / 10 || (num_int == Constants.MaxInt / 10 && digit <= Constants.MaxInt % 10))
                        {
                            num_int = 10 * num_int + digit;
                        }
                        else
                        {
                            if (!IsComm)
                            {
                                inpOut.error(203, inpOut.posNow);
                                isError = true;
                            }                        
                            num_int = 0;
                        }
                        inpOut.NextChar();
                    }
                    if (inpOut.ch == 'E')
                    {
                        inpOut.NextChar();
                        bool prov = false;
                        string flSt = num_int.ToString() + "E" ;
                        if (inpOut.ch == '+' || inpOut.ch == '-')
                        {
                            flSt += inpOut.ch;
                            inpOut.NextChar();
                        }
                        while (inpOut.ch >= '0' && inpOut.ch <= '9')
                        {
                            prov = true;
                            flSt += inpOut.ch;
                            inpOut.NextChar();
                        }
                        if (prov)
                        {
                            var k = float.TryParse(flSt, out num_float);
                            if (k)
                            {
                                symbol = Constants.floatc;
                            }
                            else
                            {
                                if (!IsComm)
                                {
                                    if (isMinus)
                                        inpOut.error(206, tp);
                                    else
                                        inpOut.error(207, tp);
                                    isError = true;

                                }
                            }
                        }
                        else
                        {
                            if (!IsComm)
                            {
                                inpOut.error(201, tp);
                                isError = true;
                            }
                        }
                       
                    }
                    else
                    {
                        if (inpOut.ch == '.')
                        {
                            num_float = num_int;
                            inpOut.NextChar();
                            var ip = 0.1;
                            while (inpOut.ch >= '0' && inpOut.ch <= '9')
                            {
                                int digit = inpOut.ch - '0';
                                if (num_int < Constants.MaxInt / 10 || (num_int == Constants.MaxInt / 10 && digit <= Constants.MaxInt % 10))
                                {
                                    num_float = (float)(num_float + ip * digit);
                                    ip *= ip;
                                }
                                else
                                {
                                    if (!IsComm)
                                    {
                                        inpOut.error(203, textPosition);
                                        isError = true;
                                    }

                                    num_float = 0;
                                }
                                inpOut.NextChar();
                            }

                            if (inpOut.ch == 'E')
                            {
                                inpOut.NextChar();
                                bool prov = false;
                                string flSt = num_int.ToString() + "E";
                                if (inpOut.ch == '+' || inpOut.ch == '-')
                                {
                                    flSt += inpOut.ch;
                                    inpOut.NextChar();
                                }
                                while (inpOut.ch >= '0' && inpOut.ch <= '9')
                                {
                                    prov = true;
                                    flSt += inpOut.ch;
                                    inpOut.NextChar();
                                }
                                if (prov)
                                {
                                    var k = float.TryParse(flSt, out num_float);
                                    if (k)
                                    {
                                        symbol = Constants.floatc;
                                    }
                                    else
                                    {
                                        if (!IsComm)
                                        {
                                            if (isMinus)
                                                inpOut.error(206, tp);
                                            else
                                                inpOut.error(207, tp);
                                            isError = true;

                                        }
                                    }
                                }
                            }
                        }
                        else
                        if ((inpOut.ch >= 'a' && inpOut.ch <= 'z') || (inpOut.ch >= 'A' && inpOut.ch <= 'Z'))
                        {// код ошибки
                            if (!IsComm)
                            {
                                inpOut.error(21, tp);
                                isError = true;
                            }

                            while ((inpOut.ch >= 'a' && inpOut.ch <= 'z') || (inpOut.ch >= 'A' && inpOut.ch <= 'Z') || (inpOut.ch >= '0' && inpOut.ch <= '9'))
                                inpOut.NextChar();
                        }
                        else
                            symbol = Constants.intc;
                    }
                    isMinus = false;
                    break;
                case '\'':
                    inpOut.NextChar();
                    if ((inpOut.ch >= 'a' && inpOut.ch <= 'z') || (inpOut.ch >= 'A' && inpOut.ch <= 'Z') || inpOut.ch >= '0' && inpOut.ch <= '9')
                    {
                        inpOut.NextChar();
                        if (inpOut.ch == '\'')
                        {
                            symbol = Constants.charc;
                            inpOut.NextChar();
                        }
                        else
                        {
                            if (!IsComm)
                            {
                                inpOut.error(75, textPosition);
                                isError = true;
                            }
                             
                        }
                            
                    }
                    else
                    {
                        if (inpOut.ch == '\'')
                            inpOut.NextChar();
                        if (!IsComm)
                        {
                            inpOut.error(75, textPosition);
                            isError = true;
                        }
                    }
                    break;
                //case '"':
                //    inpOut.NextChar();
                //    var stLen = 0;
                //    while(inpOut.ch != '"' && stLen < Constants.MaxLenStr)
                //    {
                //        inpOut.NextChar();
                //        stLen++;
                //    }
                //    if (stLen == Constants.MaxLenStr)
                //        inpOut.error(6, inpOut.posNow);
                //    else
                //    {
                //        symbol = Constants.stringc;
                //        inpOut.NextChar();
                //    }
                //    break;
                case '?':
                case '&':
                case '%':
                    if (!IsComm)
                    {
                        inpOut.error(6, textPosition);
                        isError = true;
                    }
                    inpOut.NextChar();
                    break;
                default:
                    nameLength = 0;
                    name = "";
                    while (((inpOut.ch >= 'a' && inpOut.ch <= 'z') || (inpOut.ch >= 'A' && inpOut.ch <= 'Z') ||
                            (inpOut.ch >= '0' && inpOut.ch <= '9')))
                    {
                        name += inpOut.ch;
                        inpOut.NextChar();
                    }
                    var retInt = searchInTable();
                    if (retInt.Equals(-1))
                        symbol = Constants.ident;
                    else
                        symbol = retInt;
                    break;
            }
            printinFile(true);
        }

        private int searchInTable()
        {
            return Constants.tableServiceNames[name.Length].ContainsKey(name) ? Constants.tableServiceNames[name.Length][name] : -1;
        }
    }
}
