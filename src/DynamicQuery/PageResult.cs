using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq.Dynamic
{
    public class PageResult
    {
        public dynamic Rows { get; set; }
        public int Total { get; set; }
    }
}
