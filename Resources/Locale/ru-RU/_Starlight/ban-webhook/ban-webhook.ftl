server-ban-string-infinity = Вечно
server-ban-no-name = Не найдено. ({ $hwid })
server-time-ban =
    Временный бан на { $mins } { $mins ->
        [one] минуту
        [few] минуты
        *[other] минут
    }.
server-perma-ban = Перманентный бан.
server-role-ban =
    Временный джоб-бан на { $mins } { $mins ->
        [one] минуту
        [few] минуты
        *[other] минут
    }.
server-perma-role-ban = Перманентный джоб-бан.
server-time-ban-string =
    > **Сервер:** ``{ $serverName }``

    > **Нарушитель**
    > **Логин:** ``{ $targetName }``
    > **Дискорд:** { $targetLink }

    > **Администратор**
    > **Логин:** ``{ $adminName }``
    > **Дискорд:** { $adminLink }

    > **Выдан:** { $TimeNow }
    > **Истечёт:** { $expiresString }

    > **Уровень нарушения:** { $severity }

    >>> **Причина:** { $reason }
server-ban-footer = { $server } | Раунд: #{ $round }
server-perma-ban-string =
    > **Сервер:** ``{ $serverName }``

    > **Нарушитель**
    > **Логин:** ``{ $targetName }``
    > **Дискорд:** { $targetLink }

    > **Администратор**
    > **Логин:** ``{ $adminName }``
    > **Дискорд:** { $adminLink }

    > **Выдан:** { $TimeNow }

    > **Уровень нарушения:** { $severity }

    >>> **Причина:** { $reason }
server-role-ban-string =
    > **Сервер:** ``{ $serverName }``

    > **Нарушитель**
    > **Логин:** ``{ $targetName }``
    > **Дискорд:** { $targetLink }

    > **Администратор**
    > **Логин:** ``{ $adminName }``
    > **Дискорд:** { $adminLink }

    > **Выдан:** { $TimeNow }
    > **Истечёт:** { $expiresString }

    > **Роли:** { $roles }

    > **Уровень нарушения:** { $severity }

    >>> **Причина:** { $reason }
server-perma-role-ban-string =
    > **Сервер:** ``{ $serverName }``

    > **Нарушитель**
    > **Логин:** ``{ $targetName }``
    > **Дискорд:** { $targetLink }

    > **Администратор**
    > **Логин:** ``{ $adminName }``
    > **Дискорд:** { $adminLink }

    > **Выдан:** { $TimeNow }

    > **Роли:** { $roles }

    > **Уровень нарушения:** { $severity }

    >>> **Причина:** { $reason }
