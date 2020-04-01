using System;
using AgeCalculator;
using NUnit.Framework;

namespace AgeCalculatorTests
{
    public class AgeCalculatorTests
    {
        public Calculator CreateCalculator()
        {
            return new Calculator();
        }

        [TestCase("2020-01-20", "2020-01-19")]
        [TestCase("2016-11-19", "2015-11-10")]
        [TestCase("2010-7-10", "2000-6-10")]
        public void CalculateAge_GivenPersonHasNotBeenBornYet_ShouldThrowUnbornException(DateTime dob, DateTime currentDate)
        {
            // Arrange
            var sut = CreateCalculator();
            const string unbornException = "The birth date supplied suggests the person is not born yet - cannot calculate age";
            // Act
            // Assert
            var result = Assert.Throws<Exception>(() => sut.CalculateAge(dob, currentDate));
            Assert.That(result.Message, Is.EqualTo(unbornException));
        }

        [TestCase("2020-03-30", "2020-03-30")]
        [TestCase("2000-1-8", "2000-1-8")]
        [TestCase("2010-05-13", "2010-05-13")]
        public void CalculateAge_GivenPersonBornToday_ShouldReturnAgeOf0(DateTime dob, DateTime currentDate)
        {
            // Arrange
            var sut = CreateCalculator();
            const int expectedResult = 0;
            // Act
            var actual = sut.CalculateAge(dob, currentDate);
            // Assert
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [TestCase("2019-10-10", "2020-10-10")]
        [TestCase("1998-01-20", "1999-01-20")]
        [TestCase("1988-7-28", "1989-7-28")]
        public void CalculateAge_GivenItsFirstBirthdayDate_ShouldReturnAgeOf1(DateTime dob, DateTime currentDate)
        {
            // Arrange
            var sut = CreateCalculator();
            const int expectedResult = 1;
            // Act
            var actual = sut.CalculateAge(dob, currentDate);
            // Act
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [TestCase("2005-03-22","2006-03-21")]
        [TestCase("2018-12-29","2019-12-28")]
        [TestCase("2008-09-1","2009-08-30")]
        public void CalculateAge_GivenDayBeforeFirstBirthday_ShouldReturn0(DateTime dob, DateTime currentDate)
        {
            // Arrange
            var sut = CreateCalculator();
            const int expectedResult = 0;
            // Act
            var actual = sut.CalculateAge(dob, currentDate);
            // Act
            Assert.That(actual, Is.EqualTo(expectedResult));
        }


        [TestCase("2005-03-22", "2006-03-23")]
        [TestCase("2018-12-29", "2019-12-30")]
        [TestCase("2008-09-1", "2009-09-2")]
        public void CalculateAge_GivenDayAfterFirstBirthday_ShouldReturn1(DateTime dob, DateTime currentDate)
        {
            // Arrange
            var sut = CreateCalculator();
            const int expectedResult = 1;
            // Act
            var actual = sut.CalculateAge(dob, currentDate);
            // Act
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

        [TestCase("2001-01-1", "2003-01-1",2)]
        [TestCase("2004-04-07", "2011-04-07",7)]
        [TestCase("1998-01-20", "2015-01-20",17)]
        public void CalculateAge_GivenBirthdayCelebratedToday_ShouldReturnCorrectAge(DateTime dob, DateTime currentDate, int expectedResult)
        {
            // Arrange
            var sut = CreateCalculator();
            // Act
            var actual = sut.CalculateAge(dob, currentDate);
            // Act
            Assert.That(actual, Is.EqualTo(expectedResult));
        }
        
        [TestCase("1990-02-14", "1996-01-10",5)]
        [TestCase("1980-8-3", "2010-7-3",29)]
        [TestCase("2009-05-23", "2020-04-23",10)]
        public void CalculateAge_GivenBirthdayIsOneMonthAway_ShouldReturnCurrentAge(DateTime dob, DateTime currentDate, int expectedResult)
        {
            // Arrange
            var sut = CreateCalculator();
            // Act
            var actual = sut.CalculateAge(dob, currentDate);
            // Act
            Assert.That(actual, Is.EqualTo(expectedResult));
        }  
        
        [TestCase("2014-06-23", "2019-06-22",4)]
        [TestCase("2011-07-07", "2020-07-06",8)]
        [TestCase("2000-08-2", "2017-08-1",16)]
        public void CalculateAge_GivenBirthdayIsOneDayAway_ShouldReturnCurrentAge(DateTime dob, DateTime currentDate, int expectedResult)
        {
            // Arrange
            var sut = CreateCalculator();
            // Act
            var actual = sut.CalculateAge(dob, currentDate);
            // Act
            Assert.That(actual, Is.EqualTo(expectedResult));
        }

    }
}