using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Services;
using GildedRoseCodeChallenge.Tests.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace GildedRoseCodeChallenge.Tests
{
    public class QualityCalculatorTests
    {
        private QualityCalculator _sut = new QualityCalculator();

        [Theory]
        [InlineData(-5, ItemType.NormalItem)]
        [InlineData(-10, ItemType.Conjured)]
        [InlineData(-15, ItemType.BackstagePasses)]
        [InlineData(-1500, ItemType.Sulfuras)]
        [InlineData(-50, ItemType.AgedBrie)]
        public void CalculateQuality_NeverReturnsANegativeValue(int quality, ItemType type)
        {
            //Arrange
            var item = TestItemBuilder.Build(type).WithQuality(quality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(55, ItemType.NormalItem)]
        [InlineData(60, ItemType.AgedBrie)]
        [InlineData(1000, ItemType.BackstagePasses)]
        [InlineData(500, ItemType.Conjured)]
        [InlineData(60, ItemType.Sulfuras)]
        public void CalculateQuality_WhenCalculatedQualityIsGreatherThan50_Returns50(int quality, ItemType type)
        {
            //Arrange
            var item = TestItemBuilder.Build(type).WithQuality(quality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(50, result);
        }

        [Theory]
        [InlineData(10, 5)]
        [InlineData(5, 4)]
        [InlineData(1, 3)]
        [InlineData(0, 10)]
        public void CalculateQuality_WhenItemIsNormalItem_AndSellInValueIsPositiveOrZero_QualityDropsBy1(int sellInValue, int quality)
        {
            //Arrange
            var item = TestItemBuilder.Build(ItemType.NormalItem).WithSellInValue(sellInValue).WithQuality(quality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(quality - 1, result);           
        }

        [Theory]
        [InlineData(-10, 5, 3)]
        [InlineData(-1000, 20, 18)]
        [InlineData(-1, 10, 8)]
        public void CalculateQuality_WhenItemIsNormalItem_AndSellInValueIsNegative_QualityDegradsTwiceAsFast(int sellInValue, int currentQuality, int expectedQuality )
        {
            //Arrange
            var item = TestItemBuilder.Build(ItemType.NormalItem).WithSellInValue(sellInValue).WithQuality(currentQuality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(expectedQuality, result);
        }

        [Theory]
        [InlineData(10, 5, 6)]
        [InlineData(-1000, 20, 21)]
        [InlineData(0, 10, 11)]
        public void CalculateQuality_WhenItemIsAgedBrie_QualityIncreases(int sellInValue, int currentQuality, int expectedQuality)
        {
            //Arrange
            var item = TestItemBuilder.Build(ItemType.AgedBrie).WithSellInValue(sellInValue).WithQuality(currentQuality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(expectedQuality, result);
        }

        [Theory]
        [InlineData(5, 2, 2)]
        [InlineData(-1000, 20, 20)]
        [InlineData(0, 10, 10)]
        public void CalculateQuality_WhenItemIsSulphuras_QualityStaysTheSame(int sellInValue, int currentQuality, int expectedQuality)
        {
            //Arrange
            var item = TestItemBuilder.Build(ItemType.Sulfuras).WithSellInValue(sellInValue).WithQuality(currentQuality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(expectedQuality, result);
        }

        [Theory]
        [InlineData(5, 10, 8)]
        [InlineData(-1000, 20, 16)]
        [InlineData(0, 50, 48)]
        public void CalculateQuality_WhenItemIsConjured_QualityDropsAtTwiceTheRateOfNormaltems(int sellInValue, int currentQuality, int expectedQuality)
        {
            //Arrange
            var item = TestItemBuilder.Build(ItemType.Conjured).WithSellInValue(sellInValue).WithQuality(currentQuality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(expectedQuality, result);
        }

        [Theory]
        [InlineData(10, 15, 17)]
        [InlineData(6, 20, 22)]
        public void CalculateQuality_WhenItemIsBackstagePasses_AndSellInValueLessThanOrEquals10_ButGreaterThan5_QualityRisesBy2(int sellInValue, int currentQuality, int expectedQuality)
        {
            //Arrange
            var item = TestItemBuilder.Build(ItemType.BackstagePasses).WithSellInValue(sellInValue).WithQuality(currentQuality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(expectedQuality, result);
        }

        [Theory]
        [InlineData(5, 13, 16)]
        [InlineData(1, 20, 23)]
        [InlineData(0, 15, 18)]
        public void CalculateQuality_WhenItemIsBackstagePasses_AndSellInValueLessThanOrEquals5_ButGreaterThan0_QualityRisesBy3(int sellInValue, int currentQuality, int expectedQuality)
        {
            //Arrange
            var item = TestItemBuilder.Build(ItemType.BackstagePasses).WithSellInValue(sellInValue).WithQuality(currentQuality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(expectedQuality, result);
        }

        [Theory]
        [InlineData(-2, 8, 0)]
        [InlineData(-1, 20, 0)]
        [InlineData(-500, 15, 0)]
        public void CalculateQuality_WhenItemIsBackstagePasses_AndSellInValueLessThanZero_QualityDropsToZero(int sellInValue, int currentQuality, int expectedQuality)
        {
            //Arrange
            var item = TestItemBuilder.Build(ItemType.BackstagePasses).WithSellInValue(sellInValue).WithQuality(currentQuality);

            //Act
            var result = _sut.CalculateQuality(item);

            //Assert
            Assert.Equal(expectedQuality, result);
        }

        [Theory]
        [InlineData(-5, 4, (ItemType)8)]
        [InlineData(-1, 35, (ItemType)20)]
        [InlineData(500, 20, (ItemType)15)]
        public void CalculateQuality_WhenItemIsNotRecognised_ThrowsNotFoundException(int sellInValue, int currentQuality, ItemType type)
        {
            //Arrange
            var item = TestItemBuilder.Build(type).WithSellInValue(sellInValue).WithQuality(currentQuality);

            //Act - Assert
            Assert.Throws<InvalidEnumArgumentException>(() => _sut.CalculateQuality(item));
        }
    }
}
