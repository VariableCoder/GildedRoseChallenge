using GildedRoseCodeChallenge.Enums;
using GildedRoseCodeChallenge.Services;
using Moq;
using System;
using System.Collections.Generic;
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

            //Act
            var result = _sut.CalculateQuality(0, quality, type);

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

            //Act
            var result = _sut.CalculateQuality(0, quality, type);

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

            //Act
            var result = _sut.CalculateQuality(sellInValue, quality, ItemType.NormalItem);

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

            //Act
            var result = _sut.CalculateQuality(sellInValue, currentQuality, ItemType.NormalItem);

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

            //Act
            var result = _sut.CalculateQuality(sellInValue, currentQuality, ItemType.AgedBrie);

            //Assert
            Assert.Equal(expectedQuality, result);
        }
    }
}
