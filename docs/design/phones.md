# Телефоны

| | |
|---|---|
| **Статус** | Готово |
| **Владелец** | @Evgencheg |
| **Заместитель** | - |
| **Предложение** | - |
| **Задачи** | - |
| **Обновлён** | 2026-10-17 |

## Суть

На станции появляются настоящие проводные телефоны: дисковые (на подставке) и настенные. У каждого телефона свой пятизначный номер, позвонить можно на любой другой телефон на карте через телефонную книгу или набором номера. Звонок слышно рядом с телефоном, собеседников соединяет трубка, а при желании включается громкая связь. Это ещё один способ общаться между отделами без рации и ещё одна площадка для ролевой игры (и розыгрышей).

## Механика

- Телефон состоит из подставки (`RotaryPhoneStand`, `RMCRotaryPhoneWallmount`) и трубки (`RotaryPhone`), которая лежит в слоте подставки. Подставка крепится к полу (`Anchorable`), трубку нельзя тянуть (`BlockPull`).
- Номер телефона выдаётся при инициализации: случайный из 11111-99999, без повторов; у размеченных на карте телефонов можно задать номер вручную (например, `RotaryPhoneSecurity911` - номер 911). Номер видно при осмотре.
- Трубку берут из подставки (клик по подставке), в интерфейсе набирают номер клавиатурой или выбирают телефон в телефонной книге (разделы по категориям: командование, СБ, инженерия, снабжение, медицина, наука, сервис, без категории; скрытая категория в книге не показывается). Кнопка `D` - позвонить, `C` - сбросить номер.
- У вызываемого телефона звонит звонок, на подставке меняется спрайт, всплывает подсказка с названием звонящего телефона. Поднятие трубки соединяет телефоны; положить трубку - завершить разговор у обоих. Если вызываемый телефон занят, звонящий слышит сигнал «занято».
- Пока трубка снята, она соединена с подставкой верёвкой длиной не более 3 тайлов (физический джойнт); при возвращении трубки верёвка пропадает. Трубку нельзя положить в чужой телефон: слот принимает только трубку с тем же номером.
- Речь вблизи трубки (дальность прослушивания 2 тайла) передаётся собеседнику. Режим по умолчанию - личное сообщение в чат тому, кто держит вторую трубку, со звуком разговора; текст не рисуется над головой. Альтернативный глагол «Переключить громкую связь» - телефон на другом конце произносит фразу вслух от имени говорящего.
- Отвёрткой по телефону открывается окно, где задают название телефона и категорию в книге. У размеченных на карте телефонов название задаётся на подставке (поле `name` компонента `RotaryPhoneHolder`).
- Подставка стреляет сигналами в систему связи устройств: звонок, исходящий вызов, снятие и возврат трубки (порты `PhoneRingPort`, `PhoneOutgoingPort`, `PhonePickupPort`, `PhoneHangupPort`).
- Подставка разрушается при 200 урона, трубка при этом удаляется.
- Закупка: ящик «5 дисковых телефонов в виде упаковок» в карго, 2500 кредитов (`RotaryPhoneCrateCargo`). Упаковка (`RotaryPhoneFlatPack`) собирается в подставку с трубкой.
- Должность «Торговец телефонами» (`PhoneMerchant`, сервисный отдел, `setPreference: false`): стартовый набор - 6 упаковок телефонов и мультитул; в раундовую роль без отдельного события не попадает (см. «Открытые вопросы»).

## Баланс

- **Влияет на:** общение между отделами и ролевую игру. Механически ничего не даёт: ни урона, ни денег, ни доступа.
- **Чем компенсируется:** телефон надо поставить и связать с телефоном на другом конце. Цена упаковки в карго - 500 кредитов за штуку.
- **Злоупотребления и защита:**
  - спам звонками - вызываемый занят во время звонка, вызов не копится, трубку можно просто не брать;
  - прослушка - слышно только то, что говорят в 2 тайлах от трубки, и только в разговоре (когда обе трубки сняты);
  - трубку нельзя тянуть: в источнике это починило сбой физики при перетаскивании трубки на верёвке.

## Затронутые системы

| Что | Где |
|---|---|
| Код порта | `Content.Shared/_Trauma/Phones/` (`RotaryPhoneComponent`, `RotaryPhoneHolderComponent`, `SharedRotaryPhoneSystem`, сообщения UI, события), `Content.Server/_Trauma/Phones/RotaryPhoneSystem.cs` (звонок, диалог, чат), `Content.Client/_Trauma/Phones/` (окна телефона и смены названия), `Content.Shared/_Trauma/PullBlocker/` (запрет тянуть трубку) |
| Правки в файлах Starlight/SS14 | `Content.Shared/Chat/MsgChatMessage.cs`, `Content.Server/Chat/Managers/IChatManager.cs`, `ChatManager.cs`, `Content.Client/.../ChatUIController.cs` - флаг `hidePopup`, чтобы личное сообщение от телефона не рисовало облачко речи (пометка `Trauma phones`); `Resources/Prototypes/Roles/Jobs/departments.yml` - должность в сервисном отделе (`# Trauma`) |
| Адаптация под Lost Light | В режиме громкой связи сохраняется язык говорящего (`languageOverride`), реплика озвучивается TTS голосом говорящего с эффектом телефона (`TTSSystem.PlayRelayedSpeech`, как у телефона и голопада Starlight). В личном режиме тому, кто не понимает язык говорящего, текст приходит искажённым (`ObfuscateSpeech`). У трубки нет компонента языка: говорящий берётся из события |
| Прототипы | `Resources/Prototypes/_Trauma/Entities/Objects/Devices/phones.yml`, `flatpack.yml`, `pda.yml`; `.../Misc/identification_cards.yml`; `.../PhoneCategorys.yml`; `.../DeviceLinking/source_ports.yml`; `.../Roles/Jobs/WildCards/phone_merchant.yml`; `.../Roles/play_time_trackers.yml`; `.../StatusIcon/job.yml`; `.../Catalog/Cargo/service.yml`, `.../Catalog/Fills/Crates/service.yml`; `.../Voice/speech_sounds.yml`; `Resources/Prototypes/_RMC14/Audio/telephone_sound_collections.yml` |
| Спрайты / звуки | `Resources/Textures/_RMC14/Objects/phone/`, `Resources/Textures/_RMC14/Structures/wallmount_phone.rsi`, `Resources/Textures/_Trauma/Interface/Misc/job_icons.rsi`, `Resources/Textures/_Trauma/Objects/Misc/id_cards.rsi`, `Resources/Audio/_RMC14/Phone/` |
| Локализация | `Resources/Locale/en-US/_Trauma/phones/phones.ftl` (исходник порта), `Resources/Locale/ru-RU/_Trauma/phones/phones.ftl`, имена сущностей - `ru-RU/ss14-ru/prototypes/_trauma/...` |
| Карты | Не затрагиваются: в источнике телефоны расставлены на картах Trauma Station и Goobstation (`reach`), эти правки не переносились |

## Происхождение

- **Порт** - [Trauma Station](https://github.com/Trauma-Station/Trauma-Station), AGPLv3 или новее. Автор - JohnJohn (JohnJJohn).
  - PR 909 (сама фича), 954, 957, 972, 1008, 1019, 1038, 1055, 1087, 1473 (только иконка должности), 1904, 2249;
  - найденные дополнительно: 956 (звук звонка у телефона), правки Murphy Ibbs из PR 972 (дальность звонка), коммит `fix stuff` (`RemoveAllChildren` в окне книги), ключ локализации слота телефона (из PR 2935).
- Звуки и спрайты - из RMC-14 (MIT, ассеты CC-BY-SA 3.0) и Goonstation (CC-BY-SA 3.0), оформлены в `attributions.yml` и `meta.json`.
- Изменения при переносе: пространство имён `Content.Trauma.*` → `Content.*/_Trauma`, зависимости полей без `readonly` и `partial`-классы (как принято в этом репо), язык и TTS (см. выше). В `attributions.yml` каждый файл теперь отдельным элементом списка (в источнике они были одной строкой). Звук нажатия клавиш `Tone1.ogg` перенесён по решению человека, хотя в источнике у него нет автора и лицензии (в `attributions.yml` указана лицензия по умолчанию для ассетов, CC-BY-SA-3.0); при появлении сведений об авторе - обновить.

## Настройки

CVar-ов нет. Все числа - `DataField` компонентов `RotaryPhone` и `RotaryPhoneHolder` или поля прототипов.

| Поле | По умолчанию |
|---|---|
| Номер телефона (`phoneNumber`) | случайный 11111-99999 |
| Категория (`category`) | `Uncategorized` |
| Громкая связь (`speakerPhone`) | выключена |
| Дальность прослушивания трубки (`ActiveListener.range`) | 2 |
| Длина верёвки трубки | 3 тайла (в `SharedRotaryPhoneSystem`) |
| Звуки (`ringSound`, `ringingSound`, `speakSound`, `keypadPressSound` и др.) | `RMCPhoneSpeak`, `/Audio/_RMC14/Phone/...` |

## Как выключить или удалить

**Выключить:** убрать `RotaryPhoneCrateCargo` из `Resources/Prototypes/_Trauma/Catalog/Cargo/service.yml` (телефон нельзя будет заказать); должность торговца недоступна в раундах и без этого.

**Удалить:**

1. Удалить `Content.Shared/_Trauma/Phones/`, `Content.Server/_Trauma/Phones/`, `Content.Client/_Trauma/Phones/`, `Content.Shared/_Trauma/PullBlocker/`.
2. Откатить правки в чужих файлах: убрать `HidePopup`/`hidePopup` в `MsgChatMessage.cs`, `IChatManager.cs`, `ChatManager.cs`, `ChatUIController.cs` (поиск по `Trauma phones`) и строку `PhoneMerchant` в `departments.yml` (`# Trauma`).
3. Удалить из `Resources/Prototypes/_Trauma/` файлы, перечисленные выше, и `Resources/Prototypes/_RMC14/Audio/telephone_sound_collections.yml`.
4. Удалить `Resources/Textures/_RMC14/Objects/phone/`, `.../Structures/wallmount_phone.rsi`, `Resources/Textures/_Trauma/Interface/Misc/job_icons.rsi`, `Resources/Textures/_Trauma/Objects/Misc/id_cards.rsi`, `Resources/Audio/_RMC14/Phone/`.
5. Удалить `Resources/Locale/en-US/_Trauma/phones/`, `ru-RU/_Trauma/phones/`, `ru-RU/ss14-ru/prototypes/_trauma/`.
6. Прогнать `localize.py --all`, YAML-линтер, проверить, что на картах нет телефонов.

## Открытые вопросы

- Должность «Торговец телефонами» в источнике попадает в раунд через событие «wildcard-должность» (`Resources/Prototypes/_Goobstation/GameRules/events.yml`), которого у нас нет. Сейчас должность доступна только админам; решить, нужно ли событие или должность стоит убрать.
- Телефонов нет ни на одной карте. Расставить их по нашим картам - отдельная задача.
- В личном режиме телефон не озвучивается TTS (только текст и звук разговора): в источнике это сообщение в чат владельцу трубки. Решить, нужна ли озвучка в наушник.
- У `Tone1.ogg` не подтверждены автор и лицензия: узнать у авторов Trauma Station или заменить на `/Audio/Machines/Nuke/general_beep.ogg` (поле `keypadPressSound`).
- Владелец и заместитель в таблице и реестре подставлены по умолчанию, поправьте.

## История

| Дата | Кто | Что |
|---|---|---|
| 2026-10-17 | @Evgencheg | Создан |
