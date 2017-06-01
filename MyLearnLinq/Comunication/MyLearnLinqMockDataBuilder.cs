using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace MyLearnLinq.Comunication
{
    internal class MyLearnLinqMockDataBuilder
    {
        private static readonly List<Place> _dataList;
        static MyLearnLinqMockDataBuilder()
        {
            _dataList = new List<Place>()
            {
                new Place("China","BeiJing",PlaceType.Island),
                new Place("America","New York",PlaceType.Island),
                //new Place("Japan","Hokkaido",PlaceType.Island),
                new Place("England","London",PlaceType.Island),
                new Place("Russia","Moscow",PlaceType.Island),
            };
        }

        public IReadOnlyList<Place> Build()
        {
            return _dataList.ToImmutableList();
        }
    }
}
