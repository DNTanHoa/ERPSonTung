using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Ultilities.Extensions
{
    public class MapPropertyName : Attribute
    {
        public string Name { get; private set; }

        public MapPropertyName(string Name)
        {
            this.Name = Name;
        }
    }
}
