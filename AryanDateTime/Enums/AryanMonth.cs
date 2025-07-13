using System.ComponentModel;

namespace AryanDateTime.Enums
{
    /// <summary>
    /// Aryan months (Месяцы арийского календаря)
    /// </summary>
    public enum AryanMonth : byte
    {
        /// <summary>Ramhat month (Рамхат)</summary>
        [Description("Божественного Начала")]
        Ramhat = 1,
        /// <summary>Aylet month (Айлет)</summary>
        [Description("Новых Даров")]
        Aylet = 2,
        /// <summary>Beylet month (Бейлет)</summary>
        [Description("Белого Сияния и Покоя Мира")]
        Beylet = 3,
        /// <summary>Gaylet month (Гэйлет)</summary>
        [Description("Вьюг и Стужи")]
        Gaylet = 4,
        /// <summary>Daylet month (Дайлет)</summary>
        [Description("Пробуждения Природы")]
        Daylet = 5,
        /// <summary>Elet month (Элет)</summary>
        [Description("Посева и Наречения")]
        Elet = 6,
        /// <summary>Veylet month (Вэйлет)</summary>
        [Description("Ветров")]
        Veylet = 7,
        /// <summary>Heylet month (Хейлет)</summary>
        [Description("Получения Даров Природы")]
        Heylet = 8,
        /// <summary>Taylet month (Тайлет)</summary>
        [Description("Завершения")]
        Taylet = 9
    }
}