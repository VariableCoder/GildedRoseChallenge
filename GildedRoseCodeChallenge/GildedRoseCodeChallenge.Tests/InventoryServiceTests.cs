using GildedRoseCodeChallenge.Models;
using GildedRoseCodeChallenge.Services;
using GildedRoseCodeChallenge.Services.Interfaces;
using GildedRoseCodeChallenge.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseCodeChallenge.Tests
{
    public class InventoryServiceTests
    {
        private readonly Mock<IQualityCalculator> _qualityCalculatorMock;
        private readonly IInventoryService _sut;

        public InventoryServiceTests()
        {
            _qualityCalculatorMock = new Mock<IQualityCalculator>();
            _sut = new InventoryService();
        }

        [Theory]
        [MemberData(nameof(Test1InlineData))]
        public void UpdateInventory_CalculatesCorrectSellInValue(DateTime sellByDate, int expectedSellInValue)
        {
            //Arrange
            var item = TestItemBuilder.Build().WithSellByDate(sellByDate);

            //Act
            _sut.UpdateInventory(new Item[] { item });

            //Assert
            Assert.Equal(expectedSellInValue, item.SellInValue);

        }

        public static object[][] Test1InlineData
        {
            get
            {
                return new object[][]
                {
                    new object[] {new DateTime(2020,4,4), 3 },
                    new object[] {new DateTime(2020,4,3), 4 },
                    new object[] {new DateTime(2020,4,2), 5 },
                };
            }
        }
    }
}
