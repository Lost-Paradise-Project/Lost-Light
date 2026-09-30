gofish-card-name-reverse = карта «Рыбалки»
gofish-card-desc-reverse = Не разобрать, что изображено на другой стороне этой рыбной карты.

gofish-card-name = Карта { gofish-card-value-name }
gofish-card-value-name = { $card ->
    [rules] Rules
    [carp] Space Carp
    [magic] Magic Carp
    [holo] Holocarp
    [rainbowcarp] Rainbow Carp
    [acmeco] AcmeCo
    [dromedaryco] DromedaryCo
    [nomads] Nomads
    [spessman] Spessman
    [ian] Ian
    [lisa] Lisa
    [puppy] Puppy Ian
    [oldian] Old Ian
    [appledonut] Apple Donut
    [bungodonut] Bungo Donut
    [chocolatedonut] Chocolate Donut
    [pinkdonut] Pink Donut
    [ertengineer] ERT Engineer
    [ertleader] ERT Leader
    [ertmedic] ERT Medic
    [ertsecurity] ERT Security
    [bingus] Bingus
    [exception] Exception
    [floppa] Floppa
    [runtime] Runtime
    [apple] Apple
    [banana] Banana
    [grapes] Grapes
    [orange] Orange
    [brown] Brown Mouse
    [grey] Grey Mouse
    [real] Real Mouse
    [white] White Mouse
    [deathshead] Deathshead Mothroach
    [moproach] Moproach
    [mothroach] Regular Mothroach
    [rosy] Rosy Mothroach
    [nukieelite] Elite Nukie
    [nukiejuggernaut] Nukie Juggernaut
    [nukiemedic] Nukie Medic
    [nukieoperative] Nukie Operative
    [drazil] Drazil Plushie
    [lizard] Lizard Plushie
    [rainbowlizard] Rainbow Lizard Plushie
    [spacelizard] Space Lizard Plushie
    [fourteenloko] Fourteen Loko
    [grape] Grape Soda
    [smitecranberry] Smite Cranberry Soda
    [spacecola] Space Cola
    [bloodbag] Blood Bag
    [bruisepack] Bruise Pack
    [gauze] Gauze
    [ointment] Ointment
    [clown] Clown
    [mime] Mime
    [passenger] Passenger
    [skeleton] Skeleton
    *[other] { $card }
}

gofish-card-desc =
    Рамка этой карты — { $suit }.
    Она принадлежит к группе карт { gofish-card-group-name }!

gofish-card-suit-name = { $suit ->
    [gofishblue] Blue
    [gofishgreen] Green
    [gofishred] Red
    [gofishyellow] Yellow
    *[other] { $suit }
}

gofish-card-group-name = { $id ->
    [carp] Carp
    [magic] Carp
    [holo] Carp
    [rainbowcarp] Carp
    [acmeco] Cigarette
    [dromedaryco] Cigarette
    [nomads] Cigarette
    [spessman] Cigarette
    [ian] Corgi
    [lisa] Corgi
    [puppy] Corgi
    [oldian] Corgi
    [appledonut] Donut
    [bungodonut] Donut
    [chocolatedonut] Donut
    [pinkdonut] Donut
    [ertengineer] ERT
    [ertleader] ERT
    [ertmedic] ERT
    [ertsecurity] ERT
    [bingus] Cat
    [exception] Cat
    [floppa] Cat
    [runtime] Cat
    [apple] Fruit
    [banana] Fruit
    [grapes] Fruit
    [orange] Fruit
    [brown] Mice
    [grey] Mice
    [real] Mice
    [white] Mice
    [deathshead] Mothroach
    [moproach] Mothroach
    [mothroach] Mothroach
    [rosy] Mothroach
    [nukieelite] Nukie
    [nukiejuggernaut] Nukie
    [nukiemedic] Nukie
    [nukieoperative] Nukie
    [drazil] Plushie
    [lizard] Plushie
    [rainbowlizard] Plushie
    [spacelizard] Plushie
    [fourteenloko] Soda
    [grape] Soda
    [smitecranberry] Soda
    [spacecola] Soda
    [bloodbag] Topical
    [bruisepack] Topical
    [gauze] Topical
    [ointment] Topical
    [clown] Troublemaker
    [mime] Troublemaker
    [passenger] Troublemaker
    [skeleton] Troublemaker
    *[other] !!Brother you should not be seeing this...!!
}

gofish-card-rules-content = [color=#1b67a5] { "[head=1]                  Рыбалка![/head]" }
                                                  { "[head=4]               Правила карточной игры и как играть[/head]" }[/color]
                                                  ════════════════════════════════════════
                                                  { "[head=2]    Введение:[/head]" }
    «Рыбалка» — классическая карточная игра для 2-6 игроков. Цель игры — собрать все четыре карты одной группы, чтобы заработать очки.
    Чтобы начать игру, перетасуйте колоду. Сколько карт раздавать, зависит от числа игроков...
    ════════════════════════════════════════
    { "[head=2]    Подготовка:[/head]" }
    • { "[bold]2-3 игрока:[/bold]" } по 7 карт каждому.
    • { "[bold]4-6 игроков:[/bold]" } по 5 карт каждому.
    Когда карты розданы, положите колоду в центр стола рубашкой вверх.
    ════════════════════════════════════════
    { "[head=2]    Игровой процесс:[/head]" }
    Игроки по очереди спрашивают другого игрока, есть ли у него карта определённой группы. Спрашивать можно только про группу, карта которой есть у самого спрашивающего на руках.
    { "[bold]        Игрок 1:[/bold]" } Эй, игрок 2, у тебя есть таракамоли?
     Если у игрока 2 есть карты таракамолей, он обязан отдать их все игроку 1. В этом случае игрок 1 продолжает ход и спрашивает другого игрока, пока не ошибётся.
     { "[bold]        Игрок 1:[/bold]" } Эй, игрок 3, у тебя есть таракамоли?
    Если у игрока нет карты этой группы, он должен ответить «Лови рыбку!», и спрашивающий обязан взять карту из колоды.
    { "[bold]                                                  Игрок 2:[/bold]" } Нет! Лови рыбку!
    Тогда игрок 1 берёт карту из колоды. Если ему попалась карта группы, о которой он только что спрашивал, он должен объявить об этом и продолжить ход.
    { "[bold]        Игрок 1:[/bold]" } Мне попалась таракамоль! Хожу ещё раз!
    Если карта не совпадает с группой, о которой он спрашивал, ход переходит к следующему игроку по очереди.
    ════════════════════════════════════════
    { "[head=2]    Как победить:[/head]" }
        Если игроку удалось собрать все четыре карты одной группы, он должен выложить эти четыре карты лицом вверх на стол и объявить об этом остальным.
    За каждый собранный набор игрок получает одно очко.
        Игра заканчивается, когда в колоде не осталось карт и все группы собраны. Игрок с наибольшим числом очков объявляется победителем!
    ════════════════════════════════════════
        { "[head=2]    Советы по игре:[/head]" }
    В стандартной колоде «Рыбалки» 13 групп.
        В каждой группе четыре карты, и цвет рамки каждой карты — { "[bold][color=Red]красный[/color][/bold], [bold][color=DodgerBlue]синий[/color][/bold], [bold][color=LimeGreen]зелёный[/color][/bold] или [bold][color=GoldenRod]жёлтый[/color][/bold]" }.
    Вот эти 13 групп...
    { "[mono][bold]1:[/bold] Карпы        [bold]6:[/bold] Кошки      [bold]11:[/bold] Плюшевые игрушки" }
    { "[bold]2:[/bold] Сигареты     [bold]7:[/bold] Фрукты     [bold]12:[/bold] Газировка" }
    { "[bold]3:[/bold] Корги        [bold]8:[/bold] Мыши       [bold]13:[/bold] Хулиганы" }
    { "[bold]4:[/bold] Пончики      [bold]9:[/bold] Таракамоли" }
    { "[bold]5:[/bold] ОБР         [bold]10:[/bold] Нюкеры" }[/mono]
    { "  • Не забывайте [bold]следить[/bold], о чём спрашивают другие игроки!" }
    { "  • [bold]Запоминайте, у кого какие карты[/bold], чтобы ваши догадки были" }
    успешнее!
    { "  • [bold]Не показывайте карты[/bold], с которыми вы близки к сбору" }
    набора!
    { "  • [bold]Не забывайте получать удовольствие![/bold]" }
