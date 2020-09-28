using ERP.Ultilities.TemplateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Ultilities.Extensions
{
    public static class EnumerableExtension
    {
        public static IEnumerable<TreeNavigation<T>> GenerateTree<T, K>(this IEnumerable<T> collection, Func<T, K> id, Func<T, K> parent, K root = default(K))
        {
            foreach (var item in collection.Where(c => parent(c).Equals(root)))
            {
                yield return new TreeNavigation<T>
                {
                    Item = item,
                    Childrens = collection.GenerateTree(id, parent, id(item))
                };
            }
        }
    }
}
