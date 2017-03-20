using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq.Dynamic
{
    public class DynamicQueryModel
    {
        public DynamicQueryModel()
        {
            Where = Order = string.Empty;
            IsPager = true;
        }

        public string Where { get; set; }
        public object[] WhereValue { get; set; }
        public string Order { get; set; }
        public bool IsPager { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public string Select { get; set; }
    }
}
