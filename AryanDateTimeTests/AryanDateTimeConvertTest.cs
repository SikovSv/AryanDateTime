using SlavicAryanCalendarSystem;
using SlavicAryanCalendarSystem.Enums;

namespace AryanDateTimeTests
{
    public class AryanDateTimeConvertTest
    {
        [Theory]
        [MemberData(nameof(AryanDateTimeTestDataSet.FromDateTimeTestData), MemberType = typeof(AryanDateTimeTestDataSet))]
        public void FromDateTimeTest(DateTime dateTime, AryanDateTime aryanDateTime)
        {
            var ar = AryanDateTime.FromDateTime(dateTime);
            Assert.Equal(aryanDateTime, ar);
        }

        [Theory]
        [MemberData(nameof(AryanDateTimeTestDataSet.AryanColorTestData), MemberType = typeof(AryanDateTimeTestDataSet))]
        public void AryanColorTest(int[] lives, AryanColor aryanColor)
        {
            foreach (var i in lives)
            {
                var ar = new AryanDateTime(i + 7376, AryanMonth.Ramhat, 1);
                Assert.Equal(ar.Color, aryanColor);
            }
        }

        [Theory]
        [MemberData(nameof(AryanDateTimeTestDataSet.ArianChertogTestData), MemberType = typeof(AryanDateTimeTestDataSet))]
        public void ArianChertogTest(AryanDateTime aryanDateTime, AryanChertog arianChertog)
        {
            Assert.Equal(arianChertog, aryanDateTime.Chertog);
        }
    }
}