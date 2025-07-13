using AryanDateTime.Enums;

namespace AryanDateTimeTests
{
    public class AryanDateTimeConvertTest
    {
        [Theory]
        [MemberData(nameof(AryanDateTimeTestDataSet.FromDateTimeTestData), MemberType = typeof(AryanDateTimeTestDataSet))]
        public void FromDateTimeTest(DateTime dateTime, AryanDateTime.AryanDateTime aryanDateTime)
        {
            var ar = AryanDateTime.AryanDateTime.FromDateTime(dateTime);
            Assert.Equal(aryanDateTime, ar);
        }

        [Theory]
        [MemberData(nameof(AryanDateTimeTestDataSet.AryanColorTestData), MemberType = typeof(AryanDateTimeTestDataSet))]
        public void AryanColorTest(int[] lives, AryanColor aryanColor)
        {
            foreach (var i in lives)
            {
                var ar = new AryanDateTime.AryanDateTime(i + 7376, AryanMonth.Ramhat, 1);
                Assert.Equal(ar.Color, aryanColor);
            }
        }

        [Theory]
        [MemberData(nameof(AryanDateTimeTestDataSet.ArianChertogTestData), MemberType = typeof(AryanDateTimeTestDataSet))]
        public void ArianChertogTest(AryanDateTime.AryanDateTime aryanDateTime, AryanChertog arianChertog)
        {
            Assert.Equal(arianChertog, aryanDateTime.Chertog);
        }
    }
}