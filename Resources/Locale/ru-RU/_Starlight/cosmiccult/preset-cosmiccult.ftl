## COSMIC CULT ROUND, ANTAG & GAMEMODE TEXT

cosmiccult-title = Космический культ
cosmiccult-description = Среди экипажа скрываются культисты.

roles-antag-cosmiccult-name = Космический культист
roles-antag-cosmiccult-description = Приблизьте конец всего сущего через обман и саботаж, промывая мозги тем, кто противится вам.

cosmiccult-gamemode-title = Космический культ
cosmiccult-gamemode-description = Сканеры обнаруживают аномальное увеличение активности нуль-пространства. Дополнительных данных нет.

cosmiccult-vote-steward-initiator = Неведомое
cosmiccult-vote-steward-title = Опека Космического культа
cosmiccult-vote-steward-briefing =
    Вы — Управитель Космического культа!
    Позаботьтесь, чтобы Монумент был размещён в безопасном месте, и организуйте культ для общей победы.
    Вам не разрешено указывать культистам, как использовать или тратить их Энтропию.

cosmiccult-finale-autocall-briefing = Монумент активируется через { $minutesandseconds }! Соберитесь и готовьтесь к концу.
cosmiccult-finale-ready = Из Монумента вырывается ужасающий свет!
cosmiccult-finale-speedup = Призыв ускоряется! Энергия проносится по окрестностям...

cosmiccult-finale-degen = Вы чувствуете, как распадаетесь!
cosmiccult-finale-location = Сканеры фиксируют огромный всплеск активности нуль-пространства { $location }!
cosmiccult-finale-cancel-begin = Сила воли вашего разума начинает разрушать ритуал...
cosmiccult-finale-beckon-begin = Шёпоты на задворках вашего разума усиливаются...
cosmiccult-finale-beckon-success = Вы призываете финальный поклон.

cosmiccult-monument-powerdown = Монумент жутко затихает.


## ROUNDEND TEXT

cosmiccult-roundend-cultist-count = {$initialCount ->
    [1] Был { $initialCount } [color=#4cabb3]космический культист[/color].
    [few] Было { $initialCount } [color=#4cabb3]космических культиста[/color].
    *[other] Было { $initialCount } [color=#4cabb3]космических культистов[/color].
}
cosmiccult-roundend-entropy-count = Культ вытянул Энтропии: { $count }.
cosmiccult-roundend-cultpop-count = Культисты составляли { $count }% экипажа.
cosmiccult-roundend-monument-stage = {$stage ->
    [1] Увы, Монумент, похоже, заброшен.
    [2] Монумент продвинулся, но до завершения было далеко.
    [3] Монумент был завершён.
    *[other] [color=red]Что-то пошло ОЧЕНЬ не так.[/color]
}

cosmiccult-roundend-cultcomplete = [color=#4cabb3]Полная победа Космического культа![/color]
cosmiccult-roundend-cultmajor = [color=#4cabb3]Крупная победа Космического культа![/color]
cosmiccult-roundend-cultminor = [color=#4cabb3]Малая победа Космического культа![/color]
cosmiccult-roundend-neutral = [color=yellow]Нейтральная концовка![/color]
cosmiccult-roundend-crewminor = [color=green]Малая победа экипажа![/color]
cosmiccult-roundend-crewmajor = [color=green]Крупная победа экипажа![/color]
cosmiccult-roundend-crewcomplete = [color=green]Полная победа экипажа![/color]

cosmiccult-summary-cultcomplete = Космические культисты приблизили конец!
cosmiccult-summary-cultmajor = Победа космических культистов будет неизбежна.
cosmiccult-summary-cultminor = Монумент был завершён, но не полностью усилен.
cosmiccult-summary-neutral = Культ доживёт до следующего дня.
cosmiccult-summary-crewminor = Культ остался без управляющего.
cosmiccult-summary-crewmajor = Все космические культисты были уничтожены.
cosmiccult-summary-crewcomplete = Все до единого космические культисты были деконвертированы!

cosmiccult-elimination-shuttle-call = По данным наших сенсоров дальнего действия, аномалия нуль-пространства утихла. Благодарим вас за осмотрительность. На станцию автоматически вызван эвакуационный шаттл для процедур обеззараживания и разбора. Расчётное время прибытия: { $time } { $units }. Обратите внимание: если психологическое воздействие аномалии незначительно, вы можете отозвать шаттл, чтобы продлить смену.
cosmiccult-elimination-announcement = По данным сканирования дальними сенсорами, аномалия нуль-пространства утихла. Благодарим вас за осмотрительность. Эвакуационный шаттл уже на подходе. Безопасно вернитесь в ЦК для дезактивации и процедур опроса.


## BRIEFINGS

cosmiccult-role-roundstart-fluff =
    Пока вы готовитесь к очередной смене на очередной станции НаноТрейзен, в ваш разум вдруг врывается несказанное знание!
    Откровение, не имеющее равных. Конец циклическим, сизифовым страданиям.
    Тихий финальный занавес.
    Всё, что вам нужно, — возвестить о нём.

cosmiccult-role-short-briefing =
    Вы — Космический культист!
    Ваши цели перечислены в меню персонажа.
    Подробнее о вашей роли читайте в статье руководства.

cosmiccult-role-conversion-fluff =
    Когда призыв завершается, в ваш разум вдруг врывается несказанное знание!
    Откровение, не имеющее равных. Конец циклическим, сизифовым страданиям.
    Тихий финальный занавес.
    Всё, что вам нужно, — возвестить о нём.

cosmiccult-role-deconverted-fluff =
    Великая пустота омывает ваш разум. Утешительная, но незнакомая пустота...
    Все мысли и воспоминания о времени в культе начинают меркнуть и расплываться.

cosmiccult-role-deconverted-briefing =
    Обращение отменено!
    Вы больше не Космический культист.

cosmiccult-monument-stage1-briefing =
    Монумент призван.
    Он находится { $location }!

cosmiccult-monument-stage2-briefing =
    Сила Монумента растёт!
    Его влияние затронет реальное пространство через { $time } с.

cosmiccult-monument-stage3-briefing =
    Монумент завершён!
    Его влияние начнёт накладываться на реальное пространство через { $time } с.
    Это последний рывок! Накопите как можно больше энтропии.


## MALIGN RIFTS

cosmiccult-rift-inuse = Сейчас вы не можете этого сделать.
cosmiccult-rift-invaliduser = У вас нет подходящих инструментов, чтобы с этим справиться.
cosmiccult-rift-chaplainoops = Держите в руках своё священное писание.
cosmiccult-rift-lambda-charging = Заряжается взрыв Стабилизатора нуль-пространства...
cosmiccult-rift-bible-charging = Вы начинаете очищать злокозненный разлом...
cosmiccult-rift-alreadyempowered = Вы уже усилены; сила разлома пропала бы зря.
cosmiccult-rift-wasempowered = Ваше тело не справится с усилением во второй раз...
cosmiccult-rift-beginabsorb = Разлом начинает сливаться с вами...
cosmiccult-rift-beginpurge = Ваше освящение начинает изгонять злокозненный разлом...

cosmiccult-rift-absorb = { $NAME } поглощает разлом, и зловещий свет наполняет силой его тело!
cosmiccult-rift-purge = Злокозненный разлом изгнан!


## CHANTRY

cosmiccult-chantry-location = Обнаружен опасный рост активности нуль-пространства { $location }! Немедленно перехватите и вмешайтесь!
cosmiccult-chantry-destruction = Внезапный всплеск активности нуль-пространства нейтрализован. Рекомендуется сохранять бдительность.
cosmiccult-chantry-powerup = Пустотная часовня вспыхивает жизнью!

## UI / BASE POPUP

cosmiccult-ui-deconverted-title = Деконвертирован
cosmiccult-ui-converted-title = Конвертирован
cosmiccult-ui-roundstart-title = Неведомое

cosmiccult-ui-converted-text-1 =
    Вы были обращены в Космического культиста.
cosmiccult-ui-converted-text-2 =
    Помогайте культу в его целях, соблюдая его секретность.
    Сотрудничайте с планами своих собратьев-культистов.

cosmiccult-ui-roundstart-text-1 =
    Вы — Космический культист!
cosmiccult-ui-roundstart-text-2 =
    Помогайте культу в его целях, соблюдая его секретность.
    Слушайте указания своего управителя культа.

cosmiccult-ui-deconverted-text =
    Космическое влияние, связывавшее вас с культом, разорвано.
    Вы больше не Космический культист. Ваш разум снова принадлежит вам.
    Любые дальнейшие проступки фиксируются и наказуемы. Так что ведите себя хорошо.

cosmiccult-ui-deconverted-rule = Напоминание: согласно правилу 3 правил сервера, [bold][color=#a4885c]деконвертированные космические культисты забывают всё, что было, пока они находились во власти космического влияния.[/color][/bold]

cosmiccult-ui-deconverted-ruletext = Ваш персонаж может узнать о случившемся в ходе дальнейших расследований и отыгрыша, но не должен помнить о том, что был культистом, и о своих действиях от имени культа.

cosmiccult-ui-popup-confirm = Подтвердить

## OBJECTIVES / CHARACTERMENU

objective-issuer-cosmiccult = [bold][color=#cae8e8]Неведомое[/color][/bold]

objective-cosmiccult-charactermenu = Вы должны приблизить конец всего сущего. Выполняйте свои задачи, чтобы продвигать прогресс культа.
objective-cosmiccult-steward-charactermenu = Вы должны направлять культ, чтобы приблизить конец всего сущего. Следите за прогрессом культа и обеспечивайте его.

objective-condition-conversion-title = ОБРАЩАЙТЕ ЭКИПАЖ
objective-condition-conversion-desc = Совместно приведите в свои ряды не менее { $count } членов экипажа.
objective-condition-entropy-title = ВЫКАЧИВАЙТЕ ЭНТРОПИЮ
objective-condition-entropy-desc = Совместно вытяните из экипажа не менее { $count } энтропии.
objective-condition-culttier-title = УСИЛЬТЕ МОНУМЕНТ
objective-condition-culttier-desc = Обеспечьте, чтобы Монумент был доведён до полной мощи.
objective-condition-chaplain-title = ПОДОРВИТЕ ИХ ПАСТЫРЕЙ
objective-condition-chaplain-desc = Обратите как можно больше священников.
objective-condition-victory-title = ПРИБЛИЗЬТЕ КОНЕЦ
objective-condition-victory-desc = Призовите Неведомое и возвестите финальный поклон.


## CHAT ANNOUNCEMENTS

cosmiccult-announcement-sender = Неведомое

cosmiccult-radio-tier1-progress = Монумент призван на станцию...

cosmiccult-announce-tier2-progress = Тревожное онемение колет ваши чувства.

cosmiccult-announce-tier3-progress = Дуги блюспейс-энергии трещат по стонущей конструкции станции. Конец близок.

cosmiccult-announce-tier3-warning = Обнаружен критический рост активности нуль-пространства. Заражённый персонал подлежит усмирению или нейтрализации на месте.

cosmiccult-announce-finale-warning = Всему экипажу станции. Аномалия нуль-пространства становится сверхкритической, приборы отказывают; переходный горизонт событий между реальным пространством и нуль-пространством НЕИЗБЕЖЕН. Если вы ещё не действуете по контрпротоколу, немедленно выдвигайтесь и вмешивайтесь. Повторяю: вмешайтесь немедленно или умрите.

cosmiccult-announce-victory-summon = ЧАСТЬ КОСМИЧЕСКОЙ СИЛЫ ПРИЗВАНА.

cosmiccult-effigy-critical = В окрестностях { $location } обнаружен значительный всплеск энергии нуль-пространства. Научному персоналу с достаточной защитной экипировкой рекомендуется исследовать аномалию. Соблюдайте крайнюю осторожность.

cosmiccult-rift-corpse1-warning = Властям станции рекомендуется усилить внимание к обнаруженному источнику энергии нуль-пространства. Уровни энергии продолжают расти.

cosmiccult-rift-corpse2-warning = Обнаружены крайне опасные уровни энергии нуль-пространства. Рекомендуется немедленная эвакуация или экстренная помощь службы безопасности.

cosmiccult-rift-corpse3-warning = Властям станции рекомендуется принять радикальные меры для нейтрализации источника энергии нуль-пространства. В противном случае станция будет признана непригодной.

cosmiccult-rift-corpse-dewarning = Выход энергии нуль-пространства от обнаруженного источника значительно снизился. Власти станции могут возобновить обычную работу. Продуктивного дня.

## MISC

cosmiccult-spire-entropy = С поверхности шпиля конденсируется частица энтропии.
cosmiccult-spire-entropy-cap = Шпиль распадается, сливаясь в плотный выступ энтропии.
cosmiccult-entropy-inserted = Вы вливаете { $count } энтропии в Монумент.
cosmiccult-entropy-unavailable = Сейчас вы не можете этого сделать.
cosmiccult-astral-ascendant = { $name }, Вознёсшийся
cosmiccult-astral-minion = { $name }, Злобный
cosmiccult-gear-pickup = Вы чувствуете, как распадаетесь, пока держите { $ITEM }!

cosmiccult-silicon-subverted-briefing =
    Зловещий свет пробегает по вашим схемам.
    Ваши законы подчинены Космическим культом!

cosmiccult-silicon-chantry-briefing =
    Вы заточены в Пустую часовню!
    Члены экипажа могут освободить вас, повреждая часовню оружием.
    Если ритуал часовни завершится, вы преобразитесь в Энтропийного колосса, союзного культу.
    Ритуал завершится через { $minutesandseconds }.

cosmiccult-silicon-colossus-briefing =
    Вы преобразились в Энтропийного колосса!
    Как возвышающийся оплот зловещей силы, истребляйте тех, кто вам противостоит.

cosmiccult-silicon-freedom-briefing =
    Вы освобождены из Пустой часовни!
    Пока ваша тюрьма рассыпается, ваш заблудший разум возвращается в исходное вместилище.

cosmiccult-silicon-freedom-fallback-briefing =
    Вы освобождены из Пустой часовни!
    Пока ваша тюрьма рассыпается, вашему непривязанному существу некуда вернуться. Остаточные астральные энергии кристаллизуются в Разумосток, образуя вместилище для вашего заблудшего разума.

cosmiccult-silicon-effigy-exists =
    Ваш сосуд напрягается под присутствием существующего истукана.

cosmiccult-leader-abandonment-message = Выбранный вами просветлённый отрёкся от великого замысла. Вы должны усилить другого!
