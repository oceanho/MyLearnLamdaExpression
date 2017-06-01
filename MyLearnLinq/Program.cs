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
                        where (place.Name == "China" || place.Name == "America") || (place.State == "BeiJing" && place.PlaceType == PlaceType.Island)
                        select place.PlaceType;

            foreach (PlaceType placeType in query.ToList())
                Console.WriteLine(placeType);
        }
    }
}