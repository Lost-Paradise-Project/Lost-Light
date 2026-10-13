# Teleport tab


abductors-ui-teleport = Телепортировать
abductors-ui-attract = Притянуть

abductors-ui-gizmo-transferred = Информация о цели передана

# Experiment tab

abductors-ui-experiment = Эксперимент
abductors-ui-complete-experiment = Завершить эксперимент

# Armor tab

abductors-ui-armor-control = Управление бронёй

abductors-ui-combat-mode = Боевой режим
abductors-ui-stealth-mode = Режим скрытности

abductors-ui-lock-armor = Заблокировать броню
abductors-ui-unlock-armor = Разблокировать броню

abductors-ui-vest-linked = Жилет привязан

# Shop tab

abductors-ui-shop = Магазин

abductors-ui-shop-Wonderprod = Чудо-шокер
abductors-ui-shop-WeaponAlien = Пистолет пришельцев
abductors-ui-shop-ClothingHeadHelmetAbductor = Шлем
abductors-ui-shop-AbductorGizmo = Гизмо
abductors-ui-shop-AbductorExtractor = Экстрактор
abductors-ui-shop-MedkitCombat = Боевая аптечка
abductors-ui-shop-VendingMachineRestockAbductorDispenser = пополнение раздатчика пришельцев

# Ghost role, objectives, etc.

abductors-ghost-role-name = Учёный-похититель
abductors-ghost-role-desc = Похищайте людей, набивайте их органами сомнительного происхождения.
abductora-ghost-role-name = Агент-похититель
abductora-ghost-role-desc = Похищайте людей, защищайте учёного.
abductors-ghost-role-rules = Вы — [color=red][bold]Похититель[/bold][/color].
                            Ваша задача — похищать людей со станции и заменять их органы различными экспериментальными устройствами,
                            после чего возвращать их обратно. Вам запрещено уничтожать станцию или намеренно убивать людей.
                            В ваших интересах возвращать подопытных живыми и здоровыми ради чистоты эксперимента.

                            Вы не помните ничего из прошлой жизни и ничего из того, что узнали, будучи призраком.
                            Вам разрешено помнить знания об игре в целом: как готовить, как пользоваться предметами и т. д.
                            Вам категорически [color=red]НЕЛЬЗЯ[/color] помнить, например, имя, внешность и т. п. вашего прошлого персонажа.

abductor-round-end-agent-name = похититель

objective-issuer-abductors = [color=#FD0098]Корабль-матка[/color]

objective-condition-abduct-title = Похитить человек: { $count }.
objective-condition-abduct-description = (используйте гизмо на обездвиженной жертве, затем используйте гизмо на консоли похитителей и выберите действие «притянуть»), затем замените её сердце одной из желёз, поместите её в экспериментатор и нажмите «завершить эксперимент».

abductor-role-greeting = Я профессиональный боевой учёный высокотехнологичной расы. Моя задача — похищать людей, проводить на них эксперименты и возвращать целыми ради чистоты эксперимента. В моих интересах не разрушать станцию, не убивать и не помогать экипажу.

roles-antag-abductor-objective = Похищайте членов экипажа станции и проводите на них свои эксперименты!

abductor-price = Цена: { $price }
abductor-buy = Купить
abductor-pad = площадка: { $found ->
    [true] [color=green]подключена[/color]
    *[false] [color=red]не найдена[/color]
}
abductor-dispencer = раздатчик: { $found ->
    [true] [color=green]подключён[/color]
    *[false] [color=red]не найден[/color]
}
abductor-experimentator = экспериментатор: { $found ->
    [true] [color=green]подключён[/color]
    *[false] [color=red]не найден[/color]
}
abductor-target = цель: [color=green]{ $name }[/color]
abductor-target-none = цель: [color=red]НЕТ[/color]
abductor-victim = жертва: [color=green]{ $name }[/color]
abductor-victim-none = жертва: [color=red]НЕТ[/color]
abductor-need-armor = [color=red][font size=16]Нужно подключить броню похитителя![/font][/color]

abductor-console-balance = Баланс: { $balance }
