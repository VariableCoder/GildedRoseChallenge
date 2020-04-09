using GildedRoseCodeChallenge.Enums;
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
        private Mock<IQualityCalculator> _qualityCalculatorMock;
        private IInventoryService _sut;

        public InventoryServiceTests()
        {
            _qualityCalculatorMock = new Mock<IQualityCalculator>();

            _sut = new InventoryService(_qualityCalculatorMock.Object);
        }

        [Theory]
        [MemberData(nameof(Test1InlineData))]
        public void UpdateInventory_CalculatesCorrectSellInValue(int sellInValue, int expectedSellInValue)
        {
            //Arrange
            var item = TestItemBuilder.Build().WithSellInValue(sellInValue);

            //Act
            _sut.UpdateInventory(item);

            //Assert
            Assert.Equal(expectedSellInValue, item.SellInValue);

        }

        [Fact]
        public void UpdateInventory_CallsQualityCalculator_CorrectNumberOfTimes()
        {
            //Arrange
            var item = TestItemBuilder.Build();

            //Act
            _sut.UpdateInventory(item);

            //Await
            _qualityCalculatorMock.Verify(x => x.CalculateQuality(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ItemType>()), Times.Once);
        }

        [Theory]
        [MemberData(nameof(Test2InlineData))]
        public void UpdateInventory_CallsQualityCalculator_WithCorrectValues(int sellInValue, int expectedSellInValue, int quality, ItemType type)
        {
            //Arrange
            var item = TestItemBuilder.Build().WithSellInValue(sellInValue).WithQuality(quality).WithItemType(type);
            _qualityCalculatorMock.Setup(x => x.CalculateQuality(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<ItemType>())).Returns(It.IsAny<int>());

            //Act
            _sut.UpdateInventory(item);

            //Assert
            _qualityCalculatorMock.Verify(x => x.CalculateQuality(expectedSellInValue, quality, type), Times.Once);
        }

        public static object[][] Test1InlineData
        {
            get
            {
                return new object[][]
                {
                    new object[] {4, 3 },
                    new object[] {5, 4 },
                    new object[] {6, 5 },
                };
            }
        }

        public static object[][] Test2InlineData
        {
            get
            {
                return new object[][]
                {
                    new object[] {4, 3, 20, ItemType.NormalItem },
                    new object[] {5, 4, 30, ItemType.AgedBrie },
                    new object[] {6, 5, 35, ItemType.Sulfuras },
                };
            }
        }
    }
}
