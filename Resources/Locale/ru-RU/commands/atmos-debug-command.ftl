cmd-atvrange-desc = Задаёт диапазон отладки атмосферы (два дробных числа: начало [красный] и конец [синий])
cmd-atvrange-help = Использование: { $command } <начало> <конец>
cmd-atvrange-error-start = Неверное дробное число НАЧАЛО
cmd-atvrange-error-end = Неверное дробное число КОНЕЦ
cmd-atvrange-error-zero = Масштаб не может быть равен нулю, так как это приведёт к делению на ноль в AtmosDebugOverlay.

cmd-atvmode-desc = Задаёт режим отладки атмосферы. Масштаб при этом сбрасывается автоматически.
cmd-atvmode-help = Использование: { $command } <TotalMoles/GasMoles/Temperature> [<ID газа (для GasMoles)>]
cmd-atvmode-error-invalid = Неверный режим
cmd-atvmode-error-target-gas = Для этого режима необходимо указать целевой газ.
cmd-atvmode-error-out-of-range = ID газа не удаётся разобрать, либо он вне диапазона.
cmd-atvmode-error-info = Для этого режима дополнительной информации не требуется.

cmd-atvcbm-desc = Переключает красный/зелёный/синий на оттенки серого
cmd-atvcbm-help = Использование: { $command } <true/false>
cmd-atvcbm-error = Неверный флаг
