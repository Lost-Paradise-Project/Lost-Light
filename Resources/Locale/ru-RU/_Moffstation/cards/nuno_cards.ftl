nuno-card-name-reverse = карта НУНО
nuno-card-desc-reverse = Вы понятия не имеете, что это за карта...

nuno-card-name = { $suit } { $card }
nuno-card-desc = Такая простая, но весёлая игра!

nuno-card-suit-name = { $suit ->
    [nunored] Red
    [nunoyellow] Yellow
    [nunogreen] Green
    [nunoblue] Blue
    *[invalid] !!{ $suit }!!
}

nuno-card-value-name = { $card ->
    [plus2] Plus 2
    [reverse] Reverse
    [skip] Skip
    *[other] { $card }
}

playing-card-wildcard = Джокер
playing-card-plus4 = Плюс 4
