command-description-radio-addcustom =
    Добавляет пользовательский канал в указанный компонент сущности из конвейера. Укажите true или false в конце, чтобы гарантировать существование компонента.
command-description-radio-remcustom =
    Удаляет пользовательский канал с заданным ID из указанного компонента сущности из конвейера.
command-description-container-insertentity =
    Помещает заданную сущность в указанный контейнер сущности из конвейера.
command-description-container-insert =
    Помещает сущность в переданный по конвейеру контейнер.
command-description-container-create =
    Создаёт новый контейнер на сущности из конвейера.
command-description-container-createslot =
    Создаёт новый слот-контейнер на сущности из конвейера.
command-description-container-delete =
    Удаляет контейнер на сущности из конвейера.
command-description-container-drop =
    Выбрасывает все находящиеся внутри сущности из указанного контейнера сущности из конвейера.
command-description-container-dropandget =
    Выбрасывает все находящиеся внутри сущности из указанного контейнера сущности из конвейера и возвращает все выброшенные предметы вместо сущности из конвейера.
command-description-container-dropanddelete =
    Выбрасывает все находящиеся внутри сущности из указанного контейнера сущности из конвейера, затем удаляет контейнер.
command-description-container-get =
    Получает контейнер сущности по его ID.
command-description-container-getentities =
    Получает все сущности в заданном контейнере сущности из конвейера.
command-description-container-getcontaining =
    Получает все контейнеры, в которых сейчас находится сущность из конвейера.
command-description-container-getoutercontainer =
    Получает самый внешний контейнер, содержащий сущность из конвейера.
command-description-container-getowner =
    Получает сущность, которой принадлежит указанный контейнер.
command-description-solution-adjcapacity =
    Изменяет вместимость заданного раствора.
command-description-solution-adjtemperature =
    Изменяет вместимость заданного раствора.
command-description-solution-adjthermalenergy =
    Изменяет вместимость заданного раствора.
command-description-solution-create=
    Создаёт новый раствор с заданным именем на сущности из конвейера. Возвращает существующий раствор, если он уже есть.
command-description-solution-delete=
    Удаляет указанный раствор на сущности из конвейера.
### Starlight (upstream #39080)
command-description-subtlemessage =
    Отправляет незаметное сообщение всем входным сущностям.
command-description-grid-getplayers =
    Получает всех игроков на сетке (сетках) из конвейера
command-description-grid-get =
    Получает сетку (сетки), на которой стоят игроки из конвейера.
command-description-grid-getstation =
    Получает станцию (станции), на которой стоят игроки из конвейера, или станцию самой сущности, если сетка передана в конвейер.
command-description-crewmanifest-addto =
    Добавляет сущность из конвейера в манифест экипажа указанной станции.
command-description-crewmanifest-removefrom =
    Удаляет сущность из конвейера из манифеста экипажа указанной станции.
command-description-crewmanifest-addplayer =
    Добавляет указанного игрока в манифест(ы) экипажа станции (станций) из конвейера.
command-description-crewmanifest-removeplayer =
    Удаляет указанного игрока из манифеста(ов) экипажа станции (станций) из конвейера.
command-description-storage-reshape =
    Меняет форму хранилища на основе данных, заданных командой box2iconstructor.
command-description-box2iconstructor-new =
    Создаёт на сущности новое определение списка Box2i; свяжите его с командами box2iconstructor:add, затем продолжите командой, которой оно требуется.
command-description-box2iconstructor-add =
    Добавляет новый Box2i в существующее определение. Перед этим вызовите box2iconstructor:new.
command-description-box2iconstructor-clean =
    Очищает неиспользуемое определение списка Box2i на сущности.
command-description-vector2dataconstructor-new =
    Создаёт на сущности новое определение списка Vector2; свяжите его с командами vector2dataconstructor:add, затем продолжите командой, которой оно требуется.
command-description-vector2dataconstructor-add =
    Добавляет новый Vector2 в существующее определение. Перед этим вызовите vector2dataconstructor:new.
command-description-vector2dataconstructor-clean =
    Очищает неиспользуемое определение списка Vector2 на сущности.
command-description-ccomp-ensure =
    Гарантирует, что все клиенты добавят компонент с указанным именем на сущность, если она существует.
command-description-ccomp-write =
    Пытается заставить всех клиентов выполнить vvwrite в клиентский компонент.
command-description-ccomp-rm =
    Гарантирует, что все клиенты удалят компонент с указанным именем с сущности, если она существует.
command-description-globalsound-play =
    Воспроизводит звук глобально для сущностей или сессий из конвейера.
command-description-polymorph-begin =
    Маркер начала последовательности инструкций настройки полиморфа, прикрепит к сущности PolymorphSetupComponent.
command-description-polymorph-setproto =
    Задаёт прототип, в который превратится сущность.
command-description-polymorph-seteffect =
    Задаёт прототип, создаваемый поверх превращённой сущности, обычно используется для создания спецэффектов.
command-description-polymorph-setdelay =
    Задаёт, сколько секунд нужно ждать, прежде чем снова сможно активировать именно этот полиморф.
command-description-polymorph-setduration =
    Задаёт длительность полиморфа в секундах до автоматического возврата.
command-description-polymorph-setforced =
    Делает так, что полиморф не может быть активирован или отменён самой сущностью.
command-description-polymorph-settransferdamage =
    Включает перенос урона с текущей сущности на превращённую.
command-description-polymorph-settransfername =
    Включает наследование превращённой сущностью имени оригинала.
command-description-polymorph-settransferappearance =
    Задаёт, переносить ли на превращённую сущность волосы, цвет кожи, рост и прочее.
command-description-polymorph-setinventory =
    Определяет, как инвентарь сущности будет переноситься на превращённую сущность.
command-description-polymorph-setrevertoncrit =
    Задаёт, возвращать ли полиморф, когда сущность входит в критическое состояние.
command-description-polymorph-setrevertondeath =
    Задаёт, возвращать ли полиморф, когда сущность погибает.
command-description-polymorph-setrevertondelete =
    Задаёт, возвращать ли полиморф, когда сущность удаляется.
command-description-polymorph-setrevertoneat =
    Задаёт, возвращать ли полиморф, когда сущность съедена.
command-description-polymorph-setallowrepeats =
    Задаёт, разрешены ли повторные полиморфы.
command-description-polymorph-setignoreallowrepeats =
    Разрешает произойти полиморфу, даже если AllowRepeatedMorphs равно true.
command-description-polymorph-setcooldown =
    Задаёт перезарядку в секундах перед следующим полиморфом.
command-description-polymorph-setentersound =
    Задаёт звук, воспроизводимый при входе в полиморф.
command-description-polymorph-setexitsound =
    Задаёт звук, воспроизводимый при выходе из полиморфа.
command-description-polymorph-clearentersound =
    Очищает звук, воспроизводимый при входе в полиморф.
command-description-polymorph-clearexitsound =
    Очищает звук, воспроизводимый при выходе из полиморфа.
command-description-polymorph-setenterpopup =
    Задаёт всплывающее сообщение при входе в полиморф.
command-description-polymorph-setexitpopup =
    Задаёт всплывающее сообщение при выходе из полиморфа.
command-description-polymorph-clearcopycomp =
    Очищает список компонентов, копируемых в полиморф.
command-description-polymorph-addcopycomp =
    Добавляет запись в список компонентов, копируемых в полиморф.
command-description-polymorph-rmcopycomp =
    Удаляет запись из списка компонентов, копируемых в полиморф.
command-description-polymorph-apply =
    Мгновенно применяет полиморф и завершает.
command-description-polymorph-applyget =
    Мгновенно применяет полиморф и завершает, возвращая новую сущность.
command-description-polymorph-addaction =
    Добавляет сущности действие полиморфа, используя текущую цепочку настройки полиморфа. После этого, вероятно, стоит вызвать polymorph:apply или polymorph:finish.
command-description-polymorph-addactionproto =
    Добавляет сущности действие полиморфа по прототипу.
command-description-polymorph-rmaction =
    Удаляет с сущности действие полиморфа, добавленное через polymorph:addaction.
command-description-polymorph-rmactionproto =
    Удаляет с сущности действие полиморфа по прототипу.
command-description-polymorph-revert =
    Возвращает к предыдущей сущности x, если возможно.
command-description-polymorph-reset =
    Сбрасывает полиморф сущности до исходного состояния.
command-description-polymorph-finish =
    Помечает эту цепочку настройки полиморфа как завершённую, очищая и удаляя компонент.
command-description-vv-open =
    Открывает окно ViewVariables для сущности или пути из конвейера.
command-description-vv-write =
    Изменяет значение пути через VV (View Variables). Для значения можно использовать переменную, но она должна быть сериализованной строкой.
command-description-vv-owrite =
    Изменяет значение пути через VV (View Variables). Для значения можно использовать сырую переменную.
command-description-vv-read =
    Выводит значение пути через VV (View Variables).
command-description-vv-rsave =
    Получает значение пути через VV (View Variables). Можно сохранить в переменную.
command-description-vv-rsaveraw =
    Получает значение пути через VV (View Variables). Можно сохранить в переменную. Сохраняет сырое значение вместо сериализованной строки.
command-description-mind-wipe =
    Стирает разум игрока или сущности. Учтите, что после этого игра за неё будет невозможна, пока вы не дадите ей новый разум.
command-description-mind-takeover =
    Напрямую захватывает моба, создавая разум, если его нет, и делая сущность разумной.
command-description-mind-takeoverwipe =
    Стирает ваш собственный разум, затем захватывает сущность. Это очистит все роли разума, цели и прочее.
command-description-mind-controlwipe =
    Стирает разум целевого игрока и заставляет его управлять сущностью из конвейера, создавая новый разум и делая сущность разумной.
command-description-killsign-set =
    Применяет к сущности знак смерти с указанным состоянием.
command-description-killsign-list =
    Перечисляет все доступные знаки смерти.
command-description-killsign-rm =
    Удаляет знак смерти с сущности
command-description-fixinput =
    Обновляет контекст ввода сессии сущности.
command-description-faction-add =
    Добавляет этой сущности фракцию.
command-description-faction-remove =
    Удаляет у этой сущности фракцию.
command-description-faction-aggro =
    Делает эту сущность агрессивной к целевой сущности.
command-description-faction-deaggro =
    Делает так, что эта сущность больше не агрессивна к целевой сущности.
command-description-faction-ignore =
    Заставляет эту сущность и целевую сущность игнорировать друг друга.
command-description-faction-unignore =
    Заставляет эту сущность и целевую сущность больше не игнорировать друг друга.
command-description-faction-clear =
    Очищает фракции этой сущности.
command-description-npc-sethtn =
    Создаёт NPC на сущности и задаёт его составной HTN.
command-description-npc-setenabled =
    Включает или отключает HTN-поведение этого NPC.
command-description-stationinit-begin =
    Начинает процесс инициализации новой станции посреди раунда. Прикрепляет к сетке BecomesStationMidRoundComponent.
command-description-stationinit-setid =
    Задаёт ID станции. Это нужно, чтобы избежать дубликатов.
command-description-stationinit-clearbaseprotos =
    Очищает список базовых прототипов станции.
command-description-stationinit-addbaseproto =
    Добавляет используемый базовый прототип станции.
command-description-stationinit-rmbaseproto =
    Убирает базовый прототип станции из использования.
command-description-stationinit-setallowftl =
    Задаёт, разрешать ли всем совершать FTL-прыжок на карту, где находится эта станция.
command-description-stationinit-setuseemergencyshuttle =
    Задаёт создание эвакуационного шаттла, используемого в конце раунда.
command-description-stationinit-setusearmories =
    Задаёт создание оружейных, которые можно отправить на станцию командой armory.
command-description-stationinit-setusearrivals =
    Задаёт создание шаттла прибытия для этой станции.
command-description-stationinit-setallowdungeonspawns =
    Задаёт, разрешать ли появление подземелий вроде VGroid.
command-description-stationinit-setallowcargo =
    Задаёт, разрешать ли появление грузовых шаттлов и АТС.
command-description-stationinit-clearallowedgridspawns =
    Очищает список разрешённых для появления гридспавнов из базовых прототипов.
command-description-stationinit-addallowedgridspawn =
    Добавляет разрешённый для появления гридспавн из базовых прототипов.
command-description-stationinit-rmallowedgridspawn =
    Удаляет разрешённый для появления гридспавн из базовых прототипов.
command-description-stationinit-setemergencyshuttlepath =
    Задаёт переопределение сетки эвакуационного шаттла.
command-description-stationinit-clearjobs =
    Очищает все должности этой станции.
command-description-stationinit-addjob =
    Добавляет этой станции новую должность.
command-description-stationinit-rmjob =
    Удаляет должность этой станции.
command-description-stationinit-setallowevents =
    Задаёт, разрешать ли событиям выбирать эту станцию целью.
command-description-stationinit-setdovariationpass =
    Задаёт, разрешать ли запуск прохода вариаций в начале раунда на только что созданной станции.
command-description-stationinit-namegrid =
    Переименовывает целевую сетку; имя сетки будет использовано как название станции при инициализации.
command-description-stationinit-initialize =
    Завершает настройку и инициализирует станцию.
command-description-stationinit-initializeget =
    Завершает настройку и инициализирует станцию, возвращая только что созданную сущность станции.
command-description-aitakeover =
    Заставляет сущность из конвейера захватить целевое ядро ИИ.
command-description-mobthreshold-initialize =
    Правильно инициализирует новый порог моба на сущности.
command-description-corporeal-on =
    Делает вашего призрака видимым и даёт ему возможность говорить.
command-description-corporeal-off =
    Делает вашего призрака невидимым и отнимает возможность говорить.
command-description-markup-adddesc =
    Добавляет текст с разметкой в описание сущности из конвейера с заданным ID.
command-description-markup-editdesc =
    Изменяет строку текста с разметкой в описании сущности из конвейера с заданным ID.
command-description-markup-rmdesc =
    Удаляет строку текста с разметкой из описания сущности из конвейера с заданным ID.
command-description-markup-cleardesc =
    Очищает все дополнительные строки текста с разметкой из описания сущности из конвейера.
command-description-markup-listdesc =
    Перечисляет все тексты разметки описания на сущности из конвейера и их ID.
command-description-atmos-add =
    Добавляет атмосферу на сетку из конвейера.
command-description-atmos-fix =
    Исправляет атмосферу сетки из конвейера.
command-description-atmos-rejoin =
    Пытается заставить атмосферное устройство из конвейера заново присоединиться к атмосфере.
command-description-jobs-makeunlimited =
    Делает слот должности неограниченным.
command-description-jobs-makelimited =
    Делает слот должности ограниченным. Позволяет сбросить до 0 или до значения, которое было бы в середине раунда.
