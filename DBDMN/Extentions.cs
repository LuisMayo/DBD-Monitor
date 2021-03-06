﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBDMN
{
    public static class Extentions
    {
        public static string getEnumValueName( this Enum value )
        {
            Type type = value.GetType();
            string name = Enum.GetName( type, value );
            if ( name != null )
            {
                FieldInfo field = type.GetField( name );
                if ( field != null )
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute( field,
                             typeof( DescriptionAttribute ) ) as DescriptionAttribute;

                    if ( attr != null )
                    {
                        return attr.Description;
                    }
                }

                // If no friendly name, just return the ID itself
                return name;
            }
            return null;
        }
    }
}
