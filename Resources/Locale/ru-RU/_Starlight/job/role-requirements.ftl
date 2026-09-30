job-no-requirements = У этой должности нет требований.
ghost-role-no-requirements = У этой роли нет требований.

# Coloring rule of thumb: limegreen for met requirement, yellow for unmet requirement that can still be met, red for unmeetable

role-timer-department-sufficient = У вас [color=limegreen]{ TOSTRING($current, "0") }[/color] из [color=lightblue]{ TOSTRING($required, "0") }[/color] необходимого игрового времени в отделе [color={ $departmentColor }]{ $department }[/color].
role-timer-department-insufficient = У вас [color=yellow]{ TOSTRING($current, "0") }[/color] из [color=lightblue]{ TOSTRING($required, "0") }[/color] необходимого игрового времени в отделе [color={ $departmentColor }]{ $department }[/color].
role-timer-department-not-too-high = У вас [color=limegreen]{ TOSTRING($current, "0") }[/color] игрового времени в отделе [color={ $departmentColor }]{ $department }[/color] при максимально допустимых [color=lightblue]{ TOSTRING($required, "0") }[/color].
role-timer-department-too-high = У вас [color=red]{ TOSTRING($current, "0") }[/color] игрового времени в отделе [color={ $departmentColor }]{ $department }[/color] при максимально допустимых [color=lightblue]{ TOSTRING($required, "0") }[/color]. (Вы пытаетесь играть за роль для новичков?)

role-timer-overall-sufficient = У вас [color=limegreen]{ TOSTRING($current, "0") }[/color] из [color=lightblue]{ TOSTRING($required, "0") }[/color] необходимого общего игрового времени.
role-timer-overall-insufficient = У вас [color=yellow]{ TOSTRING($current, "0") }[/color] из [color=lightblue]{ TOSTRING($required, "0") }[/color] необходимого общего игрового времени.
role-timer-overall-not-too-high = У вас [color=limegreen]{ TOSTRING($current, "0") }[/color] общего игрового времени при максимально допустимых [color=lightblue]{ TOSTRING($required, "0") }[/color].
role-timer-overall-too-high = У вас [color=red]{ TOSTRING($current, "0") }[/color] общего игрового времени при максимально допустимых [color=lightblue]{ TOSTRING($required, "0") }[/color]. (Вы пытаетесь играть за роль для новичков?)

role-timer-role-sufficient = У вас [color=limegreen]{ TOSTRING($current, "0") }[/color] из [color=lightblue]{ TOSTRING($required, "0") }[/color] необходимого игрового времени в роли [color={ $departmentColor }]{ $job }[/color].
role-timer-role-insufficient = У вас [color=yellow]{ TOSTRING($current, "0") }[/color] из [color=lightblue]{ TOSTRING($required, "0") }[/color] необходимого игрового времени в роли [color={ $departmentColor }]{ $job }[/color].
role-timer-role-not-too-high = У вас [color=limegreen]{ TOSTRING($current, "0") }[/color] игрового времени в роли [color={ $departmentColor }]{ $job }[/color] при максимально допустимых [color=lightblue]{ TOSTRING($required, "0") }[/color].
role-timer-role-too-high = У вас [color=red]{ TOSTRING($current, "0") }[/color] игрового времени в роли [color={ $departmentColor }]{ $job }[/color] при максимально допустимых [color=lightblue]{ TOSTRING($required, "0") }[/color]. (Вы пытаетесь играть за роль для новичков?)

role-whitelisted = Вы [color=limegreen]включены[/color] в белый список на эту роль.
role-not-whitelisted = Вы [color=yellow]не включены[/color] в белый список на эту роль.

role-timer-age-old-enough = Возраст вашего персонажа должен быть не менее [color=limegreen]{ $age }[/color], чтобы играть за эту роль.
role-timer-age-not-old-enough = Возраст вашего персонажа должен быть не менее [color=yellow]{ $age }[/color], чтобы играть за эту роль.
role-timer-age-young-enough = Возраст вашего персонажа должен быть не более [color=limegreen]{ $age }[/color], чтобы играть за эту роль.
role-timer-age-not-young-enough = Возраст вашего персонажа должен быть не более [color=yellow]{ $age }[/color], чтобы играть за эту роль.

role-timer-whitelisted-species-pass = Ваш персонаж [color=limegreen]должен[/color] принадлежать к одной из следующих рас, чтобы играть за эту роль: [color=limegreen]{ $species }[/color]
role-timer-whitelisted-species-fail = Ваш персонаж [color=yellow]должен[/color] принадлежать к одной из следующих рас, чтобы играть за эту роль: [color=yellow]{ $species }[/color]
role-timer-blacklisted-species-pass = Ваш персонаж [color=limegreen]не должен[/color] принадлежать ни к одной из следующих рас, чтобы играть за эту роль: [color=limegreen]{ $species }[/color]
role-timer-blacklisted-species-fail = Ваш персонаж [color=yellow]не должен[/color] принадлежать ни к одной из следующих рас, чтобы играть за эту роль: [color=yellow]{ $species }[/color]

role-timer-whitelisted-traits-pass = Ваш персонаж [color=limegreen]должен[/color] иметь одну из следующих черт: [color=limegreen]{ $traits }[/color]
role-timer-whitelisted-traits-fail = Ваш персонаж [color=yellow]должен[/color] иметь одну из следующих черт: [color=yellow]{ $traits }[/color]
role-timer-blacklisted-traits-pass = Ваш персонаж [color=limegreen]не должен[/color] иметь ни одной из следующих черт: [color=limegreen]{ $traits }[/color]
role-timer-blacklisted-traits-fail = Ваш персонаж [color=yellow]не должен[/color] иметь ни одной из следующих черт: [color=yellow]{ $traits }[/color]

role-ban = Вам [color=red]заблокировали[/color] эту роль.
