﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerPascal.Class
{
    public class ErrorPosition
    {
        public int ErrCode { get; set; }
        public int Line { get; set; }
        public int PosInLine { get; set; }
        public char Symbol { get; set; }
    }
}
