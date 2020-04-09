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
        private readonly Mock<IDateTimeProvider> _dateTimeProviderMock;
        private readonly IInventoryService _sut;

        public InventoryServiceTests()
        {
            _qualityCalculatorMock = new Mock<IQualityCalculator>();
            _dateTimeProviderMock = new Mock<IDateTimeProvider>();
            _dateTimeProviderMock.Setup(x => x.GetCurrentDateTime()).Returns(new DateTime(2020, 4, 7));

            _sut = new InventoryService(_qualityCalculatorMock.Object, _dateTimeProviderMock.Object);
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

        [Fact]
        public void UpdateInventory_CallsQualityCalculator_CorrectNumberOfTimes()
        {
            //Arrange
            var items = new Item[] { TestItemBuilder.Build(), TestItemBuilder.Build(), TestItemBuilder.Build() };

            //Act
            _sut.UpdateInventory(items);

            //Await
            _qualityCalculatorMock.Verify(x => x.CalculateQuality(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(items.Length));
        }

        [Theory]
        [MemberData(nameof(Test2InlineData))]
        public void UpdateInventory_CallsQualityCalculator_WithCorrectValues(DateTime sellByDate, int expectedSellInValue, int quality)
        {
            //Arrange
            var item = TestItemBuilder.Build().WithSellByDate(sellByDate).WithQuality(quality);
            _qualityCalculatorMock.Setup(x => x.CalculateQuality(It.IsAny<int>(), It.IsAny<int>())).Returns(It.IsAny<int>());

            //Act
            _sut.UpdateInventory(new Item[] { item });

            //Assert
            _qualityCalculatorMock.Verify(x => x.CalculateQuality(expectedSellInValue, quality), Times.Once);
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

        public static object[][] Test2InlineData
        {
            get
            {
                return new object[][]
                {
                    new object[] {new DateTime(2020,4,4), 3, 20 },
                    new object[] {new DateTime(2020,4,3), 4, 30 },
                    new object[] {new DateTime(2020,4,2), 5, 35 },
                };
            }
        }
    }
}
