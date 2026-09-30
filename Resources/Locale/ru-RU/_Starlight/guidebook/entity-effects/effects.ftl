entity-effect-guidebook-modify-solution-reagent =
    { $chance ->
        [1] { $deltasign ->
                [1] Добавляет
                *[-1] Удаляет
            }
        *[other] { $deltasign ->
                [1] добавляют
                *[-1] удаляют
            }
    } { NATURALFIXED($amount, 2) } ед. реагента «{ $reagent }» { $deltasign ->
        [1] в
        *[-1] из
    } раствор «{ $solution }»
entity-effect-guidebook-regrow-doll-shell =
    { $chance ->
        [1] Отращивает
        *[other] отращивают
    } одну часть панциря
