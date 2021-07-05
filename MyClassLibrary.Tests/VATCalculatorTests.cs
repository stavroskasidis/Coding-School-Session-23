using System;
using Xunit;

namespace MyClassLibrary.Tests
{
    public class VATCalculatorTests
    {
        private VATCalculator CreateDefaultSUT()
        {
            //sut = system under test
            var sut = new VATCalculator();
            return sut;
        }

        [Theory]
        [InlineData(100, 0.24, 124)]
        [InlineData(100, 0.13, 113)]
        [InlineData(200, 0.13, 226)]
        public void CalculateTotalValue_PossitiveNetValueIsGivenWithValidVATPerc_ReturnsTotalValueCorrectly(decimal netValue,
                                                                                                            decimal vatPerc,
                                                                                                            decimal expected)
        {
            //Arrange
            var sut = CreateDefaultSUT();

            //Act
            var actual = sut.CalculateTotalValue(netValue, vatPerc);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateTotalValue_NegativeNetValueIsGiven_ThrowsArgumentException()
        {
            //Arrange
            var sut = CreateDefaultSUT();
            var netValue = -100m;
            var varPerc = 0.24m;

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
               var actual = sut.CalculateTotalValue(netValue, varPerc);
            });
        }


        [Fact]
        public void CalculateTotalValue_InvalidVATPercIsGiven_ThrowsArgumentException()
        {
            //Arrange
            var sut = CreateDefaultSUT();
            var netValue = 100m;
            var varPerc = 4.24m;

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var actual = sut.CalculateTotalValue(netValue, varPerc);
            });
        }

        [Fact]
        public void CalculateNetValue_TotalValue124IsGivenWith24VATPerc_Returns100NetValue()
        {
            //Arrange
            var sut = CreateDefaultSUT();
            var totalValue = 124m;
            var vatPerc = 0.24m;
            var expected = 100m;

            //Act
            var actual = sut.CalculateNetValue(totalValue, vatPerc);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateNetValue_InvalidVatPerc_ThrowsArgumentException()
        {
            //Arrange
            var sut = CreateDefaultSUT();
            var totalValue = 124m;
            var varPerc = -4.24m;

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var actual = sut.CalculateNetValue(totalValue, varPerc);
            });
        }


        [Fact]
        public void CalculateNetValue_ZeroVatPerc_ReturnsNetValueAsIs()
        {
            //Arrange
            var sut = CreateDefaultSUT();
            var totalValue = 124m;
            var varPerc = 0;
            var expected = 124m;

            //Act
            var actual = sut.CalculateNetValue(totalValue, varPerc);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
