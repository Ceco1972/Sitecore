using System;

namespace Country2
{
    public class Class1
    {
        public int TaxValue(string country)
        {
            if (country == "USA")
            {
                return 10;
            }
            if (country == "Ukraine")
            {
                return 15;
            }
            if (country == "Norway")
            {
                return 30;
            }
            else return 0;
        }

    }
}
