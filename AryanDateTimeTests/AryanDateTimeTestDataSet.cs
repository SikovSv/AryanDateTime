using AryanDateTime.Enums;

namespace AryanDateTimeTests
{
    public static class AryanDateTimeTestDataSet
    {
        public static IEnumerable<object[]> AryanColorTestData = [
            [new int[] { 1, 2, 19, 20, 127, 128 }, AryanColor.Black],
            [new int[] { 17, 18, 71, 72, 143, 144 }, AryanColor.White],
            [new int[] { 81, 82, 135, 136, 63, 64 }, AryanColor.Green]
        ];

        public static IEnumerable<object[]> ArianChertogTestData = [
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Ramhat, 1, 13), AryanChertog.Deva],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Ramhat, 1, 14), AryanChertog.Vepr],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Ramhat, 1, 15), AryanChertog.Vepr],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Ramhat, 15, 15), AryanChertog.Vepr],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Ramhat, 22, 13), AryanChertog.Vepr],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Ramhat, 22, 14), AryanChertog.Shuka],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Ramhat, 40, 14), AryanChertog.Shuka],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Aylet, 1, 14), AryanChertog.Shuka],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Aylet, 4, 13), AryanChertog.Shuka],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Aylet, 4, 14), AryanChertog.Lebed],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Aylet, 20, 14), AryanChertog.Lebed],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Aylet, 25, 13), AryanChertog.Lebed],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Aylet, 25, 14), AryanChertog.Zmei],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Aylet, 40, 14), AryanChertog.Zmei],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Beylet, 5, 14), AryanChertog.Zmei],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Beylet, 7, 13), AryanChertog.Zmei],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Beylet, 7, 14), AryanChertog.Voron],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Beylet, 20, 14), AryanChertog.Voron],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Beylet, 29, 13), AryanChertog.Voron],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Beylet, 29, 14), AryanChertog.Medved],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Beylet, 40, 14), AryanChertog.Medved],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Gaylet, 10, 14), AryanChertog.Medved],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Gaylet, 12, 13), AryanChertog.Medved],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Gaylet, 12, 14), AryanChertog.Busel],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Gaylet, 20, 14), AryanChertog.Busel],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Gaylet, 37, 13), AryanChertog.Busel],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Gaylet, 37, 14), AryanChertog.Volk],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Gaylet, 40, 14), AryanChertog.Volk],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Daylet, 10, 14), AryanChertog.Volk],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Daylet, 22, 13), AryanChertog.Volk],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Daylet, 22, 14), AryanChertog.Lisa],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Daylet, 40, 14), AryanChertog.Lisa],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Elet, 2, 14), AryanChertog.Lisa],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Elet, 4, 13), AryanChertog.Lisa],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Elet, 4, 14), AryanChertog.Tur],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Elet, 20, 14), AryanChertog.Tur],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Elet, 26, 13), AryanChertog.Tur],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Elet, 26, 14), AryanChertog.Los],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Elet, 40, 14), AryanChertog.Los],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Veylet, 5, 14), AryanChertog.Los],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Veylet, 9, 13), AryanChertog.Los],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Veylet, 9, 14), AryanChertog.Finist],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Veylet, 20, 14), AryanChertog.Finist],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Veylet, 31, 13), AryanChertog.Finist],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Veylet, 31, 14), AryanChertog.Kon],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Veylet, 40, 14), AryanChertog.Kon],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Heylet, 10, 14), AryanChertog.Kon],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Heylet, 13, 13), AryanChertog.Kon],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Heylet, 13, 14), AryanChertog.Orel],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Heylet, 20, 14), AryanChertog.Orel],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Heylet, 35, 13), AryanChertog.Orel],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Heylet, 35, 14), AryanChertog.Ras],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Heylet, 40, 14), AryanChertog.Ras],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Taylet, 1, 14), AryanChertog.Ras],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Taylet, 18, 13), AryanChertog.Ras],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Taylet, 18, 14), AryanChertog.Deva],
            [new AryanDateTime.AryanDateTime(7376, AryanMonth.Taylet, 40, 14), AryanChertog.Deva],
        ];

        public static IEnumerable<object[]> FromDateTimeTestData =
        [
            [ new DateTime(1936, 12, 5), new AryanDateTime.AryanDateTime(7445, AryanMonth.Aylet, 34, 4) ],
            [ new DateTime(1941, 06, 22), new AryanDateTime.AryanDateTime(7449, AryanMonth.Veylet, 32, 4) ],
            [ new DateTime(1947, 12, 30), new AryanDateTime.AryanDateTime(7456, AryanMonth.Beylet, 20, 4) ]
        ];
    }
}