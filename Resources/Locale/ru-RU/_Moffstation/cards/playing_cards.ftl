playing-card-name-reverse = игральная карта
playing-card-desc-reverse = С этой стороны не разобрать, что это.

playing-card-name = { $card } { $suit }
playing-card-desc = Мастерство исполнения великолепно!

playing-card-suit-name = { $suit ->
    [clubs] Clubs
    [diamonds] Diamonds
    [hearts] Hearts
    [spades] Spades
    *[invalid] !!{ $suit }!!
}

playing-card-value-name = { $card ->
    [ace] Ace
    [j] Jack
    [q] Queen
    [k] King
    *[other] { $card }
}

playing-card-joker = Джокер
