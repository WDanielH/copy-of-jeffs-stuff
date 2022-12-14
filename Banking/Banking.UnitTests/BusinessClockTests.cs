using Banking.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTests;
public class BusinessClockTests
{
    [Fact]
    public void WorkStartsAtNine()
    {
        var stubbedTime = new Mock<ISystemTime>();
        stubbedTime.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 04, 20, 09, 00, 00));
        var clock = new BusinessClock(stubbedTime.Object);

        Assert.True(clock.DuringBusinessHours());
    }

    [Fact]
    public void ClosedBeforeStart()
    {
        var stubbedTime = new Mock<ISystemTime>();
        stubbedTime.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 04, 20, 08, 59, 59));
        var clock = new BusinessClock(stubbedTime.Object);

        Assert.False(clock.DuringBusinessHours());
    }
}
