using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseCodeChallenge.Services.Interfaces
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();
    }
}
