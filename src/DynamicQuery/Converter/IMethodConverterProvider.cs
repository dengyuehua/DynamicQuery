using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;

namespace System.Linq.Dynamic
{
    internal interface IMethodConverterProvider
    {
        bool Match([NotNull] DynamicQueryParam queryParam, [NotNull] Type propertyType);

        void Converter([NotNull] DynamicQueryParam queryParam, [NotNull] Type propertyType, [NotNull] DynamicQueryKeyValueCollection collection);
    }
}
