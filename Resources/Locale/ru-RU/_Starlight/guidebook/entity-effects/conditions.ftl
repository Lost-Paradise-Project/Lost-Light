entity-condition-guidebook-unknown-reagent = неизвестный реагент

entity-condition-guidebook-blood-reagent-threshold =
    { $max ->
        [2147483648] в кровотоке не менее { NATURALFIXED($min, 2) } ед. реагента «{ $reagent }»
        *[other] { $min ->
                [0] в кровотоке не более { NATURALFIXED($max, 2) } ед. реагента «{ $reagent }»
                *[other] в кровотоке от { NATURALFIXED($min, 2) } до { NATURALFIXED($max, 2) } ед. реагента «{ $reagent }»
            }
    }

entity-condition-guidebook-has-components =
    у цели { $shouldhave ->
        [true] есть
        *[false] нет
    } компонента «{ $name }»
