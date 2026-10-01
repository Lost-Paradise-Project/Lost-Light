playing-card-name-reverse = игральная карта
playing-card-desc-reverse = С этой стороны не разобрать, что это.

playing-card-name = { $card } { $suit }
playing-card-desc = Мастерство исполнения великолепно!

playing-card-suit-name = { $suit ->
    [clubs] треф
    [diamonds] бубен
    [hearts] червей
    [spades] пик
    *[invalid] !!{ $suit }!!
}

playing-card-value-name = { $card ->
    [ace] Туз
    [j] Валет
    [q] Дама
    [k] Король
    *[other] { $card }
}

playing-card-joker = Джокер
