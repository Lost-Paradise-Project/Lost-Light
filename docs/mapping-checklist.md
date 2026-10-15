# Чеклист маппера

Пройди по пунктам перед PR с картой или шаттлом. Скопируй нужные группы в описание PR или issue: GitHub сделает чекбоксы кликабельными.

> [!NOTE]
> Это краткая версия [гайдов по отделам](https://wiki.lost-paradise.space/ru/mapping/stations/overview): в каждой группе есть ссылка на полное описание. Прототипы пишутся как в игре, при сомнениях проверь в панели спауна.

## Перед сдачей карты

### Файлы и прототип

- [ ] Карта лежит в `Resources/Maps/_LP/Stations/`, шаттлы в `Resources/Maps/_LP/Shuttles/<папка>`
- [ ] На гриде станции есть компонент `BecomesStation`, поле `Id` задано через `vvwrite`
- [ ] `Id` в `BecomesStation` совпадает с `id` и с ключом станции в прототипе карты (регистр важен)
- [ ] Прототип карты в `Resources/Prototypes/_LP/Maps/`, заданы `minPlayers`, `maxPlayers`, `mapName`, `mapPath`
- [ ] В прототипе есть `StationNameSetup`, эвакуационный и грузовой шаттлы, список работ (`StationJobs`)
- [ ] Блок NT Staff добавлен под `availableJobs` (NTR, BSO, магистрат, IAA, NCT)
- [ ] Эвакуационный и грузовой шаттлы стыкуются со станцией без тесноты
- [ ] Новые шаттлы добавлены в автотест `GridPowerTests.cs` (по алфавиту)

### Перед сохранением

- [ ] Выполнен `fixgridatmos` для грида (после любых правок стен и пола)
- [ ] Выполнен `variantize` для грида
- [ ] Карта **не инициализирована** (`mapinit` не запускался) и стоит на паузе
- [ ] Станция сохранена через `savemap`, а шаттлы через `savegrid`
- [ ] Расширение `.yml` указано в имени файла
- [ ] Нет лишних несвязанных гридов (тайлы не заливались `Ctrl + ЛКМ` в пустоте)

### Оформление PR

- [ ] Новое лежит в папках `_LP`, правки чужих файлов помечены `LP edit`
- [ ] Для крупной новой станции есть диздок, ссылка на него в PR
- [ ] В PR есть скриншоты карты (раздел «Медиа»)
- [ ] Заполнены разделы шаблона PR и блок `:cl:`, если изменение видно игрокам

## ИИ и камеры

Подробно: [ИИ и камеры](https://wiki.lost-paradise.space/ru/mapping/stations/ai-cameras).

### Помещения

- [ ] Консоль загрузки законов ИИ (AI Upload)
- [ ] Консоль восстановления ИИ (AI Restoration)
- [ ] Охранные турели ИИ
- [ ] Резервное питание (подстанция или SMES с запасом на случай потери питания)
- [ ] Телекомы. Лучше мапить в [Инженерии](https://wiki.lost-paradise.space/ru/mapping/stations/engineering)
- [ ] Серверы камер. Лучше мапить в [Инженерии](https://wiki.lost-paradise.space/ru/mapping/stations/engineering)

### Загрузка законов ИИ (AI Upload)

- [ ] **Консоль загрузки ИИ** — `StationAiUploadComputer`. Меняет законы ИИ
- [ ] **Охранная турель** — `WeaponEnergyTurretAI`. 1-2
- [ ] **Панель управления турелями** — `WeaponEnergyTurretAIControlPanel`. Связана с турелями, но вне их линии видимости
- [ ] **Ящик с лаубордами** — `CrateLawboards`. Обязателен, даёт платы законов
- [ ] **Усиленные стены** — `WallReinforced`

### Питание ИИ

- [ ] **Переносной генератор P.A.C.M.A.N.** — `PortableGeneratorPacman`
- [ ] **Плазма** — `SheetPlasma`. 30
- [ ] **Продвинутый SMES** — `SMESAdvanced`
- [ ] **Подстанция** — `SubstationBasic`
- [ ] **Охранная турель** — `WeaponEnergyTurretAI`. 1
- [ ] **Панель управления турелью** — `WeaponEnergyTurretAIControlPanel`. Связана с турелью, но вне её видимости. Если в одной комнате с ядром, можно не ставить
- [ ] **Усиленные стены** — `WallReinforced`. Два слоя

### Ядро ИИ

- [ ] **Ядро ИИ** — `PlayerStationAi`
- [ ] **Охранная турель** — `WeaponEnergyTurretAI`. 1-2
- [ ] **Панель управления турелями** — `WeaponEnergyTurretAIControlPanel`. Связана с турелями, но вне их видимости
- [ ] **Шлюзы командования** — `AirlockCommandGlassLocked`. Минимум пара шлюзов
- [ ] **Усиленные стены** — `WallReinforced`. Два слоя
- [ ] **Высокозащищённая дверь** — `HighSecCommandLocked`. Минимум одна перед шлюзами

### Дополнительные компьютеры у ядра ИИ

- [ ] **Консоль управления робототехникой** — `ComputerRoboticsControl`
- [ ] **Компьютер тревог атмосферы** — `ComputerAlert`
- [ ] **Монитор энергопотребления** — `ComputerPowerMonitoring`
- [ ] **Управление солнечными панелями** — `ComputerSolarControl`
- [ ] **Монитор сети атмосферы** — `ComputerAtmosMonitoring`
- [ ] **Компьютер медицинских записей** — `ComputerMedicalRecords`

## Карго

Подробно: [Карго](https://wiki.lost-paradise.space/ru/mapping/stations/cargo).

### Помещения

- [ ] Кабинет квартирмейстера (QM)
- [ ] Раздевалка карго (иногда часть грузового отсека)
- [ ] Стойка выдачи (иногда часть грузового отсека)
- [ ] Грузовой отсек
- [ ] Почтовая
- [ ] Отсек утилизаторов (Salvage)
- [ ] Шахтёрский отсек (можно совместить с утилизаторами)

### Общее для карго

- [ ] **Техфаб карго** — `CargoTechFab`. Обязательно
- [ ] **Материальный силос** — `MachineMaterialSilo`. В радиусе действия автолата
- [ ] **Автолат** — `Autolathe`
- [ ] **Cargo drobe** — `VendingMachineCargoDrobe`
- [ ] **Спаун карготехника** — `SpawnPointCargoTechnician`. Число зависит от размера станции, минимум 2
- [ ] **Компьютер бонти карго** — `ComputerCargoBounty`

### Кабинет квартирмейстера

- [ ] **Консоль связи карго** — `ComputerCommsCargo`. Обязательно
- [ ] **Факс** — `FaxMachineBase`. Название «QM»
- [ ] **Спаун Мортиции** — `SpawnMobRaccoonMorticia`. Необязательно
- [ ] **Кровать с простынёй QM** — `Bed`, `BedsheetQM`
- [ ] **Комод** — `DresserQuarterMasterFilled`
- [ ] **Шкафчик QM** — `LockerQuarterMasterFilled`
- [ ] **Усиленная стена** — `WallReinforced`
- [ ] **Шлюзы QM** — `AirlockQuartermasterGlassLocked`, `AirlockQuartermasterLocked`
- [ ] **Спаун QM** — `SpawnPointQuartermaster`

### Отсек утилизаторов (Salvage)

- [ ] **Док** — `AirlockExternalGlassShuttleLocked`. Нужен рабочий конвейер, пример ниже
- [ ] **Шкафчик утилизатора** — `LockerSalvageSpecialistLargeFilledHardsuit`, `LockerSalvageSpecialistFilledHardsuit`. Минимум по одному на каждую работу утилизации. Есть большие шкафчики на два комплекта
- [ ] **Автомат билетов утилизации** — `SLVendingMachineSalvage`
- [ ] **Консоль шаттла утилизаторов** — `ComputerShuttleSalvage`
- [ ] **Доска заданий утилизации** — `ComputerSalvageJobBoard`
- [ ] **Автомат утилизации** — `VendingMachineSalvage`
- [ ] **Компьютер масс-сканера** — `ComputerRadar`
- [ ] **Баллоны O2 и N2** — `OxygenCanister`, `NitrogenCanister`
- [ ] **Измельчитель** — `Recycler`. Нужен рабочий конвейер
- [ ] **Раздатчик баллонов** — `VendingMachineTankDispenserEVA`. N2/O2. **НЕ ПЛАЗМА**
- [ ] **Шлюзы утилизации** — `AirlockSalvageMiningGlassLocked`, `AirlockSalvageGlassLocked`. Если зона общая, используй шлюзы `SalvageMining`
- [ ] **Спаун утилизатора** — `SpawnPointSalvageSpecialist`. Минимум 3
- [ ] **Спаун главы утилизаторов** — `SpawnPointSalvageLead`. 1

### Шахтёрский отсек (Mining)

- [ ] **Док** — `AirlockExternalGlassShuttleLocked`. Пример ниже
- [ ] **Шкафчик шахтёра** — `LockerMiningSpecialistLargeFilledHardsuit`, `LockerMiningSpecialistFilledHardsuit`. Минимум по одному на каждую работу. Есть большие на два комплекта
- [ ] **Автомат билетов шахты** — `SLVendingMachineMining`
- [ ] **Консоль шаттла шахтёров** — `ComputerShuttleMining`
- [ ] **Автомат утилизации** — `VendingMachineSalvage`
- [ ] **Компьютер масс-сканера** — `ComputerRadar`
- [ ] **Баллоны O2 и N2** — `OxygenCanister`, `NitrogenCanister`
- [ ] **Переработчик руды** — `OreProcessor`
- [ ] **Раздатчик баллонов** — `VendingMachineTankDispenserEVA`. N2/O2. **НЕ ПЛАЗМА**
- [ ] **Шлюзы шахты** — `AirlockMiningCargoGlassLocked`, `AirlockSalvageMiningGlassLocked`. Если зона общая, используй шлюзы `SalvageMining`
- [ ] **Магнит утилизации** — `SalvageMagnet`
- [ ] **Спаун шахтёра** — `SpawnPointminingspecialist`. Минимум 2

### Грузовой отсек

- [ ] **Док** — `AirlockExternalGlassShuttleLocked`. Пример ниже. Нужны рабочие конвейеры
- [ ] **Зона выгрузки ящиков**. Минимум 3x3 для ящиков, вокруг можно пройти
- [ ] **Консоль грузового шаттла** — `ComputerShuttleCargo`
- [ ] **Дальний голопад (станция, грузовой отсек)** — `HolopadCargoBayLongRange`
- [ ] **Спаун карго-гориллы** — `SpawnMobCargorilla`. Необязательно

### Грузовой док

- [ ] **Направленный вентилятор** — `AtmosDeviceFanDirectional`. Под шлюзами, лицом в космос
- [ ] **Внешний стыковочный шлюз** — `AirlockExternalGlassShuttleLocked`
- [ ] **HV** — `CableHV`. Соединяет шлюзы с питанием станции
- [ ] **Труба распределения** — `GasPipeStraight`. Центр
- [ ] **Труба экспорта** — `GasPipeStraight`. Справа/снизу
- [ ] **Труба импорта** — `GasPipeStraight`. Слева/сверху

### Стойка выдачи карго

- [ ] **Стол** — `TableReinforced`
- [ ] **Компьютер заказов** — `ComputerCargoOrders`
- [ ] **Факс** — `FaxMachineBase`. Название «cargo»
- [ ] **Принтер документов** — `PrinterDoc`
- [ ] **Защищённое окно-дверь** — `WindoorSecureCargoLocked`

### Почтовые ящики

- [ ] **Ящик карго** — `CargoMailBox`. У стойки карго или у утилизации/шахты
- [ ] **Ящик командования** — `CommandMailBox`. У входа на мостик
- [ ] **Ящик инженерии** — `EngineeringMailBox`. У стойки инженерии
- [ ] **Ящик медицины** — `MedicalMailBox`. У стойки медбея
- [ ] **Ящик науки** — `ScienceMailBox`. У стойки науки
- [ ] **Ящик СБ** — `SecurityMailBox`. У стойки СБ
- [ ] **Ящик сервиса** — `ServiceMailBox`. Снаружи **общежития**

### Почтовая комната

- [ ] **Табличка «Почта»** — `SignMail`. Вывески важны
- [ ] **Спаун почтальона** — `SpawnPointmailtech`. В почтовой
- [ ] **Шлюз / стеклянный шлюз почты** — `AirlockMailLocked`, `AirlockMailGlassLocked`. Используй, если не мешает карготехникам
- [ ] **Окно-дверь почты** — `WindoorMailLocked`. Для стойки
- [ ] **Почтовый телепорт** — `CargoMailTeleporter`. В почтовой
- [ ] **Почтовая тележка** — `MailCart`. Необязательно
- [ ] **Почтовая тележка-стеллаж** — `MailTrolley`. В почтовой

## Командование

Подробно: [Командование](https://wiki.lost-paradise.space/ru/mapping/stations/command).

### Главы смен

- [ ] Квартирмейстер (QM): [Карго](https://wiki.lost-paradise.space/ru/mapping/stations/cargo)
- [ ] Главный инженер (CE): [Инженерия](https://wiki.lost-paradise.space/ru/mapping/stations/engineering)
- [ ] Главный врач (CMO): [Медицина](https://wiki.lost-paradise.space/ru/mapping/stations/medical)
- [ ] Директор исследований (RD): [Наука](https://wiki.lost-paradise.space/ru/mapping/stations/science)
- [ ] Глава СБ (HOS): [Служба безопасности](https://wiki.lost-paradise.space/ru/mapping/stations/security)
- [ ] Глава персонала (HOP): [Сервис](https://wiki.lost-paradise.space/ru/mapping/stations/service)

### Помещения

- [ ] Мостик (много компьютеров)
- [ ] Кабинет капитана
- [ ] Конференц-зал
- [ ] Хранилище (Vault)

### Мостик

- [ ] **Табличка «Мостик»** — `SignBridge`. Вывески критичны
- [ ] **Техфаб командования** — `CommandTechFab`. Обязательно
- [ ] **Факс [CMD: Bridge]** — `FaxMachineCommandBridge`. Главный инструмент мостика
- [ ] **Принтер документов** — `PrinterDoc`. Для бумажной работы
- [ ] **Стопка бумаги (5/10/20)** — `PaperBin5`, `PaperBin10`, `PaperBin20`. Рядом с принтером
- [ ] **Компьютер связи** — `ComputerComms`. Для объявлений
- [ ] **Компьютер ID-карт** — `ComputerId`. Для обновления ID-карт
- [ ] **Компьютер распределения бюджета** — `ComputerFundingAllocation`. Минимум один должен быть в **кабинете HOP**. Второй на мостике допустим
- [ ] **Зарядник батарей** — `PowerCellRecharger`. Особенно для переводчиков
- [ ] **Зарядник** — `WeaponCapacitorRecharger`. Для некоторых предметов (обычно дизейблеров)
- [ ] **Клетка хомяка [Хамлет]** — `CrateNPCHamlet`. Питомец мостика
- [ ] **Дальний голопад [Station - Bridge]** — `HolopadCommandBridgeLongRange`. Дальнего действия, голозвонки между шаттлами
- [ ] **Голопад [Bridge]** — `HolopadCommandBridge`. Ближнего действия, только по станции
- [ ] **Стены и окна** — `WallReinforced`, `ReinforcedWindow`. Периметр прочный, внутренние стены могут быть слабее

### Необязательные дополнения мостика

- [ ] **Монитор камер** — `ComputerSurveillanceCameraMonitor`. Для слежки
- [ ] **Компьютер записей СБ** — `ComputerCriminalRecords`. Статус розыска, цель ниндзя
- [ ] **Монитор питания** — `ComputerPowerMonitoring`
- [ ] **Управление солнечными панелями** — `ComputerSolarControl`
- [ ] **Компьютер тревог атмосферы** — `ComputerAlert`
- [ ] **Монитор сети атмосферы** — `ComputerAtmosMonitoring`. Показывает сети труб
- [ ] **Консоль мониторинга экипажа** — `ComputerCrewMonitoring`. Здоровье экипажа
- [ ] **Компьютер масс-сканера** — `ComputerRadar`. Другие шаттлы и гриды рядом
- [ ] **Компьютер кадровых записей** — `ComputerStationRecords`. Список экипажа
- [ ] **Компьютер медицинских записей** — `ComputerMedicalRecords`
- [ ] **Консоль управления робототехникой** — `ComputerRoboticsControl`. Управление силиконами
- [ ] **Компьютер R&D** — `ComputerResearchAndDevelopment`. Состояние науки
- [ ] **Компьютер заказов карго** — `ComputerCargoOrders`. Для заказа ~~пиццы~~ необходимого
- [ ] **Компьютер** — `BaseComputer`. Обычный компьютер, заполнить пустое место

### Кабинет капитана

- [ ] **Табличка «Глава»** — `SignHead`. Вывески критичны
- [ ] **Спаун капитана** — `SpawnPointCaptain`. Минимум один, можно несколько для разных мест
- [ ] **Факс [CMD: Captain, NukeCodes]** — `FaxMachineCaptain`. Самый мощный факс на станции
- [ ] **Устройство авторизации ключ-картой** — `KeycardAuth`. Для авторизации через Secure Command Terminal (ERT, CBURN и т. д.)
- [ ] **Консоль верфи** — `ComputerShipyard`. В кабинете капитана, а если места нет, на мостике
- [ ] **Стеклянный ящик [антикварный лазер]** — `GlassBoxLaserFilled`. Обязательно
- [ ] **Спаун лисы Рено (питомец капитана)** — `SpawnMobFoxRenault`. Цель вора
- [ ] **Запасная ID-карта капитана** — `CaptainIDCard`. На столе или на видном месте
- [ ] **Кровать с простынёй капитана** — `Bed`, `BedsheetCaptain`. В кабинете **или** в спальне рядом. Цель вора
- [ ] **Комод** — `DresserCaptainFilled`. В кабинете **или** в спальне
- [ ] **Шкафчик капитана** — `LockerCaptainFilledNoLaser`. В кабинете **или** в спальне. Именно этот, а не другие варианты
- [ ] **Хранилище скафандра** — `SuitStorageCaptain`. Обязательно
- [ ] **Шлюз капитана** — `AirlockCaptainLocked`, `AirlockCaptainGlassLocked`. С доступом капитана
- [ ] **Стены и окна** — `WallReinforced`, `ReinforcedWindow`. Периметр прочный

### Санузел капитана

- [ ] **Золотой унитаз [Dirty Water, цель кражи]** — `ToiletGoldenDirtyWater`. Можно поставить в хранилище, если санузла нет. Цель вора
- [ ] **Шлюз капитана** — `AirlockCaptainLocked`. С доступом капитана
- [ ] **Стены и окна** — `WallReinforced`, `ReinforcedWindow`. Периметр прочный

### Конференц-зал

- [ ] **Табличка «Конференц-зал»** — `SignConference`. Вывески критичны
- [ ] **Смотровые окна** — `ReinforcedWindow`. Экипаж любит сплетни и драмы командования
- [ ] **Жалюзи** — `ShuttersNormalOpen`. Иногда экипаж надоедает, и жалюзи надо закрыть
- [ ] **Обычные столы** — `Table`, `TableWood`, `TableGlass`, `TableReinforced`, `TableReinforcedGlass`. Чтобы за ним сидело много людей, *минимум* 8 мест, лучше больше
- [ ] **Красивые столы** — `TableFancyBlack`, `TableFancyBlue`, `TableFancyCyan`, `TableFancyGreen`, `TableFancyOrange`, `TableFancyPink`, `TableFancyPurple`, `TableFancyRed`, `TableFancySkyBlue`, `TableFancyWhite`. Много цветов, чаще всего синий. Проявляй фантазию
- [ ] **Стулья** — `ChairOfficeLight`, `ChairOfficeDark`, `ChairOfficeSleek`, `ComfyChairBlue`. Неполный список, ищи `chair` в панели спауна
- [ ] **Стены и окна** — `WallReinforced`, `ReinforcedWindow`. Периметр прочный

### Хранилище (Vault)

- [ ] **Табличка «Хранилище»** — `SignVault`. Вывески критичны
- [ ] **Высокозащищённая дверь** — `HighSecCommandLocked`. Прочные двери для прочного хранилища
- [ ] **Защитный якорь** — `protectionanchor`. Защищает от магического и нуль-пространственного проникновения
- [ ] **Ядерная бомба** — `NuclearBomb`. Бомба
- [ ] **Морозильник [Vault, Filled]** — `LockerFreezerVaultFilled`. Деньги и желанный пистолет Деккарда
- [ ] **Золотой ящик с инструментами** — `ToolboxGoldFilled`. Обязательно, 30 золота
- [ ] **Золото** — `IngotGold`. Обязательно, стопка 30
- [ ] **Серебро** — `IngotSilver`. Обязательно, стопка 30
- [ ] **Очищенный алмаз** — `MaterialDiamond1`. От 1 до 3
- [ ] **Спесо** — `SpaceCash100`. Не больше 4000 спесо
- [ ] **Запасные платы компьютеров** — `CommsComputerCircuitboard`, `IDComputerCircuitboard`. Проявляй фантазию
- [ ] **Разные ценности** — `DrinkGoldenCup`, `GoldRingDiamond`. Ценности субъективны: то, что людям нравится или кажется полезным. Можно добавить ограниченное число предметов только для науки
- [ ] **Усиленная стена** — `WallReinforced`. Возможно два слоя, особенно у космоса

## Общие зоны

Подробно: [Общие зоны](https://wiki.lost-paradise.space/ru/mapping/stations/common).

### Коридоры

- [ ] **Карта станции** — `StationMap`. Должна быть **легко** найти
- [ ] **Экран** — `Screen`. Сообщает экипажу уровень тревоги
- [ ] **Указатели** — ищи `SignDirectional`. Критично для ориентирования к отделам, эвакуации и т. д. Режим `AlignDirectionalSign` в панели спауна выравнивает их
- [ ] **Настенные таблички** — ищи `Sign`. Делают стены менее скучными и помогают найти отделы
- [ ] **Банкомат** — `ATM`. Должен быть **легко** найден. Нужен для покупок в автоматах
- [ ] **Автоматы** — `RandomVending` [Any], `RandomVendingClothing`, `RandomVendingDrinks`, `RandomVendingSnacks`. **Отличный способ заполнить пространство.** Смешивай ручную расстановку и случайные спаунеры
- [ ] **Стулья** — ищи `chair`. Люди любят сидеть
- [ ] **Скамьи** — ищи `bench`. Люди любят зависать на скамьях
- [ ] **Столы** — ищи `table`. Есть без стола плохо. Ставь столы, пожалуйста
- [ ] **Случайные плакаты** — `RandomPosterLegit`, `RandomPosterAny`, `RandomPosterContraband`. В большинстве общественных мест используй `RandomPosterLegit`, добавляй остальные в «тёмных» местах
- [ ] **Освещение** — `Poweredlight`, `PoweredSmallLight`. **Стремись к сбалансированному свету.** В маленькой комнате 1-2 лампы, в большой редко больше 4. Не ставь больше двух ламп рядом: от избытка света мерцают тени
- [ ] **Аварийное освещение** — `EmergencyLight`. Включается по уровню тревоги. Не в каждой комнате, но по коридорам можно ориентироваться при аварийном свете
- [ ] **Утилизатор (disposal unit)** — `DisposalUnit`. Для мусора
- [ ] **Камеры** — `SurveillanceCameraGeneral`. В общих коридорах, где ИИ и СБ имеет смысл видеть. Не ставь в приватных зонах (туалеты, общежитие), чтобы у антагонистов были места для планов

### Техтоннели (Maintenance)

- [ ] **Топливный бак** — `WeldingFuelTankFull`. Разбросать
- [ ] **Бак с водой** — `WaterTankFull`. Разбросать
- [ ] **Переносной генератор J.R.P.A.C.M.A.N.** — `PortableGeneratorJrPacman`. Работает на топливе для сварки. Экипаж ищет его при отключении питания
- [ ] **Шкаф техтоннеля** — `ClosetMaintenanceFilledRandom`. Даёт пресловутый «лут техтоннелей»
- [ ] **Шкаф сварочных принадлежностей** — `LockerWeldingSuppliesFilled`. Разбросать
- [ ] **Аварийный шкаф** — `ClosetEmergencyFilledRandom`. O2, разбросать
- [ ] **Аварийный шкаф с азотом** — `ClosetEmergencyN2FilledRandom`. N2, разбросать
- [ ] **Пожарный шкаф** — `ClosetFireFilled`. Пожарная безопасность, разбросать
- [ ] **Баллон кислорода** — `OxygenCanister`. Разбросать
- [ ] **Баллон азота** — `NitrogenCanister`. Разбросать
- [ ] **Шкафчик ремонта эвакуации** — `LockerEvacRepairFilled`. Разбросать
- [ ] **Шкафчик электрических принадлежностей** — `LockerElectricalSuppliesFilled`. Разбросать
- [ ] **Ящик с инструментами** — ищи `toolbox`. Разбросать, смешивать
- [ ] **«Лут техтоннелей»** — ищи `loot`. **Много** вариантов. Хорошо ставить спаунеры на `Rack` и `Table`
- [ ] **Технические комнаты**. В техтоннелях должны быть комнаты в разной степени разрухи и интересные находки. Проявляй фантазию
- [ ] **Маркер интерьера техтоннеля** — `MaintsRoomMarker`. Генерирует случайную комнату 5x5. Для разнообразия и чтобы заполнить пустое место

### Прибытие (Arrivals)

- [ ] **Табличка «Прибытие»** — `SignArrivals`. Вывески критичны
- [ ] **Точка позднего входа [Job Spawn]** — `SpawnPointLatejoin`. Ставь по одной у каждой стыковочной двери прибытия. Это защита, чтобы новичков не размазало шаттлом. Вне зоны прибытия не ставь
- [ ] **Внешний шлюз [External, Arrivals, Glass, Docking]** — `AirlockExternalGlassShuttleArrivals`. Используй **только** на прибытии. Шаттл стремится стыковаться именно с ними. Если не получилось (заблокированы или разрушены), стыкуется с другим свободным шлюзом станции, а если не выйдет, то с ATS
- [ ] **Направленный вентилятор** — `AtmosDeviceFanDirectional`. Под каждым внешним шлюзом, смотрящим в космос
- [ ] **Экран прибытия** — `ArrivalsShuttleTimer`. Показывает, сколько до стыковки. Хорошо по одному на внешнюю дверь
- [ ] **Аварийный шкаф** — `ClosetEmergencyFilledRandom`. Прибытие часто разгерметизировано
- [ ] **Аварийный шкаф с азотом** — `ClosetEmergencyN2FilledRandom`

### Эвакуация (Evac)

- [ ] **Шлюз дока** — `AirlockExternalGlassShuttleEmergencyLocked`. Стандартная схема ниже, можно использовать свои шаттлы эвакуации
- [ ] **Шлюз** — `AirlockExternalGlass`. По одному на каждый док
- [ ] **Направленный вентилятор** — `AtmosDeviceFanDirectional`. По одному под каждым, лицом в космос
- [ ] **Экран** — `Screen`. Минимум один на док
- [ ] **Места для сидения**

### Менеджер ассистентов

- [ ] **Спаун менеджера ассистентов** — `SpawnPointAssistantManager`. Снаружи **кабинета HOP** или снаружи **общежития**

### Криосон

- [ ] **Криокапсула** — `CryogenicSleepUnit`, `CryogenicSleepUnitSpawnerLateJoin`. Минимум по 2 каждого. **Не** используй `CryogenicSleepUnitSpawner`, только пустую капсулу и капсулу позднего входа. Тот вариант работает как точка спауна работ и заставит людей стартовать в криосне

### Общежитие (Dorms)

- [ ] **Кровать с простынёй** — `Bed`. Лучше случайная простыня
- [ ] **Стол** — `Table`, `TableWood`
- [ ] **Комод** — `DresserFilled`
- [ ] **Кнопка запирания двери** — `SignalButtonDirectional`. Не в казармах
- [ ] **Шторы на окнах**
- [ ] **ClothesMate**. В комнате или рядом

### Санузел

- [ ] **Унитаз** — `ToiletDirtyWater`. В них можно прятать вещи
- [ ] **Кнопка запирания кабинок** — `SignalButtonDirectional`
- [ ] **Раковина** — `SinkWide`
- [ ] **Зеркало** — `MirrorModern`, `Mirror`. На стене над каждой раковиной

### Инструментальная

- [ ] **YouTool** — `VendingMachineYouTool`
- [ ] **Зарядник батарей** — `PowerCellRecharger`
- [ ] **Vendomat** — `VendingMachineVendomat`. Необязательно
- [ ] **Ящики с инструментами** — `ToolboxElectricalFilled`, `ToolboxMechanicalFilled`
- [ ] **Топливо для сварки** — `WeldingFuelTankFull`

### Автоматы

- [ ] **ClothesMate** — `VendingMachineClothing`. В общежитии или рядом
- [ ] **Good Clean Fun** — `VendingMachineGames`. Рядом с общедоступным местом (общежитие, библиотека)
- [ ] **WinterDrobe** — `VendingMachineWinter`
- [ ] **Раздатчик объятий** — `SLVendingMachineHugDispenser`. Рядом с банкоматом
- [ ] **Fashion-o-Mat** — `SLVendingMachineFashion`. Рядом с банкоматом
- [ ] **Любые автоматы еды**
- [ ] **Любые автоматы напитков**

### Вся станция

- [ ] **Свет** — `Poweredlight`, `PoweredSmallLight`. На тесте станция должна быть полностью освещена, но не слишком ярко. Тёплый свет только в спальнях
- [ ] **Аварийное освещение** — `EmergencyLight`. По одному на лампу, перекрытие допустимо
- [ ] **Сеть труб распределения**. `#0055CCFF`, соединена с вентиляциями
- [ ] **Вентиляция** — `GasVentPump`. Подключена к воздушной тревоге комнаты и к сети распределения. Пассивные вентиляции не используй
- [ ] **Сеть труб отходов**. `#990000FF`, соединена со скрубберами
- [ ] **Скруббер** — `GasVentScrubber`. Подключён к воздушной тревоге комнаты и к сети отходов
- [ ] **Датчик воздуха** — `AirSensor`. Подключён к воздушной тревоге комнаты
- [ ] **Пожарная тревога** — `FireAlarm`. Подключена ко всем пожарным шлюзам и датчикам воздуха комнаты
- [ ] **Пожарный шлюз** — `FirelockGlass`. Подключён к воздушной тревоге обеих соседних комнат. Разделяет коридоры на управляемые секторы, закрывает все входы в техтоннели, стойки и границы отделов. Лучше стеклянные
- [ ] **Воздушная тревога** — `AirAlarm`. Одна на комнату, подключена ко всем пожарным шлюзам, вентиляциям, скрубберам и датчикам комнаты
- [ ] **Подстанция** — `SubstationBasic`. Подключена HV-кабелем напрямую к банку SMES инженерии. Обычно в техтоннелях. Минимум 1-2 на отдел, на больших станциях 2-3
- [ ] **APC** — `APCBasic`. Один на комнату, подключён MV-кабелем к ближайшей подстанции отдела. LV должен доставать до всего в комнате и не создавать петель. Почти всегда используй базовый APC
- [ ] **Утилизатор** — `DisposalUnit`. В каждом отделе минимум несколько, доступных всем сотрудникам, на одном тайле с трубой утилизации
- [ ] **Сеть утилизации**. Направляет весь мусор в утилизаторы. Подробнее в сервисе
- [ ] **Маяки станции**. Читаются картой станции. Названия понятные, не дурацкие. Все места, связанные с работой, должны иметь маяк
- [ ] **Камеры**. Оверлей ИИ должен видеть ~85% станции
- [ ] **Мусор**. Зависит от желаемой грязности, но хоть немного
- [ ] **Грязь (cleanable)**. То же
- [ ] **Голопад**. Почти в любой комнате может быть голопад
- [ ] **NanoMed band-aid** — `VendingMachineWallMedicalCivilian`. Разбросать. Рядом с эвакуацией, боксёрскими рингами и т. д.

## Инженерия

Подробно: [Инженерия](https://wiki.lost-paradise.space/ru/mapping/stations/engineering).

### Помещения

- [ ] Кабинет CE
- [ ] Раздевалка инженеров
- [ ] Раздевалка атмосников (иногда общая с инженерами)
- [ ] Стойка инженерии
- [ ] Стойка атмоса
- [ ] Банк батарей SMES
- [ ] Комната AME
- [ ] Главная двигательная (где вырабатывается основная энергия)
- [ ] Гравитация
- [ ] Якорь
- [ ] Атмос
- [ ] Хранилище баллонов (иногда часть атмоса)
- [ ] Телекомы (иногда серверы ставят в кабинеты глав)
- [ ] Комната роутеров камер (иногда в телекомах или ядре ИИ)
- [ ] Солнечные панели

### Главный двигатель

- [ ] Сингулярность
- [ ] Тесла
- [ ] Суперматерия
- [ ] TEG

### Общее для инженерии

- [ ] **Техфаб инженерии** — `EngineeringTechFab`. Обязательно
- [ ] **Компьютер заказов инженерии** — `ComputerCargoOrdersEngineering`
- [ ] **YouTool** — `VendingMachineYouTool`
- [ ] **Engi-Vend** — `VendingMachineEngivend`. **НЕ** в одной зоне со стойкой
- [ ] **Engi Dispenser** — `SLVendingMachineEngi`
- [ ] **Генераторы PACMAN** — `PortableGeneratorPacman`, `PortableGeneratorSuperPacman`, `PortableGeneratorJrPacman`. Минимум: 1 super, 2 обычных, 2 jr
- [ ] **Раздатчик топлива** — `FuelDispenser`. Баланс сомнительный, на каждой станции не ставь
- [ ] **Топливные баки** — `WeldingFuelTankFull`
- [ ] **Материальный силос** — `MachineMaterialSilo`
- [ ] **Автолат** — `Autolathe`
- [ ] **Шкафы радиационных костюмов** — `ClosetRadiationSuitFilled`. Минимум 2, больше на станциях с SM или сингулярностью
- [ ] **Материалы** — `SheetSteel`, `SheetPlasma`, `SheetPlastic`, `SheetGlass`. Возможно в хранилище материалов, обычно по 30-90 каждого
- [ ] **Зарядник батарей** — `PowerCellRecharger`

### Кабинет и каюта CE

- [ ] **Консоль связи инженерии** — `ComputerCommsEngineering`. Обязательно
- [ ] **Факс** — `FaxMachineBase`. Название «CE»
- [ ] **Спаун Полли** — `SpawnMobPollyParrot`. Необязательно
- [ ] **Кровать с простынёй CE** — `Bed`, `BedsheetCE`
- [ ] **Комод** — `DresserChiefEngineerFilled`
- [ ] **Шкафчик главного инженера** — `LockerChiefEngineerFilled`
- [ ] **Хранилище скафандра** — `SuitStorageCE`
- [ ] **Усиленная стена** — `WallReinforced`
- [ ] **Шлюзы CE** — `AirlockChiefEngineerGlassLocked`, `AirlockChiefEngineerLocked`
- [ ] **Спаун главного инженера** — `SpawnPointChiefEngineer`
- [ ] **Монитор питания** — `ComputerPowerMonitoring`

### Необязательные компьютеры в кабинете CE

- [ ] **Компьютер солнечных панелей** — `ComputerSolarControl`
- [ ] **Компьютер тревог атмосферы** — `ComputerAlert`
- [ ] **Монитор сети атмосферы** — `ComputerAtmosMonitoring`

### AME

- [ ] **Контроллер AME** — `AmeController`. Должен быть на HV, считается генератором и должен питать банк SMES, **не** тот, что в ящике
- [ ] **Ящик с упакованным антиматерийным реактором** — `CrateEngineeringAMEShielding`, `AmePartFlatpack`. По умолчанию 9 деталей, это одно ядро. Добавь ещё в ящик. AME вместе со стартовым банком SMES должны питать станцию ~10 минут
- [ ] **Ящик с банками антиматерии** — `CrateEngineeringAMEJar`, `AmeJar`. На очень больших станциях добавь несколько

### Техническое хранилище

- [ ] **Ящик аварийного перезапуска** — `CrateEmergencyRestart`

### Гравитация

- [ ] **Генератор гравитации** — `GravityGenerator`

### Телекомы

- [ ] **Телекоммуникационный сервер** — `TelecomServerFilledLaw`, `TelecomServerFilledService`, `TelecomServerFilledCommand`, `TelecomServerFilledScience`, `TelecomServerFilledSecurity`, `TelecomServerFilledEngineering`, `TelecomServerFilledCommon`, `TelecomServerFilledMedical`, `TelecomServerFilledCargo`, `TelecomServerFilled`. Всего 9. На очень малых станциях можно один «общий»
- [ ] **Шлюз** — `AirlockChiefEngineerGlassLocked`, `AirlockCommandGlassLocked`. Шлюз CE, если в инженерии

### Роутеры камер

- [ ] **Роутер камер** — `SurveillanceCameraWirelessRouterEntertainment`, `SurveillanceCameraRouterConstructed`, `SurveillanceCameraWirelessRouterConstructed`, `SurveillanceCameraRouterService`, `SurveillanceCameraRouterCommand`, `SurveillanceCameraRouterScience`, `SurveillanceCameraRouterSecurity`, `SurveillanceCameraRouterEngineering`, `SurveillanceCameraRouterGeneral`, `SurveillanceCameraRouterMedical`, `SurveillanceCameraRouterSupply`. Всего 11. Развлекательный можно поставить в/около репортёра
- [ ] **Шлюз** — `AirlockCommandGlassLocked`, `AirlockChiefEngineerGlassLocked`, `AirlockHeadOfSecurityGlassLocked`. CE, если в инженерии. Иногда в СБ, тогда шлюз HoS

### SMES

- [ ] **SMES** — `SMESAdvanced`, `SMESBasic`. Продвинутый или обычный. Столько, чтобы на старте раунда запитать всю станцию минимум на 5 минут

### Стойка

- [ ] **Факс** — `FaxMachineBase`. Название «Engineering»
- [ ] **Монитор питания** — `ComputerPowerMonitoring`
- [ ] **Стойка** — `TableReinforced`
- [ ] **Принтер документов** — `PrinterDoc`
- [ ] **Защищённое окно-дверь** — `WindoorSecureEngineeringLocked`

### Раздевалка

- [ ] **Шкафчики инженеров** — `LockerEngineerFilled`. По одному на каждое место инженера
- [ ] **Хранилище скафандра** — `SuitStorageEngi`. По одному на каждое место инженера
- [ ] **Спаун инженера** — `SpawnPointStationEngineer`. Минимум по одному на каждое стартовое место
- [ ] **Спаун технического ассистента** — `SpawnPointTechnicalAssistant`. Минимум по одному на каждое стартовое место
- [ ] **EngiDrobe** — `VendingMachineEngiDrobe`

### TEG

- [ ] **Холодный контур**. Цвет `#087CA7FF`
- [ ] **Горячий контур**. Цвет `#EF6F6CFF`
- [ ] **Камера сгорания** — `ReinforcedPlasmaWindow`. Цвет `#947507FF`. Нужен инжектор и какая-то защита от переопрессовки
- [ ] **TEG** — `TegCirculator`, `TegCenter`. Два циркулятора и один генератор. Генератор должен быть на HV

### Суперматерия

- [ ] **Суперматерия** — `SupermatterCrystal`
- [ ] **Радиационно-стойкая камера** — `ReinforcedUraniumWindow`. Стандарт: радиационные заслонки, усиленные стены и усиленное урановое стекло
- [ ] **Радиационный коллектор** — `RadiationCollectorFullTank`. Считается генератором, должен быть на HV. 3-6 штук
- [ ] **Катушка тесла** — `TeslaCoil`. Считается генератором, должна быть на HV. 2-4 штуки
- [ ] **Заземляющий стержень** — `TeslaGroundingRod`. 2-4
- [ ] **Охлаждающий контур**
- [ ] **Какой-либо аварийный сброс**. Много вариантов
- [ ] **Эмиттер** — `Emitter`. Направлен на отражатели. Максимум 2-6
- [ ] **Отражатель** — `Reflector`. Направлен на SM. *Лучи эмиттера глючат, если их быстро отражать и менять направление, поэтому избегай схем, где луч поворачивается больше одного раза*
- [ ] **Раздатчик баллонов** — `VendingMachineTankDispenserEngineering`. Плазма + O2

### Солнечные панели

- [ ] **Солнечная панель** — `SolarPanel`. По 750 Вт. На HV → клеммник
- [ ] **Солнечный трекер** — `SolarTracker`. На HV → клеммник
- [ ] **Клеммник** — `CableTerminal`. HV → SMES
- [ ] **SMES** — `SMESBasic`
- [ ] **Компьютер солнечных панелей** — `ComputerSolarControl`
- [ ] **Хранилище скафандра** — `SuitStorageEngi`. Необязательно
- [ ] **Шлюз инженерии** — `AirlockEngineeringLocked`

### Управление PA (ускоритель частиц)

- [ ] **Левый эмиттер PA** — `ParticleAcceleratorEmitterPortUnfinished`. Слева
- [ ] **Передний эмиттер PA** — `ParticleAcceleratorEmitterForeUnfinished`. По центру, выровнен и направлен на сингулярность или тесла-генератор
- [ ] **Правый эмиттер PA** — `ParticleAcceleratorEmitterStarboardUnfinished`. Справа
- [ ] **Блок питания PA** — `ParticleAcceleratorPowerBoxUnfinished`. На MV
- [ ] **Топливная камера PA** — `ParticleAcceleratorFuelChamberUnfinished`
- [ ] **Крышка PA** — `ParticleAcceleratorEndCapUnfinished`
- [ ] **Компьютер управления PA** — `ParticleAcceleratorControlBoxUnfinished`

### Сингулярность

- [ ] **Генератор силового поля** — `ContainmentFieldGenerator`. 4 шт., квадрат, обычно 9x9
- [ ] **Эмиттер** — `Emitter`. 4 шт., направлены на генератор поля, на MV
- [ ] **Радиационные коллекторы** — `RadiationCollectorFullTank`. 6 шт. Считаются генератором, должны быть на HV. Число зависит от размера станции
- [ ] **Генератор гравитационной сингулярности** — `SingularityGenerator`. В центре квадрата
- [ ] **Резервное питание**. Коллекторы идут в клеммник → SMES → подстанцию, питающую эмиттеры. Также она питает главный банк. Нельзя перерезать вне зоны сингулярности/PA

### Тесла

- [ ] **Генератор силового поля** — `ContainmentFieldGenerator`. 4 шт., квадрат, обычно 3x3
- [ ] **Эмиттер** — `Emitter`. 4 шт., направлены на генератор поля, на MV
- [ ] **Катушка тесла** — `TeslaCoil`. 4 шт. Считается генератором, должна быть на HV
- [ ] **Заземляющий стержень** — `TeslaGroundingRod`. 4 **обязательны**: любая схема менее чем с 4 стержнями **всегда** проиграет
- [ ] **Тесла-генератор** — `TeslaGenerator`. В центре квадрата
- [ ] **Резервное питание**. Катушки идут в клеммник → SMES → подстанцию, питающую эмиттеры. Также она питает главный банк. Нельзя перерезать вне зоны теслы/PA

### Якорь

- [ ] **Якорь станции** — `StationAnchor`

### Подстанции

- [ ] **Базовая подстанция** — `SubstationBasic`. Минимум одна на отдел, обычно две
- [ ] **Усиленные стены** — `WallReinforced`
- [ ] **Шлюз** — `AirlockEngineeringLocked`. Инженерия

### Атмос

- [ ] **Монитор сети атмосферы** — `ComputerAtmosMonitoring`
- [ ] **Компьютер тревог атмосферы** — `ComputerAlert`
- [ ] **N2-майнер** — `GasMinerNitrogenStationLarge`. Обычно для больших станций. Подключён к смесителю для хранения воздуха (в комнате должен быть N2 atmosfix)
- [ ] **O2-майнер** — `GasMinerOxygenStationLarge`. Обычно для больших станций. Подключён к смесителю (в комнате должен быть O2 atmosfix)
- [ ] **Хранилище воздуха**. Минимум буфер для наполнения баллонов, но может быть целым баком, как у майнеров (если есть место, используй вакуум или маркер atmos fix воздуха)
- [ ] **Хранилище плазмы**. Комната, заполненная плазмой (atmosfix)
- [ ] **Сборщики отходов**. Число и тип на усмотрение маппера. **НЕ СТАВЬ** майнеры трития, плазмы, закиси азота и фрезона. Майнеры CO2 и водяного пара можно. Вакуумный atmosfix для всех, кроме плазмы
- [ ] **Усиленные стены** — `WallReinforced`. Любые майнеры и хранилища газа, по которым могут попасть обломки, требуют дополнительной защиты
- [ ] **Переносные скрубберы** — `PortableScrubber`. 2+. В сети отходов должно быть куда их подключить
- [ ] **Охладители/нагреватели** — `GasThermoMachineFreezer`, `GasThermoMachineHeater`. Около 6 всего. По одному каждого можно подключить к хранилищу воздуха или к распределению на старте. Тогда не дай им «воевать»: нагреватель низко, охладитель высоко, разница минимум 2 K

### Раздевалка атмоса

- [ ] **Шкафчики атмосника** — `LockerAtmosphericsFilled`. По одному на каждое место
- [ ] **Хранилище скафандра** — `SuitStorageAtmos`. По одному на каждое место
- [ ] **Спаун атмосника** — `SpawnPointAtmos`. Минимум по одному на каждое стартовое место
- [ ] **AtmosDrobe** — `VendingMachineAtmosDrobe`
- [ ] **Усиленные стены** — `WallReinforced`

### Стойка атмоса

- [ ] **Стойка** — `TableReinforced`
- [ ] **Факс** — `FaxMachineBase`. Название «Atmos»
- [ ] **Усиленные стены** — `WallReinforced`
- [ ] **Защищённое окно-дверь** — `WindoorSecureAtmosphericsLocked`

### Хранилище баллонов

- [ ] **Баллон плазмы** — `PlasmaCanister`. 2-6, зависит от размера станции и двигателей
- [ ] **Баллон воздуха** — `AirCanister`. 2+
- [ ] **Баллон N2** — `NitrogenCanister`. 2+
- [ ] **Баллон O2** — `OxygenCanister`. 2+
- [ ] **Баллон хранения** — `StorageCanister`. 2+
- [ ] **Разные баллоны** — `WaterVaporCanister`, `AmmoniaCanister`, `CarbonDioxideCanister`, `NitrousOxideCanister`. Баллоны N2O, водяного пара, аммиака и CO2 необязательны. Без жидких баллонов, без трития и фрезона. Максимум один N2O
- [ ] **Усиленные стены** — `WallReinforced`

### Общежитие или казарма

- [ ] **Кровать с простынёй** — `Bed`. Лучше случайная простыня
- [ ] **Стол** — `Table`, `TableWood`
- [ ] **Комод** — `DresserFilled`
- [ ] **Кнопка запирания двери** — `SignalButtonDirectional`. Не в казармах
- [ ] **Шторы на окнах**

## Медицина

Подробно: [Медицина](https://wiki.lost-paradise.space/ru/mapping/stations/medical).

### Помещения

- [ ] Кабинет CMO
- [ ] Раздевалка медиков
- [ ] Стойка / регистратура / зал ожидания
- [ ] Медбей
- [ ] Крионика (криокапсулы), иногда часть медбея
- [ ] Химия
- [ ] Хирургия
- [ ] Морг
- [ ] Психология
- [ ] Комната парамедиков
- [ ] Вирусология
- [ ] Генетика

### Кабинет CMO

- [ ] **Консоль связи медицины** — `ComputerCommsMedical`. Обязательно
- [ ] **Факс** — `FaxMachineBase`. Название «CMO»
- [ ] **Спаун случайной кошки** — `SpawnMobCat`. Необязательно
- [ ] **Кровать с простынёй CMO** — `Bed`, `BedsheetCMO`
- [ ] **Комод** — `DresserChiefMedicalOfficerFilled`
- [ ] **Шкафчик** — `LockerChiefMedicalOfficerFilled`
- [ ] **Хранилище скафандра** — `SuitStorageCMO`
- [ ] **Шлюзы CMO** — `AirlockChiefMedicalOfficerGlassLocked`, `AirlockChiefMedicalOfficerLocked`
- [ ] **Спаун CMO** — `SpawnPointChiefMedicalOfficer`
- [ ] **Компьютер медицинских записей** — `ComputerMedicalRecords`
- [ ] **Усиленные стены** — `WallReinforced`

### Раздевалка медиков

- [ ] **Шкафчик врача** — `LockerMedicalFilled`. По одному на каждое место врача
- [ ] **Спаун врача** — `SpawnPointMedicalDoctor`
- [ ] **Спаун интерна** — `SpawnPointMedicalIntern`

### Комната парамедиков

- [ ] **Шкафчик парамедика** — `LockerParamedicFilled`. По одному на каждое место
- [ ] **Спаун парамедика** — `SpawnPointParamedic`
- [ ] **Консоль мониторинга экипажа** — `ComputerCrewMonitoring`
- [ ] **Каталка** — `RollerBedSpawnFolded`, `EmergencyRollerBedSpawnFolded`, `CheapRollerBedSpawnFolded`. По одной на каждое место парамедика

### Стойка

- [ ] **Факс** — `FaxMachineBase`. Название «Medical»
- [ ] **Компьютер медицинских записей** — `ComputerMedicalRecords`
- [ ] **Консоль мониторинга экипажа** — `ComputerCrewMonitoring`
- [ ] **Стойка** — `TableReinforced`
- [ ] **Принтер документов** — `PrinterDoc`
- [ ] **Защищённое окно-дверь** — `WindoorSecureMedicalLocked`

### Медбей

- [ ] **Медицинский техфаб** — `EngineeringTechFab`. Обязательно
- [ ] **Шкаф с лекарствами** — `LockerMedicineFilled`. Минимум один
- [ ] **Медкровать с медпростынёй** — `MedicalBed`, `BedsheetMedical`. Столько, чтобы кровать была примерно на 1/20 ожидаемого экипажа
- [ ] **Стазис-кровать** — `StasisBed`. Минимум 1, около 1 на каждые 4 медкровати
- [ ] **NanoMed Plus** — `VendingMachineMedical`
- [ ] **SmartFridge [Medical]** — `SmartFridgeMedical`

### Крионика

- [ ] **Криокапсула** — `CryoPod`. 1 на малых станциях, 2 на больших
- [ ] **Охладитель газа** — `GasThermoMachineFreezer`. 140 K
- [ ] **Мензурка с криоксадоном** — `CryoxadoneBeakerSmall`
- [ ] **Газоанализатор** — `GasAnalyzer`
- [ ] **Рабочая газовая система**. Фильтр зависит от того, кто в капсуле (фильтр отходов)

### Хирургия

- [ ] **Операционный стол** — `OperatingTable`. Связан с операционным компьютером
- [ ] **Операционный компьютер** — `computerBodyScanner`. Связан со столом
- [ ] **Баллон закиси азота** — `NitrousOxideTankFilled`
- [ ] **Ящик хирургических принадлежностей** — `CrateMedicalSurgery`
- [ ] **Морозильник** — `CrateFreezer`
- [ ] **Шлюзы хирурга** — `AirlockSurgeryLocked`. По возможности
- [ ] **Слив** — `FloorDrain`
- [ ] **Спаун хирурга** — `SpawnPointSurgeon`

### Морг

- [ ] **Морг** — `Morgue`. Примерно вдвое больше числа медкроватей
- [ ] **Коробка мешков для тел** — `BoxBodyBag`

### Химия

- [ ] **ChemVend** — `VendingMachineChemicals`
- [ ] **Шкафчик химика** — `LockerChemistryFilled`
- [ ] **Зарядник батарей** — `PowerCellRecharger`
- [ ] **Измельчитель реагентов** — `KitchenReagentGrinder`. 1 на химика
- [ ] **Плитка** — `ChemistryHotplate`. 1 на химика
- [ ] **Настольная центрифуга** — `MachineCentrifuge`
- [ ] **Электролизёр** — `MachineElectrolysisUnit`
- [ ] **ChemDrobe** — `VendingMachineChemDrobe`
- [ ] **Раздатчик реагентов** — `ChemDispenser`. 1 на химика
- [ ] **ChemMaster 4000** — `ChemMaster`. 1 на химика
- [ ] **Слив** — `FloorDrain`
- [ ] **Спаун химика** — `SpawnPointChemist`
- [ ] **Усиленная стена** — `WallReinforced`

### Стойка химии

- [ ] **Факс** — `FaxMachineBase`. Название «Chemistry»
- [ ] **Стойка** — `TableReinforced`
- [ ] **Принтер документов** — `PrinterDoc`
- [ ] **Защищённое окно-дверь** — `WindoorSecureChemistryLocked`

### Вирусология

- [ ] **Табличка вирусологии** — `SignVirology`. **Таблички обязательны**
- [ ] **Шкаф биозащиты 3 уровня** — `ClosetL3VirologyFilled`. По одному на место
- [ ] **Камеры содержания подопытных**. Минимум 2x3 каждая, минимум две камеры
- [ ] **Шлюзы вирусологии** — `AirlockVirologyLocked`, `AirlockVirologyGlassLocked`. Вход должен быть **шлюзом с болтами**
- [ ] **ViroDrobe** — `VendingMachineViroDrobe`
- [ ] **Голопад [Virology]** — `HolopadMedicalVirology`
- [ ] **Матрас / кровать / медкровать** — `Mattress`, `Bed`, `MedicalBed`. Место для сна подопытных
- [ ] **Вакцинатор** — `Vaccinator`. Пока декоративный
- [ ] **Disease Diagnoser Delta Extreme** — `DiseaseDiagnoser`. Пока декоративный
- [ ] **Настольная центрифуга** — `MachineCentrifuge`. Запасная, если разрушена в химии
- [ ] **Раковина** — `Sink`, `SinkWide`
- [ ] **Слив** — `FloorDrain`
- [ ] **Раздатчик стерильных тампонов** — `BoxMouthSwab`
- [ ] **Коробка стерильных масок** — `BoxSterileMask`
- [ ] **Защищённое окно-дверь [Medical, Locked]** — `WindoorSecureMedicalLocked`. Для камер содержания

## Персонал NT

Подробно: [Персонал NT](https://wiki.lost-paradise.space/ru/mapping/stations/nt-staff).

### Помещения

- [ ] Кабинет NTR
- [ ] Кабинет BSO
- [ ] Кабинет магистрата
- [ ] Зал суда
- [ ] Кабинет IAA
- [ ] Кабинет NCT

### Кабинет NTR

- [ ] **Спаун NTR [Job Spawn]** — `SpawnPointNtrep`. В кабинете NTR или на мостике
- [ ] **Факс [NT: NTR]** — `FaxMachineNTRep`. Если есть кабинет
- [ ] **Маяк станции [NanoTrasen Representative]** — `DefaultStationBeaconNTR`. Если есть кабинет
- [ ] **Шлюз / стеклянный шлюз / техдоступ [NanoTrasen, Locked]** — `AirlockNTLocked`, `AirlockNTGlassLocked`, `AirlockMaintNTLocked`. Двери NT. Двери командования не использовать
- [ ] **Шкафчик представителя [Filled]** — `LockerRepresentativeFilled`. NTR
- [ ] **Стены и окна** — `WallReinforced`, `ReinforcedWindow`. Периметр прочный, внутренние могут быть слабее

### Кабинет BSO

- [ ] **Спаун BSO [Job Spawn]** — `SpawnPointBlueShield`. В кабинете BSO или на мостике
- [ ] **Факс [NT: BSO]** — `FaxMachineNTBlueshield`. Если есть кабинет
- [ ] **Маяк станции [Blueshield Officer]** — `DefaultStationBeaconBSO`. Если есть кабинет
- [ ] **Шлюз / стеклянный шлюз / техдоступ [NanoTrasen, Locked]** — `AirlockNTLocked`, `AirlockNTGlassLocked`, `AirlockMaintNTLocked`. Двери NT. Двери командования не использовать
- [ ] **Шкафчик офицера Blueshield [Filled]** — `LockerBlueshieldFilled`. В идеале в кабинете BSO
- [ ] **Хранилище скафандра [Blueshield]** — `SuitStorageBlueShield`. В идеале в кабинете BSO
- [ ] **Стены и окна** — `WallReinforced`, `ReinforcedWindow`. Периметр прочный

### Кабинет магистрата

- [ ] **Спаун магистрата [Job Spawn]** — `SpawnPointMagistrate`. В его кабинете, можно в кабинете IAA. На мостик только в крайнем случае
- [ ] **Факс [NT: Magi]** — `FaxMachineNTMagi`. Если есть кабинет
- [ ] **Шлюз / стеклянный шлюз / техдоступ [NanoTrasen, Locked]** — `AirlockNTLocked`, `AirlockNTGlassLocked`, `AirlockMaintNTLocked`. Двери NT, если даёшь кабинет. Но зал суда всё равно с дверьми зала суда!
- [ ] **Телеком-сервер [Law]** — `TelecomServerFilledLaw`. По возможности в телекомах, иначе в кабинете IAA
- [ ] **Шкафчик магистрата [Filled]** — `LockerMagistrateFilled`. Один
- [ ] **Стены и окна** — `WallReinforced`, `ReinforcedWindow`. Периметр прочный

### Зал суда

- [ ] **Спаун магистрата [Job Spawn]** — `SpawnPointMagistrate`. В его комнате или в зале суда
- [ ] **Шкафчик магистрата [Filled]** — `LockerMagistrateFilled`. В его комнате или в зале суда
- [ ] **Табличка «Закон»** — `SignLawyer`. Обязательно
- [ ] **Маяк станции [Courtroom]** — `DefaultStationBeaconCourtroom`. Обязательно
- [ ] **Молоток судьи** — `GavelHammer`. Чем стучать
- [ ] **Подставка** — `GavelBlock`. По чему стучать
- [ ] **Судейская трибуна** — `Table`, `TableBrass`, `TableFancyBlack`. Место магистрата. Используй столы творчески, дерево и латунь выглядят «судебнее» всего, красивые столы тоже хороши
- [ ] **Обвинение и защита** — `Carpet`, `BoxFolderRedThreePapers`, `CarpetBlue`, `BoxFolderBlueThreePapers`. Обвинение **красное**, защита **синяя**. Ковры и декали отлично показывают, кто где сидит
- [ ] **Зрительская галерея** — `WoodenBench`, `Chair`. Скамьи, лавки, стулья. Не ставь направленные окна на тот же тайл, что и скамьи: это обычно отстёгивает людей от сидений
- [ ] **Место свидетеля / секретаря** — `ChairWood`. Необязательно. Подумай, где сидит секретарь и где стоят вызванные свидетели
- [ ] **Окна-двери и шлюзы** — `WindoorSecureCourtroomLocked`, `AirlockCourtroomLocked`, `AirlockMaintCourtroomLocked`. **Важно использовать версии `Courtroom`.** У них доступ `Security` для СБ, `InternalAffairs` для IAA/магистрата, `Legal` для юристов
- [ ] **Таймер-экран** — `ScreenTimer`. Судья ограничивает время речи
- [ ] **Голопад [Courtroom]** — `HolopadSecurityCourtroom`. Нужен для показаний ИИ
- [ ] **Факс** — `FaxMachineBase`. Отвёрткой задай название `Courtroom`. Для документов в последнюю минуту

### Кабинет IAA

- [ ] **Табличка «Внутренние дела»** — `SignIAA`. Вывески критичны
- [ ] **Спаун IAA [Job Spawn]** — `SpawnPointIAA`. Два, в кабинете IAA
- [ ] **Факс [NT: IAA]** — `FaxMachineNTInternalAffairs`. В кабинете IAA
- [ ] **Принтер документов** — `PrinterDoc`. Обязательно
- [ ] **Стопка бумаги** — `PaperBin10`, `PaperBin20`. Обязательно
- [ ] **Маяк станции [Internal Affairs]** — `DefaultStationBeaconIAA`. В кабинете IAA
- [ ] **LawDrobe** — `VendingMachineLawDrobe`. Требует доступ IAA. Не путать с LegalDrobe
- [ ] **Голопад [IAA]** — `HolopadSecurityInternalAffairs`. Чтобы IAA звонили людям
- [ ] **Телеком-сервер [Law]** — `TelecomServerFilledLaw`. По возможности в телекомах, иначе в кабинете IAA
- [ ] **Шкафчик IAA [Filled]** — `LockerIAAFilled`. По одному на IAA
- [ ] **Шлюзы** — `AirlockInternalAffairsLocked`, `AirlockInternalAffairsGlassLocked`, `AirlockMaintInternalAffairsLocked`. Используй правильные шлюзы. Если СБ или юрист не должны туда попадать, не используй шлюзы доступа [Security] или [Legal]. Двери NT не использовать
- [ ] **Декор** — `BookshelfFilled`, `filingCabinetDrawerRandom`, `filingCabinetRandom`, `Lamp`, `ChairOfficeDark`. Много вариантов
- [ ] **Стены и окна** — `WallReinforced`, `ReinforcedWindow`. Периметр прочный

## Наука

Подробно: [Наука](https://wiki.lost-paradise.space/ru/mapping/stations/science).

### Помещения

- [ ] Кабинет RD
- [ ] Раздевалка учёных
- [ ] Стойка / регистратура
- [ ] Аномалии
- [ ] Артефакты
- [ ] Хранилище баллонов (может быть частью артефактов)
- [ ] Робототехника
- [ ] Ксенобиология (пока не реализована)
- [ ] Серверная

### Исследования

- [ ] **Техфаб науки** — `ScienceTechFab`. **Заменяет** автолат и протолат!
- [ ] **Принтер плат** — `CircuitImprinter`
- [ ] **Материальный силос** — `MachineMaterialSilo`

### Кабинет и каюта RD

- [ ] **Консоль связи науки** — `ComputerCommsScience`. Обязательно
- [ ] **Факс** — `FaxMachineBase`. Название «RD»
- [ ] **Спаун Бандито** — `SpawnMobBandito`. Необязательно
- [ ] **Кровать с простынёй RD** — `Bed`, `BedsheetRD`
- [ ] **Комод** — `DresserResearchDirectorFilled`
- [ ] **Шкафчик директора исследований** — `LockerResearchDirectorFilled`
- [ ] **Хранилище скафандра** — `SuitStorageRD`
- [ ] **Усиленная стена** — `WallReinforced`
- [ ] **Шлюзы RD** — `AirlockResearchDirectorGlassLocked`, `AirlockResearchDirectorLocked`
- [ ] **Спаун RD** — `SpawnPointResearchDirector`
- [ ] **Консоль управления робототехникой** — `ComputerRoboticsControl`
- [ ] **Экспериментальный сварщик, силовая дрель** — `PowerDrill`, `WelderExperimental`. Необязательно

### Раздевалка

- [ ] **Шкафчик учёного** — `LockerScienceFilled`. По одному на каждое место учёного
- [ ] **Спаун учёного** — `SpawnPointScientist`. Минимум по одному на каждое стартовое место
- [ ] **Спаун научного ассистента** — `SpawnPointResearchAssistant`. Минимум по одному на каждое стартовое место
- [ ] **SciDrobe** — `VendingMachineSciDrobe`

### Серверная

- [ ] **Компьютер R&D** — `ComputerResearchAndDevelopment`
- [ ] **Сервер R&D** — `ResearchAndDevelopmentServer`
- [ ] **Терминал дисков технологий** — `ComputerTechnologyDiskTerminal`

### Стойка

- [ ] **Факс** — `FaxMachineBase`. Название «Science»
- [ ] **Компьютер R&D** — `ComputerResearchAndDevelopment`
- [ ] **Стойка** — `TableReinforced`
- [ ] **Принтер документов** — `PrinterDoc`
- [ ] **Защищённое окно-дверь** — `WindoorSecureScienceLocked`

### Робототехника

- [ ] **Зарядная станция киборгов** — `BorgCharger`. 1 + (1/3 мест боргов), округлить вниз
- [ ] **Фабрикатор экзокостюмов** — `ExosuitFabricator`
- [ ] **Robotech Deluxe** — `VendingMachineRobotics`
- [ ] **Консоль управления робототехникой** — `ComputerRoboticsControl`. За дверью робототехники, необязательно
- [ ] **Спаун робототехника** — `SpawnPointRoboticist`
- [ ] **Гардероб робототехники** — `WardrobeRoboticsFilled`

### Ремонт IPC

- [ ] **Табличка «Робо-хирургия»** — `SignRoboSurgery`. Вывески критичны
- [ ] **Операционный стол** — `OperatingTable`. Косметика, но для атмосферы приятно
- [ ] **Зарядная станция киборгов** — `BorgCharger`. Заряжает IPC с севшими батареями
- [ ] **Умный сантехнический раздатчик** — `PlumbingSmartDispenser`. Если поставить рядом слив, можно перерабатывать масло, которое теряют IPC
- [ ] **Сантехнический слив** — `PlumbingDrain`. См. выше
- [ ] **Анализатор машин** — `HandheldMachineAnalyzer`. Как анализатор здоровья, но для машин
- [ ] **Робо-аптечка** — `MedkitRoboticFilled`. Сварочная маска, сварщик и расходники для ремонта IPC
- [ ] **Микроволновка** — `KitchenMicrowave`. Для масляных пакетов
- [ ] **Раздатчик топлива** — `FuelDispenser`. Для сварки. Если много места, можно полный бак
- [ ] **Катушка HV-кабеля** — `CableHVStack`. Лечит ожоги IPC
- [ ] **Масляный пакет** — `OilPack`. Восстанавливает «кровопотерю» IPC
- [ ] **Ставни** — `ShuttersNormal`. Необязательно, добавляет ощущение «гаража»

### Артефакты

- [ ] **Консоль анализа** — `ComputerAnalysisConsole`. Связана с анализатором артефактов в «камере артефактов»
- [ ] **Газоанализатор** — `GasAnalyzer`
- [ ] **Экспериментальные предметы**. 2-4. Многие предметы запускают узлы артефактов, примеры в таблице ниже
- [ ] **Баллон хранения** — `StorageCanister`
- [ ] **Контейнер артефактов** — `CrateArtifactContainer`. 1 на «камеру артефактов»
- [ ] **Усиленные стены** — `WallReinforced`

### Камера артефактов

- [ ] **Анализатор артефактов** — `MachineArtifactAnalyzer`. Связан с консолью анализа вне камеры. Должен быть хотя бы один спаунер/анализатор артефактов
- [ ] **Кнопка** — `SignalButtonDirectional`. Связана с переключением взрывной двери
- [ ] **Взрывная дверь** — `BlastDoorOpen`. Открывается в решётку
- [ ] **Вход газа**
- [ ] **Выход газа**
- [ ] **Датчик воздуха** — `AirSensor`. Связан с воздушной тревогой

### Экспериментальные предметы

- [ ] **Урановое копьё** — `SpearUranium`
- [ ] **Магнитные ботинки** — `ClothingShoesBootsMagSci`
- [ ] **Баллон плазмы** — `PlasmaCanister`
- [ ] **Баллон закиси азота** — `NitrousOxideCanister`
- [ ] **Пояс** — `ClothingBeltUtilityFilled`
- [ ] **Спаунер случайных инструментов** — `RandomInstruments`
- [ ] **Огнетушитель** — `FireExtinguisher`
- [ ] **Кубики обезьян/кобольдов** — `VariantCubeBox`

### Аномалии

- [ ] **Генератор аномалий** — `MachineAnomalyGenerator`
- [ ] **A.P.E.** — `MachineAPE`. 1 + (1 на каждые 50 ожидаемого максимума населения)
- [ ] **Сосуд для аномалий** — `MachineAnomalyVessel`. 1 + (1 на каждые 50)
- [ ] **Листы плазмы** — `SheetPlasma`. 30
- [ ] **Сканер аномалий** — `AnomalyScanner`

### Хранилище баллонов

- [ ] **Баллон плазмы** — `PlasmaCanister`. Максимум 1
- [ ] **Баллон аммиака** — `AmmoniaCanister`. Максимум 1
- [ ] **Баллон CO2** — `CarbonDioxideCanister`. Максимум 1
- [ ] **Баллон азота** — `NitrogenCanister`. 1 + (1 на каждые 50)
- [ ] **Баллон кислорода** — `OxygenCanister`. 1 + (1 на каждые 50)
- [ ] **Баллон закиси азота** — `NitrousOxideCanister`. Максимум 1
- [ ] **Баллон хранения** — `StorageCanister`. 1 + (1 на каждые 50)

### Ксенобиология

- [ ] **Табличка «Ксенобио»** — `SignXenobio`. **Таблички обязательны**
- [ ] **Шкаф биозащиты 3 уровня** — `ClosetL3ScienceFilled`. По одному на место
- [ ] **Камеры содержания**. Минимум 2x3 тайла, минимум две камеры
- [ ] **Компьютер** — `BaseComputer`. Декор
- [ ] **Каркас компьютера** — `ComputerFrame`. Декор
- [ ] **Сломанный компьютер** — `ComputerBroken`. Декор
- [ ] **Раковина** — `Sink`, `SinkWide`
- [ ] **Слив** — `FloorDrain`
- [ ] **Каркас машины [готов]** — `MachineFrame`. Декор
- [ ] **Каркас машины [не закончен]** — `UnfinishedMachineFrame`. Декор
- [ ] **Разрушенный каркас машины** — `MachineFrameDestroyed`. Декор
- [ ] **Настольная центрифуга** — `MachineCentrifuge`. Запасная, если разрушена в химии
- [ ] **Электролизёр** — `MachineElectrolysisUnit`
- [ ] **Измельчитель реагентов** — `KitchenReagentGrinder`
- [ ] **Защищённое окно-дверь [Science, Locked]** — `WindoorSecureScienceLocked`. Для камер содержания
- [ ] **Взрывная дверь** — `BlastDoor`. Вместо окон-дверей
- [ ] **Деревянная баррикада** — `Barricade`, `BarricadeBlock`, `BarricadeDirectional`. Для заброшенного вида

### Общежитие или казарма

- [ ] **Кровать с простынёй** — `Bed`. Лучше случайная простыня
- [ ] **Стол** — `Table`, `TableWood`
- [ ] **Комод** — `DresserFilled`
- [ ] **Кнопка запирания двери** — `SignalButtonDirectional`. Не в казармах
- [ ] **Шторы на окнах**

## Служба безопасности

Подробно: [Служба безопасности](https://wiki.lost-paradise.space/ru/mapping/stations/security).

### Помещения

- [ ] Кабинет HOS
- [ ] Кабинет смотрителя (Warden)
- [ ] Раздевалка СБ
- [ ] Стойка
- [ ] Брик (Genpop)
- [ ] Обработка заключённых (сюда спаунятся дежурные офицеры)
- [ ] Бригмед
- [ ] Детектив
- [ ] Допросная
- [ ] Оружейная
- [ ] Одиночное заключение (обычно часть брика)

### Кабинет HOS

- [ ] **Консоль связи СБ** — `ComputerCommsSecurity`. Обязательно
- [ ] **Факс** — `FaxMachineBase`. Название «HoS»
- [ ] **Спаунер оружия главы СБ** — `SpawnPointHeadOfSecurityWeapon`. **Не** ставь WT550 и магазины вручную, используй этот спаунер
- [ ] **Спаун Шивы** — `SpawnMobShiva`
- [ ] **Кровать с простынёй HoS** — `Bed`, `BedsheetHOS`
- [ ] **Комод** — `DresserHeadOfSecurityFilled`
- [ ] **Шкафчик главы СБ** — `LockerHeadOfSecurityFilled`
- [ ] **Хранилище скафандра** — `SuitStorageHOS`
- [ ] **Усиленная стена** — `WallReinforced`
- [ ] **Шлюзы HoS** — `AirlockHeadOfSecurityGlassLocked`, `AirlockHeadOfSecurityLocked`
- [ ] **Спаун главы СБ** — `SpawnPointHeadOfSecurity`
- [ ] **Компьютер записей СБ** — `ComputerCriminalRecords`. Необязательно
- [ ] **Монитор камер** — `ComputerSurveillanceCameraMonitor`. Необязательно

### Кабинет смотрителя (Warden)

- [ ] **Факс** — `FaxMachineBase`. Название «Warden»
- [ ] **Шкафчик смотрителя** — `LockerWardenFilled`
- [ ] **Хранилище скафандра** — `SuitStorageWarden`
- [ ] **Комод** — `DresserWardenFilled`
- [ ] **Спаун смотрителя** — `SpawnPointWarden`
- [ ] **Спаун МакГриффа** — `SpawnMobMcGriff`. Необязательно
- [ ] **Собачья лежанка** — `DogBed`. Необязательно
- [ ] **Консоль мониторинга экипажа** — `ComputerCrewMonitoring`
- [ ] **Монитор камер** — `ComputerSurveillanceCameraMonitor`
- [ ] **Компьютер записей СБ** — `ComputerCriminalRecords`
- [ ] **Компьютер кадровых записей** — `ComputerStationRecords`. Необязательно
- [ ] **Бинокль** — `Binoculars`. Необязательно
- [ ] **Зарядник** — `WeaponCapacitorRecharger`. Если есть место
- [ ] **Зарядник батарей** — `PowerCellRecharger`. Необязательно
- [ ] **Стол** — `TableReinforced`
- [ ] **Двери смотрителя** — `AirlockArmoryGlassLocked`, `AirlockArmoryLocked`. Доступ оружейной и смотрителя чаще всего эквивалентны
- [ ] **Защищённое окно-дверь** — `WindoorSecureArmoryLocked`. У стойки
- [ ] **Принтер документов** — `PrinterDoc`

### Бригмед

- [ ] **Спаун бригмеда [Job Spawn]** — `SpawnPointBrigmedic`. В брикмеде или рядом
- [ ] **Шкафчик бригмеда** — `LockerBrigmedicFilled`. По одному на брикмед
- [ ] **NanoMed Security** — `VendingMachineMedicalSecurity`. **Обязательно**
- [ ] **Медкровать** — `MedicalBed`
- [ ] **Стазис-кровать** — `StasisBed`
- [ ] **Продвинутые мази («красные пакеты»)** — `RedBruizPack`, `RedLacePack`, `RedPunctPack`. По 1 каждого, в каждом по 20 применений
- [ ] **Продвинутые аптечки** — `MedkitCombatFilled`, `MedkitAdvancedFilled`. По 1 боевой и продвинутой (на больших картах 2)
- [ ] **Обычные аптечки** — `MedkitFilled`, `MedkitBruteFilled`, `MedkitBurnFilled`, `MedkitOxygenFilled`, `MedkitToxinFilled`, `MedkitRadiationFilled`. Обычно по 1 каждой, на усмотрение маппера. На больших картах максимум по 2
- [ ] **Зарядник батарей / зарядник** — `PowerCellRecharger`, `WeaponCapacitorRecharger`. Один из двух, для зарядки батарей
- [ ] **Шлюз бригмеда** — `AirlockBrigmedLocked`, `AirlockBrigmedGlassLocked`. Лучше, чем шлюзы СБ
- [ ] **Операционный стол** — `OperatingTable`. Бригмеды оперируют сотрудников СБ
- [ ] **Операционный компьютер** — `computerBodyScanner`. Свяжи мультитулом с операционным столом
- [ ] **Ящик хирургических принадлежностей / хирургическая сумка** — `CrateMedicalSurgery`, `ClothingBackpackDuffelSurgeryFilled`. Достаточно одного из двух
- [ ] **Слив** — `FloorDrain`. В идеале рядом с операционной
- [ ] **Морг** — `Morgue`. Для хранения погибших, достаточно 1-2
- [ ] **Коробка мешков для тел** — `BoxBodyBag`. **Обязательно**, если в брикмеде нет моргов

### Брик (Genpop)

- [ ] **Спаун дежурного офицера [Job Spawn]** — `SpawnPointDutyOfficer`. Минимум два
- [ ] **Хранилище скафандра [Prisoner EVA]** — `SuitStorageEVAPrisoner`. 2 + (1 на каждые 25 ожидаемого максимума населения)
- [ ] **Шкафы заключённых** — `LockerPrisoner`, `LockerPrisoner2` и т. д.. 3 + (1 на каждые 25). Не используй два одинаковых
- [ ] **Гардероб заключённых** — `WardrobePrisonFilled`
- [ ] **Турникет** — `TurnstileGenpopEnter`, `TurnstileGenpopLeave`. Заключённые должны уметь выходить сами, пример ниже
- [ ] **Грядка** — `hydroponicsTray`. 3-5
- [ ] **Экстрактор семян** — `SeedExtractor`
- [ ] **Биогенератор** — `Biogenerator`
- [ ] **MegaSeed Servitor** — `VendingMachineSeedsUnlocked`. Обязательно **разблокированный** вариант: у заключённых нет доступа ботаники
- [ ] **Раковина** — `SinkWide`. Вода для питья и выращивания
- [ ] **Автомат питания** — `VendingMachineSustenance`
- [ ] **Микроволновка** — `KitchenMicrowave`
- [ ] **Good Clean Fun** — `VendingMachineGames`
- [ ] **Развлечения**. На усмотрение маппера

### Детектив

- [ ] **Компьютер записей СБ** — `ComputerCriminalRecords`
- [ ] **Монитор камер** — `ComputerSurveillanceCameraMonitor`
- [ ] **DetDrobe** — `VendingMachineDetDrobe`
- [ ] **Шкаф детектива** — `LockerDetectiveFilled`
- [ ] **Спаун детектива** — `SpawnPointDetective`

### K9 (служебные собаки)

- [ ] **Спаун K9 [Job Spawn]** — `SpawnPointK9`. Рядом с раздевалкой или там, где спаунятся офицеры. Не ставь в случайных «колоритных» местах вроде бара, они должны спаунаться рядом с офицером СБ
- [ ] **Мягкая лежанка / собачья лежанка** — `SoftPetBedRed`, `DogBed`. Много цветов, можно и обычную лежанку
- [ ] **Источник воды** — `WaterCooler`, `Sink`, `SinkWide`. Чтобы офицеры могли напоить собаку
- [ ] **Переноска** — `PetCarrier`. По одной на K9

### Стойка

- [ ] **Факс** — `FaxMachineBase`. Название «Security»
- [ ] **Принтер документов** — `PrinterDoc`
- [ ] **Стойка** — `TableReinforced`
- [ ] **Защищённое окно-дверь** — `WindoorSecureSecurityLocked`

### Оружейная

- [ ] **Техфаб СБ** — `SecurityTechFab`. Обязательно
- [ ] **Высокозащищённая дверь** — `HighSecArmoryLocked`
- [ ] **Ящик хранения контрабанды** — `CrateContrabandStorageSecure`
- [ ] **Сейф с тяжёлым оружием** — `GunSafeHeavyWeapons`
- [ ] **Сейф с SMG** — `GunSafeSubMachineGunDrozd`
- [ ] **Сейф с лазерами** — `GunSafeLaserCarbine`
- [ ] **Сейф с винтовками** — `GunSafeRifleLecter`
- [ ] **Сейф с дробовиками** — `GunSafeShotgunKammerer`
- [ ] **Ящик имплантеров** — `CrateSecurityTrackingMindshieldImplants`
- [ ] **Сейф для оружия** — `GunSafeBaseSecure`
- [ ] **Переносная вспышка** — `PortableFlasher`. 1 + (1 на каждые 50 максимума населения)
- [ ] **Хранилище скафандра** — `SuitStorageSec`
- [ ] **Дополнительное снаряжение**. На усмотрение маппера
- [ ] **Раскладной барьер** — `DeployableBarrier`. На 1 меньше, чем нужно, чтобы забаррикадировать весь отдел

### Допросная

- [ ] **Лампа допроса** — `LampInterrogator`
- [ ] **Тусклая малая лампа** — `PoweredDimSmallLight`

### Раздевалка

- [ ] **Шкафчик офицера СБ** — `LockerSecurityFilled`, `LockerSecurityLargeFilled`. По одному на место офицера, есть двойные
- [ ] **Спаун офицера СБ** — `SpawnPointSecurityOfficer`
- [ ] **Спаун кадета СБ** — `SpawnPointSecurityCadet`
- [ ] **SecDrobe** — `VendingMachineSecDrobe`

### Общежитие или казарма

- [ ] **Кровать с простынёй** — `Bed`. Лучше случайная простыня
- [ ] **Стол** — `Table`, `TableWood`
- [ ] **Комод** — `DresserFilled`
- [ ] **Кнопка запирания двери** — `SignalButtonDirectional`. Не в казармах
- [ ] **Шторы на окнах**

## Сервис

Подробно: [Сервис](https://wiki.lost-paradise.space/ru/mapping/stations/service).

### Помещения

- [ ] Кабинет HOP
- [ ] Кухня
- [ ] Столовая / обеденный зал (где-то поесть)
- [ ] Бар
- [ ] Комната бармена
- [ ] Гидропоника
- [ ] Комната ботаника
- [ ] Театр (клоун, мим, артисты, музыкант)
- [ ] Комната клоуна
- [ ] Комната мима
- [ ] Шрайн (где работает священник)
- [ ] Комната священника
- [ ] Подсобка уборщика
- [ ] Утилизация
- [ ] Репортёр
- [ ] Библиотека
- [ ] Комната библиотекаря
- [ ] Кабинет юриста
- [ ] Общежитие
- [ ] Санузлы
- [ ] Боксёрский ринг (для боксёра)
- [ ] Комната музыканта
- [ ] Зоопарк / зоны с животными (для зоолога)
- [ ] Дополнительные подсобки уборщиков

### Общее для сервиса

- [ ] **Техфаб сервиса** — `ServiceTechFab`. Лучше за дверью с доступом сервиса
- [ ] **Компьютер заказов сервиса** — `ComputerCargoOrdersService`. Лучше за дверью с доступом сервиса

### Кабинет и каюта HoP

- [ ] **Консоль связи сервиса** — `ComputerCommsService`. Обязательно
- [ ] **Консоль мониторинга экипажа** — `ComputerCrewMonitoring`. Необязательно
- [ ] **Компьютер кадровых записей** — `ComputerStationRecords`
- [ ] **Компьютер ID-карт** — `ComputerId`
- [ ] **Компьютер распределения бюджета** — `ComputerFundingAllocation`. В комнате HOP. Если там нет места, можно на мостик
- [ ] **PTech** — `VendingMachineCart`. Обязательно
- [ ] **Спаун корги** — `SpawnMobCorgi`. Обязательно
- [ ] **Собачья лежанка** — `DogBed`
- [ ] **Принтер униформы** — `UniformPrinter`. Обязательно
- [ ] **Ткань** — `MaterialCloth`. 60
- [ ] **Дюраткань** — `MaterialDurathread`. 30
- [ ] **Стойка** — `TableReinforced`
- [ ] **Защищённое окно-дверь** — `WindoorSecureHeadOfPersonnelLocked`
- [ ] **Двери HoP** — `AirlockHeadOfPersonnelGlassLocked`, `AirlockHeadOfPersonnelLocked`
- [ ] **Комод** — `DresserHeadOfPersonnelFilled`
- [ ] **Шкафчик главы персонала** — `LockerHeadOfPersonnelFilled`
- [ ] **Кровать с простынёй HoP** — `Bed`, `BedsheetHOP`
- [ ] **Спаун HoP** — `SpawnPointHeadOfPersonnel`

### Склад EVA

- [ ] **Шлюз (EVA)** — `AirlockEVALocked`, `AirlockEVAGlassLocked`, `AirlockMaintCommandLocked` (для техтоннелей). Используй правильные шлюзы, не шлюзы HOP
- [ ] **Хранилище скафандра** — `SuitStorageEVAAlternate`. 1 на 10 человек экипажа
- [ ] **Мини-джетпак** — `JetpackMiniFilled`. Вдвое меньше, чем EVA-костюмов
- [ ] **Магнитные ботинки** — `ClothingShoesBootsMag`, `ClothingShoesBootsMagSci`. Вдвое меньше, чем EVA-костюмов
- [ ] **Раздатчик баллонов** — `VendingMachineTankDispenserEVA`. Выдаёт баллоны O2/N2

### Кухня

- [ ] **Спаун повара** — `SpawnPointChef`
- [ ] **Спаун Александра** — `MobAlexander`. Необязательно
- [ ] **Микроволновка** — `KitchenMicrowave`. 1 на повара
- [ ] **Измельчитель реагентов** — `KitchenReagentGrinder`. 1 на повара
- [ ] **Духовка** — `KitchenOven`. 1 на повара
- [ ] **Плита** — `KitchenStove`. 1 на повара, ставь поверх духовки
- [ ] **Plasteel Chef's Dinnerware Vendor** — `VendingMachineDinnerware`
- [ ] **ChefVend** — `VendingMachineChefvend`
- [ ] **Раковина** — `SinkWide`
- [ ] **Зона раздачи**
- [ ] **Тележка с едой** — `FoodCartCold`, `FoodCartHot`. Необязательно

### Морозильная камера

- [ ] **Морозильник** — `GasThermoMachineFreezerEnabled`. Подключён напрямую к пассивной вентиляции в камере
- [ ] **Морозильный ящик** — `CrateFreezer`
- [ ] **VariantCubeBox** — `VariantCubeBox`
- [ ] **Мясной крюк** — `KitchenSpike`
- [ ] **Шлюз морозилки** — `AirlockFreezerLocked`
- [ ] **Морозильный шкаф** — `LockerFreezer`
- [ ] **Слив** — `FloorDrain`
- [ ] **Маркер atmos fix морозилки** — `AtmosFixFreezerMarker`
- [ ] **Воздушная тревога морозилки** — `AirAlarmFreezer`

### Обеденный зал

- [ ] **Столы** — `Table`
- [ ] **Стулья**
- [ ] **Станция приправ** — `VendingMachineCondiments`
- [ ] **Спаун работника сервиса** — `SpawnPointServiceWorker`

### Бар

- [ ] **Спаун бармена** — `SpawnPointBartender`
- [ ] **Спаун обезьяны Пун-Пун** — `SpawnMobMonkeyPunpun`
- [ ] **Раздатчик газировки** — `SodaDispenser`
- [ ] **Раздатчик алкоголя** — `BoozeDispenser`
- [ ] **Booze-O-Mat** — `VendingMachineBooze`
- [ ] **Зона раздачи**
- [ ] **Раковина** — `SinkWide`
- [ ] **Слив** — `FloorDrain`
- [ ] **BarDrobe** — `VendingBarDrobe`
- [ ] **Склад выпивки** — `LockerBoozeFilled`

### Гидропоника

- [ ] **Грядка** — `hydroponicsTray`. Минимум 8, больше при большем числе ботаников
- [ ] **MegaSeed Servitor** — `VendingMachineSeeds`
- [ ] **NutriMax** — `VendingMachineNutri`
- [ ] **HyDrobe** — `VendingMachineHydrobe`
- [ ] **Шкафчик ботаника** — `LockerBotanistFilled`. По одному на место ботаника
- [ ] **Раковина** — `SinkWide`
- [ ] **Бак воды большой ёмкости** — `WaterTankHighCapacity`
- [ ] **Измельчитель реагентов** — `KitchenReagentGrinder`
- [ ] **Биогенератор** — `Biogenerator`
- [ ] **Спаун ботаника** — `SpawnPointBotanist`
- [ ] **Стойка** — `TableCounterMetal`
- [ ] **Окно-дверь** — `WindoorHydroponicsLocked`

### Театр

- [ ] **AutoDrobe** — `VendingMachineTheater`
- [ ] **Пианино** — `UprightPianoInstrument`. Пример, чтобы делать музыку
- [ ] **HohohonkersVend** — `VendingMachineClown`
- [ ] **Шкафчик клоуна** — `LockerClown`. Маппер может наполнить смешными вещами
- [ ] **Шкафчик мима** — `LockerMime`. Маппер может наполнить вещами для мима
- [ ] **Парадный шкаф** — `WardrobeFormal`. Можно наполнить инструментами и парадной одеждой
- [ ] **Спаунер случайных инструментов** — `RandomInstruments`. Пример
- [ ] **Пушка для пирогов** — `LauncherCreamPie`. Пример
- [ ] **Банановые шкурки** — `TrashBananaPeel`. Пример
- [ ] **Бургер мима** — `FoodBurgerMime`. Пример
- [ ] **Коробка мелков** — `CrayonBox`. Пример

### Радиоведущий

- [ ] **Табличка радиоведущего** — `SignRadioHost`. Вывески критичны
- [ ] **Табличка «в эфире»** — `OnAirSignLights`. Свяжи с кнопкой, чтобы ведущий включал и выключал
- [ ] **Тонированное окно** — `TintedWindow`. Можно связать с той же кнопкой
- [ ] **Маяк станции [Radio Studio]** — `DefaultStationBeaconRadioHost`. Маяки критичны
- [ ] **Спаун радиоведущего [Job Spawn]** — `SpawnPointRadioHost`. По одному на место
- [ ] **Факс [SRV: Radio Host]** — `FaxMachineRadioHost`
- [ ] **Станционный радиокомплекс** — `StationRadioRig`. Мультитулом свяжи со станционным радиосервером и проигрывателем винила
- [ ] **Станционный радиосервер** — `StationRadioServer`. Это **микрофон** радиоведущего. ЛКМ включает и выключает трансляцию голоса. Радиус 4 тайла, поставь в тихое место
- [ ] **Голопад [RadioHost]** — `HolopadServiceRadioHost`. Ставь рядом с радиосервером для голо-интервью
- [ ] **Проигрыватель винила** — `VinylPlayer`. Играет виниловые пластинки на станционное радио. Музыка транслируется, только если он связан с радиокомплексом, а тот связан с радиосервером
- [ ] **Магнитофон** — `TapeDeck`. Работает как ручной диктофон. Ставь рядом с микрофоном, чтобы транслировать кассеты
- [ ] **Станционное радио** — `StationRadioReceiver`. Ставь там, где должны быть слышны музыка и голос. Играет музыку и голоса, если всё связано правильно. У каждого своя громкость и кнопки
- [ ] **Станционное радио [Random]** — `RandomSpawnStationRadioReceiver`. Как выше, но появляется в 45% случаев. **Для бара и радиостудии лучше гарантированные радио.** В одной комнате не ставь два таких спаунера: шанс двух радио в одной комнате около 20%
- [ ] **Ящик с винилом** — `CrateRadioHostVinyls`. **Обязательно.** 12 случайных пластинок. Минимум один, больше для большой комнаты
- [ ] **Стойка с CD** — `CdRackFilled`. **Обязательно.** Со случайными рекламными CD. Один

### Шрайн

- [ ] **Скамья** — `PewEndRight`, `PewEndLeft`, `PewMiddle`
- [ ] **Алтарь** — `AltarSpawner`, `ConvertAltarSpawner`
- [ ] **Церковный орган** — `ChurchOrganInstrument`
- [ ] **Церковный колокол** — `ChurchBell`
- [ ] **Спаун священника** — `SpawnPointChaplain`

### Крематорий

- [ ] **Крематорий** — `Crematorium`
- [ ] **Гроб** — `CrateCoffin`. Необязательно
- [ ] **Урна** — `Urn`. Необязательно

### Комната священника

- [ ] **PietyVend** — `VendingMachineChapel`

### Кабинет юриста

- [ ] **Табличка «Юрист»** — `SignLawyerOffice`. Вывески критичны
- [ ] **Спаун юриста** — `SpawnPointLawyer`. В кабинете юриста или в зале суда. Всегда ставь 2 спауна
- [ ] **Маяк станции [Lawyer]** — `DefaultStationBeaconLawyer`. Обязательно
- [ ] **Шлюзы** — `AirlockLegalLocked`, `AirlockLegalGlassLocked`, `AirlockMaintLegalLocked`. Для юриста используй шлюзы с доступом Legal
- [ ] **LegalDrobe** — `VendingMachineLegalDrobe`. Требует доступ Legal. Не путать с LawDrobe
- [ ] **Голопад [Lawyer]** — `HolopadServiceLawyer`. Чтобы IAA звонили людям
- [ ] **Принтер документов** — `PrinterDoc`. Обязательно
- [ ] **Факс [SRV: Lawyer]** — `FaxMachineServiceLawyer`. Обязательно
- [ ] **Стопка бумаги** — `PaperBin10`, `PaperBin20`. Обязательно
- [ ] **Декор** — `BookshelfFilled`, `filingCabinetDrawerRandom`, `filingCabinetRandom`, `Lamp`, `ChairOfficeDark`. Много вариантов

### Уборщик

- [ ] **Спаун уборщика** — `SpawnPointJanitor`
- [ ] **Бак воды большой ёмкости** — `WaterTankHighCapacity`
- [ ] **Шкаф уборщика** — `ClosetJanitorFilled`. 1 на уборщика
- [ ] **Мусорная тележка** — `CrateTrashCartJani`
- [ ] **Шкаф биозащиты 3 уровня** — `ClosetL3JanitorFilled`
- [ ] **Тележка уборщика** — `JanitorialTrolley`
- [ ] **Ведро со шваброй** — `MopBucketFull`
- [ ] **Швабра** — `MopItem`
- [ ] **JaniDrobe** — `VendingMachineJaniDrobe`
- [ ] **Табличка «Мокрый пол»** — `WetFloorSign`
- [ ] **Голографический проектор знаков** — `Holoprojector`
- [ ] **Заменитель ламп** — `LightReplacer`
- [ ] **Ведро** — `Bucket`
- [ ] **Раковина** — `SinkWide`
- [ ] **Слив** — `FloorDrain`

### Утилизация

- [ ] **Измельчитель** — `Recycler`. С рабочей системой конвейера
- [ ] **Труба утилизации** — `DisposalTrunk`. Должна подавать мусор из системы утилизации на конвейер
- [ ] **Система выброса**. Способ избавиться от мусора, который нельзя переработать

### Общежитие или казарма

- [ ] **Кровать с простынёй** — `Bed`. Лучше случайная простыня
- [ ] **Стол** — `Table`, `TableWood`
- [ ] **Комод** — `DresserFilled`
- [ ] **Кнопка запирания двери** — `SignalButtonDirectional`. Не в казармах
- [ ] **Шторы на окнах**

### Репортёр

- [ ] **Спаун репортёра**
- [ ] **Монитор беспроводных камер**
- [ ] **Консоль менеджера новостей**
- [ ] **Беспроводная камера** — 1 переносная, одна закреплена и смотрит на место для репортажей
- [ ] **Роутер камер развлечений** — Необязательно, можно вместе с другими роутерами

### Боксёрский ринг

- [ ] **Спаун Уиллоу**
- [ ] **Спаун боксёра** — 1 на малых станциях, 2 на больших
- [ ] **Боксёрский ринг**
- [ ] **Кулер с водой**
- [ ] **Бинты**
- [ ] **Железные таблетки**
- [ ] **Боксёрские перчатки**

### Библиотека

- [ ] **Good Clean Fun**
- [ ] **Спаун библиотекаря**
- [ ] **Спаунер «ленивца с бумагами»**
- [ ] **CuraDrobe**
- [ ] **Стойка** — Для библиотекаря
- [ ] **Книжные шкафы** — Смесь полных и пустых
- [ ] **Факс** — Название «Library». Это общедоступный факс. Если библиотеки нет или места мало, поставь общедоступный факс в другом месте
- [ ] **Принтер документов** — То же: если библиотеки нет, поставь в другом месте
- [ ] **Стол для настольных игр**

## Шаттл (если делаешь корабль)

Подробно: [Шаттл (если делаешь корабль)](https://wiki.lost-paradise.space/ru/mapping/shuttles/guidelines).

### Мостик

- [ ] **Консоль шаттла** — `ComputerShuttle`. На мостике

### Инженерка

- [ ] **Питание** — `GeneratorBasic15kW`, `GeneratorBasic20kW`. До 6 генераторов. Если нужно больше, добавь AME или TEG с топливом минимум на час
- [ ] **Источник N2** — `GasMinerNitrogen`, `NitrogenCanister`. Работающий майнер или баллон, зависит от размера шаттла
- [ ] **Источник O2** — `GasMinerOxygen`, `OxygenCanister`. То же
- [ ] **Источник воздуха** — `AirCanister`. Смесь N2 и O2 или баллон воздуха на очень малом шаттле
- [ ] **Раздача воздуха**. Вентиляции
- [ ] **Отходы**. Скрубберы; отходы можно сбрасывать в космос пассивной вентиляцией
- [ ] **Гироскопы** — `Gyroscope`. Минимум один
- [ ] **Мини-генератор гравитации** — `GravityGeneratorMini`. Для больших гридов (обычно только ивентовых) можно полноразмерный

### Двигатели

- [ ] **Двигатель** — `Thruster`. Работает только от LV, должен стоять на тайле, смотреть на решётку или космос. Может испепелить людей
- [ ] **Большой двигатель** — `ThrusterLarge`. Для очень больших кораблей, потребляет много энергии, обычно нужны отдельные APC

### Стыковка

- [ ] **Внешний стыковочный шлюз** — `AirlockExternalGlassShuttleLocked`. Стыкуется с другими шлюзами
- [ ] **Направленный вентилятор** — `AtmosDeviceFanDirectional`. Под шлюзом, лицом в космос. Не используй tiny fan!
- [ ] **HV** — `CableHV`. Под шлюзом, нужен для соединения с сетью станции
- [ ] **Труба распределения** — `GasPipeStraight`. См. [стандарт труб](https://wiki.lost-paradise.space/ru/mapping/pipe-docks)
- [ ] **Труба экспорта** — `GasPipeStraight`
- [ ] **Труба импорта** — `GasPipeStraight`
