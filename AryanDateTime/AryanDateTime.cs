using AryanDateTime.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AryanDateTime
{
    /// <summary>
    /// Арийская дата
    /// </summary>
    public readonly struct AryanDateTime
    {
        #region ConstDefine
        private const int GregorianHourInDay = 24;
        private const int GregorianMinutesInHour = 60;
        private const int GregorianSecondInMinutes = 60;
        private const int GregorianMSecondInSecond = 1000;
        private const int GregorianMSecondInHour = GregorianMinutesInHour * GregorianSecondInMinutes * GregorianMSecondInSecond; //3600000
        private const int GregorianMSecondInDay = GregorianHourInDay * GregorianMSecondInHour; //86400000

        private const int SlavAriHourInDay = 16;
        private const int SlavAriPartInHour = 144;
        private const int SlavAriShareInPart = 1296;
        private const int SlavAriInstantInShare = 72;
        private const int SlavAriMomentInInstant = 760;
        private const int SlavAriSigInMoment = 160;

        private const int MSecondInSlavAriHour = GregorianMSecondInDay / SlavAriHourInDay; //5400000
        private const int MSecondInSlavAriPart = MSecondInSlavAriHour / SlavAriPartInHour; //37500

        private const int deltaYear = 5508;

        private static readonly DateTime[]?[] monthsByLeto = new DateTime[]?[]
       {
            null,
            null,
            new DateTime[]{ new DateTime(1, 9, 23), new DateTime(1, 11, 3), new DateTime(1, 12, 13), new DateTime(1, 1, 23), new DateTime(1, 3, 4), new DateTime(1, 4, 14), new DateTime(1, 5, 24), new DateTime(1, 7, 4), new DateTime(1, 8, 13) },
            new DateTime[]{new DateTime(1, 9, 23), new DateTime(1, 11, 3), new DateTime(1, 12, 13), new DateTime(1, 1, 23), new DateTime(1, 3, 3), new DateTime(1, 4, 13), new DateTime(1, 5, 23), new DateTime(1, 7, 3), new DateTime(1, 8, 12) },
            null,
            null,
            new DateTime[]{new DateTime(1, 9, 22), new DateTime(1, 11, 2), new DateTime(1, 12, 12), new DateTime(1, 1, 22), new DateTime(1, 3, 3), new DateTime(1, 4, 13), new DateTime(1, 5, 23), new DateTime(1, 7, 3), new DateTime(1, 8, 12) },
            new DateTime[]{new DateTime(1, 9, 22), new DateTime(1, 11, 2), new DateTime(1, 12, 12), new DateTime(1, 1, 22), new DateTime(1, 3, 2), new DateTime(1, 4, 12), new DateTime(1, 5, 22), new DateTime(1, 7, 2), new DateTime(1, 8, 11) },
            null,
            null,
            new DateTime[]{new DateTime(1, 9, 21), new DateTime(1, 11, 1), new DateTime(1, 12, 11), new DateTime(1, 1, 21), new DateTime(1, 3, 2), new DateTime(1, 4, 12), new DateTime(1, 5, 22), new DateTime(1, 7, 2), new DateTime(1, 8, 11) },
            new DateTime[]{new DateTime(1, 9, 21), new DateTime(1, 11, 1), new DateTime(1, 12, 11), new DateTime(1, 1, 21), new DateTime(1, 3, 1), new DateTime(1, 4, 11), new DateTime(1, 5, 21), new DateTime(1, 7, 1), new DateTime(1, 8, 10) },
            null,
            null,
            new DateTime[]{new DateTime(1, 9, 20), new DateTime(1, 10, 31), new DateTime(1, 12, 10), new DateTime(1, 1, 20), new DateTime(1, 3, 1), new DateTime(1, 4, 11), new DateTime(1, 5, 21), new DateTime(1, 7, 1), new DateTime(1, 8, 10) },
            new DateTime[]{new DateTime(1, 9, 20), new DateTime(1, 10, 31), new DateTime(1, 12, 11), new DateTime(1, 1, 21), new DateTime(1, 3, 2), new DateTime(1, 4, 12), new DateTime(1, 5, 23), new DateTime(1, 7, 3), new DateTime(1, 8, 13) }
       };

        /// <summary>
        /// Дни Недели, с которых начинаются Лета Круголета
        /// </summary>
        private static readonly Dictionary<AryanWeekday, int[]> weekdaysByLeto = new Dictionary<AryanWeekday, int[]>()
        {
            { AryanWeekday.Monday, new int[] {1, 10, 20, 29, 39, 48, 49, 58, 68, 77, 87, 96, 106, 116, 125, 135, 144 } },
            { AryanWeekday.Tuesday, new int[] {3, 12, 22, 31, 41, 51, 60, 70, 79, 89, 99, 108, 118, 127, 137 } },
            { AryanWeekday.Wednesday, new int[] {5, 14, 24, 34, 43, 53, 62, 72, 82, 91, 97, 101, 110, 120, 130, 139 } },
            { AryanWeekday.Thursday, new int[] {7, 16, 17, 26, 36, 45, 55, 64, 65, 74, 84, 93, 103, 112, 113, 122, 132, 141 } },
            { AryanWeekday.Friday, new int[] {9, 19, 28, 38, 47, 57, 67, 76, 86, 95, 105, 115, 124, 134, 143 } },
            { AryanWeekday.Saturday, new int[] {2, 11, 21, 30, 40, 50, 59, 69, 78, 88, 98, 107, 117, 126, 136 } },
            { AryanWeekday.Sunday, new int[] {4, 13, 23, 32, 33, 42, 52, 61, 71, 80, 81, 90, 100, 109, 119, 128, 129, 138 } },
            { AryanWeekday.Octaday, new int[] {6, 15, 25, 35, 44, 54, 63, 73, 83, 92, 102, 111, 121, 131, 140 } },
            { AryanWeekday.Week, new int[] {8, 18, 27, 37, 46, 56, 66, 75, 85, 94, 104, 114, 123, 133, 142 } }
        };

        /// <summary>
        /// Чередование дней недели четного (Ключ) - нечетного (значение) месяца в зависимости от дня недели первого месяца в году для простых лет
        /// </summary>
        private static readonly Dictionary<AryanWeekday, AryanWeekday> weekdaysOddEven = new Dictionary<AryanWeekday, AryanWeekday>()
        {
            [AryanWeekday.Monday] = AryanWeekday.Saturday,
            [AryanWeekday.Saturday] = AryanWeekday.Tuesday,
            [AryanWeekday.Tuesday] = AryanWeekday.Sunday,
            [AryanWeekday.Sunday] = AryanWeekday.Wednesday,
            [AryanWeekday.Wednesday] = AryanWeekday.Octaday,
            [AryanWeekday.Octaday] = AryanWeekday.Thursday,
            [AryanWeekday.Thursday] = AryanWeekday.Week,
            [AryanWeekday.Week] = AryanWeekday.Friday,
            [AryanWeekday.Friday] = AryanWeekday.Monday
        };

        private static readonly Dictionary<AryanMonth, Dictionary<AryanWeekday, int>> weekdaysBySaintMonth = new Dictionary<AryanMonth, Dictionary<AryanWeekday, int>>()
        {
            [AryanMonth.Ramhat] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 1, [AryanWeekday.Thursday] = 4, [AryanWeekday.Sunday] = 7 },
            [AryanMonth.Aylet] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 6, [AryanWeekday.Thursday] = 9, [AryanWeekday.Sunday] = 3 },
            [AryanMonth.Beylet] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 2, [AryanWeekday.Thursday] = 5, [AryanWeekday.Sunday] = 8 },
            [AryanMonth.Gaylet] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 7, [AryanWeekday.Thursday] = 1, [AryanWeekday.Sunday] = 4 },
            [AryanMonth.Daylet] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 3, [AryanWeekday.Thursday] = 6, [AryanWeekday.Sunday] = 9 },
            [AryanMonth.Elet] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 8, [AryanWeekday.Thursday] = 2, [AryanWeekday.Sunday] = 5 },
            [AryanMonth.Veylet] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 4, [AryanWeekday.Thursday] = 7, [AryanWeekday.Sunday] = 1 },
            [AryanMonth.Heylet] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 9, [AryanWeekday.Thursday] = 3, [AryanWeekday.Sunday] = 6 },
            [AryanMonth.Taylet] = new Dictionary<AryanWeekday, int>() { [AryanWeekday.Monday] = 5, [AryanWeekday.Thursday] = 8, [AryanWeekday.Sunday] = 2 }
        };

        /// <summary>
        /// Даты смены Чертогов Сварожьего Круга
        /// </summary>
        private static readonly (AryanMonth Month, int Day)[] ChertogChangeDates = new (AryanMonth, int)[] {
            (AryanMonth.Ramhat, 1),
            (AryanMonth.Ramhat, 22),
            (AryanMonth.Aylet, 4),
            (AryanMonth.Aylet, 25),
            (AryanMonth.Beylet, 7),
            (AryanMonth.Beylet, 29),
            (AryanMonth.Gaylet, 12),
            (AryanMonth.Gaylet, 37),
            (AryanMonth.Daylet, 22),
            (AryanMonth.Elet, 4),
            (AryanMonth.Elet, 26),
            (AryanMonth.Veylet, 9),
            (AryanMonth.Veylet, 31),
            (AryanMonth.Heylet, 13),
            (AryanMonth.Heylet, 35),
            (AryanMonth.Taylet, 18)
        };

        /// <summary>
        /// Описание чертога
        /// </summary>
        private static readonly string[] ChertogDescription = new string[]
        {
            "Ярило-Солнце находится в Чертоге Девы, Богиня-Покровительница ЖИВА. Люди, родившиеся в этом Чертоге, очень целеустремленные. Они стремятся познавать мир, проявляют лидерские качества и упрямство. Эти люди обладают всеми качествами лидера, способны достигать намеченного.",
            "Ярило-Солнце находится в Чертоге Вепря, Бог-Покровитель РАМХАТ. В это время рождаются любознательные и настойчивые люди. Их отличает целеустремленность и умение преодолевать препятствия. Недостатком является способность не принимать во внимание интересы других людей.",
            "Ярило-Солнце находится в Чертоге Щуки, Богиня-Покровительница РОЖАНА. Людям, родившимся в этот период, свойственно стремление к спокойной, размеренной жизни. Основная сложность для них – принять важное решение. Однако к новым и неожиданным обстоятельствам они приспосабливаются легко.",
            "Ярило-Солнце находится в Чертоге Лебедя, Богиня-Покровительница МАКОШЬ. Представителям этого чертога, как правило, присуща уникальная душевная организация, но также их отличает и завидное трудолюбие. Они всегда рассчитывают только на себя, не полагаются на удачу.",
            "Ярило-Солнце находится в Чертоге Змея, Бог-Покровитель СЕМАРГЛ. Отличительная особенность людей этого периода – мудрость. Однако, в некоторых ситуациях они склонны проявлять эгоизм и консервативность.",
            "Ярило-Солнце находится в Чертоге Ворона, Бог-Покровитель КОЛЯДА. Люди, родившиеся в этом Чертоге, неординарны и не выносят одиночества, добрые и приятные в общении. Очень часто они не могут наладить свою семейную жизнь вплоть до 40 лет.",
            "Ярило-Солнце находится в Чертоге Медведя, Бог-Покровитель СВАРОГ. Рожденные в этом Чертоге люди – добрые и внимательные к окружающим. Они настойчиво идут к своей главной цели – облагородить все вокруг себя. Они умеют начать дело с нуля и довести его до завершения.",
            "Ярило-Солнце находится в Чертоге Бусла (Аиста), Бог-Покровитель РОД. Люди, родившиеся в этот период, очень трудолюбивы. Все, что они имеют в жизни, — это результат их труда. Они отзывчивы, и по первому зову спешат на выручку к близким.",
            "Ярило-Солнце находится в Чертоге Волка, Бог-Покровитель ВЕЛЕС. Чувство любопытства у людей, рожденных в этом Чертоге, сильнее страха перед неизвестным. Это экспериментаторы и искатели смысла в жизни, их интересует только истина.",
            "Ярило-Солнце находится в Чертоге Лисы, Богиня-Покровительница МОРЕНА. Представителей этого чертога отличает неуемное любопытство и склонность к изворотливости. Судьба этих людей складывается довольно непросто, но вместе с тем, они обладают особыми возможностями.",
            "Ярило-Солнце находится в Чертоге Тура, Бог-Покровитель КРЫШЕНЬ. Люди этого периода – идеалисты по мировоззрению, обладают повышенным чувством ответственности. Их отличает повышенная работоспособность, но увлекаясь созиданием, они часто забывают о родных и близких.",
            "Ярило-Солнце находится в Чертоге Лося, Богиня-Покровительница ЛАДА. Люди, рожденные в этом чертоге, отличаются невероятной выносливостью, общительностью и любвеобильностью. Однако, им бывает сложно довериться незнакомому человеку, они не верят никому и ничего не принимают на слово.",
            "Ярило-Солнце находится в Чертоге Финиста, Бог-Покровитель ВЫШЕНЬ. Людей этого периода отличает невероятная энергия, они стремятся делать сразу несколько дел. Их недостатком можно считать склонность к резким сменам настроения.",
            "Ярило-Солнце находится в Чертоге Коня, Бог-Покровитель КУПАЛА. Родившиеся в этот период люди обладают умением легко справляться с разными неприятностями и ударами Судьбы. Часто из них получаются прекрасные руководители.",
            "Ярило-Солнце находится в Чертоге Орла, Бог-Покровитель ПЕРУН. У людей этого чертога сильно развито чувство покровительства и доброжелательность. Правда, иногда это перерастает в назойливость и навязывание своего мнения другим.",
            "Ярило-Солнце находится в Чертоге Раса (Леопарда), Бог-Покровитель ТАРХ. Людей этого чертога отличает целеустремленность и рассудительность. Однако, при этом они не всегда способны принимать во внимание мнение другого человека. Они умеют ценить то, что им дано Свыше.",
        };
        #endregion

        /// <param name="smzh">Лет от СМЗХ (Сотворения Мира в Звездном храме)</param>
        /// <param name="month">Месяц</param>
        /// <param name="day">День</param>
        /// <param name="hour">Час</param>
        /// <param name="part">Часть</param>
        /// <param name="share">Доля</param>
        public AryanDateTime(
            int smzh,
            AryanMonth month,
            int day,
            int hour = 0,
            int part = 0,
            int share = 0)
        {
            this.Smzh = smzh;
            this.Month = month;
            this.Day = day;
            this.Hour = hour;
            this.Part = part;
            this.Share = share;
        }

        /// <summary>
        /// Лет от СМЗХ (Сотворения Мира в Звездном храме)
        /// </summary>
        public int Smzh { get; }

        /// <summary>
        /// Лето в круге Жизни
        /// </summary>
        public int Live => GetLive(this.Smzh);

        /// <summary>
        /// Лето в круге Лет
        /// </summary>
        public AryanKruglet Leto => GetLeto(this.Live);
        private int Sign => this.Live % 18 == 0 ? 18 : this.Live % 18;
        /// <summary>
        /// Начало
        /// </summary>
        public AryanGender Gender => (AryanGender)(this.Sign % 2);

        /// <summary>
        /// Месяц
        /// </summary>
        public AryanMonth Month { get; }

        /// <summary>
        /// День
        /// </summary>
        public int Day { get; }

        /// <summary>
        /// День недели
        /// </summary>
        public AryanWeekday Weekday => GetWeekday(this.Live, this.Leto, this.Month, this.Day);

        /// <summary>
        /// Цвет
        /// </summary>
        public AryanColor Color => (AryanColor)GetLiveIndex(this.Live);

        /// <summary>
        /// Стихия
        /// </summary>
        public AryanElement Element => (AryanElement)GetLiveIndex(this.Live);

        /// <summary>
        /// Чертог Сварожьего Круга
        /// </summary>
        public AryanChertog Chertog => (AryanChertog)GetChertogIndex();

        /// <summary>
        /// Бог-Покровитель Чертога Сварожьего Круга
        /// </summary>
        public AryanGod ChertogGod => (AryanGod)GetChertogIndex();

        /// <summary>
        /// Час
        /// </summary>
        public int Hour { get; }

        /// <summary>
        /// Часть
        /// </summary>
        public int Part { get; }

        /// <summary>
        /// Доля
        /// </summary>
        public int Share { get; }

        /// <summary>
        /// Текущая дата и время
        /// </summary>
        public static AryanDateTime Now => FromDateTime(DateTime.Now);

        /// <summary>
        /// Преобразование даты и времени из Григорианского в Славяно-Арийский календарь
        /// </summary>
        /// <param name="gregorian">Дата и время по Григорианскому календарю</param>
        public static AryanDateTime FromDateTime(DateTime gregorian)
        {
            var seekingDate = new DateTime(1, gregorian.Month, gregorian.Day);
            var __leto = (gregorian.Year + deltaYear - 7376) % 16 == 0 ? 16 : (gregorian.Year + deltaYear - 7376) % 16;
            var equinoxOffset = (int)Math.Ceiling((__leto + 1) / 4.0) % 4 == 0 ? 4 : (int)Math.Ceiling((__leto + 1) / 4.0) % 4;
            var equinoxDate = new DateTime(1, 9, 24 - equinoxOffset);
            var isShifted = seekingDate >= equinoxDate;
            var smzh = gregorian.Year + deltaYear + (isShifted ? 1 : 0);
            var live = GetLive(smzh);
            var leto = GetLeto(live);

            (AryanMonth month, int day) = GetMonthAndDay(leto, seekingDate);

            var mSecThisDay = (gregorian.TimeOfDay.TotalMilliseconds + GregorianMSecondInHour * 6) % GregorianMSecondInDay;// остаток миллисекунд в новых (текущих) сутках - сегодня, учитывая смещение начала дня на 6 часов
            var hour = Math.Floor(mSecThisDay / MSecondInSlavAriHour); // Славяно-Арийский час "числом" (текущий)
            hour = hour == 0 ? 16 : hour;
            var part = Math.Floor((mSecThisDay % MSecondInSlavAriHour) / MSecondInSlavAriPart); // Славяно-Арийских частей часа (текущих)
            var share = Math.Floor(((mSecThisDay % MSecondInSlavAriHour) % MSecondInSlavAriPart) * SlavAriShareInPart / MSecondInSlavAriPart);

            return new AryanDateTime(smzh, month, day, (int)hour, (int)part, (int)share);
        }

        /// <summary>
        /// Лето в круге жизни
        /// </summary>
        /// <param name="smzh"></param>
        private static int GetLive(int smzh)
        {
            return (smzh - 7376) % 144 == 0 ? 144 : (smzh - 7376) % 144;
        }

        private static int GetLiveIndex(int live)
        {
            if (live < 1 || live > 144)
                throw new ArgumentOutOfRangeException(nameof(live));
            var res = ((live + 1) / 2 % 9);
            return res == 0 ? 9 : res;
        }

        /// <summary>
        /// Лето в круге лет
        /// </summary>
        /// <param name="live">Лето в круге жизни</param>
        private static AryanKruglet GetLeto(int live)
        {
            return (AryanKruglet)(live % 16 == 0 ? 16 : live % 16);
        }

        /// <summary>
        /// День недели
        /// </summary>
        /// <param name="live"></param>
        /// <param name="leto"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        private static AryanWeekday GetWeekday(int live, AryanKruglet leto, AryanMonth month, int day)
        {
            //Первый день недели в данном году в круге лет
            var weekdayYear = GetStartYearWeekday(live);

            int weekdayMonth = leto != AryanKruglet.Temple
                ? (int)month % 2 != 0 ? (int)weekdayYear : (int)weekdaysOddEven[weekdayYear]
                : weekdaysBySaintMonth[month][weekdayYear];

            return (AryanWeekday)((weekdayMonth + day - 1) % 9 == 0 ? 9 : (weekdayMonth + day - 1) % 9);
        }

        private static (AryanMonth Month, int Day) GetMonthAndDay(AryanKruglet leto, DateTime seekingDate)
        {
            var months = monthsByLeto[(int)leto - 1] ?? monthsByLeto[(int)leto] ?? monthsByLeto[(int)leto + 1];
            int month = 0;
            for (int i = 0; i < months.Length; i++)
            {
                if (DateRange(months[i], seekingDate) <= 41)
                {
                    month = i;
                }
            }

            var beginDate = months[month];

            var day = DateRange(beginDate, seekingDate);

            return ((AryanMonth)(month + 1), day);
        }

        private static AryanWeekday GetStartYearWeekday(int live)
        {
            if (live < 0 || live > 144)
                throw new ArgumentOutOfRangeException(nameof(live), live, "Лето в круге лет должно лежать в диапазоне от 1 до 144");

            return weekdaysByLeto.Single(x => x.Value.Contains(live)).Key;
        }

        /// <summary>
        /// Получение индекса чертога
        /// </summary>
        /// <remarks>Чертог, где находится Ярило-Солнце: в "переходной день" смена Чертога произходит в 14:000 (Подани - начало Времени отдыха после трапезы)</remarks>
        private int GetChertogIndex()
        {
            for (int i = 0; i < ChertogChangeDates.Length; i++)
            {
                var (month, day) = ChertogChangeDates[i];

                // Если текущий месяц больше месяца в записи - пропускаем
                if (Month > month) continue;

                // Если текущий месяц меньше месяца в записи - возвращаем предыдущий индекс
                if (Month < month) return i + 1;

                // Если месяцы совпадают, сравниваем дни
                if (Day > day) continue;

                if (Day == day && Hour >= 14) continue;

                return i + 1;
            }

            return 1;
        }

        private static int DateRange(DateTime date1, DateTime date2)
        {
            if (date2 < date1)
            {
                date2 = new DateTime(date2.Year + 1, date2.Month, date2.Day);
            }
            return (int)(date2 - date1).TotalDays + 1;
        }         
    }
}