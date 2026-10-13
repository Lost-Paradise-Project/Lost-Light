<p align="center"><img alt="Lost Paradise" width="512" src="Resources/Textures/_LP/Logo/splashlogo.png" /></p>

<div align="center">

[![Discord](https://img.shields.io/badge/Discord-Lost%20Paradise-5865F2?logo=discord&logoColor=white)](https://wiki.lost-paradise.space/discord)
[![Wiki](https://img.shields.io/badge/Вики-lost--paradise.space-blue)](https://wiki.lost-paradise.space)
[![Steam](https://img.shields.io/badge/Steam-SS14-blue)](https://store.steampowered.com/app/1255460/Space_Station_14/)

</div>

Это репозиторий русскоязычного сервера Lost Paradise по Space Station 14. Сборка основана на [Starlight](https://github.com/ss14Starlight/space-station-14): мы переводим игру на русский язык, поддерживаем актуальные изменения Starlight и добавляем собственный контент.


## Документация

- [Вики Lost Paradise: путеводитель для разработчиков и мапперов](https://wiki.lost-paradise.space/guide): правила, гайды, процесс, маппинг. Начинайте отсюда.
- [Документация Starlight для разработчиков](https://docs.starlight.network/s/d49865f5-b555-4803-b5d7-5c2fde54fbd9/doc/developer-guides-Hf0UsFaugc): особенности кодовой базы Starlight.
- [Документация Space Station 14](https://docs.spacestation14.com/): контент, движок, геймдизайн и материалы для начинающих разработчиков.

## Контрибьют

Мы рады вкладу от любого человека: исправлениям, новому контенту, переводам. Если хотите помочь, заходите в [Discord](https://wiki.lost-paradise.space/discord) и не бойтесь просить о помощи.

Всё, что нужно знать перед первым PR, собрано на вики: [Как внести вклад](https://wiki.lost-paradise.space/dev/start/contributing) (краткая версия в [CONTRIBUTING.md](CONTRIBUTING.md)). Также ознакомьтесь с [руководством по оформлению PR](https://docs.spacestation14.com/en/general-development/codebase-info/pull-request-guidelines.html).

Коротко: наш контент кладите в папки `_LP`, а правки в чужих файлах (Starlight, SS14) отмечайте комментариями `// LP edit start` / `// LP edit end` (в YAML — `# LP edit start` / `# LP edit end`, для одной строки — `// LP edit` или `# LP edit` в конце строки, в XAML — `<!-- LP edit -->`). В `.ftl` файлах и в директивах `using` пометки не ставятся.

## Программные требования

1. [Python 3](https://www.python.org/downloads/)
2. [Git](https://git-scm.com/install/)
3. [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)

## Сборка

Windows:
1. Склонируйте этот репозиторий локально
2. Запустите buildAllRelease.bat для инициализации подмодулей и скачивания движка, а также билда сборки. Путь: Scripts/bat/
3. Запустите runQuickAll.bat

Linux:
1. Склонируйте этот репозиторий локально
2. Запустите buildAllRelease.sh для инициализации подмодулей и скачивания движка, а также билда сборки. Путь: Scripts/sh/
3. Запустите runQuickAll.sh

Подробнее: [настройка окружения на вики](https://wiki.lost-paradise.space/dev/start/dev-environment) и [документация SS14](https://docs.spacestation14.com/en/general-development/setup.html).

## Активность проекта

![Alt](https://repobeats.axiom.co/api/embed/549093b983da9830fa26a233302295c8c0acbab5.svg "Repobeats analytics image")

## Лицензия

Проект в целом распространяется по лицензии [AGPLv3](./LICENSE-AGPLv3.txt). Отдельные части остаются под своими лицензиями: код Space Wizards Federation — [MIT](./LICENSE-MIT.TXT), вклады Starlight — MIT и [Starlight License](./LICENSE-Starlight.TXT). Список проектов-источников с лицензиями и требования к ассетам есть в [LEGAL.md](./LEGAL.md).

> [!NOTE]
> Вклады Starlight с **04.11.2024** (коммит `84205e38`) по **28.02.2026** (коммит `01eff0f7`) распространяются по Starlight License, пока их авторы не дадут согласие на перелицензирование под MIT ([issue #3499](https://github.com/ss14Starlight/space-station-14/issues/3499)). Эта лицензия требует указывать Starlight как источник, поэтому ссылка на [репозиторий Starlight](https://github.com/ss14Starlight/space-station-14) должна оставаться в этом файле.

Ассеты (спрайты, звуки, иконки) по умолчанию распространяются по [CC BY-SA 3.0](https://creativecommons.org/licenses/by-sa/3.0/), если в папке или файле (`meta.json`, `attributions.yml`) не указано иное.
