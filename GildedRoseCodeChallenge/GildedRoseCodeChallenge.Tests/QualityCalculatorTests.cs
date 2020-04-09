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
        [InlineData(-5)]
        [InlineData(-10)]
        public void CalculateQuality_NeverReturnsANegativeValue(int quality)
        {
            //Arrange

            //Act
            var result = _sut.CalculateQuality(0, quality);

            //Assert
            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData(55)]
        [InlineData(60)]
        public void CalculateQuality_WhenCalculatedQualityIsGreatherThan50_Returns50(int quality)
        {
            //Arrange

            //Act
            var result = _sut.CalculateQuality(0, quality);

            //Assert
            Assert.Equal(50, result);
        }

        [Theory]
        [InlineData(10, 5)]
        [InlineData(5, 4)]
        [InlineData(1, 3)]
        public void CalculateQuality_QualityDropsBy1(int sellInValue, int quality)
        {
            //Arrange

            //Act
            var result = _sut.CalculateQuality(sellInValue, quality);

            //Assert
            Assert.Equal(quality - 1, result);           
        }

        [Theory]
        [InlineData(-10, 5, 3)]
        [InlineData(-1000, 20, 18)]
        [InlineData(-1, 10, 8)]
        public void CalculateQuality_WhenSellInValueIsNegative_QualityDegradsTwiceAsFast(int sellInValue, int currentQuality, int expectedQuality )
        {
            //Arrange

            //Act
            var result = _sut.CalculateQuality(sellInValue, currentQuality);

            //Assert
            Assert.Equal(expectedQuality, result);
        }
    }
}
