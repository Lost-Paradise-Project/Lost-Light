## Rev Head

roles-antag-rev-head-name = Глава революции
roles-antag-rev-head-objective = Ваша задача — захватить станцию, склонив членов экипажа на свою сторону, и устранив всех членов командования.

head-rev-role-greeting =
    Вы — глава революции. Вам поручено устранить весь командный состав станции путём убийства, ареста или конверсии.
    Синдикат проспонсировал вас особой вспышкой, которая обращает других на вашу сторону. Осторожно, она не сработает на тех, у кого есть имплант "Щит разума", и тех, кто носит защиту для глаз. Помните, что в процессе найма члены командования и службы безопасности проходят имплантацию "Щитом разума".
    Viva la revolución!

head-rev-briefing =
    Используйте вспышки, чтобы обратить членов экипажа на свою сторону.
    Убейте, арестуйте или конвертируйте всех членом командования, чтобы захватить станцию.

head-rev-break-mindshield = Имплант "Щит разума" был уничтожен!

## Rev

roles-antag-rev-name = Революционер
roles-antag-rev-objective = Ваша задача — защищать и выполнять приказы глав революции и помочь им захватить станцию, устранив всех членов командования.

rev-break-control = { $name } { GENDER($name) ->
    [male] вспомнил, кому он верен
    [female] вспомнила, кому она верна
    [epicene] вспомнили, кому они верни
    *[neuter] вспомнило, кому оно верно
} на самом деле!

rev-role-greeting =
    Вы — Революционер. Вам поручено защищать глав революции и помогать им захватить станцию.
    Революция должна работать вместе, чтобы убить, арестовать или конвертировать всех членов командования.
    Viva la revolución!

rev-briefing = Помогите главам революции убить, арестовать или конвертировать всех членов командования, чтобы захватить станцию.

## General

rev-title = Революционеры
rev-description = Революционеры скрывающиеся среди экипажа стремятся обратить других на свою сторону и свергнуть командование.

rev-not-enough-ready-players = Недостаточно игроков готовы к игре! { $readyPlayersCount } игроков из необходимых { $minimumPlayers } готовы. Нельзя запустить пресет Революционеры.
rev-no-one-ready = Нет готовых игроков! Нельзя запустить пресет Революционеры.
rev-no-heads = Нет кандидатов на роль главы революции. Нельзя запустить пресет Революционеры.

rev-won = Главы революции выжили и уничтожили весь командный состав станции.

rev-lost = Все главы революции погибли, а командование выжило.

rev-stalemate = И командование и главы революции погибли. Это ничья.

rev-reverse-stalemate = И командование и главы революции выжили.

# Starlight - added "or have abandoned the station" as a clarification for why revs may have won
central-command-revolution-announcement = Based on our scans from our long-range sensors, we believe the station has fallen under the control of hostile revolutionary forces. All heads of staff have been confirmed deceased, missing, or have abandoned the station. All remaining crew members are to stand by for further instructions.

soviet-commissariat-revolution-announcement = Long range communications array online. Motherland salutes you comrades, but the battle is not yet over. Your corporation will check if they can reclaim your station one last time, but do not worry! The SSF will arrive shorty. Glory to the USSP!

centcomm-revs-gammarift = Based on long-range sensor scans, we have detected hostile revolutionary activity on-board. Martial law is now in effect. Glory to NanoTrasen.

centcomm-revs-alldead = Long-range sensor scans report all USSP SKB agents on-board are now permanently deceased.

central-command-sender = Central Command

soviet-commissariat-sender = Soviet People's Commissariat

rev-headrev-count = { $initialCount ->
    [one] Глава революции был один:
    *[other] Глав революции было { $initialCount }:
}

rev-headrev-name-user = [color=#5e9cff]{ $name }[/color] ([color=gray]{ $username }[/color]) конвертировал { $count } { $count ->
    [one] члена
    [few] члена
    *[other] членов
} экипажа

rev-headrev-name = [color=#5e9cff]{ $name }[/color] конвертировал { $count } { $count ->
    [one] члена
    [few] члена
    *[other] членов
} экипажа

## Deconverted window

rev-deconverted-title = Разконвертированы!
rev-deconverted-text =
    Со смертью последнего главы революции, революция оканчивается.

    Вы больше не революционер, так что ведите себя хорошо.

rev-deconverted-rule = Reminder: As per Rule 3 of server rules, [bold][color=#a4885c]De-converted Revolutionaries forget what happened while they were brainwashed.[/color][/bold]

rev-deconverted-ruletext = Your character may learn what happened through further investigation and roleplay, but should not be able to remember being a revolutionary nor any actions they commited on behalf of the revolution.

rev-deconverted-confirm = Подтвердить
