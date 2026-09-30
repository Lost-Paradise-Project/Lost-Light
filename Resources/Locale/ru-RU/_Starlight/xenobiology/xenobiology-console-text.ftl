# The selectors in the case of 1 just don't work for some reason.
# Guess we're always going for plural?

xenobiology-console-monkey-cube-inserted = Спасибо, что вставили обезьяний кубик! Теперь в консоли { $cubes } {$cubes ->
    [1] кубик
    [few] кубика
    *[other] кубиков
}.

xenobiology-console-mutation-potion-inserted = Спасибо, что вставили зелье мутации! Теперь в консоли { $potions } {$potions ->
    [1] зелье
    [few] зелья
    *[other] зелий
}.

xenobiology-console-stabilizer-potion-inserted = Спасибо, что вставили зелье стабилизатора! Теперь в консоли { $potions } {$potions ->
    [1] зелье
    [few] зелья
    *[other] зелий
}.

xenobiology-console-slime-picked-up = Подобран { $name }.
xenobiology-console-slime-picked-up-fail-full = Не удалось подобрать { $name }. Попробуйте выпустить нескольких слаймов.
xenobiology-console-slime-picked-up-fail-none-found = Слаймы не найдены. Попробуйте подойти ближе к одному из них.

xenobiology-console-slime-placed-down = Выпущен { $name }.
xenobiology-console-slime-placed-down-fail-none-stored = Слаймы не сохранены. Попробуйте подобрать одного.

xenobiology-console-monkey-placed = Выпущена обезьяна. Теперь у вас { $cubes } {$cubes ->
    [1] кубик
    [few] кубика
    *[other] кубиков
}.
xenobiology-console-monkey-placed-fail-empty = Недостаточно обезьяньих кубиков ({ $cubes }). Попробуйте вставить один или переработать уже съеденных обезьян.

xenobiology-console-monkey-recycled = Переработано { $monkeys } {$monkeys ->
    [1] обезьяна
    [few] обезьяны
    *[other] обезьян
}. Теперь у вас { $cubes } {$cubes ->
    [1] кубик
    [few] кубика
    *[other] кубиков
}.
xenobiology-console-monkey-recycled-failed-none = Обезьян для переработки не найдено. Подойдите ближе или убедитесь, что они достаточно повреждены.

xenobiology-console-mutation-potion-applied = К { $name } применено зелье мутации. Теперь шанс мутации: { $chance }.
xenobiology-console-mutation-potion-applied-failed-empty = Зелья мутации не сохранены. Попробуйте вставить одно.

xenobiology-console-stabilizer-potion-applied = К { $name } применено зелье стабилизатора. Теперь шанс мутации: { $chance }.
xenobiology-console-stabilizer-potion-applied-failed-empty = Зелья стабилизатора не сохранены. Попробуйте вставить одно.
