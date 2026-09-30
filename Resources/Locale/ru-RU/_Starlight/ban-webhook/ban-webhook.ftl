server-ban-string-infinity = Навсегда
server-ban-no-name = Не найдено. ({ $hwid })
server-time-ban =
    Временный бан на { $mins } { $mins ->
        [one] минуту
        [few] минуты
        *[other] минут
    }.
server-perma-ban = Постоянный бан
server-role-ban =
    Временный запрет должностей на { $mins } { $mins ->
        [one] минуту
        [few] минуты
        *[other] минут
    }.
server-perma-role-ban = Постоянный запрет должностей
server-time-ban-string =
    > **Нарушитель**
    > **Логин:** ``{ $targetName }``
    > **Discord:** { $targetLink }
    > **Администратор**
    > **Логин:** ``{ $adminName }``
    > **Discord:** { $adminLink }
    > **Время**
    > **Выдан:** { $TimeNow }
    > **Истекает:** { $expiresString }
    > **Причина:** { $reason }
    > **Уровень тяжести:** { $severity }
server-ban-footer = { $server } | Раунд: #{ $round }
server-perma-ban-string =
    > **Нарушитель**
    > **Логин:** ``{ $targetName }``
    > **Discord:** { $targetLink }
    > **Администратор**
    > **Логин:** ``{ $adminName }``
    > **Discord:** { $adminLink }
    > **Время**
    > **Выдан:** { $TimeNow }
    > **Причина:** { $reason }
    > **Уровень тяжести:** { $severity }
server-role-ban-string =
    > **Нарушитель**
    > **Логин:** ``{ $targetName }``
    > **Discord:** { $targetLink }
    > **Администратор**
    > **Логин:** ``{ $adminName }``
    > **Discord:** { $adminLink }
    > **Время**
    > **Выдан:** { $TimeNow }
    > **Истекает:** { $expiresString }
    > **Роли:** { $roles }
    > **Причина:** { $reason }
    > **Уровень тяжести:** { $severity }
server-perma-role-ban-string =
    > **Нарушитель**
    > **Логин:** ``{ $targetName }``
    > **Discord:** ``{ $targetLink }``
    > **Администратор**
    > **Логин:** ``{ $adminName }``
    > **Discord:** { $adminLink }
    > **Время**
    > **Выдан:** { $TimeNow }
    > **Роли:** { $roles }
    > **Причина:** { $reason }
    > **Уровень тяжести:** { $severity }
