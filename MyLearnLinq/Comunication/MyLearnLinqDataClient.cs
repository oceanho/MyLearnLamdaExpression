using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLearnLinq.Comunication
{
    public class MyLearnLinqDataClient
    {
        public Place[] GetPlace(string[] locations)
        {
            return new MyLearnLinqMockDataBuilder().Build().Where(p => locations.Contains(p.Name)).ToArray();
        }
    }
}
