using GildedRoseCodeChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Console.Models
{
    public class BackstagePasses : Item
    {
        public override int RateOfDegrade
        {
            get
            {
                if (SellInValue <= 10 && SellInValue > 5)
                    return 2;

                if (SellInValue <= 5 && SellInValue >= 0)
                    return 3;

                if (SellInValue < 0)
                    return -Quality;

                return base.RateOfDegrade;
            }
        }
    }
}
