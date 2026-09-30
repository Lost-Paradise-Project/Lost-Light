# Playback Commands

cmd-replay-play-desc = Возобновить воспроизведение записи.
cmd-replay-play-help = replay_play

cmd-replay-pause-desc = Приостановить воспроизведение записи
cmd-replay-pause-help = replay_pause

cmd-replay-toggle-desc = Возобновить или приостановить воспроизведение записи.
cmd-replay-toggle-help = replay_toggle

cmd-replay-toggle-screenshot-mode-desc = Переключает режим скриншота для записей, скрывая виджет управления записью.
cmd-replay-toggle-screenshot-mode-help = replay_toggle_screenshot_mode

cmd-replay-stop-desc = Остановить и выгрузить запись.
cmd-replay-stop-help = replay_stop

cmd-replay-load-desc = Загрузить и запустить запись.
cmd-replay-load-help = replay_load <replay folder>
cmd-replay-load-hint = Папка записи

cmd-replay-skip-desc = Перемотать вперёд или назад по времени.
cmd-replay-skip-help = replay_skip <tick or timespan>
cmd-replay-skip-hint = Тики или промежуток времени (ЧЧ:ММ:СС).

cmd-replay-set-time-desc = Перейти вперёд или назад к определённому времени.
cmd-replay-set-time-help = replay_set <tick or time>
cmd-replay-set-time-hint = Тик или промежуток времени (ЧЧ:ММ:СС), начиная с

cmd-replay-error-time = "{ $time }" не является целым числом или промежутком времени.
cmd-replay-error-args = Неверное число аргументов.
cmd-replay-error-no-replay = Запись сейчас не воспроизводится.
cmd-replay-error-already-loaded = Запись уже загружена.
cmd-replay-error-run-level = Нельзя загрузить запись, будучи подключённым к серверу.

cmd-replay-toggleui-desc = Переключение пользовательского интерфейса управления воспроизведением.

# Recording commands

cmd-replay-recording-start-desc = Начинает запись реплея, при желании с ограничением по времени.
cmd-replay-recording-start-help = Использование: replay_recording_start [имя] [overwrite] [ограничение времени]
cmd-replay-recording-start-success = Запись реплея начата.
cmd-replay-recording-start-already-recording = Запись реплея уже идёт.
cmd-replay-recording-start-error = При попытке начать запись произошла ошибка.
cmd-replay-recording-start-hint-time = [time limit (minutes)]
cmd-replay-recording-start-hint-name = [name]
cmd-replay-recording-start-hint-overwrite = [overwrite (bool)]

cmd-replay-recording-stop-desc = Останавливает запись реплея.
cmd-replay-recording-stop-help = Использование: replay_recording_stop
cmd-replay-recording-stop-success = Запись реплея остановлена.
cmd-replay-recording-stop-not-recording = Запись реплея сейчас не идёт.

cmd-replay-recording-stats-desc = Показывает информацию о текущей записи реплея.
cmd-replay-recording-stats-help = Использование: replay_recording_stats
cmd-replay-recording-stats-result = Длительность: { $time } мин, тиков: { $ticks }, размер: { $size } МБ, скорость: { $rate } МБ/мин.


# Time Control UI
replay-time-box-scrubbing-label = Динамическая перемотка
replay-time-box-replay-time-label = Время записи: { $current } / { $end }  ({ $percentage }%)
replay-time-box-server-time-label = Время сервера: { $current } / { $end }
replay-time-box-index-label = Индекс: { $current } / { $total }
replay-time-box-tick-label = Тик: { $current } / { $total }
