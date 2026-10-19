contraband-tier-1 = ограниченная
contraband-tier-2 = строго регулируемая
contraband-tier-3 = серьёзная
contraband-tier-4 = крайне незаконная
contraband-tier-5 = особо опасная

contraband-type-syndicate = синдикатовская
contraband-type-magical = магическая
contraband-type-ussp = советская
contraband-type-tsf = Альянса Независимых Систем
contraband-type-cybernetic = кибернетическая
contraband-type-medtak = МедТак
contraband-type-casino = казино «Гоморра»
contraband-type-cosmic = космокультовая
contraband-type-central-command = Центрального командования
contraband-type-nanotrasen = НаноТрейзен
contraband-type-eto = ЕТО

contraband-examine-text-tier =
    { $itemType ->
        *[item] [color={ $color }]Этот предмет — контрабанда: уровень { $tier }, { $descriptor }.[/color]
        [reagent] [color={ $color }]Этот реагент — контрабанда: уровень { $tier }, { $descriptor }.[/color]
    }

contraband-examine-text-tier-typed =
    { $itemType ->
        *[item] [color={ $color }]Этот предмет — контрабанда: уровень { $tier }, { $descriptor }, тип: { $contrabandType }.[/color]
        [reagent] [color={ $color }]Этот реагент — контрабанда: уровень { $tier }, { $descriptor }, тип: { $contrabandType }.[/color]
    }

contraband-examine-text-restricted =
    { $itemType ->
        *[item] [color=yellow]Этот предмет разрешён только для: { $authorizations }.[/color]
        [reagent] [color=yellow]Этот реагент разрешён только для: { $authorizations }.[/color]
    }

contraband-authorization-prescription-patients = пациентов с действующим рецептом
