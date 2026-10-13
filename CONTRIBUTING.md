# Участие в разработке Lost Paradise

Актуальные правила, пошаговый путь от форка до Pull Request и все гайды живут на вики:

**https://wiki.lost-paradise.space/guide**

Коротко о главном:

- Всё новое кладём в папки `_LP` (`Content.*/_LP/`, `Resources/Prototypes/_LP/` и т. д.).
- Правки в чужих файлах (Starlight, SS14) делаем минимально и помечаем `LP edit` (`// LP edit`, `# LP edit`, `<!-- LP edit -->`). Директивы `using` в C# и файлы `.ftl` не помечаем.
- Никакого хардкода языка/параметров что придется менять.
- CVar-ы проекта лежат в `Resources/ConfigPresets/_LP/LP.toml`.
- Секретов (токены, пароли, ключи) в репозитории быть не должно.
- Не используй веб-редактор GitHub, работай локально.

Подробности: [Как внести вклад](https://wiki.lost-paradise.space/dev/start/contributing).
