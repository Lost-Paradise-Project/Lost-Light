admin-verb-make-blood-bound = Сделать цель связанным кровью.

admin-verb-text-make-blood-bound = Сделать связанным кровью

blood-bound-round-end-agent-name = связанный кровью

objective-issuer-blood-bound = [color=mediumvioletred]Кровавая клятва[/color]

blood-bound-round-end-no-mind = [color=white]{ CAPITALIZE($name) }[/color] ([color=gray]{ $username }[/color]) принёс кровавую клятву вместе с [color=white]{ $partnerName }[/color].
blood-bound-round-end = [color=white]{ CAPITALIZE($name) }[/color] ([color=gray]{ $username }[/color]) принёс кровавую клятву вместе с [color=white]{ $partnerName }[/color] ([color=gray]{ $partnerUsername }[/color]).

blood-bound-recruiter-greeting =
    Вы — связанный кровью.
    Вам дана способность скрепить кровавой клятвой одного из членов экипажа.
    Используйте её с умом и выполните цели, которые поставили перед вами Дети Нар'Си.

blood-bound-role-greeting =
    Вы принесли кровавую клятву.
    Слушайте своего напарника по клятве и помогайте ему достигать его целей.

blood-bound-briefing = Действуйте сообща с напарником по клятве, чтобы выполнить все свои цели.

# Conversion

blood-bound-convert-failed-no-mind = У { $converted } нет разума
blood-bound-convert-failed-already-bound = { CAPITALIZE($converted) } уже связан кровью
blood-bound-convert-failed-target = { CAPITALIZE($converted) } — ваша цель
blood-bound-convert-failed-zombie = { CAPITALIZE($converted) } — зомби
blood-bound-convert-failed-shielded = Разум { $converted } слишком хорошо защищён
blood-bound-convert-failed-dead = { CAPITALIZE($converted) } мёртв
blood-bound-convert-failed-preference = Разум { $converted } не поддаётся обращению

blood-bound-convert-convertible = { CAPITALIZE($converted) } можно обратить
blood-bound-conversion-popup = { CAPITALIZE($converter) } крепко хватает { $converted } и вырезает глубокие символы на руках.

guide-entry-blood-bound = Связанный кровью

role-subtype-blood-bound = Связанный кровью

roles-antag-blood-bound-name = Связанный кровью
roles-antag-blood-bound-objective = Во имя Нар'Си действуйте сообща с напарником по клятве, чтобы выполнить все свои цели.

blood-bound-convert-failed-bound = Вы уже принесли кровавую клятву.

objective-condition-blood-bound-progress-title = Помогите { $targetName } достичь его целей.

objective-condition-blood-bound-steal-description = Нам нужно добыть: { $itemName }.
objective-condition-blood-bound-steal-multiply-description = Нам нужно добыть: { $itemName } (количество: { $count }).

objective-condition-blood-bound-steal-heart = Украдите сердце { $targetName }, { CAPITALIZE($job) }.
objective-condition-blood-bound-firestake = Сожгите на кострах { $count } { $count ->
    [one] человека
    [few] человек
    *[other] человек
} в месте «{ $zone }».
objective-condition-blood-bound-firestake-description = Нам нужно сжечь { $count } { $count ->
    [one] человека
    [few] человек
    *[other] человек
} на кострах в месте «{ $zone }», пока они ещё живы.
