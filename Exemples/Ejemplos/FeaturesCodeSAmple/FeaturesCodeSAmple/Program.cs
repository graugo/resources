using FeaturesCodeSAmple.Delegate;
using FeaturesCodeSAmple.GenericTypes;
using FeaturesCodeSAmple.Regex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FeaturesCodeSAmple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //new RegexExample().RegexExecution();
            DelegateExample.ProcessBooks();

            Action a = () => { };
            Task.Run(a);     
            Func<int, int> f = x => { 
                var b = x;
                return b;
            };

            var list = new List<int>();
            var list2 = new List<int>();

            list.Map<List<int>,int>(2);

            var filter = from item in list where item != 0 select item;
            var filter2 = list.Where(x => x != 0);
            list.All(x => x == 8);
            list.Any(x => x == 8);
            list.FirstOrDefault();
            list.Join(list2, x => x, y => y, (x,y)=> x);
        }
    }
}
