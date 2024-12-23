# Разработка корпоративных приложений
[Таблица с успеваемостью](https://docs.google.com/spreadsheets/d/1j8YNA_P-8_UbMoDqIovw82hmGAIQxD6DM8_PFpF1ct4)

# Управление Персоналом (вариант 3)

## Описание

Проект **"Управление Персоналом"** представляет собой систему для управления сотрудниками компании. Она включает в себя основные функции, такие как добавление, редактирование и удаление сотрудников, а также управление их отделами, должностями и другими атрибутами.

## Структура Проекта

- **Staff.Domain**: Содержит бизнес-логику и модели данных, связанные с сотрудниками, отделами, должностями и другими сущностями.
- **Staff.Tests**: Включает модульные тесты для проверки корректности работы бизнес-логики и функционала системы.

# Описание Классов и Их Полей

В проекте **"Управление Персоналом"** используются несколько ключевых классов, представляющих различные аспекты управления сотрудниками. Ниже приведено описание основных классов и их полей.

## Классы

### 1. `Employee` (Сотрудник)

Представляет сотрудника компании с его личными данными, должностью и другими атрибутами.

- **`RegistrationNumber`** (`int`): Уникальный регистрационный номер сотрудника.
- **`Surname`** (`string`): Фамилия сотрудника.
- **`Name`** (`string`): Имя сотрудника.
- **`Patronymic`** (`string`): Отчество сотрудника.
- **`DateOfBirth`** (`DateTime`): Дата рождения сотрудника.
- **`Gender`** (`Gender`): Пол сотрудника (перечисление `Gender`).
- **`DateOfHire`** (`DateTime`): Дата найма сотрудника.
- **`Departments`** (`List<Department>`): Список отделов, в которых работает сотрудник.
- **`Workshop`** (`Workshop`): Цех, к которому прикреплён сотрудник.
- **`Position`** (`Position`): Должность сотрудника.
- **`Address`** (`Address`): Адрес проживания сотрудника.
- **`WorkPhone`** (`string`): Рабочий телефон сотрудника.
- **`HomePhone`** (`string`): Домашний телефон сотрудника.
- **`MaritalStatus`** (`MaritalStatus`): Семейное положение сотрудника (перечисление `MaritalStatus`).
- **`FamilySize`** (`int`): Размер семьи сотрудника.
- **`NumberOfChildren`** (`int`): Количество детей у сотрудника.
- **`EmploymentArchive`** (`List<EmploymentArchiveRecord>`): История занятости сотрудника.
- **`IsUnionMember`** (`bool`): Является ли сотрудник членом профсоюза.
- **`UnionBenefits`** (`List<UnionBenefit>`): Перечень льгот профсоюза, полученных сотрудником.

### 2. `Department` (Отдел)

Представляет отдел компании, в котором работают сотрудники.

- **`DepartmentId`** (`int`): Уникальный идентификатор отдела.
- **`Name`** (`string`): Название отдела.

### 3. `Workshop` (Цех)

Представляет производственный цех, к которому прикреплены сотрудники.

- **`WorkshopId`** (`int`): Уникальный идентификатор цеха.
- **`Name`** (`string`): Название цеха.

### 4. `Position` (Должность)

Представляет должность, занимаемую сотрудником.

- **`PositionId`** (`int`): Уникальный идентификатор должности.
- **`Title`** (`string`): Название должности.

### 5. `EmploymentArchiveRecord` (Запись Архива Занятости)

Представляет запись в архиве занятости сотрудника, отражающую его предыдущие должности и периоды работы.

- **`StartDate`** (`DateTime`): Дата начала периода занятости на данной должности.
- **`EndDate`** (`DateTime?`): Дата окончания периода занятости на данной должности. Может быть `null`, если сотрудник всё ещё занимает эту должность.
- **`Position`** (`Position`): Должность, которую занимал сотрудник в этот период.

### 6. `UnionBenefit` (Профсоюзная Льгота)

Представляет льготы, предоставляемые профсоюзом сотруднику.

- **`UnionBenefitId`** (`int`): Уникальный идентификатор льготы.
- **`BenefitType`** (`BenefitType`): Тип льготы (перечисление `BenefitType`).
- **`DateReceived`** (`DateTime`): Дата получения льготы.

### 7. `Address` (Адрес)

Представляет адрес проживания сотрудника.

- **`Street`** (`string`): Название улицы.
- **`HouseNumber`** (`string`): Номер дома.
- **`City`** (`string`): Город.
- **`PostalCode`** (`string`): Почтовый индекс.
- **`Country`** (`string`): Страна.

## Перечисления (Enums)

### 1. `Gender` (Пол)

Отражает пол сотрудника.

- **`Male`**: Мужской.
- **`Female`**: Женский.
- **`Other`**: Другой/Неопределённый.

### 2. `MaritalStatus` (Семейное Положение)

Отражает семейное положение сотрудника.

- **`Single`**: Холост/Не замужем.
- **`Married`**: Женат/Замужем.
- **`Divorced`**: Разведён.
- **`Widowed`**: Вдова/Вдовец.

### 3. `BenefitType` (Тип Льготы)

Отражает тип профсоюзной льготы.

- **`SanatoriumVoucher`**: Ваучер на санаторно-курортное лечение.
- **`HolidayHomeVoucher`**: Ваучер на приобретение дачного дома.
- **`PioneerCampVoucher`**: Ваучер на посещение лагеря "пионеров".
- **`Other`**: Другая льгота.

## Связи Между Классами

- **`Employee`** связан с **`Department`** через коллекцию `Departments`, что означает, что один сотрудник может работать в нескольких отделах.
- **`Employee`** связан с **`Workshop`** и **`Position`** напрямую, что отражает его текущий цех и должность.
- **`Employee`** имеет список **`EmploymentArchiveRecord`**, который хранит историю занятости сотрудника.
- **`Employee`** может получать несколько **`UnionBenefit`**, отражающих льготы профсоюза.
- **`Employee`** имеет **`Address`**, представляющий его место жительства.

## Технологии

- **Язык программирования**: C#
- **Платформа**: .NET 8.0
- **Тестирование**: xUnit
- **Система контроля версий**: Git
- **Среда разработки**: Visual Studio / Visual Studio Code
