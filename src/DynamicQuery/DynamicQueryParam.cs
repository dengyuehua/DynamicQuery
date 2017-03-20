using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq.Dynamic
{
    public class DynamicQueryParam
    {
        public string Field { get; set; }
        public QueryOperation Operator { get; set; }
        public object Value { get; set; }
    }
}
