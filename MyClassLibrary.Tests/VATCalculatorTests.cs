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


            dfghdfghj fgdsfgdhj dfghjfdghjfghdj

            //Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                var actual = sut.CalculateTotalValue(netValue, varPerc);
            });
        }
    }
}
