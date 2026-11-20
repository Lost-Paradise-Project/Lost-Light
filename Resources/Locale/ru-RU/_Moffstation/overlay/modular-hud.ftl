# Verbs
modularhud-verb-insert-module = Вставить модуль
modularhud-verb-insert-module-message = Вставляет { $module } в { $hud }.
modularhud-verb-insert-module-error-fails-requirements = { CAPITALIZE($module) } нельзя установить в { $hud }.
modularhud-verb-insert-module-error-slots-full = { CAPITALIZE($hud) }: свободных слотов нет.
modularhud-verb-remove-modules = Извлечь модули
modularhud-verb-remove-modules-message = Извлекает модули из { $hud }.
modularhud-verb-remove-modules-error-missing-tool-quality = Для этого нужен инструмент с качеством «{ $quality }».
modularhud-verb-remove-modules-error-no-modules-to-remove = { CAPITALIZE($hud) }: модулей внутри нет.

# Examine
modularhud-examine-capacity = Всего вмещает { $capacity ->
    [one] [bold]{ $capacity }[/bold] модуль
    [few] [bold]{ $capacity }[/bold] модуля
    *[other] [bold]{ $capacity }[/bold] модулей
}.
modularhud-examine-no-modules = Модулей внутри нет.
modularhud-examine-modules-header = Внутри находятся:
modularhud-examine-module-item = - [bold]{ $module }[/bold]

# Labels for premade HUDs
modularhud-premade-security = Охранный
modularhud-premade-noir = Нуар-тех
modularhud-premade-medical = Медицинский
modularhud-premade-diagnostic = Диагностический
modularhud-premade-command = Командный
modularhud-premade-thirst = Пивной
modularhud-premade-chemistry = Химический анализ
modularhud-premade-engineering = Инженерный
modularhud-premade-medchem = «Валькирия» МедХим
modularhud-premade-medSec = МедСек

# Module requirements
modular-hud-requirement-full-coverage = Требуются очки, полностью закрывающие все глаза

# Loadout name overrides
moff-loadout-admin-sunglasses = административные очки
moff-loadout-admin-hud = административный визор
moff-loadout-noir-sunglasses = нуар-тех солнцезащитные очки
moff-loadout-security-sunglasses = охранные солнцезащитные очки
moff-loadout-security-patch = охранная глазная повязка
moff-loadout-security-hud = охранный визор
moff-loadout-engineering-glasses = инженерные солнцезащитные очки
moff-loadout-engineering-goggles = инженерные очки
moff-loadout-chemistry-goggles = очки химического анализа
moff-loadout-medical-glasses = медицинские солнцезащитные очки
moff-loadout-diagnostic-hud = диагностический визор
moff-loadout-diagnostic-patch = диагностическая повязка
moff-loadout-beer-hud = пивной визор
moff-loadout-beer-patch = пивная повязка
moff-loadout-medical-hud = медицинский визор
moff-loadout-medical-patch = медицинская повязка
