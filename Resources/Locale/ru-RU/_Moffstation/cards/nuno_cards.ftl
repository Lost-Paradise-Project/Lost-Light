nuno-card-name-reverse = карта НУНО
nuno-card-desc-reverse = Вы понятия не имеете, что это за карта...

nuno-card-name = { $suit } { $card }
nuno-card-desc = Такая простая, но весёлая игра!

nuno-card-suit-name = { $suit ->
    [nunored] Красная
    [nunoyellow] Жёлтая
    [nunogreen] Зелёная
    [nunoblue] Синяя
    *[invalid] !!{ $suit }!!
}

nuno-card-value-name = { $card ->
    [plus2] Плюс 2
    [reverse] Разворот
    [skip] Пропуск
    *[other] { $card }
}

playing-card-wildcard = Джокер
playing-card-plus4 = Плюс 4
