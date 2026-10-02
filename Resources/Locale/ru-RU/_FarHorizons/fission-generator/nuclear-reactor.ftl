### Popups
reactor-smoke-start = { CAPITALIZE(THE($owner)) } начинает дымить!
reactor-smoke-stop = { CAPITALIZE(THE($owner)) } перестаёт дымить.
reactor-fire-start = { CAPITALIZE(THE($owner)) } начинает гореть!
reactor-fire-stop = { CAPITALIZE(THE($owner)) } перестаёт гореть.

reactor-unanchor-melted = Вы не можете открепить { THE($owner) }, он расплавился и прирос к корпусу!
reactor-unanchor-warning = Вы не можете открепить { THE($owner) }, пока он не пуст или горячее 80°C!
reactor-anchor-warning = Недопустимое место для крепления.

### Messages
reactor-smoke-start-message = ТРЕВОГА: { CAPITALIZE(THE($owner)) } достиг опасной температуры: { $temperature } К. Немедленно вмешайтесь, чтобы предотвратить расплавление.
reactor-smoke-stop-message = { CAPITALIZE(THE($owner)) } остыл ниже опасной температуры. Хорошего дня.
reactor-fire-start-message = ТРЕВОГА: { CAPITALIZE(THE($owner)) } достиг КРИТИЧЕСКОЙ температуры: { $temperature } К. РАСПЛАВЛЕНИЕ НЕИЗБЕЖНО.
reactor-fire-stop-message = { CAPITALIZE(THE($owner)) } остыл ниже критической температуры. Расплавление предотвращено.

reactor-temperature-dangerous-message = { CAPITALIZE(THE($owner)) } имеет опасную температуру: { $temperature } К.
reactor-temperature-critical-message = { CAPITALIZE(THE($owner)) } имеет критическую температуру: { $temperature } К.
reactor-temperature-cooling-message = { CAPITALIZE(THE($owner)) } остывает: { $temperature } К.

reactor-melting-announcement = Ядерный реактор на борту станции начинает плавиться. Рекомендуется эвакуировать окружающую территорию.
reactor-melting-announcement-sender = Ядерная авария

reactor-meltdown-announcement = Ядерный реактор на борту станции катастрофически перегрузился. Вероятны радиоактивные обломки, ядерные осадки и пожары теплоносителя. Настоятельно рекомендуется немедленная эвакуация окружающей территории.
reactor-meltdown-announcement-sender = Ядерное расплавление

### UI
comp-nuclear-reactor-ui-locked = Заблокировано
comp-nuclear-reactor-ui-insert-button = Вставить
comp-nuclear-reactor-ui-remove-button = Убрать
comp-nuclear-reactor-ui-eject-button = Извлечь

comp-nuclear-reactor-ui-view-change = Сменить вид
comp-nuclear-reactor-ui-view-temp = Вид температуры
comp-nuclear-reactor-ui-view-neutron = Вид нейтронов
comp-nuclear-reactor-ui-view-fuel = Вид топлива

comp-nuclear-reactor-ui-status-panel = Состояние реактора
comp-nuclear-reactor-ui-reactor-temp = Температура
comp-nuclear-reactor-ui-reactor-rads = Радиация
comp-nuclear-reactor-ui-reactor-therm = Тепловая мощность
comp-nuclear-reactor-ui-reactor-control = Управляющие стержни
comp-nuclear-reactor-ui-therm-format = { POWERWATTS($power) }т

comp-nuclear-reactor-ui-footer-left = Опасно: высокая радиация.
comp-nuclear-reactor-ui-footer-right = 1.0 REV 1
