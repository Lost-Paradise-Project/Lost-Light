moff-blade-server-rack-window-title = Стойка блейд-серверов
moff-blade-server-rack-window-footer-flavor = ПРОШИВКА УСТРОЙСТВА © 2125 NANOSOFT

moff-blade-server-rack-slot-status = Слот { $index }: { $content }

moff-blade-server-rack-slot-entity-unknown = неизвестно
moff-blade-server-rack-slot-empty = пусто

moff-blade-server-rack-slot-eject = Извлечь
moff-blade-server-rack-slot-insert = Вставить
moff-blade-server-rack-slot-power-toggle = Переключить питание

moff-blade-server-rack-slot-locked-fail = Заблокировано!
moff-blade-server-rack-slot-whitelist-fail = Это не подходит!

moff-blade-server-rack-examine-empty = Она содержит [color=#1f8ab2]ноль блейдов[/color].
moff-blade-server-rack-examine-single = Она содержит только { $slot }.
moff-blade-server-rack-examine-multiple-start = Она содержит
moff-blade-server-rack-examine-multiple-slot-line = - { $slot }
moff-blade-server-rack-examine-slot = [color=#1f8ab2]{ CAPITALIZE($name) }[/color] в слоте { $index }
moff-blade-server-rack-examine-distant =
    Она содержит [color=#1f8ab2]{ $numBlades } { $numBlades ->
        [one] блейд
        [few] блейда
        *[other] блейдов
    }[/color], но с такого расстояния не разобрать, { $numBlades ->
        [one] что это
        *[other] что это
    }.

moff-blade-server-frame-incompatible-board = Эта плата, похоже, несовместима с каркасом...
moff-blade-server-board-compatible-hint = Из неё можно сделать [color=#1f8ab2]блейд-сервер[/color]
