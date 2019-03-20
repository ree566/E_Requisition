using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Requisition.Extensions
{
    public static class NulltoEmptyExtension
    {
        public static string ifNulltoEmpty(this string str)
        {
            return str ?? "";
        }
    }
}