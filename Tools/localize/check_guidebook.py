"""Проверка переведённых страниц гайдбука.

Сравнивает каждый изменённый .xml в Resources/ServerInfo с версией из git (по умолчанию HEAD):
разметка (<Тег ...>, [тег=...]) и все непереводимые атрибуты должны совпасть один в один.
Переводить можно только текст, Caption="..." и textlink="...".

Запуск из корня репо:
    python Tools/localize/check_guidebook.py [ревизия]   - проверить разметку
    python Tools/localize/check_guidebook.py --todo      - список ещё не переведённых страниц
"""
import collections
import pathlib
import re
import subprocess
import sys
import xml.etree.ElementTree as ET

ARGS = [a for a in sys.argv[1:] if not a.startswith("--")]
REV = ARGS[0] if ARGS else "HEAD"
# свои правила сервера пишем сами, их не переводим
SKIP_TODO = re.compile(r"ServerRules")
TRANSLATABLE_ATTRS = re.compile(r'\b(Caption|textlink)="[^"]*"')
XML_TAG = re.compile(r"</?[A-Za-z][^<>]*?/?>")
BB_TAG = re.compile(r"\[/?[a-zA-Z][^\[\]]*\]")


def markup(text: str) -> collections.Counter:
    tags = XML_TAG.findall(text) + BB_TAG.findall(text)
    return collections.Counter(TRANSLATABLE_ATTRS.sub(r'\1=""', t) for t in tags)


def xml_error(text: str) -> str:
    try:
        ET.fromstring(text)
    except ET.ParseError as e:
        return str(e)
    return ""


def xml_ok(text: str) -> bool:
    return not xml_error(text)


def todo() -> int:
    left = []
    for f in sorted(pathlib.Path("Resources/ServerInfo").rglob("*.xml")):
        if SKIP_TODO.search(f.as_posix()):
            continue
        text = BB_TAG.sub("", XML_TAG.sub("", f.read_text(encoding="utf-8")))
        latin = len(re.findall(r"[A-Za-z]", text))
        cyrillic = len(re.findall(r"[А-Яа-яЁё]", text))
        if latin > cyrillic:
            left.append((f.as_posix(), latin))
    for path, n in left:
        print(f"{n:7}  {path}")
    print(f"Не переведено страниц: {len(left)}")
    return 0


def main() -> int:
    sys.stdout.reconfigure(encoding="utf-8")
    if "--todo" in sys.argv:
        return todo()
    files = subprocess.run(
        ["git", "diff", "--name-only", REV, "--", "Resources/ServerInfo"],
        capture_output=True, text=True, encoding="utf-8", check=True,
    ).stdout.split()
    errors = 0
    for path in files:
        if not path.endswith(".xml"):
            continue
        try:
            new = open(path, encoding="utf-8").read()
        except FileNotFoundError:
            print(f"[УДАЛЁН] {path}")
            errors += 1
            continue
        old = subprocess.run(
            ["git", "show", f"{REV}:{path}"],
            capture_output=True, text=True, encoding="utf-8",
        ).stdout
        if not old:
            continue
        # гайдбук не строгий XML: ругаемся, только если перевод сломал разбор
        if xml_ok(old) and not xml_ok(new):
            print(f"[XML] {path}: {xml_error(new)}")
            errors += 1
        a, b = markup(old), markup(new)
        if a != b:
            errors += 1
            print(f"[РАЗМЕТКА] {path}")
            for t in (a - b).elements():
                print(f"    пропало:  {t}")
            for t in (b - a).elements():
                print(f"    появилось: {t}")
    print(f"Проверено файлов: {len(files)}, с ошибками: {errors}")
    return 1 if errors else 0


if __name__ == "__main__":
    sys.exit(main())
