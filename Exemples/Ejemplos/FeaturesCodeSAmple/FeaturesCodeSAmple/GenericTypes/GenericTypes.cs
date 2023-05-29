using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturesCodeSAmple.GenericTypes
{
    internal static class GenericTypes
    {
        //static int Data { get; set; }

        //public static T1 Method(string str) 
        //{
        //    if(Data.GetType().GetProperties().Any(x => x.Name == str))
        //        return Data;
        //    return default(T1);
        //}

        public static T2 Map<T2, T1>(this T2 source, T1 input) 
        {
            var obj = Activator.CreateInstance(typeof(T2));
            var prop1 = source.GetType().GetProperties();
            var prop2 = input.GetType().GetProperties();

            return (T2)obj;
        }
    }
}
