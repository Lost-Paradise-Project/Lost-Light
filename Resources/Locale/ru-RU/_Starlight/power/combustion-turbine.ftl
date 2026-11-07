## Examine

combustion-turbine-examine-part = Установлена деталь [color=lightblue]уровня { $tier }[/color].
combustion-turbine-examine-no-part = [color=yellow]Деталь турбины отсутствует.[/color]
combustion-turbine-examine-unassembled = [color=yellow]Она не собрана с центральным ротором.[/color]
combustion-turbine-examine-rpm = Ротор вращается со скоростью [color=orange]{ $rpm }[/color] об/мин.
combustion-turbine-examine-integrity = Целостность ротора: [color=orange]{ $integrity }%[/color].
combustion-turbine-examine-power = Вырабатывает [color=yellow]{ POWERWATTS($power) }[/color].

## Assembly

combustion-turbine-assembly-ready = Турбина полностью собрана.
combustion-turbine-assembly-missing-compressor = [color=yellow]Ей нужен входной компрессор позади центрального ротора, направленный в ту же сторону.[/color]
combustion-turbine-assembly-missing-outlet = [color=yellow]Ей нужен выходной узел турбины перед центральным ротором, направленный в ту же сторону.[/color]
combustion-turbine-assembly-panel-open = [color=yellow]Техническая панель турбины открыта.[/color]
combustion-turbine-assembly-missing-part = [color=yellow]В одной из секций турбины нет детали.[/color]

## Parts

combustion-turbine-part-wrong-stage = Эта деталь не подходит к этой секции.
combustion-turbine-part-panel-closed = Сначала откройте техническую панель.
combustion-turbine-part-running = Сначала остановите турбину.
combustion-turbine-part-occupied = Сначала выньте установленную деталь ломом.
combustion-turbine-part-max-tier = Эта деталь уже максимального уровня.
combustion-turbine-part-wrong-material = Этот материал не подходит для улучшения детали.
combustion-turbine-part-not-enough = Для улучшения этой детали нужно { $amount } ед. материала «{ $material }».
combustion-turbine-part-upgraded = Деталь теперь уровня { $tier }.
combustion-turbine-part-examine-tier = Деталь [color=lightblue]уровня { $tier }[/color], рассчитана на [color=orange]{ $rpm }[/color] об/мин и [color=orange]{ $temperature } К[/color].
combustion-turbine-part-examine-compressor = Забор компрессора: [color=orange]{ $value }%[/color].
combustion-turbine-part-examine-rotor = Трение ротора: [color=orange]{ $value }%[/color].
combustion-turbine-part-examine-stator = Эффективность статора: [color=orange]{ $value }%[/color].
combustion-turbine-part-examine-upgrade = Можно улучшить с помощью [color=yellow]{ $amount } ед. материала «{ $material }»[/color].
combustion-turbine-part-examine-max-tier = Деталь максимального уровня.

## Radio

combustion-turbine-alert-damage = Внимание: газовая турбина возле «{ $location }» получает повреждения! Целостность ротора: { $integrity }%.
combustion-turbine-alert-failure = У газовой турбины возле «{ $location }» произошёл катастрофический отказ ротора!

## Console

combustion-turbine-console-title = Управление газовой турбиной
combustion-turbine-console-status-connected = Турбина подключена
combustion-turbine-console-status-unlinked = Турбина не подключена. Привяжите центральный ротор мультитулом.
combustion-turbine-console-status-no-compressor = За центральным ротором нет входного компрессора.
combustion-turbine-console-status-no-outlet = Перед центральным ротором нет выходного узла турбины.
combustion-turbine-console-status-panel-open = Техническая панель турбины открыта.
combustion-turbine-console-status-missing-part = В одной из секций турбины нет детали.
combustion-turbine-console-power = Питание турбины
combustion-turbine-console-on = Вкл.
combustion-turbine-console-off = Выкл.
combustion-turbine-console-starter = Стартер включён...
combustion-turbine-console-governor = Регулятор скорости удерживает ротор: забор { $value }%
combustion-turbine-console-overheat = ПЕРЕГРЕВ: входящий газ горячее, чем рассчитаны детали!
combustion-turbine-console-rpm = Скорость ротора
combustion-turbine-console-rpm-value = { $rpm } / { $max } об/мин
combustion-turbine-console-integrity = Целостность ротора
combustion-turbine-console-output = Выходная мощность
combustion-turbine-console-power-value = { POWERWATTS($power) }
combustion-turbine-console-inlet-temperature = Температура на входе
combustion-turbine-console-temperature-value = { $temperature } К (детали рассчитаны на { $max } К)
combustion-turbine-console-exhaust-temperature = Температура на выхлопе
combustion-turbine-console-kelvin-value = { $temperature } К
combustion-turbine-console-inlet-pressure = Давление на входе
combustion-turbine-console-outlet-pressure = Давление на выхлопе
combustion-turbine-console-pressure-value = { $pressure } кПа
combustion-turbine-console-pressure-ratio = Степень расширения
combustion-turbine-console-pressure-ratio-value = { $ratio } : 1
combustion-turbine-console-pressure-ratio-vacuum = выброс в вакуум
combustion-turbine-console-pressure-ratio-stalled = срыв, слишком высокое давление на выхлопе
combustion-turbine-console-flow = Расход газа
combustion-turbine-console-flow-value = { $flow } моль/с
combustion-turbine-console-intake = Регулятор забора
combustion-turbine-console-percent = { $value }%
combustion-turbine-console-intake-value = { $value }% ({ $volume } л/с)
combustion-turbine-console-parts = Уровни деталей
combustion-turbine-console-parts-value = компрессор { $compressor }, ротор { $rotor }, статор { $stator }

combustion-turbine-slot-part = Деталь турбины
