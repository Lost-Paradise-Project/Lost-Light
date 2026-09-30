### Examine

gas-turbine-examine-stator-null = Похоже, статор отсутствует.
gas-turbine-examine-stator = Статор на месте.

gas-turbine-examine-blade-null = Похоже, лопасть турбины отсутствует.
gas-turbine-examine-blade = Лопасть турбины на месте.

gas-turbine-spinning-0 = Лопасти не вращаются.
gas-turbine-spinning-1 = Лопасти медленно вращаются.
gas-turbine-spinning-2 = Лопасти вращаются.
gas-turbine-spinning-3 = Лопасти быстро вращаются.
gas-turbine-spinning-4 = [color=red]Лопасти вращаются вразнос![/color]

gas-turbine-damaged-0 = Кажется, она в хорошем состоянии.[/color]
gas-turbine-damaged-1 = Турбина выглядит немного потрёпанной.[/color]
gas-turbine-damaged-2 = [color=yellow]Турбина выглядит сильно повреждённой.[/color]
gas-turbine-damaged-3 = [color=orange]Она в критическом состоянии![/color]

gas-turbine-ruined = [color=red]Она полностью сломана![/color]

### Popups

# Shown when an event occurs
gas-turbine-overheat = { $owner } активирует аварийный клапан сброса перегрева!
gas-turbine-explode = { CAPITALIZE(THE($owner)) } разрывает на части!

# Shown when damage occurs
gas-turbine-spark = { CAPITALIZE(THE($owner)) } начинает искрить!
gas-turbine-spark-stop = { CAPITALIZE(THE($owner)) } перестаёт искрить.
gas-turbine-smoke = { CAPITALIZE(THE($owner)) } начинает дымить!
gas-turbine-smoke-stop = { CAPITALIZE(THE($owner)) } перестаёт дымить.

# Shown during repairs
gas-turbine-repair-fail-blade = Перед ремонтом нужно заменить лопасть турбины.
gas-turbine-repair-fail-stator = Перед ремонтом нужно заменить статор.
gas-turbine-repair-ruined = Вы чините корпус { THE($target) } с помощью { THE($tool) }.
gas-turbine-repair-partial = Вы устраняете часть повреждений { THE($target) } с помощью { THE($tool) }.
gas-turbine-repair-complete = Вы заканчиваете ремонт { THE($target) } с помощью { THE($tool) }.
gas-turbine-repair-no-damage = У { THE($target) } нет повреждений, которые можно починить с помощью { THE($tool) }.

# Anchoring warnings
gas-turbine-unanchor-warning = Нельзя открепить { THE($owner) }, пока турбина вращается!
gas-turbine-anchor-warning = Недопустимое место для крепления.

gas-turbine-eject-fail-speed = Нельзя извлекать детали турбины, пока она вращается!
gas-turbine-insert-fail-speed = Нельзя вставлять детали турбины, пока она вращается!

### UI

# Shown when using the UI
gas-turbine-ui-tab-main = Управление
gas-turbine-ui-tab-parts = Детали

gas-turbine-ui-rpm = ОБ/МИН

gas-turbine-ui-overspeed = ПРЕВЫШЕНИЕ СКОРОСТИ
gas-turbine-ui-overtemp = ПЕРЕГРЕВ
gas-turbine-ui-stalling = СРЫВ
gas-turbine-ui-undertemp = НЕДОГРЕВ

gas-turbine-ui-flow-rate = Скорость потока
gas-turbine-ui-stator-load = Нагрузка статора

gas-turbine-ui-blade = Лопасть турбины
gas-turbine-ui-blade-integrity = Целостность
gas-turbine-ui-blade-stress = Напряжение

gas-turbine-ui-stator = Статор турбины
gas-turbine-ui-stator-potential = Потенциал
gas-turbine-ui-stator-supply = Подача

gas-turbine-ui-power = { POWERWATTS($power) }

gas-turbine-ui-locked-message = Управление заблокировано.
gas-turbine-ui-footer-left = Опасно: быстро движущиеся механизмы.
gas-turbine-ui-footer-right = 2.1 REV 1
