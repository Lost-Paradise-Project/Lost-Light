## Secure Command Terminal – UI strings

secure-terminal-window-title = Защищённый терминал
secure-terminal-requests-header = Запросы
secure-terminal-information-header = Информация
secure-terminal-authorization-header = Авторизация

secure-terminal-select-request = Выберите запрос в списке слева, чтобы увидеть подробности.

secure-terminal-request-button = Запрос
secure-terminal-request-button-confirm = Подтвердить?
secure-terminal-authorize-button = Разрешить
secure-terminal-deny-button = Отклонить / Отмена
secure-terminal-rescind-button = Отозвать
secure-terminal-recall-button = Отозвать оружейную
secure-terminal-recall-locked = { $minutes ->
    [1] Отзыв будет доступен через 1 минуту.
    *[other] Отзыв будет доступен через { $minutes } мин.
}
secure-terminal-used-note = Эта оружейная была окончательно активирована или отозвана в этом раунде и не может быть развёрнута снова.
secure-terminal-already-used = Этот ресурс уже использован в этом раунде и не может быть запрошен снова.

secure-terminal-auth-waiting = Нет активного предложения по этому запросу. Требуемая авторизация:
secure-terminal-auth-desc = Текущее предложение — нет ответа = [color=red]красный[/color], согласие = [color=green]зелёный[/color]:
secure-terminal-awaiting-admin-desc = Полностью подтверждено местным командованием. Ожидается ответ Центрального командования…
secure-terminal-awaiting-member = Ожидание: { $label }
secure-terminal-authorized-by-label = Подписали:
secure-terminal-rescind-label = Отзыв

secure-terminal-pending-countdown-label = Истекает через { $minutes } мин. { $seconds } с…
secure-terminal-countdown-label = Активация через { $minutes } мин. { $seconds } с…

secure-terminal-fee-note = Плата за обработку: { $fee }
secure-terminal-salary-note = Изменения зарплат:
secure-terminal-salary-source-everyone = Все
secure-terminal-salary-source-interstellar-trade-guild = Межзвёздная торговая гильдия
secure-terminal-delay-note = { $minutes ->
    [1] Расчётное время: 1 минута после авторизации.
    *[other] Расчётное время: { $minutes } мин. после авторизации.
}
secure-terminal-delay-note-immediate = Вступает в силу сразу после авторизации.

secure-terminal-requires-no-war-note = Отключено во время военных операций.
secure-terminal-requires-war-note = Доступно только во время военных операций.
secure-terminal-requires-alert-note = Требуется активный уровень тревоги: { $level }.
secure-terminal-alert-time-remaining = { $minutes ->
    [1] Уровень тревоги должен действовать ещё 1 минуту, прежде чем это можно будет запросить.
    *[other] Уровень тревоги должен действовать ещё { $minutes } мин., прежде чем это можно будет запросить.
}
secure-terminal-on-cooldown-note = { $minutes ->
    [1] На перезарядке — доступно через 1 минуту.
    *[other] На перезарядке — доступно через { $minutes } мин.
}
secure-terminal-requires-alert-suffix = Нужно: { $level }
secure-terminal-requires-war-suffix = Нужно: военная операция

secure-terminal-reason = Укажите причину запроса:

## Server → global announcements

secure-terminal-proposal-created = { $request } запрошено и ожидает совместной авторизации.
secure-terminal-proposal-created-reason = { $request } запрошено и ожидает совместной авторизации. Причина: { $reason }
secure-terminal-proposal-denied = Запрос «{ $request }» отменён.
secure-terminal-proposal-denied-cc = Запрос «{ $request }» отклонён Центральным командованием.
secure-terminal-proposal-cancelled-by = Защищённый терминал — { $actor } отменил запрос «{ $request }».
secure-terminal-proposal-rescinded-by = Защищённый терминал — запрос «{ $request }» отозвали: { $rescinders }.
secure-terminal-radio-proposal = Предложено: { $request }. Пожалуйста, подойдите к ближайшему устройству карточной авторизации, чтобы разрешить или отклонить.
secure-terminal-radio-proposal-reason = Предложено: { $request }. Пожалуйста, подойдите к ближайшему устройству карточной авторизации, чтобы разрешить или отклонить. Причина: { $reason }
secure-terminal-radio-denied = Запрос «{ $request }» отменён.
secure-terminal-activation-countdown = { $request } полностью авторизовано.
    Активация через { $minutes } мин.
    Зарплата станции снижена из-за стоимости мобилизации.
secure-terminal-unknown-job = Неизвестно

## Popup messages

secure-terminal-no-station = Для этой консоли не найдена станция.
secure-terminal-request-denied = Доступ запрещён.
secure-terminal-authorize-denied = У вас нет необходимого допуска, чтобы подписать этот запрос.
secure-terminal-requires-war = Этот запрос доступен только после официального объявления военных операций.
secure-terminal-wrong-alert = Текущий уровень тревоги не соответствует требованиям этого запроса.
secure-terminal-alert-not-long-enough = Уровень тревоги действует недостаточно долго для авторизации. Подождите и повторите попытку.
secure-terminal-recall-too-soon = Оружейная развёрнута недостаточно давно, чтобы её отозвать. Подождите.
secure-terminal-on-cooldown = Этот запрос на перезарядке.
secure-terminal-already-pending = Предложение по этому запросу уже ожидает рассмотрения.
secure-terminal-already-active = Другой запрос уже ожидает рассмотрения или выполняется. Дождитесь его завершения, прежде чем делать новый.
secure-terminal-no-active-proposal = Активное предложение по этому запросу не найдено.
secure-terminal-already-authorized = Вы уже авторизовали это предложение.
secure-terminal-already-activated = Этот терминал уже авторизовал это предложение.
secure-terminal-auth-note = Этот терминал предназначен только для авторизации.
secure-terminal-authorized-by = Внимание — запрос «{ $request }» авторизован. Авторизовали: { $signatories }.
secure-terminal-armory-recalled = Отдан приказ об отзыве: { $request }. Развёртывание оружейной отменено.
secure-terminal-awaiting-admin = Внимание — запрос «{ $request }» отправлен. Ожидается авторизация Центральным командованием.
secure-terminal-admin = Запрос одобрения администрацией: { $request }
                        Причина: { $reason }
                        Используйте всплывающее окно или AGhost (интерфейс связи), чтобы одобрить или отклонить.
                        Закрытие окна НЕ отклонит запрос.
secure-terminal-admin-approval-title = Одобрение администрации для защищённого терминала
secure-terminal-admin-approval-request = Запрос: { $request }
secure-terminal-admin-approval-description = Действие: { $description }
secure-terminal-admin-approval-reason = Причина: { $reason }
secure-terminal-admin-approval-authorized-by = Подписали:
secure-terminal-admin-approval-approve = Одобрить
secure-terminal-admin-approval-deny = Отклонить
secure-terminal-authorized-by-central-command = Центральное командование подтвердило этот запрос.
secure-terminal-authorized-by-central-command-deferred = Центральное командование передало решение командованию станции.

## Request names & descriptions

secure-terminal-ai-leadership-name = Руководство ИИ
secure-terminal-captain-and-ntrep-name = Капитан и представитель НаноТрейзен
secure-terminal-captain-name = Капитан
secure-terminal-captain-or-ntrep-name = Капитан или представитель НаноТрейзен
secure-terminal-chief-medical-officer-name = Главный врач
secure-terminal-civilian-leadership-name = Гражданское руководство
secure-terminal-command-name = Командование
secure-terminal-engineering-leadership-name = Инженерное руководство
secure-terminal-head-of-security-name = Глава службы безопасности
secure-terminal-med-and-science-leadership-name = Руководство медицинского и научного отделов
secure-terminal-medical-leadership-name = Медицинское руководство
secure-terminal-research-director-name = Директор исследований
secure-terminal-security-and-command-name = Служба безопасности и командование
secure-terminal-security-leadership-name = Руководство службы безопасности
secure-terminal-security-name = Служба безопасности

secure-terminal-warops-security-name = Ядерная группа реагирования
secure-terminal-warops-security-desc = Направляет отряд СБ ОБР, специализированный на военных операциях. Доступно только во время военных операций.
                                       Используйте, когда станция подвергается прямому вооружённому нападению во время объявленной военной операции.
secure-terminal-warops-security-announcement = Отряд быстрого реагирования — специализированный отряд СБ — авторизован и уже в пути. Расчётное время прибытия: 30 минут.

secure-terminal-ert-security-name = СБ ОБР
secure-terminal-ert-security-desc = Направляет отряд СБ ОБР.
secure-terminal-ert-security-announcement = Отряд быстрого реагирования — отряд СБ — авторизован и уже в пути. Расчётное время прибытия: 10 минут.

secure-terminal-ert-engineering-name = Инженеры ОБР
secure-terminal-ert-engineering-desc = Направляет инженерный отряд ОБР для помощи с критической инфраструктурой станции.
    Рекомендуется, если станция понесла катастрофические конструкционные, атмосферные или энергетические повреждения, которые не устранить своими силами.
secure-terminal-ert-engineering-announcement = Отряд быстрого реагирования — инженерный отряд — авторизован и уже в пути. Расчётное время прибытия: 10 минут.

secure-terminal-ert-medical-name = Медики ОБР
secure-terminal-ert-medical-desc = Направляет медицинский отряд ОБР для сортировки при массовых потерях и экстренных операций.
    Рекомендуется, если медицинский отдел станции перегружен, недееспособен или уничтожен.
secure-terminal-ert-medical-announcement = Отряд быстрого реагирования — медицинский отряд — авторизован и уже в пути. Расчётное время прибытия: 10 минут.

secure-terminal-ert-janitorial-name = Уборщики ОБР
secure-terminal-ert-janitorial-desc = Направляет отряд уборщиков ОБР для устранения опасных загрязнений и восстановления станции.
    Рекомендуется после масштабного биологического, химического или экологического заражения, требующего быстрой дезактивации.
secure-terminal-ert-janitorial-announcement = Отряд быстрого реагирования — отряд уборщиков — авторизован и уже в пути. Расчётное время прибытия: 10 минут.

secure-terminal-ert-chaplain-name = Священник ОБР
secure-terminal-ert-chaplain-desc = Направляет священника ОБР для поддержки морального духа экипажа и последнего напутствия.
    Обеспечивает духовную поддержку и сохраняет боевой дух экипажа при затяжных чрезвычайных ситуациях.
secure-terminal-ert-chaplain-announcement = Отряд быстрого реагирования — священник — авторизован и уже в пути. Расчётное время прибытия: 10 минут.

secure-terminal-ert-cburn-name = ОБР РХБЗ
secure-terminal-ert-cburn-desc = Направляет отряд ОБР РХБЗ.
secure-terminal-ert-cburn-announcement = Отряд быстрого реагирования — отряд РХБЗ — авторизован и уже в пути. Расчётное время прибытия: 15 минут.

secure-terminal-code-gamma-name = Код ГАММА
secure-terminal-code-gamma-desc = Повышает тревогу на станции до [color=palevioletred]ГАММА[/color]. Военное положение — всех гражданских должна сопровождать СБ в безопасные зоны.
    СБ должна быть вооружена постоянно. Все гражданские должны явиться к ближайшему главе отдела и под сопровождением проследовать в безопасное место. Включается аварийное освещение.
secure-terminal-code-gamma-announcement = Внимание! Код ГАММА скоро вступит в силу. Будет введено военное положение. Всему экипажу немедленно доложить ближайшему главе.

secure-terminal-end-gamma-name = Отбой тревоги ГАММА
secure-terminal-end-gamma-desc = Снимает тревогу [color=palevioletred]ГАММА[/color] и возвращает станцию в зелёный код. Требуется, чтобы ГАММА действовала не менее 15 минут.
secure-terminal-end-gamma-announcement = Код ГАММА снимается. Станция возвращается к нормальной работе. Сохраняйте бдительность и ждите дальнейших указаний вашего главы.

secure-terminal-code-psi-name = Код ПСИ
secure-terminal-code-psi-desc = Повышает тревогу на станции до [color=mediumpurple]ПСИ[/color]. Обнаружены враждебные синтетические юниты — избегайте несоответствующих киборгов и обращайтесь к командованию.
    Означает активность враждебных или несоответствующих киборгов. Экипаж должен избегать незнакомых боргов, держаться группами и следовать указаниям глав отделов.
secure-terminal-code-psi-announcement = Внимание! Командование объявило код ПСИ. Кремниевые юниты, не принадлежащие НаноТрейзен, признаны активной угрозой. Всему экипажу — доложить ближайшему главе.

secure-terminal-end-psi-name = Отбой тревоги ПСИ
secure-terminal-end-psi-desc = Снимает тревогу [color=mediumpurple]ПСИ[/color] и возвращает станцию в зелёный код. Требуется, чтобы ПСИ действовала не менее 15 минут.
secure-terminal-end-psi-announcement = Код ПСИ снимается. Выявленная синтетическая угроза нейтрализована. Станция возвращается к нормальной работе.

secure-terminal-armory-gamma-name = Гамма-оружейная
secure-terminal-armory-gamma-desc = Отправляет [color=palevioletred]гамма-оружейную[/color] — склад тяжёлого оружия для ситуаций ГАММА. Разовое развёртывание.
                                    Выдаёт тяжёлое снаряжение СБ уполномоченному персоналу.
secure-terminal-armory-gamma-announcement = Гамма-оружейная авторизована и уже в пути.

secure-terminal-armory-psi-name = Пси-оружейная
secure-terminal-armory-psi-desc = Отправляет [color=mediumpurple]пси-оружейную[/color] — противокибернетическое вооружение для ситуаций ПСИ. Разовое развёртывание.
                                  Даёт средства для нейтрализации несоответствующих синтетиков.
secure-terminal-armory-psi-announcement = Пси-оружейная авторизована и уже в пути.

secure-terminal-med-pod-name = Экстренный медицинский модуль
secure-terminal-med-pod-desc = Отправляет экстренный медицинский модуль — быстро разворачиваемую сортировку с хирургическим и реанимационным оборудованием.
    Используйте, если массовые потери превышают возможности медотсека станции.
secure-terminal-med-pod-announcement = Экстренный медицинский модуль авторизован и уже в пути. Расчётное время прибытия: 5 минут.

secure-terminal-itg-salvage-team-name = Спасательная команда МТГ
secure-terminal-itg-salvage-team-desc = Нанимает местную спасательную команду Межзвёздной торговой гильдии для борьбы с активными угрозами станции.
    Рекомендуется, если на станции нет СБ или она не справляется без помощи.
secure-terminal-itg-salvage-team-announcement = Местная спасательная команда Межзвёздной торговой гильдии нанята для борьбы с активными угрозами станции.

secure-terminal-dismiss-itg-salvage-team-name = Распустить спасательную команду МТГ
secure-terminal-dismiss-itg-salvage-team-desc = Прекращает контракт помощи Межзвёздной торговой гильдии и возвращает её команду к обычным обязанностям.
    Рекомендуется, когда все угрозы станции устранены.
secure-terminal-dismiss-itg-salvage-team-announcement = Контракт Межзвёздной торговой гильдии завершён, и её спасательная команда вернулась к обычным обязанностям.

secure-terminal-nukerequest-name = Код самоуничтожения
secure-terminal-nukerequest-desc = Запросить коды ядерного самоуничтожения.
                                   Злоупотребление системой запроса ядерных кодов не допускается ни при каких обстоятельствах.
                                   Отправка запроса не гарантирует ответа.

secure-terminal-code-violet-name = Код Фиолетовый
secure-terminal-code-violet-desc = Объявляет [color=Violet]фиолетовую[/color] тревогу в ответ на подтверждённую вспышку по всей станции.

secure-terminal-end-violet-name = Отбой фиолетовой тревоги
secure-terminal-end-violet-desc = Снимает [color=Violet]фиолетовую[/color] тревогу и возвращает станцию в зелёный код. Требуется, чтобы фиолетовая тревога действовала не менее 10 минут.

secure-terminal-emergency-maintenance-name = Экстренный доступ в техтоннели
secure-terminal-emergency-maintenance-desc = Предоставить экстренный доступ в техтоннели.
secure-terminal-emergency-maintenance-announcement = Ограничения доступа на техтоннели и внешние шлюзы сняты.

secure-terminal-end-emergency-maintenance-name = Отозвать экстренный доступ в техтоннели
secure-terminal-end-emergency-maintenance-desc = Отозвать экстренный доступ в техтоннели.
secure-terminal-end-emergency-maintenance-announcement = Ограничения доступа на техтоннели и внешние шлюзы восстановлены.

secure-terminal-emergency-station-name = Экстренный доступ по всей станции
secure-terminal-emergency-station-desc = Включить экстренный доступ по всей станции.
secure-terminal-emergency-station-announcement = Ограничения доступа на всех шлюзах станции сняты из-за продолжающегося кризиса. Законы о проникновении по-прежнему действуют, если командование не прикажет иное.

secure-terminal-end-emergency-station-name = Отключить экстренный доступ по всей станции
secure-terminal-end-emergency-station-desc = Отключить экстренный доступ по всей станции.
secure-terminal-end-emergency-station-announcement = Ограничения доступа на всех шлюзах станции восстановлены. Если застряли, обратитесь к ИИ станции или за помощью к коллеге.

secure-terminal-unlock-escape-pods-name = Разблокировать спасательные капсулы
secure-terminal-unlock-escape-pods-desc = Спасательные капсулы будут разблокированы, и экипаж сможет запускать их по желанию
secure-terminal-unlock-escape-pods-announcement = Командование разрешило использовать спасательные капсулы для эвакуации

secure-terminal-ui-veto = Вето
secure-terminal-insufficient-funds = Недостаточно средств. Нужно: { $fee }₡
secure-terminal-fee-held = { $fee }₡ заблокировано до подтверждения.
