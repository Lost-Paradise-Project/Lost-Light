command-list-langs-desc = Перечисляет языки, на которых ваша текущая сущность может говорить в данный момент.
command-list-langs-help = Использование: { $command }
command-saylang-desc = Отправляет сообщение на определённом языке. Чтобы выбрать язык, можно указать его название или его номер в списке языков.
command-saylang-help = Использование: { $command } <ID языка> <сообщение>. Пример: { $command } GalacticCommon "Hello World!". Пример: { $command } 1 "Hello World!"
command-language-select-desc = Выбирает язык, на котором в данный момент говорит ваша сущность. Можно указать название языка или его номер в списке языков.
command-language-select-help = Использование: { $command } <ID языка>. Пример: { $command } 1. Пример: { $command } GalacticCommon
command-language-spoken = Говорит:
command-language-understood = Понимает:
command-language-current-entry = { $id }. { $language } — { $name } (текущий)
command-language-entry = { $id }. { $language } — { $name }
command-language-invalid-number = Номер языка должен быть от 0 до { $total }. Также можно использовать название языка.
command-language-invalid-language = Язык { $id } не существует, или вы не можете на нём говорить.
# Toolshed

command-description-language-add = Добавляет новый язык сущности из конвейера. Два последних аргумента указывают, может ли она на нём говорить и понимать его. Пример: 'self language:add "Canilunzt" true true'
command-description-language-rm = Удаляет язык у сущности из конвейера. Работает аналогично language:add. Пример: 'self language:rm "GalacticCommon" true true'.
command-description-language-lsspoken = Перечисляет все языки, на которых сущность может говорить. Пример: 'self language:lsspoken'
command-description-language-lsunderstood = Перечисляет все языки, которые сущность может понимать. Пример: 'self language:lssunderstood'
command-description-translator-addlang = Добавляет новый целевой язык переводчику из конвейера. Подробности см. в language:add.
command-description-translator-rmlang = Удаляет целевой язык у переводчика из конвейера. Подробности см. в language:rm.
command-description-translator-addrequired = Добавляет новый требуемый язык переводчику из конвейера. Пример: 'ent 1234 translator:addrequired "GalacticCommon"'
command-description-translator-rmrequired = Удаляет требуемый язык у переводчика из конвейера. Пример: 'ent 1234 translator:rmrequired "GalacticCommon"'
command-description-translator-lsspoken = Перечисляет все разговорные языки переводчика из конвейера. Пример: 'ent 1234 translator:lsspoken'
command-description-translator-lsunderstood = Перечисляет все понимаемые языки переводчика из конвейера. Пример: 'ent 1234 translator:lssunderstood'
command-description-translator-lsrequired = Перечисляет все требуемые языки переводчика из конвейера. Пример: 'ent 1234 translator:lsrequired'
command-language-error-this-will-not-work = Это не сработает.
command-language-error-not-a-translator = Сущность { $entity } не является переводчиком.
