using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyClassLibrary.Tests
{
    public class FakeSystemClock : ISystemClock
    {
        public DateTime GetNow()
        {
            return new DateTime(2021, 1, 1, 3, 30, 00);
        }
    }

    public class TimeOfDayProviderTests
    {
        [Fact]
        public void GetTimeOfDay_Is3AM_ReturnsNight()
        {
            //Arrange
            var sut = new TimeOfDayProvider(new FakeSystemClock());
            var expected = TimeOfDay.Night;

            //Act
            var actual = sut.GetTimeOfDay();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
