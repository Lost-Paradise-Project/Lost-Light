# FTLdiskburner
cmd-ftldisk-desc = Создаёт диск с координатами FTL для полёта на карту, на которой находится сущность с указанным EntityID
cmd-ftldisk-help = ftldisk [EntityID]

cmd-ftldisk-no-transform = У сущности { $destination } нет компонента Transform!
cmd-ftldisk-no-map = Сущность { $destination } не находится ни на какой карте!
cmd-ftldisk-no-map-comp = Сущность { $destination } каким-то образом находится на карте { $map } без компонента карты.
cmd-ftldisk-map-not-init = Сущность { $destination } находится на карте { $map }, которая не инициализирована! Убедитесь, что её безопасно инициализировать, и сначала инициализируйте карту, иначе игроки застрянут на месте!
cmd-ftldisk-map-paused = Сущность { $desintation } находится на карте { $map }, которая приостановлена! Сначала снимите карту с паузы, иначе игроки застрянут на месте.
cmd-ftldisk-planet = Сущность { $desintation } находится на карте планеты { $map } и потребует точку FTL. Возможно, она уже существует.
cmd-ftldisk-already-dest-not-enabled = Сущность { $destination } находится на карте { $map }, у которой уже есть FTLDestinationComponent, но он не включён! Для безопасности настройте это вручную.
cmd-ftldisk-requires-ftl-point = Сущность { $destination } находится на карте { $map }, для полёта на которую нужна точка FTL! Возможно, она уже существует.

cmd-ftldisk-hint = netID карты
