### Localization for engine console commands

cmd-hint-float = [float]

## generic command errors

cmd-invalid-arg-number-error = Неверное число аргументов.

cmd-parse-failure-integer = { $arg } не является допустимым целым числом.
cmd-parse-failure-float = { $arg } не является допустимым дробным числом.
cmd-parse-failure-bool = { $arg } не является допустимым значением bool.
cmd-parse-failure-uid = { $arg } не является допустимым UID сущности.
cmd-parse-failure-mapid = { $arg } не является допустимым MapId.
cmd-parse-failure-enum = { $arg } не является значением перечисления { $enum }.
cmd-parse-failure-grid = { $arg } не является допустимым гридом.
cmd-parse-failure-cultureinfo = "{ $arg }" не является допустимым CultureInfo.
cmd-parse-failure-entity-exist = UID { $arg } не соответствует существующей сущности.
cmd-parse-failure-session = Нет сессии с именем пользователя: { $username }
cmd-parse-failure-session-guid = Нет сессии с GUID: { $guid }

cmd-error-file-not-found = Не удалось найти файл: { $file }.
cmd-error-dir-not-found = Не удалось найти каталог: { $dir }.

cmd-failure-no-attached-entity = К этой оболочке не привязана ни одна сущность.

## 'help' command
cmd-help-desc = Показывает общую справку или справку по конкретной команде.
cmd-help-help = Использование: { $command } [имя команды]
    Если имя команды не указано, показывает общую справку. Если указано, показывает справку по этой команде.

cmd-help-no-args = Чтобы показать справку по конкретной команде, введите 'help <команда>'. Чтобы вывести список всех доступных команд, введите 'list'. Чтобы найти команды, используйте 'list <фильтр>'.
cmd-help-unknown = Неизвестная команда: { $command }
cmd-help-top = { $command } — { $description }
cmd-help-invalid-args = Неверное количество аргументов.
cmd-help-arg-cmdname = [command name]

## 'cvar' command
cmd-cvar-desc = Получает или задаёт CVar.
cmd-cvar-help = Использование: { $command } <имя | ?> [значение]
    Если передано значение, оно разбирается и сохраняется как новое значение CVar.
    Если нет, отображается текущее значение CVar.
    Используйте 'cvar ?', чтобы получить список всех зарегистрированных CVar.

cmd-cvar-invalid-args = Необходимо передать ровно один или два аргумента.
cmd-cvar-not-registered = CVar '{ $cvar }' не зарегистрирован. Используйте 'cvar ?', чтобы получить список всех зарегистрированных CVar.
cmd-cvar-parse-error = Введённое значение имеет неверный формат для типа { $type }
cmd-cvar-compl-list = Вывести доступные CVar
cmd-cvar-arg-name = <имя | ?>
cmd-cvar-value-hidden = <значение скрыто>

## 'cvar_subs' command
cmd-cvar_subs-desc = Выводит подписки OnValueChanged для CVar.
cmd-cvar_subs-help = Использование: { $command } <имя>

cmd-cvar_subs-invalid-args = Необходимо передать ровно один аргумент.
cmd-cvar_subs-arg-name = <имя>

## 'list' command
cmd-list-desc = Выводит список доступных команд с необязательным поисковым фильтром.
cmd-list-help = Использование: { $command } [фильтр]
    Выводит список всех доступных команд. Если передан аргумент, он используется для фильтрации команд по имени.

cmd-list-heading = СТОРОНА ИМЯ            ОПИСАНИЕ{ "\u000A" }-------------------------{ "\u000A" }

cmd-list-arg-filter = [filter]

## '>' command, aka remote exec
cmd-remoteexec-desc = Выполняет команды на стороне сервера.
cmd-remoteexec-help = Использование: > <команда> [арг] [арг] [арг...]
    Выполняет команду на сервере. Это необходимо, если на клиенте существует команда с таким же именем, так как простой запуск команды выполнил бы сначала клиентскую.

## 'gc' command
cmd-gc-desc = Запускает GC (сборщик мусора).
cmd-gc-help = Использование: { $command } [поколение]
    Использует GC.Collect() для запуска сборщика мусора.
    Если передан аргумент, он разбирается как номер поколения GC и используется GC.Collect(int).
    Используйте команду 'gfc' для полной сборки мусора с уплотнением LOH.
cmd-gc-failed-parse = Не удалось разобрать аргумент.
cmd-gc-arg-generation = [generation]

## 'gcf' command
cmd-gcf-desc = Запускает GC полностью, с уплотнением LOH и всего остального.
cmd-gcf-help = Использование: { $command }
    Выполняет полный GC.Collect(2, GCCollectionMode.Forced, true, true) с одновременным уплотнением LOH.
    Скорее всего, это подвесит игру на сотни миллисекунд, имейте в виду.

## 'gc_mode' command
cmd-gc_mode-desc = Меняет/показывает режим задержки GC.
cmd-gc_mode-help = Использование: { $command } [тип]
    Если аргумент не передан, возвращает текущий режим задержки GC.
    Если аргумент передан, он разбирается как GCLatencyMode и устанавливается в качестве режима задержки GC.

cmd-gc_mode-current = текущий режим задержки gc: { $prevMode }
cmd-gc_mode-possible = возможные режимы:
cmd-gc_mode-option = - { $mode }
cmd-gc_mode-unknown = неизвестный режим задержки gc: { $arg }
cmd-gc_mode-attempt = попытка смены режима задержки gc: { $prevMode } -> { $mode }
cmd-gc_mode-result = итоговый режим задержки gc: { $mode }
cmd-gc_mode-arg-type = [type]

## 'mem' command
cmd-mem-desc = Выводит информацию об управляемой памяти.
cmd-mem-help = Использование: { $command }

cmd-mem-report = Размер кучи: { TOSTRING($heapSize, "N0") }
    Всего выделено: { TOSTRING($totalAllocated, "N0") }

## 'physics' command
cmd-physics-overlay = { $overlay } не является известным оверлеем

## 'lsasm' command
cmd-lsasm-desc = Выводит список загруженных сборок по контексту загрузки.
cmd-lsasm-help = Использование: lsasm

## 'exec' command
cmd-exec-desc = Выполняет файл сценария из перезаписываемых пользовательских данных игры.
cmd-exec-help = Использование: { $command } <имя файла>
    Каждая строка файла выполняется как отдельная команда, если она не начинается с #

cmd-exec-arg-filename = <имя файла>

## 'dump_net_comps' command
cmd-dump_net_comps-desc = Выводит таблицу сетевых компонентов.
cmd-dump_net_comps-help = Использование: { $command }

cmd-dump_net_comps-error-writeable = Регистрация всё ещё доступна для записи, сетевые id не сгенерированы.
cmd-dump_net_comps-header = Регистрации сетевых компонентов:

## 'dump_event_tables' command
cmd-dump_event_tables-desc = Выводит таблицы направленных событий для сущности.
cmd-dump_event_tables-help = Использование: { $command } <entityUid>

cmd-dump_event_tables-missing-arg-entity = Отсутствует аргумент сущности
cmd-dump_event_tables-error-entity = Неверная сущность
cmd-dump_event_tables-arg-entity = <entityUid>

## 'monitor' command
cmd-monitor-desc = Переключает отладочный монитор в меню F3.
cmd-monitor-help = Использование: { $command } <имя>
    Возможные мониторы: { $monitors }
    Также можно использовать специальные значения "-all" и "+all", чтобы скрыть или показать все мониторы соответственно.

cmd-monitor-arg-monitor = <монитор>
cmd-monitor-invalid-name = Неверное имя монитора
cmd-monitor-arg-count = Отсутствует аргумент монитора
cmd-monitor-minus-all-hint = Скрывает все мониторы
cmd-monitor-plus-all-hint = Показывает все мониторы


## 'setambientlight' command
cmd-set-ambient-light-desc = Позволяет задать окружающее освещение для указанной карты в SRGB.
cmd-set-ambient-light-help = Использование: { $command } [mapid] [r g b a]
cmd-set-ambient-light-parse = Не удалось разобрать аргументы как значения байтов цвета.

## Mapping commands

cmd-savemap-desc = Сериализует карту на диск. Карту после инициализации не сохранит, если не принудить.
cmd-savemap-help = Использование: { $command } <MapID> <путь> [force]
cmd-savemap-not-exist = Целевой карты не существует.
cmd-savemap-init-warning = Попытка сохранить карту после инициализации без принуждения.
cmd-savemap-attempt = Попытка сохранить карту { $mapId } в { $path }.
cmd-savemap-success = Карта успешно сохранена.
cmd-savemap-error = Не удалось сохранить карту! Подробности в журнале сервера.
cmd-hint-savemap-id = <ID карты>
cmd-hint-savemap-path = <путь>
cmd-hint-savemap-force = [bool]

cmd-loadmap-desc = Загружает карту с диска в игру.
cmd-loadmap-help = Использование: { $command } <MapID> <путь> [x] [y] [rotation] [consistentUids]
cmd-loadmap-nullspace = Нельзя загрузить в карту 0.
cmd-loadmap-exists = Карта { $mapId } уже существует.
cmd-loadmap-success = Карта { $mapId } загружена из { $path }.
cmd-loadmap-error = При загрузке карты из { $path } произошла ошибка.
cmd-hint-loadmap-x-position = [x-position]
cmd-hint-loadmap-y-position = [y-position]
cmd-hint-loadmap-rotation = [rotation]
cmd-hint-loadmap-uids = [float]

cmd-hint-savebp-id = <EntityID грида>

## 'flushcookies' command
# Note: the flushcookies command is from Robust.Client.WebView, it's not in the main engine code.

cmd-flushcookies-desc = Сбрасывает хранилище cookie CEF на диск.
cmd-flushcookies-help = Использование: { $command }
    Это гарантирует, что cookie будут корректно сохранены на диск при аварийном завершении работы.
    Учтите, что сама операция выполняется асинхронно.

cmd-ldrsc-desc = Предварительно кэширует ресурс.
cmd-ldrsc-help = Использование: { $command } <путь> <тип>

cmd-rldrsc-desc = Перезагружает ресурс.
cmd-rldrsc-help = Использование: { $command } <путь> <тип>

cmd-gridtc-desc = Получает количество плиток грида.
cmd-gridtc-help = Использование: { $command } <gridId>


# Client-side commands
cmd-guidump-desc = Выгружает дерево GUI в /guidump.txt в пользовательских данных.
cmd-guidump-help = Использование: { $command }

cmd-uitest-desc = Открывает тестовое окно интерфейса-пустышку.
cmd-uitest-help = Использование: { $command }

## 'uitest2' command
cmd-uitest2-desc = Открывает окно ОС для тестирования элементов интерфейса.
cmd-uitest2-help = Использование: { $command } <вкладка>
cmd-uitest2-arg-tab = <вкладка>
cmd-uitest2-error-args = Ожидается не более одного аргумента
cmd-uitest2-error-tab = Неверная вкладка: '{ $value }'
cmd-uitest2-title = UITest2


cmd-setclipboard-desc = Задаёт содержимое системного буфера обмена.
cmd-setclipboard-help = Использование: { $command } <текст>

cmd-getclipboard-desc = Получает содержимое системного буфера обмена.
cmd-getclipboard-help = Использование: { $command }

cmd-togglelight-desc = Переключает отрисовку освещения.
cmd-togglelight-help = Использование: { $command }

cmd-togglefov-desc = Переключает поле зрения для клиента.
cmd-togglefov-help = Использование: { $command }

cmd-togglehardfov-desc = Переключает жёсткое поле зрения для клиента. (для отладки space-station-14#2353)
cmd-togglehardfov-help = Использование: { $command }

cmd-toggleshadows-desc = Переключает отрисовку теней.
cmd-toggleshadows-help = Использование: { $command }

cmd-togglelightbuf-desc = Переключает отрисовку освещения. Включает тени, но не поле зрения.
cmd-togglelightbuf-help = Использование: { $command }

cmd-chunkinfo-desc = Получает информацию о чанке под курсором мыши.
cmd-chunkinfo-help = Использование: { $command }

cmd-chunkentities-desc = Выводит сущности чанков в области просмотра клиента ИЛИ в указанном диапазоне.
cmd-chunkentities-help = Использование: { $command } [<корневая сущность> <x> <y> <диапазон>]
cmd-chunkentities-error-invalid-root = Неверная корневая сущность: { $root }
cmd-chunkentities-error-parse = x, y и диапазон должны быть числами.
cmd-chunkentities-error-nullspace = Текущий глаз находится в нуль-пространстве.
cmd-chunkentities-error-no-map = Нет сущности карты для карты текущего глаза { $map }.
cmd-chunkentities-range-header = Сущности чанков для { $root } вокруг ({ $x }, { $y }), диапазон { $range }:
cmd-chunkentities-viewport-header = Сущности чанков в области просмотра клиента на карте { $map } ({ $viewport }):
cmd-chunkentities-total = Всего: { $count }
cmd-chunkentities-root-count = Корень { $root }: { $count }
cmd-chunkentities-entry = { $netEntity } uid={ $uid } корень={ $root } чанк={ $chunk } компонентов={ $componentCount } { $name }
cmd-chunkentities-arg-root = <корневая сущность>
cmd-chunkentities-arg-x = <x>
cmd-chunkentities-arg-y = <y>
cmd-chunkentities-arg-range = <диапазон>

cmd-rldshader-desc = Перезагружает все шейдеры.
cmd-rldshader-help = Использование: { $command }

cmd-cldbglyr-desc = Переключает отладочные слои поля зрения и освещения.
cmd-cldbglyr-help= Использование: { $command } <слой>: Переключить <слой>
    cldbglyr: Выключить все слои

cmd-key-info-desc = Выводит информацию о клавише.
cmd-key-info-help = Использование: { $command } <клавиша>

## 'bind' command
cmd-bind-desc = Привязывает комбинацию клавиш ввода к команде ввода.
cmd-bind-help = Использование: { $command } { cmd-bind-arg-key } { cmd-bind-arg-mode } { cmd-bind-arg-command }
    Учтите, что это НЕ сохраняет привязки автоматически.
    Используйте команду 'svbind', чтобы сохранить конфигурацию привязок.

cmd-bind-arg-key = <ИмяКлавиши>
cmd-bind-arg-mode = <РежимПривязки>
cmd-bind-arg-command = <КомандаВвода>

cmd-net-draw-interp-desc = Переключает отладочную отрисовку сетевой интерполяции.
cmd-net-draw-interp-help = Использование: { $command }

cmd-net-watch-ent-desc = Выводит в консоль все сетевые обновления для EntityId.
cmd-net-watch-ent-help = Использование: { $command } <0|EntityUid>

cmd-net-refresh-desc = Запрашивает полное состояние сервера.
cmd-net-refresh-help = Использование: { $command }

cmd-net-entity-report-desc = Переключает панель отчёта о сетевых сущностях.
cmd-net-entity-report-help = Использование: { $command }

cmd-fill-desc = Заполняет консоль для отладки.
cmd-fill-help = Использование: { $command }
                Заполняет консоль всякой ерундой для отладки.

cmd-cls-desc = Очищает консоль.
cmd-cls-help = Использование: { $command }
               Очищает отладочную консоль от всех сообщений.

cmd-sendgarbage-desc = Отправляет мусор на сервер.
cmd-sendgarbage-help = Использование: { $command }
                       Сервер ответит 'no u'

cmd-loadgrid-desc = Загружает грид из файла в существующую карту.
cmd-loadgrid-help = Использование: { $command } <MapID> <путь> [x y] [rotation] [storeUids]

cmd-loc-desc = Выводит в консоль абсолютные координаты сущности игрока.
cmd-loc-help = Использование: { $command }

cmd-tpgrid-desc = Телепортирует грид в новое место.
cmd-tpgrid-help = Использование: { $command } <gridId> <X> <Y> [<MapId>]

cmd-rmgrid-desc = Удаляет грид с карты. Грид по умолчанию удалить нельзя.
cmd-rmgrid-help = Использование: { $command } <gridId>

cmd-mapinit-desc = Запускает инициализацию карты.
cmd-mapinit-help = Использование: { $command } <mapID>

cmd-lsmap-desc = Выводит список карт.
cmd-lsmap-help = Использование: { $command }

cmd-lsgrid-desc = Выводит список гридов.
cmd-lsgrid-help = Использование: { $command }

cmd-addmap-desc = Добавляет в раунд новую пустую карту. Если mapID уже существует, команда ничего не делает.
cmd-addmap-help = Использование: { $command } <mapID> [pre-init]

cmd-rmmap-desc = Удаляет карту из мира. Нуль-пространство удалить нельзя.
cmd-rmmap-help = Использование: { $command } <mapId>

cmd-pausemap-desc = Приостанавливает карту, останавливая на ней всю обработку симуляции.
cmd-pausemap-help = Использование: pausemap <ID карты>

cmd-unpausemap-desc = Снимает карту с паузы, возобновляя на ней всю обработку симуляции.
cmd-unpausemap-help = Использование: unpausemap <ID карты>

cmd-querymappaused-desc = Проверяет, приостановлена ли карта.
cmd-querymappaused-help = Использование: querymappaused <ID карты>

cmd-savegrid-desc = Сериализует грид на диск.
cmd-savegrid-help = Использование: { $command } <gridID> <путь>

cmd-testbed-desc = Загружает физический тестовый стенд на указанную карту.
cmd-testbed-help = Использование: { $command } <mapid> <тест>

## 'flushcookies' command
# Note: the flushcookies command is from Robust.Client.WebView, it's not in the main engine code.

## 'addcomp' command
cmd-addcomp-desc = Добавляет компонент сущности.
cmd-addcomp-help = Использование: { $command } <uid> <componentName>
cmd-addcompc-desc = Добавляет компонент сущности на клиенте.
cmd-addcompc-help = Использование: { $command } <uid> <componentName>

## 'rmcomp' command
cmd-rmcomp-desc = Удаляет компонент у сущности.
cmd-rmcomp-help = Использование: { $command } <uid> <componentName>
cmd-rmcompc-desc = Удаляет компонент у сущности на клиенте.
cmd-rmcompc-help = Использование: { $command } <uid> <componentName>

## 'addview' command
cmd-addview-desc = Позволяет подписаться на вид сущности в отладочных целях.
cmd-addview-help = Использование: { $command } <entityUid>
cmd-addviewc-desc = Позволяет подписаться на вид сущности в отладочных целях.
cmd-addviewc-help = Использование: { $command } <entityUid>

## 'removeview' command
cmd-removeview-desc = Позволяет отписаться от вида сущности в отладочных целях.
cmd-removeview-help = Использование: { $command } <entityUid>

## 'loglevel' command
cmd-loglevel-desc = Меняет уровень журналирования для указанной пилорамы (sawmill).
cmd-loglevel-help = Использование: { $command } <sawmill> <уровень>
      sawmill: метка-префикс сообщений журнала. Именно для неё задаётся уровень.
      уровень: уровень журналирования. Должен совпадать с одним из значений перечисления LogLevel.

cmd-testlog-desc = Записывает тестовое сообщение в журнал sawmill.
cmd-testlog-help = Использование: { $command } <sawmill> <уровень> <сообщение>
    sawmill: метка-префикс записываемого сообщения.
    уровень: уровень журналирования. Должен совпадать с одним из значений перечисления LogLevel.
    сообщение: записываемое сообщение. Возьмите его в двойные кавычки, если хотите использовать пробелы.

## 'vv' command
cmd-vv-desc = Открывает View Variables.
cmd-vv-help = Использование: { $command } <ID сущности|имя интерфейса IoC|имя интерфейса SIoC>

## 'showvelocities' command
cmd-showvelocities-desc = Отображает ваши угловую и линейную скорости.
cmd-showvelocities-help = Использование: { $command }

## 'setinputcontext' command
cmd-setinputcontext-desc = Задаёт активный контекст ввода.
cmd-setinputcontext-help = Использование: { $command } <контекст>

## 'forall' command
cmd-forall-desc = Выполняет команду над всеми сущностями с указанным компонентом.
cmd-forall-help = Использование: { $command } <BQL-запрос> do <команда...>

## 'delete' command
cmd-delete-desc = Удаляет сущность с указанным ID.
cmd-delete-help = Использование: { $command } <UID сущности>

# System commands
cmd-showtime-desc = Показывает время сервера.
cmd-showtime-help = Использование: { $command }

cmd-restart-desc = Корректно перезапускает сервер (а не только раунд).
cmd-restart-help = Использование: { $command }

cmd-shutdown-desc = Корректно выключает сервер.
cmd-shutdown-help = Использование: { $command }
cmd-shutdown-hint-1 = Причина

cmd-saveconfig-desc = Сохраняет конфигурацию сервера в файл конфигурации.
cmd-saveconfig-help = Использование: { $command }

cmd-netaudit-desc = Выводит информацию о безопасности NetMsg.
cmd-netaudit-help = Использование: { $command }

# Player commands
cmd-tp-desc = Телепортирует игрока в любую точку раунда.
cmd-tp-help = Использование: { $command } <x> <y> [<mapID>]

cmd-tpto-desc = Телепортирует текущего игрока или указанных игроков/сущности к первому указанному игроку/сущности.
cmd-tpto-help = Использование: { $command } <имя пользователя|uid> [имя пользователя|NetEntity]...
cmd-tpto-destination-hint = назначение (NetEntity или имя пользователя)
cmd-tpto-victim-hint = телепортируемая сущность (NetEntity или имя пользователя)
cmd-tpto-parse-error = Не удаётся определить сущность или игрока: { $str }

cmd-listplayers-desc = Выводит список всех подключённых игроков.
cmd-listplayers-help = Использование: { $command }

cmd-kick-desc = Кикает подключённого игрока с сервера, отключая его.
cmd-kick-help = Использование: { $command } <PlayerIndex> [<причина>]

# Spin command
cmd-spin-desc = Заставляет сущность вращаться. По умолчанию — родитель подключённого игрока.
cmd-spin-help = Использование: { $command } скорость [сопротивление] [entityUid]

# Localization command
cmd-rldloc-desc = Перезагружает локализацию (клиент и сервер).
cmd-rldloc-help = Использование: { $command }

# Debug entity controls
cmd-spawn-desc = Создаёт сущность указанного типа.
cmd-spawn-help = Использование: { $command } <прототип> | { $command } <прототип> <ID относительной сущности> | { $command } <прототип> <x> <y>
cmd-cspawn-desc = Создаёт клиентскую сущность указанного типа у ваших ног.
cmd-cspawn-help = Использование: { $command } <тип сущности>

cmd-dumpentities-desc = Выводит список сущностей.
cmd-dumpentities-help = Использование: { $command }
                        Выводит список UID сущностей и прототипов.

cmd-getcomponentregistration-desc = Получает информацию о регистрации компонента.
cmd-getcomponentregistration-help = Использование: { $command } <componentName>

cmd-showrays-desc = Переключает отладочную отрисовку физических лучей. Необходимо передать целое число для <raylifetime>.
cmd-showrays-help = Использование: { $command } <raylifetime>

cmd-disconnect-desc = Немедленно отключается от сервера и возвращает в главное меню.
cmd-disconnect-help = Использование: { $command }

cmd-entfo-desc = Показывает подробную диагностику для сущности.
cmd-entfo-help = Использование: { $command } <entityuid>
    К UID сущности можно добавить префикс 'c', чтобы преобразовать его в UID клиентской сущности.

cmd-fuck-desc = Выбрасывает исключение.
cmd-fuck-help = Использование: { $command }

cmd-showpos-desc = Показывает положение всех сущностей на экране.
cmd-showpos-help = Использование: { $command }

cmd-showrot-desc = Показывает поворот всех сущностей на экране.
cmd-showrot-help = Использование: { $command }

cmd-showvel-desc = Показывает локальную скорость всех сущностей на экране.
cmd-showvel-help = Использование: { $command }

cmd-showangvel-desc = Показывает угловую скорость всех сущностей на экране.
cmd-showangvel-help = Использование: { $command }

cmd-sggcell-desc = Выводит сущности в ячейке привязки к сетке.
cmd-sggcell-help = Использование: { $command } <gridID> <vector2i>\nПараметр vector2i задаётся в форме x<int>,y<int>.

cmd-overrideplayername-desc = Меняет имя, используемое при попытке подключиться к серверу.
cmd-overrideplayername-help = Использование: { $command } <имя>

cmd-showanchored-desc = Показывает закреплённые сущности на определённой плитке.
cmd-showanchored-help = Использование: { $command }

cmd-dmetamem-desc = Выводит члены типа в формате, подходящем для файла конфигурации песочницы.
cmd-dmetamem-help = Использование: { $command } <тип>

cmd-launchauth-desc = Загружает токены аутентификации из данных лаунчера для облегчения тестирования на боевых серверах.
cmd-launchauth-help = Использование: { $command } <имя аккаунта>

cmd-lightbb-desc = Переключает показ ограничивающих рамок освещения.
cmd-lightbb-help = Использование: { $command }

cmd-monitorinfo-desc = Информация о мониторах.
cmd-monitorinfo-help = Использование: { $command } <id>

cmd-setmonitor-desc = Задаёт монитор.
cmd-setmonitor-help = Использование: { $command } <id>

cmd-physics-desc = Показывает отладочный оверлей физики. Переданный аргумент определяет оверлей.
cmd-physics-help = Использование: { $command } <aabbs / com / contactnormals / contactpoints / distance / joints / shapeinfo / shapes>

cmd-hardquit-desc = Мгновенно убивает игровой клиент.
cmd-hardquit-help = Использование: { $command }
                    Мгновенно убивает игровой клиент, не оставляя следов. Даже не попрощавшись с сервером.

cmd-quit-desc = Корректно завершает работу игрового клиента.
cmd-quit-help = Использование: { $command }
                Корректно завершает работу игрового клиента, уведомляя подключённый сервер и так далее.

cmd-csi-desc = Открывает интерактивную консоль C#.
cmd-csi-help = Использование: { $command }

cmd-scsi-desc = Открывает интерактивную консоль C# на сервере.
cmd-scsi-help = Использование: { $command }

cmd-watch-desc = Открывает окно наблюдения за переменными.
cmd-watch-help = Использование: { $command }

cmd-showspritebb-desc = Переключает показ границ спрайтов.
cmd-showspritebb-help = Использование: { $command }

cmd-togglelookup-desc = Показывает / скрывает границы entitylookup через оверлей.
cmd-togglelookup-help = Использование: { $command }

cmd-net_entityreport-desc = Переключает панель отчёта о сетевых сущностях.
cmd-net_entityreport-help = Использование: { $command }

cmd-net_refresh-desc = Запрашивает полное состояние сервера.
cmd-net_refresh-help = Использование: { $command }

cmd-net_graph-desc = Переключает панель сетевой статистики.
cmd-net_graph-help = Использование: { $command }

cmd-net_watchent-desc = Выводит в консоль все сетевые обновления для EntityId.
cmd-net_watchent-help = Использование: { $command } <0|EntityUid>

cmd-net_draw_interp-desc = Переключает отладочную отрисовку сетевой интерполяции.
cmd-net_draw_interp-help = Использование: { $command } <0|EntityUid>

cmd-vram-desc = Показывает статистику использования видеопамяти игрой.
cmd-vram-help = Использование: { $command }

cmd-showislands-desc = Показывает физические тела, входящие в каждый физический остров.
cmd-showislands-help = Использование: { $command }

cmd-showgridnodes-desc = Показывает узлы, используемые для разделения гридов.
cmd-showgridnodes-help = Использование: { $command }

cmd-profsnap-desc = Делает снимок профилирования.
cmd-profsnap-help = Использование: { $command }

cmd-devwindow-desc = Окно разработчика.
cmd-devwindow-help = Использование: { $command }

cmd-scene-desc = Немедленно меняет сцену/состояние интерфейса.
cmd-scene-help = Использование: { $command } <className>

cmd-szr_stats-desc = Выводит статистику сериализатора.
cmd-szr_stats-help = Использование: { $command }

cmd-hwid-desc = Возвращает текущий HWID (идентификатор оборудования).
cmd-hwid-help = Использование: { $command }

cmd-vvread-desc = Получает значение по пути через VV (View Variables).
cmd-vvread-help = Использование: { $command } <путь>

cmd-vvwrite-desc = Изменяет значение по пути через VV (View Variables).
cmd-vvwrite-help = Использование: { $command } <путь>

cmd-vvinvoke-desc = Вызывает путь с аргументами через VV.
cmd-vvinvoke-help = Использование: { $command } <путь> [аргументы...]

cmd-dump_dependency_injectors-desc = Выводит кэш внедрителей зависимостей IoCManager.
cmd-dump_dependency_injectors-help = Использование: { $command }
cmd-dump_dependency_injectors-total-count = Всего: { $total }

cmd-dump_netserializer_type_map-desc = Выводит карту типов NetSerializer и хэш сериализатора.
cmd-dump_netserializer_type_map-help = Использование: { $command }

cmd-hub_advertise_now-desc = Немедленно рекламирует сервер на главном хабе.
cmd-hub_advertise_now-help = Использование: { $command }

cmd-echo-desc = Выводит аргументы обратно в консоль.
cmd-echo-help = Использование: { $command } "<сообщение>"

## 'vfs_ls' command
cmd-vfs_ls-desc = Выводит содержимое каталога в VFS.
cmd-vfs_ls-help = Использование: { $command } <путь>
    Пример:
    vfs_list /Assemblies

cmd-vfs_ls-err-args = Нужен ровно 1 аргумент.
cmd-vfs_ls-hint-path = <путь>

cmd-reloadtiletextures-desc = Перезагружает атлас текстур плиток, позволяя горячую перезагрузку спрайтов плиток.
cmd-reloadtiletextures-help = Использование: { $command }

cmd-audio_length-desc = Показывает длину аудиофайла
cmd-audio_length-help = Использование: { $command } { cmd-audio_length-arg-file-name }
cmd-audio_length-arg-file-name = <имя файла>

## PVS
cmd-pvs-override-info-desc = Выводит информацию о любых переопределениях PVS, связанных с сущностью.
cmd-pvs-override-info-empty = У сущности { $nuid } нет переопределений PVS.
cmd-pvs-override-info-global = У сущности { $nuid } есть глобальное переопределение.
cmd-pvs-override-info-clients = У сущности { $nuid } есть переопределение сессии для { $clients }.

cmd-localization_set_culture-desc = Задаёт DefaultCulture для клиентского LocalizationManager.
cmd-localization_set_culture-help = Использование: { $command } <cultureName>
cmd-localization_set_culture-culture-name = <название культуры>
cmd-localization_set_culture-changed = Локализация изменена на { $code } ({ $nativeName } / { $englishName })

cmd-addmap-hint-2 = инициализация карты [true / false]
