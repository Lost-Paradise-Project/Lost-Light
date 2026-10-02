## Base actions

alerts-vampire-blood-name = Кровавое опьянение
alerts-vampire-blood-desc = Показывает, сколько крови вы выпили. Выпустите клыки и щёлкните левой кнопкой по цели, чтобы пить.

alerts-vampire-fed-name = Кровяная сытость
alerts-vampire-fed-desc = Ваша текущая кровяная сытость. Пейте кровь, чтобы оставаться сытым.

roles-antag-vampire-name = Вампир
roles-antag-vampire-description = Питайтесь экипажем. Выпустите клыки и пейте их кровь.

roles-antag-thrall-name = Раб
roles-antag-thrall-objective = Верно служите своему хозяину и подчиняйтесь его приказам.

vampire-roundend-name = вампир

vampire-drink-start = Вы вонзаете клыки в { CAPITALIZE(THE($target)) }.

vampire-not-enough-blood = Недостаточно крови.

vampire-mouth-covered = Ваш рот закрыт!
vampire-drink-invalid-target = Нельзя пить кровь вампиров и их рабов.
vampire-target-protected-by-faith = Этого человека защищает его вера!
vampire-drink-target-empty = В этом существе не осталось крови!
vampire-drink-target-maxed = Вы уже выпили { $amount } ед. крови у этой цели.
vampire-drink-target-hard-max = Вы выпили максимум крови у этой цели ({ $amount } ед.).
vampire-full-power-achieved = Ваша вампирская сущность бурлит — достигнута полная сила!
vampire-umbrae-full-power-fov = Тени подчиняются вашей воле. Теперь вы можете видеть сквозь стены!
vampire-drink-target-not-viable = У этого существа нет бьющегося сердца!
vampire-drink-target-rot = Сущность этого существа порочна!
vampire-sleep-shielded = Это существо нельзя усыпить из-за импланта!
vampire-sleep-protected = Нужен лучший зрительный контакт...

vampire-role-greeting = Вы вампир!
    Жажда крови заставляет вас питаться членами экипажа. Используйте свои способности, чтобы обращать других.
    Клыки позволяют вам пить кровь гуманоидов. Кровь восстанавливает здоровье и открывает новые способности.
    Найдите, чем заняться в эту смену!

# Objectives
objective-issuer-vampire = [color=crimson]Вампир[/color]

objective-condition-drain-title = Выпить { $count } ед. крови
objective-condition-drain-description = Выпейте { $count } ед. крови у членов экипажа с помощью клыков.

objective-vampire-thrall-obey-master-title = Повинуйтесь своему хозяину, { $targetName }.

# Class selection action
action-vampire-class-select = Выбрать класс вампира
action-vampire-class-select-desc = Выберите подкласс вампира

# Round end statistics
roundend-prepend-vampire-drained-low = Вампиры едва питались в эту смену, выпив лишь { $blood } ед. крови.
roundend-prepend-vampire-drained-medium = Вампиры неплохо поели, выпив { $blood } ед. крови.
roundend-prepend-vampire-drained-high = У вампиров был кровавый пир, они выпили { $blood } ед. крови!
roundend-prepend-vampire-drained-critical = Вампиры впали в кормовое безумие, выпив ошеломляющие { $blood } ед. крови!

roundend-prepend-vampire-drained = В этом раунде ни одному вампиру не удалось выпить значительное количество крови.
roundend-prepend-vampire-drained-named = { $name } был самым кровожадным вампиром, выпив в общей сложности { $number } ед. крови.

# Vampire class selection tooltips
vampire-class-hemomancer-tooltip = Гемомант
    Специализируется на магии крови и управлении кровью вокруг

vampire-class-umbrae-tooltip = Умбра
    Специализируется на тьме, скрытных засадах и мобильности

vampire-class-gargantua-tooltip = Гаргантюа
    Специализируется на стойкости и ближнем бою

vampire-class-dantalion-tooltip = Дантальон
    Специализируется на порабощении и иллюзиях

# Hemomancer abilities
action-vampire-hemomancer-tendrils-wrong-place = Здесь нельзя применить.

action-vampire-blood-barrier-wrong-place = Здесь нельзя ставить барьеры.

action-vampire-sanguine-pool-already-in = Вы уже в форме кровавой лужи!
action-vampire-sanguine-pool-invalid-tile = Здесь вы не можете стать лужей крови.
action-vampire-sanguine-pool-enter = Вы превращаетесь в лужу крови!
action-vampire-sanguine-pool-exit = Вы восстаёте из лужи крови!
vampire-space-burn-warning = Резкий свет пустоты обжигает вашу нежить-плоть!

action-vampire-blood-eruption-activated = Вы вызываете, чтобы кровь взметнулась шипами вокруг вас!

action-vampire-blood-bringers-rite-not-enough-power = Вам не хватает полной вампирской силы (нужно более 1000 суммарной крови и 8 разных жертв)
action-vampire-blood-brighters-rite-not-enough-blood = Недостаточно крови, чтобы активировать обряд кровоносцев
action-vampire-blood-bringers-rite-start = Обряд кровоносцев активирован!
action-vampire-blood-bringers-rite-stop = Обряд кровоносцев деактивирован
action-vampire-blood-bringers-rite-stop-blood = Обряд кровоносцев деактивирован — недостаточно крови

vampire-locate-result = Ваши чувства прослеживают { $target } до { $location }.
vampire-locate-not-same-sector = vampire-locate-not-same-sector = Этот человек не в вашем секторе.
vampire-locate-unknown = Неизвестная область
vampire-locate-no-targets = В этом секторе не чувствуется добычи.

predator-sense-title = Чутьё хищника
vampire-locate-search-placeholder = Поиск...

vampiric-claws-remove-popup = Вы заставляете когти исчезнуть.

# Umbrae abilities
action-vampire-cloak-of-darkness-start = Вы сливаетесь с тенями!
action-vampire-cloak-of-darkness-stop = Вы выходите из теней.

action-vampire-shadow-snare-placed = Вы ставите теневую ловушку.
action-vampire-shadow-snare-wrong-place = Здесь нельзя ставить ловушку.
action-vampire-shadow-snare-scatter = Вы разбросали теневую ловушку.
vampire-shadow-snare-oldest-removed = Ваша старая теневая ловушка рассеивается.

action-vampire-shadow-anchor-returned = Вы вернулись к теневому якорю
action-vampire-shadow-anchor-installed = Вы заняли место в тенях

action-vampire-shadow-boxing-start = Вы начинаете бой с тенью.
action-vampire-shadow-boxing-stop = Бой с тенью остановлен.
action-vampire-shadow-boxing-ends = Бой с тенью заканчивается.

action-vampire-dark-passage-wrong-place = Здешняя тьма непроницаема...
action-vampire-dark-passage-activated = Вы проскользнули сквозь тьму...

action-vampire-extinguish-activated = Вы поглотили свет вокруг вас...({ $count })

action-vampire-eternal-darkness-not-enough-blood = У вас кончилась кровь, чтобы поддерживать вечную тьму.
action-vampire-eternal-darkness-start = Вы призвали вечную тьму...
action-vampire-eternal-darkness-stop = Вечная тьма рассеялась...

# Dantalion
vampire-enthrall-start = Вы проникаете в разум { CAPITALIZE(THE($target)) }...
vampire-enthrall-success = { CAPITALIZE(THE($target)) } преклоняет колено и становится вашим рабом.
vampire-enthrall-target = Ваш разум подавлен вампирским господством!
vampire-enthrall-limit = Вы не можете контролировать больше рабов.
vampire-enthrall-invalid = Эту цель нельзя поработить.
vampire-thrall-released = Вампирская власть над вами слабеет.

vampire-pacify-invalid = Эту цель нельзя успокоить.
vampire-pacify-success = { CAPITALIZE(THE($target)) } поддаётся вашему всепоглощающему спокойствию.
vampire-pacify-target = Подавляющее спокойствие топит вашу волю к борьбе!

vampire-subspace-swap-thrall = Вы не можете меняться местами в подпространстве со своими рабами.
vampire-subspace-swap-dead = Этот разум вне вашей досягаемости.
vampire-subspace-swap-failed = Подпространственный разлом бесполезно шипит.
vampire-subspace-swap-success = Пространство искривляется, когда вы меняетесь местами с { CAPITALIZE(THE($target)) }!
vampire-subspace-swap-target = Реальность искривляется, и вас выбрасывает в новое положение!

vampire-rally-thralls-success = {$count ->
    [one] Ваш зов возвращает раба на вашу сторону!
    [few] Ваш зов возвращает { $count } рабов на вашу сторону!
    *[other] Ваш зов возвращает { $count } рабов на вашу сторону!
}
vampire-rally-thralls-none = Ни один из ваших рабов не может ответить на зов.
vampire-thrall-holy-water-freed = Святая вода очищает ваш разум от вампирской хватки!

vampire-blood-bond-start = Реки крови связывают вас с вашими рабами.
vampire-blood-bond-stop = Вы ослабляете кровную связь.
vampire-blood-bond-no-thralls = У вас нет порабощённых слуг для связи.
vampire-blood-bond-stop-blood = Связь рвётся сама; вам не хватает крови, чтобы её поддерживать.

action-vampire-not-enough-power = Вашей силы недостаточно (нужно более 1000 суммарной крови и 8 разных жертв).

# Gargantua
vampire-blood-swell-start = Ваши мышцы вздуваются нечестивой силой
vampire-blood-swell-end = Кровавая ярость стихает.

vampire-blood-rush-start = Кровь бурлит в ваших конечностях!
vampire-blood-rush-end = Ваша сверхъестественная скорость угасает.

vampire-seismic-stomp-activate = Земля содрогается под вашей яростью!

vampire-overwhelming-force-start = Ваше присутствие становится непоколебимым.
vampire-overwhelming-force-stop = Вы ослабляете железную хватку.
vampire-overwhelming-force-too-heavy = Этот предмет слишком тяжёл, чтобы его двигать!
vampire-overwhelming-force-door-pried = Вы грубой силой вырываете дверь.

vampire-demonic-grasp-hit = Демоническая лапа хватает вас!
vampire-demonic-grasp-pull = Лапа тащит вас к вампиру!

vampire-charge-start = Вы несётесь вперёд с неудержимой силой!
vampire-charge-impact = Вы врезаетесь в { CAPITALIZE(THE($target)) } с сокрушительной силой!

vampire-blood-swell-cancel-shoot = Ваши пальцы не проходят в спусковую скобу!!

vampire-holy-place-burn = Священная земля обжигает вашу нечестивую плоть!

alerts-vampire-blood-swell-name = Кровавое вздутие
alerts-vampire-blood-swell-desc = Ваши мышцы вздуваются нечестивой силой.
alerts-vampire-blood-rush-name = Кровавый порыв
alerts-vampire-blood-rush-desc = Сверхъестественная скорость течёт по вашим конечностям.

Vamp-converted-title = Порабощён!
Vamp-converted-text =
    Вы порабощены!
    Верно повинуйтесь своему хозяину, вы можете получить доступ к общему разуму через '+p'
Vamp-converted-confirm = Понимает
