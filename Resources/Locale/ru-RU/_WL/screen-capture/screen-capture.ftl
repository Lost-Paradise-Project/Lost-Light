image-window-title = Изображение
image-window-title-player = Снимок экрана { $player } ({ $type })
screen-capture-type-clyde = окно целиком
screen-capture-type-viewport = только сцена

screen-capture-error-timeout = Клиент { $player } не прислал снимок экрана за отведённое время. Возможно, клиент изменён.
screen-capture-error-repeat-request = Запрос снимка экрана уже отправлен. Дождитесь ответа.
screen-capture-error-disconnected = { $player } отключился, не прислав снимок экрана.
screen-capture-error-client = Клиент { $player } не смог сделать снимок экрана. Попробуйте другой способ (capturescreenclyde или capturescreenviewport).
screen-capture-error-invalid = Клиент { $player } прислал некорректный снимок экрана (неверный формат или размер). Возможно, клиент изменён.
screen-capture-error-decode = Не удалось открыть снимок экрана

cmd-capturescreenclyde-desc = Делает снимок всего окна игры игрока: интерфейс, худы, оверлеи. Если пришёл чёрный экран, используйте capturescreenviewport.
cmd-capturescreenclyde-help = capturescreenclyde <пользователь>
cmd-capturescreenviewport-desc = Делает снимок только игровой сцены игрока, без интерфейса. Для клиентов, где не работает capturescreenclyde.
cmd-capturescreenviewport-help = capturescreenviewport <пользователь>
