## Strings for the "grant_connect_bypass" command.

cmd-grant_connect_bypass-desc = Временно позволяет пользователю обходить обычные проверки подключения.
cmd-grant_connect_bypass-help = Использование: grant_connect_bypass <пользователь> [длительность в минутах]
    Временно даёт пользователю возможность обходить обычные ограничения подключения.
    Обход действует только на этом игровом сервере и истекает (по умолчанию) через 1 час.
    Пользователь сможет зайти независимо от белого списка, панического бункера и лимита игроков.

cmd-grant_connect_bypass-arg-user = <пользователь>
cmd-grant_connect_bypass-arg-duration = [duration minutes]

cmd-grant_connect_bypass-invalid-args = Ожидался 1 или 2 аргумента
cmd-grant_connect_bypass-unknown-user = Не удалось найти пользователя '{ $user }'
cmd-grant_connect_bypass-invalid-duration = Неверная длительность '{ $duration }'

cmd-grant_connect_bypass-success = Обход успешно добавлен для пользователя '{ $user }'
