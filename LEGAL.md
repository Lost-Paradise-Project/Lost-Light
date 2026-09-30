# Юридическая информация

## Определения

**Пространство имён (namespace)** - поддиректория, название которой начинается с `_` (например, `_LP`), указывающая на авторство содержимого.

**Код** - любые файлы исходного кода C#, скомпилированные сборки, YML-файлы в `Resources` и связанные скрипты (включая директорию `Tools`).

**Ассеты** - спрайты, звуки, музыка, шрифты, иконки и другие нетекстовые ресурсы.

## Авторские права

Авторы сохраняют все права на свои работы, представленные в этом репозитории, и могут свободно распространять свой контент где угодно.

## Лицензии кода

Проект в целом распространяется по лицензии [AGPLv3](./LICENSE-AGPLv3.txt), условия которой должны соблюдаться независимо от лицензий исходных проектов. Части кода, взятые из других проектов, дополнительно остаются под своими исходными лицензиями:

- **Код Lost Paradise** находится в пространстве имён `_LP` и распространяется по лицензии AGPLv3.
- **Исходный код из [Space Station 14](https://github.com/space-wizards/space-station-14)** взят под [лицензией MIT](./LICENSE-MIT.TXT).
- **Код [Starlight](https://github.com/ss14Starlight/space-station-14)**, на котором основана сборка, распространяется по лицензии MIT. Исключение - вклады Starlight с 04.11.2024 (коммит `84205e38`) по 28.02.2026 (коммит `01eff0f7`): они распространяются по [Starlight License](./LICENSE-Starlight.TXT), пока их авторы не дадут согласие на перелицензирование под MIT ([issue #3499](https://github.com/ss14Starlight/space-station-14/issues/3499)). Starlight License требует указывать проект Starlight как источник со ссылкой на его репозиторий.
- **Весь код вне конкретных пространств имён** распространяется как MIT + AGPLv3: исходный код Space Wizards Federation - по MIT, изменения Starlight - по MIT или Starlight License (за указанный выше период), изменения Lost Paradise - по AGPLv3.
- **Код в пространствах имён других проектов** распространяется по лицензиям, указанным в [таблице атрибуции](#таблица-атрибуции).

Запрещается удалять тексты лицензий MIT и Starlight License из любых дистрибутивов, содержащих код под этими лицензиями.

## Лицензии ассетов

По умолчанию ассеты распространяются по лицензии [CC BY-SA 3.0](https://creativecommons.org/licenses/by-sa/3.0/). Если для ассета указана другая лицензия, действует она. Лицензия и авторство каждого ассета указаны в файлах `meta.json` и `attributions.yml`, соблюдайте их индивидуально.

Особые требования:

1. **Ассеты с пометкой «All Rights Reserved»** запрещено использовать в любых производных работах. При использовании кода этой сборки в других проектах их необходимо удалить.
2. **Некоммерческие ассеты** (CC BY-NC и аналогичные) допускаются только в некоммерческих сборках, требуют указания авторства и должны быть удалены при коммерческом использовании.
3. **Ассеты под [лицензией Sawians](./LICENSE-Sawians.md)** (звуки из `Resources/Audio/_Starlight/*/Experiment/`) разрешено использовать только в экосистеме Space Station 14, с указанием автора. Автор может отозвать лицензию для конкретного сервера.

Перед коммерческим использованием проверьте все ассеты и удалите контент с пометкой «All Rights Reserved» и некоммерческими лицензиями. Рекомендуется консультация с юристом.

## Таблица атрибуции

| Пространство имён | Проект | Исходный репозиторий | Лицензия |
|---|---|---|---|
| `_LP` | Lost Paradise | этот репозиторий | AGPL 3.0 |
| `_Corvax` | Corvax | https://github.com/space-syndicate/space-station-14/ | MIT |
| `_Starlight`, `_NullLink` | Starlight | https://github.com/ss14Starlight/space-station-14 | MIT + Starlight License |
| `_FarHorizons` | Far Horizons | https://github.com/Far-Horizons-SS14/Far-Horizons-SS14 | MIT + Starlight License |
| `_Goobstation` | Goob Station | https://github.com/Goob-Station/Goob-Station | AGPL 3.0 |
| `_Funkystation` | Funky Station | https://github.com/funky-station/funky-station | AGPL 3.0 |
| `_Impstation` | Impstation | https://github.com/impstation/imp-station-14 | AGPL 3.0 (вклады до 15.08.2024 - MIT) |
| `_DEN` | The Den | https://github.com/TheDenSS14/TheDen | AGPL 3.0 |
| `_Mono` | Monolith | https://github.com/Monolith-Station/Monolith | AGPL 3.0 (часть файлов - MPL 2.0) |
| `DeltaV` | Delta-V | https://github.com/DeltaV-Station/Delta-v | AGPL 3.0 + MIT |
| `_Moffstation` | Moff Station | https://github.com/moff-station/moff-station-14 | MIT |
| `_Carpmosia` | Carpmosia | https://github.com/carpmosia/carpmosia | MIT |
| `_Blimpuf` | Blimpuf Station | https://github.com/Blimpuf-Station/BlimpufStation | MIT |
| `_CD` | Cosmatic Drift | https://github.com/cosmatic-drift-14/cosmatic-drift | MIT (часть файлов - MPL 2.0) |
| `_CP14` | CrystallEdge | https://github.com/crystallpunk-14/crystall-punk-14 | MIT |
| `_Afterlight` | Afterlight | уточняется | уточняется |
| `_ES` | уточняется | уточняется | уточняется |
| `_ST` | уточняется | уточняется | MIT |
| `_Starfall` | уточняется | уточняется | уточняется |
| `_TP`, `_TP14` | уточняется | уточняется | уточняется |
| `_Paradise` | уточняется (только текстуры) | уточняется | см. `meta.json` |

Файлы под MPL 2.0 помечены заголовком в начале файла. Эти файлы должны оставаться под MPL 2.0.

## Устаревший код

Если вы не согласны с условиями этих лицензий, вы можете использовать код до [этого коммита](https://github.com/Lost-Paradise-Project/Lost-Light/commit/23f6333b4d6e49664db9fabff3215b396531b36a), доступный под лицензиями MIT и Starlight License.

## Отказ от гарантий

ПРОГРАММНОЕ ОБЕСПЕЧЕНИЕ ПРЕДОСТАВЛЯЕТСЯ «КАК ЕСТЬ», БЕЗ КАКИХ-ЛИБО ГАРАНТИЙ. АВТОРЫ И ПРАВООБЛАДАТЕЛИ НЕ НЕСУТ ОТВЕТСТВЕННОСТИ ЗА ЛЮБЫЕ ПРЕТЕНЗИИ, УБЫТКИ ИЛИ ИНЫЕ ОБЯЗАТЕЛЬСТВА.
