# AryanDateTime Library

A .NET library for working with the ancient Slavic-Aryan calendar system (Славяно-Арийский календарь).

## Features

- Conversion between Gregorian and Slavic-Aryan dates
- Complete representation of Slavic-Aryan time units:
  - Leta (Лета) - years
  - Months (Месяцы)
  - Days (Дни)
  - Hours (Часы)
  - Parts (Части)
  - Shares (Доли)
- Calculation of celestial attributes:
  - Elements (Стихии)
  - Colors (Цвета)
  - Kruglets (Круги)
  - Chertogs (Чертоги Сварожьего Круга)
  - Gods (Боги-Покровители)

## Installation

Install via NuGet:

```bash
Install-Package AryanDateTime
```

Or using .NET CLI:

```bash
dotnet add package AryanDateTime
```

## Usage

### Basic Conversion

```csharp
using AryanDateTime;

// Convert current date
var aryanNow = AryanDateTime.Now;

// Convert specific Gregorian date
var gregorianDate = new DateTime(2023, 12, 31);
var aryanDate = AryanDateTime.FromDateTime(gregorianDate);
```

### Accessing Calendar Properties

```csharp
Console.WriteLine($"Year from Creation: {aryanDate.Smzh}");
Console.WriteLine($"Month: {aryanDate.Month}");
Console.WriteLine($"Day: {aryanDate.Day}");
Console.WriteLine($"Weekday: {aryanDate.Weekday}");
Console.WriteLine($"Hour: {aryanDate.Hour}");
Console.WriteLine($"Part: {aryanDate.Part}");
Console.WriteLine($"Share: {aryanDate.Share}");

// Celestial properties
Console.WriteLine($"Element: {aryanDate.Element}");
Console.WriteLine($"Color: {aryanDate.Color}");
Console.WriteLine($"Kruglet: {aryanDate.Leto}");
Console.WriteLine($"Chertog: {aryanDate.Chertog}");
Console.WriteLine($"Chertog God: {aryanDate.ChertogGod}");
```

### Creating Custom Dates

```csharp
var customAryanDate = new AryanDateTime(
    smzh: 7531,    // Year from Creation
    month: AryanMonth.Ramhat,
    day: 1,
    hour: 10,
    part: 30,
    share: 120);
```

## API Reference

### Main Struct: `AryanDateTime`

#### Properties:
- `Smzh` - Лет от СМЗХ (Сотворения Мира в Звездном храме)
- `Live` - Лето в круге Жизни
- `Leto` - Лето в круге Лет (Kruglet)
- `Gender` - Начало (Мужское/Женское)
- `Month` - Месяц
- `Day` - День
- `Weekday` - День недели
- `Color` - Цвет года
- `Element` - Стихия года
- `Chertog` - Чертог Сварожьего Круга
- `ChertogGod` - Бог-Покровитель Чертога
- `Hour` - Час (1-16)
- `Part` - Часть (1-144)
- `Share` - Доля (1-1296)

#### Static Methods:
- `FromDateTime(DateTime)` - Converts Gregorian to Slavic-Aryan date
- `Now` - Gets current Slavic-Aryan date/time

### Enums:

1. `AryanMonth` - Months of the year
2. `AryanWeekday` - Days of the week
3. `AryanElement` - Elements (Earth, Fire, Water, Air)
4. `AryanColor` - Year colors
5. `AryanKruglet` - Year cycles (16-year)
6. `AryanChertog` - Heavenly Halls (16)
7. `AryanGod` - Patron Gods

## Calendar System Details

The Slavic-Aryan calendar is based on:
- 16-hour days
- 9-day weeks
- 9-month years (40 or 41 days)
- 16-year cycles (Leto)
- 144-year cycles (Life Circle)

## License

MIT License. See [LICENSE](LICENSE.txt) for details.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## Acknowledgements

Based on ancient Slavic-Aryan astronomical and calendar systems.