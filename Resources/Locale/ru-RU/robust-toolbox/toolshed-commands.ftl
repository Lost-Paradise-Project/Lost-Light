command-help-usage =
    Использование:
command-help-invertible =
    Поведение этой команды можно инвертировать с помощью префикса "not".
command-description-tpto =
    Телепортирует указанные сущности к некоторой целевой сущности.
command-description-player-list =
    Возвращает список всех игровых сессий.
command-description-player-self =
    Возвращает текущую игровую сессию.
command-description-player-imm =
    Возвращает сессию, связанную с игроком, указанным в качестве аргумента.
command-description-player-entity =
    Возвращает сущности входных сессий.
command-description-self =
    Возвращает текущую привязанную сущность.
command-description-physics-velocity =
    Возвращает скорость входных сущностей.
command-description-physics-angular-velocity =
    Возвращает угловую скорость входных сущностей.
command-description-buildinfo =
    Предоставляет информацию о сборке игры.
command-description-cmd-list =
    Возвращает список всех команд для этой стороны.
command-description-explain =
    Объясняет указанное выражение, предоставляя описания и сигнатуры команд. Работает только для корректных выражений, команды, которые не удаётся разобрать, объяснить нельзя.
command-description-search =
    Ищет указанное значение во входных данных.
command-description-stopwatch =
    Измеряет время выполнения указанного выражения.
command-description-types-consumers =
    Выводит все команды, способные принять указанный тип.
command-description-types-tree =
    Отладочный инструмент: возвращает все типы, к которым интерпретатор команд может привести входные данные.
command-description-types-gettype =
    Возвращает тип входных данных.
command-description-types-fullname =
    Возвращает полное имя входного типа по данным CoreCLR.
command-description-as =
    Приводит входные данные к указанному типу.
    По сути подсказка типа, если вы знаете тип, а интерпретатор нет.
command-description-count =
    Считает количество элементов во входных данных и возвращает целое число.
command-description-map =
    Применяет указанный блок ко входным данным.
command-description-select =
    Выбирает N объектов или N% объектов из входных данных.
    Эту команду можно инвертировать с помощью not, чтобы она выбирала всё, кроме N объектов.
command-description-comp =
    Возвращает указанный компонент входных сущностей, отбрасывая сущности без этого компонента.
command-description-delete =
    Удаляет входные сущности.
command-description-ent =
    Возвращает указанный ID сущности.
command-description-entities =
    Возвращает все сущности на сервере.
command-description-paused =
    Фильтрует входные сущности по тому, приостановлены ли они.
command-description-with =
    Фильтрует входные сущности по наличию у них указанного компонента.
command-description-fuck =
    Выбрасывает исключение.
command-description-ecscomp-listty =
    Выводит все зарегистрированные типы компонентов.
command-description-cd =
    Меняет текущий каталог сессии на указанный относительный или абсолютный путь.
command-description-ls-here =
    Выводит содержимое текущего каталога.
command-description-ls-in =
    Выводит содержимое указанного относительного или абсолютного пути.
command-description-methods-get =
    Возвращает все методы, связанные с входным типом.
command-description-methods-overrides =
    Возвращает все методы, переопределённые во входном типе.
command-description-methods-overridesfrom =
    Возвращает все методы, переопределённые во входном типе из указанного типа.
command-description-cmd-moo =
    Задаёт важные вопросы.
command-description-cmd-descloc =
    Возвращает строку локализации описания команды.
command-description-cmd-getshim =
    Возвращает оболочку выполнения команды.
command-description-help =
    Кратко объясняет, как пользоваться toolshed.
command-description-ioc-registered =
    Возвращает все типы, зарегистрированные в IoCManager в текущем потоке (обычно в игровом)
command-description-ioc-get =
    Получает экземпляр регистрации IoC.
command-description-loc-tryloc =
    Пытается получить строку локализации и возвращает null, если не удалось.
command-description-loc-loc =
    Получает строку локализации и возвращает нелокализованную строку, если не удалось.
command-description-physics-angular_velocity =
    Возвращает угловую скорость указанных сущностей.
command-description-vars =
    Выводит список всех переменных, заданных в этой сессии.
command-description-any =
    Возвращает true, если во входных данных есть хоть какие-то значения, иначе false.
command-description-contains =
    Возвращает, содержит ли входная последовательность указанное значение.
command-description-ArrowCommand =
    Присваивает входные данные переменной.
command-description-isempty =
    Возвращает true, если входные данные пусты, иначе false.
command-description-isnull =
    Возвращает true, если входные данные равны null, иначе false.
command-description-unique =
    Фильтрует входную последовательность по уникальности, удаляя повторяющиеся значения.
command-description-where =
    Для некоторой входной последовательности IEnumerable<T> принимает блок сигнатуры T -> bool, который решает, включать ли каждое входное значение в выходную последовательность.
command-description-do =
    Обратная совместимость с BQL: применяет указанные старые команды ко входной последовательности.
command-description-named =
    Фильтрует входные сущности по имени с помощью регулярного выражения ^selector$.
command-description-prototyped =
    Фильтрует входные сущности по прототипу.
command-description-nearby =
    Создаёт новый список всех сущностей рядом со входными в указанном радиусе.
command-description-first =
    Возвращает первый элемент указанной последовательности.
command-description-splat =
    «Размножает» блок, значение или переменную, создавая в списке N их копий.
command-description-val =
    Приводит указанное значение, блок или переменную к указанному типу. По большей части это обход текущих ограничений переменных.
command-description-var =
    Возвращает содержимое указанной переменной. Пытается автоматически определить тип переменной. Составным командам, изменяющим переменную, может потребоваться вместо этого команда 'val'.
command-description-actor-controlled =
    Фильтрует сущности по тому, управляются ли они активно.
command-description-actor-session =
    Возвращает сессии, связанные с входными сущностями.
command-description-physics-parent =
    Возвращает родителей входных сущностей.
command-description-emplace =
    Выполняет указанный блок над входными данными, помещая входное значение в переменную $value внутри блока.
    Дополнительно для сущностей выделяет $wx, $wy, $proto, $desc, $name и $paused.
    Для других типов тоже могут быть выделенные значения, подробности смотрите в документации по этому типу.
command-description-AddCommand =
    Выполняет числовое сложение.
command-description-SubtractCommand =
    Выполняет числовое вычитание.
command-description-MultiplyCommand =
    Выполняет числовое умножение.
command-description-DivideCommand =
    Выполняет числовое деление.
command-description-min =
    Возвращает минимум из двух значений.
command-description-max =
    Возвращает максимум из двух значений.
command-description-BitAndCommand =
    Выполняет побитовое И.
command-description-bitor =
    Выполняет побитовое ИЛИ.
command-description-BitXorCommand =
    Выполняет побитовое исключающее ИЛИ.
command-description-neg =
    Меняет знак входного значения.
command-description-GreaterThanCommand =
    Выполняет сравнение «больше», x > y.
command-description-LessThanCommand =
    Выполняет сравнение «меньше», x < y.
command-description-GreaterThanOrEqualCommand =
    Выполняет сравнение «больше или равно», x >= y.
command-description-LessThanOrEqualCommand =
    Выполняет сравнение «меньше или равно», x <= y.
command-description-EqualCommand =
    Выполняет сравнение на равенство и возвращает true, если входные значения равны.
command-description-NotEqualCommand =
    Выполняет сравнение на равенство и возвращает true, если входные значения не равны.
command-description-append =
    Добавляет значение во входную последовательность.
command-description-DefaultIfNullCommand =
    Заменяет входные данные значением типа по умолчанию, если они равны null, но только для типов-значений (не объектов).
command-description-OrValueCommand =
    Если входные данные равны null, использует указанное альтернативное значение.
command-description-DebugPrintCommand =
    Прозрачно выводит указанное значение, для отладочных выводов при выполнении команды.
command-description-i =
    Целочисленная константа.
command-description-f =
    Дробная константа.
command-description-s =
    Строковая константа.
command-description-b =
    Булева константа.
command-description-join =
    Объединяет две последовательности в одну.
command-description-reduce =
    Принимает блок-свёртку и превращает последовательность в одно значение.
    Левая часть блока подразумевается, а правая хранится в $value.
command-description-rep =
    Повторяет входное значение N раз, формируя последовательность.
command-description-take =
    Берёт N значений из входной последовательности
command-description-spawn-at =
    Создаёт сущность по указанным координатам.
command-description-spawn-on =
    Создаёт сущность на указанной сущности, в её координатах.
command-description-spawn-in =
    Создаёт сущность в указанном контейнере указанной сущности; если не помещается, роняет её в координатах сущности
command-description-spawn-attached =
    Создаёт сущность, прикреплённую к указанной сущности, в точке (0 0) относительно неё.
command-description-mappos =
    Возвращает координаты сущности относительно её текущей карты.
command-description-pos =
    Возвращает координаты сущности.
command-description-tp-coords =
    Телепортирует указанные сущности в целевые координаты.
command-description-tp-to =
    Телепортирует указанные сущности к целевой сущности.
command-description-tp-into =
    Телепортирует указанные сущности «внутрь» целевой сущности, прикрепляя их в точке (0 0) относительно неё.
command-description-comp-get =
    Получает указанный компонент у указанной сущности.
command-description-comp-add =
    Добавляет указанный компонент указанной сущности.
command-description-comp-ensure =
    Гарантирует, что у указанной сущности есть указанный компонент.
command-description-comp-has =
    Проверяет, есть ли у указанной сущности указанный компонент.
command-description-AddVecCommand =
    Прибавляет скаляр (одиночное значение) к каждому элементу входных данных.
command-description-SubVecCommand =
    Вычитает скаляр (одиночное значение) из каждого элемента входных данных.
command-description-MulVecCommand =
    Умножает каждый элемент входных данных на скаляр (одиночное значение).
command-description-DivVecCommand =
    Делит каждый элемент входных данных на скаляр (одиночное значение).
command-description-rng-to =
    Возвращает число от входного значения (включительно) до аргумента (не включая).
command-description-rng-from =
    Возвращает число от аргумента (включительно) до входного значения (не включая)
command-description-rng-prob =
    Возвращает булево значение по входной вероятности/шансу (от 0 до 1)
command-description-sum =
    Вычисляет сумму входных данных.
command-description-bin =
    «Раскладывает по корзинам» входные данные, подсчитывая, сколько раз встречается каждый уникальный элемент.
command-description-extremes =
    Возвращает два крайних конца списка вперемешку.
command-description-sortby =
    Сортирует входные данные по возрастанию вычисленного ключа.
command-description-sortmapby =
    Сортирует входные данные по возрастанию вычисленного ключа, после чего заменяет значение вычисленным ключом.
command-description-sort =
    Сортирует входные данные по возрастанию.
command-description-sortdownby =
    Сортирует входные данные по убыванию вычисленного ключа.
command-description-sortmapdownby =
    Сортирует входные данные по убыванию вычисленного ключа, после чего заменяет значение вычисленным ключом.
command-description-sortdown =
    Сортирует входные данные по убыванию.
command-description-iota =
    Возвращает список чисел от 1 до N.
command-description-to =
    Возвращает список чисел от N до M.
command-description-curtick =
    Текущий игровой тик.
command-description-curtime =
    Текущее игровое время (TimeSpan)
command-description-realtime =
    Текущее реальное время с момента запуска (TimeSpan)
command-description-servertime =
    Текущее игровое время сервера или ноль, если мы и есть сервер (TimeSpan)
command-description-replace =
    Заменяет входные сущности сущностями указанного прототипа, сохраняя положение и поворот (но ничего больше)
command-description-allcomps =
    Возвращает все компоненты указанной сущности.
command-description-entitysystemupdateorder-tick =
    Выводит порядок обновления систем сущностей по тикам.
command-description-entitysystemupdateorder-frame =
    Выводит порядок обновления систем сущностей по кадрам.
command-description-more =
    Выводит содержимое $more, то есть всё лишнее, что Toolshed не вывел при выполнении последней команды.
command-description-ModulusCommand =
    Вычисляет остаток от деления двух значений.
    Обычно это остаток, подробнее смотрите документацию C# для этого типа.
command-description-ModVecCommand =
    Выполняет операцию взятия остатка над входными данными с указанной константой в правой части.
command-description-BitAndNotCommand =
    Выполняет побитовое И-НЕ над входными данными.
command-description-bitornot =
    Выполняет побитовое ИЛИ-НЕ над входными данными.
command-description-BitXnorCommand =
    Выполняет побитовое исключающее ИЛИ-НЕ над входными данными.
command-description-BitNotCommand =
    Выполняет побитовое НЕ над входными данными.
command-description-abs =
    Вычисляет абсолютное значение входных данных (убирая знак)
command-description-average =
    Вычисляет среднее (арифметическое) входных данных.
command-description-bibytecount =
    Возвращает размер входных данных в байтах при условии, что они реализуют IBinaryInteger.
    Это НЕ sizeof.
command-description-shortestbitlength =
    Возвращает минимальное число бит, необходимое для представления входного значения.
command-description-countleadzeros =
    Считает количество старших двоичных нулей во входном значении.
command-description-counttrailingzeros =
    Считает количество младших двоичных нулей во входном значении.
command-description-fpi =
    число пи (3,14159...) как float.
command-description-fe =
    число e (2,71828...) как float.
command-description-ftau =
    число тау (6,28318...) как float.
command-description-fepsilon =
    Значение эпсилон для float, ровно 1,4e-45.
command-description-dpi =
    число пи (3,14159...) как double.
command-description-de =
    число e (2,71828...) как double.
command-description-dtau =
    число тау (6,28318...) как double.
command-description-depsilon =
    Значение эпсилон для double, ровно 4,9406564584124654E-324.
command-description-hpi =
    число пи (3,14...) как half.
command-description-he =
    число e (2,71...) как half.
command-description-htau =
    число тау (6,28...) как half.
command-description-hepsilon =
    Значение эпсилон для half, ровно 5,9604645E-08.
command-description-floor =
    Возвращает округление входного значения вниз (к нулю).
command-description-ceil =
    Возвращает округление входного значения вверх (от нуля).
command-description-round =
    Округляет входное значение.
command-description-trunc =
    Отбрасывает дробную часть входного значения.
command-description-round2frac =
    Округляет входное значение до указанного числа дробных знаков.
command-description-exponentbytecount =
    Возвращает число байт, необходимое для хранения экспоненты.
command-description-significandbytecount =
    Возвращает число байт, необходимое для хранения мантиссы.
command-description-significandbitcount =
    Возвращает точную длину мантиссы в битах.
command-description-exponentshortestbitcount =
    Возвращает минимальное число бит для хранения экспоненты.
command-description-stepnext =
    Переходит к следующему значению float, прибавляя единицу к мантиссе с переносом.
command-description-stepprev =
    Переходит к предыдущему значению float, вычитая единицу из мантиссы с переносом.
command-description-checkedto =
    Преобразует входной числовой тип в целевой, выдавая ошибку, если это невозможно.
command-description-saturateto =
    Преобразует входной числовой тип в целевой, с насыщением, если значение вне диапазона.
    Например, преобразование 382 в byte даст насыщение до 255 (максимальное значение byte).
command-description-truncto =
    Преобразует входной числовой тип в целевой с усечением.
    Для целых чисел это побитовое приведение с расширением знака.
command-description-iscanonical =
    Возвращает, находится ли входное значение в канонической форме.
command-description-iscomplex =
    Возвращает, является ли входное значение комплексным числом (по значению, а не по типу)
command-description-iseven =
    Возвращает, является ли входное значение чётным.
    Это не пакет для javascript.
command-description-isodd =
    Возвращает, является ли входное значение нечётным.
command-description-isfinite =
    Возвращает, является ли входное значение конечным.
command-description-isimaginary =
    Возвращает, является ли входное значение чисто мнимым (без вещественной части).
command-description-isinfinite =
    Возвращает, является ли входное значение бесконечным.
command-description-isinteger =
    Возвращает, является ли входное значение целым числом (по значению, а не по типу)
command-description-isnan =
    Возвращает, является ли входное значение не числом (NaN).
    Это особое значение с плавающей запятой, поэтому проверка идёт по значению, а не по типу.
command-description-isnegative =
    Возвращает, является ли входное значение отрицательным.
command-description-ispositive =
    Возвращает, является ли входное значение положительным.
command-description-isreal =
    Возвращает, является ли входное значение чисто вещественным (без мнимой части).
command-description-issubnormal =
    Возвращает, находится ли входное значение в субнормальной форме.
command-description-iszero =
    Возвращает, равно ли входное значение нулю.
command-description-pow =
    Вычисляет левую часть в степени правой части. x^y.
command-description-sqrt =
    Вычисляет квадратный корень входного значения.
command-description-cbrt =
    Вычисляет кубический корень входного значения.
command-description-root =
    Вычисляет корень N-й степени из входного значения.
command-description-hypot =
    Вычисляет гипотенузу треугольника с указанными катетами A и B.
command-description-sin =
    Вычисляет синус входного значения.
command-description-sinpi =
    Вычисляет синус входного значения, умноженного на пи.
command-description-asin =
    Вычисляет арксинус входного значения.
command-description-asinpi =
    Вычисляет арксинус входного значения, умноженного на пи.
command-description-cos =
    Вычисляет косинус входного значения.
command-description-cospi =
    Вычисляет косинус входного значения, умноженного на пи.
command-description-acos =
    Вычисляет арккосинус входного значения.
command-description-acospi =
    Вычисляет арккосинус входного значения, умноженного на пи.
command-description-tan =
    Вычисляет тангенс входного значения.
command-description-tanpi =
    Вычисляет тангенс входного значения, умноженного на пи.
command-description-atan =
    Вычисляет арктангенс входного значения.
command-description-atanpi =
    Вычисляет арктангенс входного значения, умноженного на пи.
command-description-iterate =
    Применяет указанную функцию ко входным данным N раз и возвращает список результатов.
    Представьте это как последовательное применение функции к значению с запоминанием всех промежуточных значений.
command-description-pick =
    Выбирает случайное значение из входных данных.
command-description-tee =
    Направляет входные данные в указанный блок, игнорируя результат блока.
    По сути, это позволяет создать в коде ветвь для выполнения нескольких операций над одним значением.
command-description-cmd-info =
    Возвращает CommandSpec для указанной команды.
    Сама по себе выводит справочное сообщение команды.
command-description-comp-rm =
    Убирает указанный компонент у сущности.

command-description-overlay-toggle = Включить или выключить оверлей
command-description-overlay-add = Добавить оверлей (если его ещё нет)
command-description-overlay-remove = Убрать оверлей
