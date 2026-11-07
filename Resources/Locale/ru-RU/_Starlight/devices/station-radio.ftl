signal-port-name-vinyl-player = Выход проигрывателя пластинок
signal-port-description-vinyl-player = Музыкальный выход проигрывателя пластинок. Подключается к радиоаппаратуре.

signal-port-name-cd-player = Выход радио-CD-проигрывателя
signal-port-description-cd-player = Выход радио-CD-проигрывателя. Подключается к радиоаппаратуре, играет вместе с виниловым проигрывателем.

signal-port-name-radio-mixer = Выход радиомикшера
signal-port-description-radio-mixer = Управляющий выход радиомикшера. Подключается к радиоаппаратуре, которая питает управляемый сервер.

signal-port-name-radio-rig = Вход радиоаппаратуры
signal-port-description-radio-rig = Вход радиоаппаратуры: подключите к нему проигрыватель пластинок, а затем подключите аппаратуру к радиосерверу.

signal-port-name-radio-server = Вход сервера
signal-port-description-radio-server = Вход радиосервера: подключите к нему радиоаппаратуру, чтобы музыка играла по всей станции!

vinyl-popout-no-station = Пластинка выскакивает: вы не на станции!
vinyl-popout-no-power = Пластинка выскакивает: проигрыватель не запитан!
vinyl-popout-no-radio-connection = Пластинка выскакивает: проигрыватель не подключён к радиосистеме!

vinyl-player-examine-empty = Он пуст.
vinyl-player-examine-loaded = Внутри лежит копия { $vinyl }.
vinyl-player-examine-playing = Играет.
vinyl-player-examine-paused = На паузе.
vinyl-player-verb-play = Воспроизвести
vinyl-player-verb-pause = Пауза
vinyl-player-verb-rewind = Перемотать
vinyl = винил
station-radio-server-cancelled-anchor = Эта станция уже имеет радио сервер!

station-radio-receiver-examine-full-volume = Играет на полной громкости.
station-radio-receiver-examine-low-volume = Играет на низкой громкости.
ui-options-radio-music-volume = Громкость музыки радио:

station-radio-server-examine-recording = Сервер станции не записывает.
station-radio-server-examine-not-recording = Сервер станции сейчас записывает.

station-radio-server-microphone-on-use = Микрофон { $radioState }.

item-slot-component-slot-name-vinyl = пластинка
item-slot-component-slot-name-cd = компакт-диск

station-radio-mixer-title = Радиомикшер
station-radio-mixer-no-server = Не подключён к запитанному радиосерверу. Подключите микшер к радиоаппаратуре.
station-radio-mixer-voice = Голос
station-radio-mixer-master = Общая громкость
station-radio-mixer-monitor = Монитор
station-radio-mixer-level = { $level }%
station-radio-mixer-empty = нет диска
station-radio-mixer-playlist = Плейлист
station-radio-mixer-next = Далее
station-radio-mixer-eject = Извлечь
station-radio-mixer-tracks = Треков: { $name }
station-radio-mixer-track = { $number }. { $disc }

signal-port-name-broadcast-recorder = Выход радиорекордера
signal-port-description-broadcast-recorder = Связь радиорекордера. Подключите к радиоаппаратуре, чтобы записывать и воспроизводить трансляцию этого сервера.
item-slot-component-slot-name-broadcast-tape = кассета с эфиром

broadcast-recorder-title = Радиорекордер
broadcast-recorder-no-tape = Нет кассеты
broadcast-recorder-no-server = Не подключён к запитанному радиосерверу. Подключите радиорекордер к радиоаппаратуре.
broadcast-recorder-mode-stopped = Остановлен
broadcast-recorder-mode-recording = Запись
broadcast-recorder-mode-playing = Воспроизведение
broadcast-recorder-record = Записать
broadcast-recorder-play = Воспроизвести
broadcast-recorder-stop = Стоп
broadcast-recorder-rewind = Перемотать
broadcast-recorder-popup-no-tape = В радиорекордере нет кассеты.
broadcast-recorder-popup-no-power = У рекордера нет питания.
broadcast-recorder-popup-no-server = Радиорекордер не подключён к запитанному радиосерверу.
broadcast-recorder-popup-tape-full = Кассета заполнена.
broadcast-tape-examine = Записано [color=yellow]{ $recorded }[/color] из [color=yellow]{ $max }[/color].

wire-name-station-radio-music = МУЗ
wire-name-station-radio-microphone = МИК
wire-name-station-radio-interference = ПОМХ

radio-advert-popup-paid = Реклама принесла { $reward } кредитов от { $listeners } { $listeners ->
    [one] слушателя
    [few] слушателей
    *[other] слушателей
} (чистый эфир: { $quality }%).
radio-advert-popup-repeat = Слушатели недавно уже слышали эту рекламу, она ничего не приносит.
radio-advert-popup-no-listeners = Рекламу никто не слушал.
radio-advert-popup-too-soon = Слушатели устали от рекламы, подождите ещё { $minutes } { $minutes ->
    [one] минуту
    [few] минуты
    *[other] минут
} до следующей оплачиваемой.
radio-advert-popup-drowned = Рекламу заглушили музыка или разговоры, она ничего не принесла.

station-radio-mixer-listeners = Слушателей: { $count }
station-radio-mixer-interference = Помехи в эфире!

station-radio-receiver-title = Радио станции
station-radio-receiver-power = Питание
station-radio-receiver-knob = Громкость: перетаскивайте или прокручивайте

record-crate-full = Ящик заполнен.
record-crate-examine = В нём [color=yellow]{ $count }[/color] из { $capacity } пластинок.
