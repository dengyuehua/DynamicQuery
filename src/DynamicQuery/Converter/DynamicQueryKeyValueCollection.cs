﻿using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq.Dynamic
{
    internal class DynamicQueryKeyValueCollection
    {
        public DynamicQueryKeyValueCollection()
        {
            Builder = new StringBuilder();
            Values = new List<object>();
            Ids = 0;
        }

        public StringBuilder Builder { get; }
        public IList<object> Values { get; set; }
        public int Ids { get; set; }
    }
}
