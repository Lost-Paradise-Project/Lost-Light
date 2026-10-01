# Спонсорский и закрытый контент

Как закрыть предмет, маркинг, расу, профессию или призрака ролью Discord. Роли приходят через NullLink: игрок привязывает Discord, и игра видит его роли на нашем сервере.

## Требования по ролям

Требование - прототип `roleRequirementPrototype` со списком ID ролей Discord. Если у игрока есть любая роль из списка, требование выполнено.

Наши требования лежат в [`Resources/Prototypes/_LP/NullLink/`](../Resources/Prototypes/_LP/NullLink/). Папку `_NullLink/RolesReq` (Starlight) не трогаем и на её прототипы в нашем контенте не ссылаемся.

Уже есть:

| ID | У кого |
|---|---|
| `LPSponsorTier1Req` | спонсоры 1-6 уровня |
| `LPSponsorTier2Req` | спонсоры 2-6 уровня |
| `LPSponsorTier3Req` | спонсоры 3-6 уровня |
| `LPSponsorTier4Req` | спонсоры 4-6 уровня |
| `LPSponsorTier5Req` | спонсоры 5-6 уровня |
| `LPBoosterReq` | бустеры |

Уровни наследуются: бонус 3 уровня закрывайте `LPSponsorTier3Req`, и его получат 3, 4, 5 и 6 уровни.

Новое требование (например, для победителей ивентов):

```yaml
- type: roleRequirementPrototype
  id: LPEventWinnerReq
  roles:
  - 123456789012345678 # Победитель ивента
  discord: roles-req-discord-lp
  rolesLoc: roles-req-lp-event-winner
```

Текст роли добавьте в [`Resources/Locale/ru-RU/_LP/nulllink/requirements.ftl`](../Resources/Locale/ru-RU/_LP/nulllink/requirements.ftl). Игрок без роли увидит «Вам нужна любая из следующих ролей на Discord Lost Paradise: победитель ивента».

## Спонсорский предмет (лодаут)

Предмет кладётся в рюкзак. Прототип - в `Resources/Prototypes/_LP/Loadouts/`:

```yaml
- type: loadout
  id: LPSponsorUnderwearRed
  effects:
  - !type:GroupLoadoutEffect
    proto: LPSponsorTier3
  storage:
    back:
    - ClothingUnderwearRedSponsor
```

Группы `LPSponsorTier3` и `LPSponsorTier5` уже есть в [`sponsor.yml`](../Resources/Prototypes/_LP/Loadouts/sponsor.yml). Для другого уровня добавьте группу по образцу или укажите требование прямо:

```yaml
  effects:
  - !type:RolesReqLoadoutEffect
    proto: LPSponsorTier4Req
```

Чтобы лодаут появился в меню, добавьте его ID в группу лодаутов, например `Trinkets` в `Resources/Prototypes/Loadouts/LoadoutGroups/loadout_groups.yml`:

```yaml
  - LPSponsorUnderwearRed # LP edit
```

## Личный предмет

Доступен только указанным аккаунтам. UUID аккаунта SS14 видно в админ-панели игрока.

```yaml
- type: loadout
  id: LPPersonalNickname
  effects:
  - !type:PersonalLoadoutEffect
    users:
    - 00000000-0000-0000-0000-000000000000 # Ник
  storage:
    back:
    - ToyPlushieSomething
```

И так же добавьте ID в группу лодаутов.

## Спонсорский маркинг

Добавьте маркингу поле `rolesRequirement`:

```yaml
- type: marking
  id: LPSponsorTailFluffy
  bodyPart: Tail
  markingCategory: Tail
  rolesRequirement: LPSponsorTier3Req
  sprites:
  - sprite: _LP/Mobs/Customization/sponsor_tails.rsi
    state: fluffy
```

Без роли маркинга нет в меню, а если он уже стоит на персонаже, то снимается при сохранении. Работает и для причёсок.

## Спонсорская раса

То же поле у расы:

```yaml
- type: species
  id: LPSomeSpecies
  roundStart: true
  rolesRequirement: LPSponsorTier4Req
  # ...
```

Без роли расы нет в списке, а персонаж этой расы при сохранении становится человеком. Подрасы закрываются так же.

## Закрытая профессия

В требования профессии добавьте:

```yaml
  requirements:
  - !type:RolesRequirement
    proto: LPSponsorTier4Req
```

Без роли профессия в лобби закрыта с подсказкой, какая роль нужна.

## Призрак

Тема призрака по роли:

```yaml
  requirements:
  - !type:DiscordRolesRequirement
    requirement: LPSponsorTier1Req
```

Личный призрак:

```yaml
  requirements:
  - !type:UserIdRequirement
    userId: 00000000-0000-0000-0000-000000000000 # Ник
```

Свои темы призраков кладите в `Resources/Prototypes/_LP/`, спрайты - в `Resources/Textures/_LP/`.

## Призраки и профессии Starlight

Все призраки и профессии Starlight, закрытые ролями их Discord, уже переведены на наши требования (`staff.yml`, `sponsors.yml`). Синий щит, представитель НТ, магистрат и помощник менеджера открываются только по плейтайму.

Если появится новый контент Starlight с их ролями (после обновления), переводите его так же: в прототипе Starlight меняется одна строка с пометкой, а сами прототипы в `_NullLink/RolesReq` не правим.

```yaml
    requirement: LPSponsorTier1Req # LP edit
```

## Слоты персонажей и титулы

- Слоты по уровням (10/15/20/25/30) - прототипы `characterSlots` в [`sponsors.yml`](../Resources/Prototypes/_LP/NullLink/sponsors.yml). Без спонсорки число слотов берётся из `game.maxcharacterslots` в `LP.toml`.
- Значки у ника в OOC и LOOC - [`titles.yml`](../Resources/Prototypes/_LP/NullLink/titles.yml). В каждом сегменте берётся первый подходящий титул, поэтому старшие уровни стоят выше.
