using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerPascal.Class
{
    public static class Constants
    {
        public static int CountErrorInLine { get; } = 6;
        public static Dictionary<int, string> DictMessages { get; } = new Dictionary<int, string>()
        {
                { 1,"ошибка в простом типе" },
                { 2,"должно идти имя" },
                { 3,"должно быть служебное слово PROGRAM" },
                { 4,"должен идти символ  ')'"},
                { 5,"должен идти символ  ':'"},
                { 6,"запрещенный символ"},
                { 7,"ошибка в списке параметров"},
                { 8,"должно идти  OF"},
                { 9,"должен идти символ  '('"},
                { 10,"ошибка в типе"},
                { 11,"должен идти символ  '['"},
                { 12,"должен идти символ  ']'"},
                { 13,"должно идти слово  END"},
                { 14,"должен идти символ  ';'"},
                { 15,"должно идти целое"},
                { 16,"должен идти символ  '='"},
                { 17,"должно идти слово  BEGIN"},
                { 18,"ошибка в разделе описаний" },
                { 19,"ошибка в списке полей" },
                { 20, "должен идти символ  ','" },
                { 21,"ошибка в переменной" },
                { 50,"ошибка в константе" },
                { 51,"должен идти символ  ':='" },
                { 52,"должно идти слово  THEN" },
                { 53,"должно идти слово  UNTIL"},
                { 54,"должно идти слово  DO"},
                { 55,"должно идти слово  TO  или  DOWNTO"},
                { 56,"должно идти слово  IF"},
                { 61,"должен идти символ  '.'"},
                { 74,"должен идти символ  '..'"},
                { 75,"ошибка в символьной константе"},
                { 76,"слишком длинная строковая константа"},
                { 86,"комментарий не закрыт"},
                { 83,"Должна идти символьная константа"},
                { 100,"использование имени не соответствует описанию"},
                { 101,"имя описано повторно"},
                { 102,"нижняя граница превосходит верхнюю"},
                { 103,"Имя не принадлежит соответствующему классу"},
                { 104,"имя не описано"},
                { 105,"недопустимое рекурсивное определение"},
                { 108,"файл здесь использовать нельзя"},
                { 109,"тип не должен быть  REAL"},
                { 111,"несовместимость с типом дискриминанта"},
                { 112,"недопустимый ограниченный тип"},
                { 114,"тип основания не должен быть  REAL  или  INTEGER"},
                { 115,"файл должен быть текстовым"},
                { 116,"ошибка в типе параметра стандартной процедуры"},
                { 117 ,"неподходящее опережающее описание"},
                { 118 ,"едопустимый тип пpизнака ваpиантной части записи"},
                { 119 ,"опережающее описание: повторение списка параметров не допускается"},
                { 120 ,"тип результата функции должен быть скалярным, ссылочным или ограниченным" },
                { 121 ,"параметр-значение не может быть файлом"},
                { 122 ,"опережающее описание функции: повторять тип результата нельзя"},
                { 123 ,"в описании функции пропущен тип результата"},
                { 124 ,"F-формат только для  REAL"},
                { 125 ,"ошибка в типе параметра стандартной функции"},
                { 126 ,"число параметров не согласуется с описанием"},
                { 127 ,"недопустимая подстановка параметров"},
                { 128 ,"тип результата функции не соответствует описанию"},
                { 130 ,"выражение не относится к множественному типу"},
                { 135 ,"тип операнда должен быть  BOOLEAN"},
                { 137 ,"недопустимые типы элементов множества"},
                { 138 ,"переменная не есть массив"},
                { 139 ,"тип индекса не соответствует описанию"},
                { 140 ,"переменная не есть запись"},
                { 141 ,"переменная должна быть файлом или ссылкой"},
                { 142 ,"недопустимая подстановка параметров"},
                { 143 ,"недопустимый тип параметра цикла"},
                { 144 ,"недопустимый тип выражения"},
                { 145 ,"конфликт типов"},
                { 147 ,"тип метки не совпадает с типом выбирающего выражения"},
                { 149 ,"тип индекса не может быть  REAL  или  INTEGER"},
                { 152 ,"в этой записи нет такого поля"},
                { 156 ,"метка варианта определяется несколько раз"},
                { 165 ,"метка определяется несколько раз"},
                { 166 ,"метка описывается несколько раз"},
                { 167 ,"неописанная метка"},
                { 168,"неопределенная метка" },
                { 169,"ошибка в основании множества  ( базовом типе )"},
                { 170 ,"тип не может быть упакован"},
                { 177 ,"здесь не допускается присваивание имени функции"},
                { 182 ,"типы не совместны"},
                { 183 ,"запрещенная в данном контексте операция"},
                { 184 ,"элемент этого типа не может иметь знак"},
                { 186 ,"несоответствие типов для операции отношения"},
                { 189 ,"конфликт типов параметров"},
                { 190 ,"повторное опережающее описание"},
                { 191 ,"ошибка в конструкторе множества"},
                { 193 ,"лишний индекс для доступа к элементу массива"},
                { 194 ,"указано слишком мало индексов для доступа к злементу массива"},
                { 195 ,"выбирающая константа вне границ описанного диапазона"},
                { 196 ,"недопустимый тип выбирающей константы"},
                { 197 ,"параметры процедуры(функции),являющейся параметром, д.б. пар.-значениями" },
                { 198 ,"несоответствие количества параметров параметра-процедуры(функции)"},
                { 199 ,"несоответствие типов параметров параметра-процедуры(функции)"},
                { 200 ,"тип парамера-функции не соответствует описанию"},
                { 201 ,"ошибка в вещественной константе: должна идти цифра"},
                { 203 ,"целая константа превышает предел"},
                { 206 ,"слишком маленькая вещественная константа"},
                { 207 ,"слишком большая вещественная константа"},
                { 208 ,"недопустимые типы операндов в операции IN"},
                { 209 ,"вторым операндом IN должно быть множество"},
                { 210 ,"операнды AND, NOT, OR должны быть булевыми"},
                { 211 ,"недопустимые типы операндов в операции + или -"},
                { 212 ,"операнды DIV и MOD должны быть целыми"},
                { 213 ,"недопустимые типы операндов в операции *"},
                { 214 ,"недопустимые типы операндов в операции /"},
                { 215 ,"первым операндом IN должно быть выражение базового типа множества"},
                { 216 ,"опережающее описание есть, полного нет"},
                { 305 ,"индексное значение выходит за границы"},
                { 306 ,"присваиваемое значение выходит за границы"},
                { 307 ,"выражение для элемента множества выходит за пределы"},
                { 308 ,"выражение выходит за допустимые пределы"},
                { 309 ,"должно идти слово EXPORT"},
                { 310 ,"должно идти слово IMPORT"},
                { 311 ,"должно идти слово INTERFACE"},
                { 312 ,"должно идти слово IMPLEMENTATION"},
                { 313 ,"должно идти слово MODULE"},
                { 314 ,"слишком много меток"},
                { 322 ,"Странный оператор"},
                { 323 ,"Плохие константы в ограниченном типе"},
                { 324 ,"Небывает такого типа"},
                { 325 ,"Неправильный вызов процедуры"},
                { 326 ,"Слишком мало параметров"},
                { 327 ,"Слишком много параметров"},
                { 328 ,"Несоответствие типов"},
                { 329 ,"Слишком много индексов"},
                { 330 ,"Слишком мало индексов"},
                { 331 ,"Должен идти тип"},
                { 332 ,"Переменная не является массивом"},
                { 333 ,"Неправильный способ использования идентификатора"},
        };

       
        public static int MaxInt { get; } = 32767;
        public static int MaxLenStr { get; } = 10;


        public static int star { get; } = 21;                           /***/
        public static int slash { get; } = 60;                          /*/*/
        public static int equal { get; } = 16;                          /*=*/
        public static int comma { get; } = 20;                          /*,*/
        public static int semicolon { get; } = 14;                      /*;*/
        public static int colon { get; } = 5;                           /*:*/
        public static int point { get; } = 61;                          /*.*/
        public static int arrow { get; } = 62;                          /*^*/
        public static int leftpar { get; } = 9;                         /*(*/
        public static int rightpar { get; } = 4;                        /*)*/
        public static int lbracket { get; } = 11;                       /*[*/
        public static int rbracket { get; } = 12;                       /*]*/
        public static int flpar { get; } = 63;                          /*{*/
        public static int frpar { get; } = 64;                          /*}*/
        public static int later { get; } = 65;                          /*<*/
        public static int greater { get; } = 66;                        /*>*/
        public static int laterequal { get; } = 67;                     /*<=*/
        public static int greaterequal { get; } = 68;                   /*=>*/
        public static int latergreater { get; } = 69;                   /*<>*/
        public static int plus { get; } = 70;                           /*-*/
        public static int minus { get; } = 71;                          /*+*/
        public static int lcomment { get; } = 72;                       /*(**/
        public static int rcomment { get; } = 73;                       /**)*/
        public static int assign { get; } = 51;                         /*:=*/
        public static int twopoints { get; } = 74;                      /*..*/


        public static int ident { get; } = 2;                           /*Идентификатор*/
        public static int floatc { get; } = 82;                         /*Вещ. константа*/
        public static int intc { get; } = 15;                           /*Целая константа*/
        public static int charc { get; } = 83;                          /*Симв. константа*/
        public static int stringc { get; } = 84;                        /*Стр. константа*/

        public static int endoffile { get; } = 253;                     /*код конца файла*/
        public static int eolint { get; } = 88;                         /*признак конца последовательности целых чисел*/

        public static int FALSE { get; } = 0;                           /*ложь*/
        public static int TRUE { get; } = 1;                            /*истина*/


        public static int dosy { get; } = 54;
        public static int ifsy { get; } = 56;
        public static int insy { get; } = 22;
        public static int ofsy { get; } = 8;
        public static int orsy { get; } = 23;                           /*Разделитель !*/
        public static int tosy { get; } = 55;

        public static int andsy { get; } = 24;                          /*Разделитель &*/
        public static int divsy { get; } = 25;
        public static int endsy { get; } = 13;
        public static int forsy { get; } = 26;
        public static int modsy { get; } = 27;
        public static int nilsy { get; } = 89;
        public static int notsy { get; } = 28;
        public static int setsy { get; } = 29;
        public static int varsy { get; } = 30;

        public static int casesy { get; } = 31; 
        public static int elsesy { get; } = 32;                         
        public static int filesy { get; } = 57;                         
        public static int gotosy { get; } = 33;                         
        public static int onlysy { get; } = 90;                         
        public static int thensy { get; } = 52;
        public static int typesy { get; } = 34;                         
        public static int unitsy { get; } = 35;
        public static int usessy { get; } = 36;
        public static int withsy { get; } = 37;

        public static int arraysy { get; } = 38;
        public static int beginsy { get; } = 17;
        public static int constsy { get; } = 39;
        public static int labelsy { get; } = 40;
        public static int untilsy { get; } = 53;
        public static int whilesy { get; } = 41;

        public static int downtosy { get; } = 55;
        public static int exportsy { get; } = 91;
        public static int importsy { get; } = 92;
        public static int modulesy { get; } = 93;
        public static int packedsy { get; } = 42;
        public static int recordsy { get; } = 43;
        public static int repeatsy { get; } = 44;
        public static int vectorsy { get; } = 45;
        public static int stringsy { get; } = 46;

        public static int forwardsy { get; } = 47;
        public static int processsy { get; } = 48;
        public static int programsy { get; } = 3;
        public static int segmentsy { get; } = 49;

        public static int functionsy { get; } = 77;
        public static int separatesy { get; } = 78;

        public static int interfacesy { get; } = 79;
        public static int proceduresy { get; } = 80;
        public static int qualifiedsy { get; } = 94;

        public static int implementationsy { get; } = 81;

        public static Dictionary<int, Dictionary<string, int>> tableServiceNames { get; } = new Dictionary<int, Dictionary<string, int>>()
            {
                {
                    1,  new Dictionary<string, int>()
                },
                {
                    2,  new Dictionary<string, int>()
                            {
                                { "if", Constants.ifsy },
                                { "do", Constants.dosy },
                                { "of", Constants.ofsy },
                                { "or", Constants.orsy },
                                { "in", Constants.insy },
                                { "to", Constants.tosy },
                            }
                },
                {
                    3,  new Dictionary<string, int>()
                            {
                                { "end", Constants.endsy },
                                { "var", Constants.varsy },
                                { "div", Constants.divsy },
                                { "and", Constants.andsy },
                                { "not", Constants.notsy },
                                { "for", Constants.forsy },
                                { "mod", Constants.modsy },
                                { "nil", Constants.nilsy },
                                { "set", Constants.setsy },
                            }
                },
                {
                    4,  new Dictionary<string, int>()
                            {
                                { "then", Constants.thensy },
                                { "else", Constants.elsesy },
                                { "case", Constants.casesy },
                                { "file", Constants.filesy },
                                { "goto", Constants.gotosy },
                                { "type", Constants.typesy },
                                { "with", Constants.withsy },
                                { "only", Constants.onlysy },
                                { "unit", Constants.unitsy },
                                { "uses", Constants.usessy },
                            }
                },
                {
                    5,  new Dictionary<string, int>()
                            {
                                { "begin", Constants.beginsy },
                                { "while", Constants.whilesy },
                                { "array", Constants.arraysy },
                                { "const", Constants.constsy },
                                { "label", Constants.labelsy },
                                { "until", Constants.untilsy },
                            }
                },
                {
                    6,  new Dictionary<string, int>()
                            {
                                { "downto", Constants.downtosy },
                                { "packed", Constants.packedsy },
                                { "record", Constants.recordsy },
                                { "export", Constants.exportsy },
                                { "import", Constants.importsy },
                                { "module", Constants.modulesy },
                                { "vector", Constants.vectorsy },
                                { "string", Constants.stringsy },
                                { "repeat", Constants.repeatsy }
                            }
                },
                {
                    7,  new Dictionary<string, int>()
                            {
                                { "program", Constants.programsy },
                                { "forward", Constants.forwardsy },
                                { "process", Constants.processsy },
                                { "segment", Constants.segmentsy },
                            }
                },
                {
                    8,  new Dictionary<string, int>()
                            {
                                { "function", Constants.functionsy },
                                { "separate", Constants.separatesy },
                            }
                },
                {
                    9,  new Dictionary<string, int>()
                            {
                                { "procedure", Constants.proceduresy },
                                { "interface", Constants.interfacesy },
                                { "qualified", Constants.qualifiedsy },
                            }
                },
                {
                    10,  new Dictionary<string, int>()
                },
                {
                    11,  new Dictionary<string, int>()
                },
                {
                    12,  new Dictionary<string, int>()
                },
                {
                    13,  new Dictionary<string, int>()
                },
                {
                    14,  new Dictionary<string, int>()
                },
                {
                    15,  new Dictionary<string, int>()
                            {
                                { "implementation", Constants.implementationsy }
                            }
                },
            };

    }
}
