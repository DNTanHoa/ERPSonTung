using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Ultilities.TemplateModel
{
    public class TreeNavigation<T>
    {
        public T Item { get; set; }

        public IEnumerable<TreeNavigation<T>> Childrens { get; set; }
    }
}
