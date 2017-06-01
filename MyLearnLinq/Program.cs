using MyLearnLinq.Comunication;
using MyLearnLinq.LinqExpression;
using System;

using System.Linq;

/*
 * 
 * more info
 * https://msdn.microsoft.com/library/Bb546158.aspx
 */
namespace MyLearnLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 必须导入 System.Linq 命名空间，否则此处提示未能找到XXXX的where实现
             * */
            var terraPlaces = new MyLearnQueryData<Place>();

            var query = from place in terraPlaces
                            //where (1 == 1) || (place.Name == "China" || place.Name == "America") || (place.State == "BeiJing" && place.PlaceType == PlaceType.Island)
                        where 1 == 1
                        select place;

            foreach (var place in query.ToList())
                Console.WriteLine(place.ToString());

            Console.ReadLine();
        }
    }
}