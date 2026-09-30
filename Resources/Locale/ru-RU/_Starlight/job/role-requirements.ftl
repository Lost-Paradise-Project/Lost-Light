job-no-requirements = This job has no requirements.
ghost-role-no-requirements = This role has no requirements.

# Coloring rule of thumb: limegreen for met requirement, yellow for unmet requirement that can still be met, red for unmeetable

role-timer-department-sufficient = You have [color=limegreen]{ TOSTRING($current, "0") }[/color] of the [color=lightblue]{ TOSTRING($required, "0") }[/color] playtime required in the [color={ $departmentColor }]{ $department }[/color] department.
role-timer-department-insufficient = Требуется ещё [color=yellow]{ $time }[/color] игрового времени за [color={ $departmentColor }]{ $department }[/color], чтобы разблокировать это.
role-timer-department-not-too-high = You have [color=limegreen]{ TOSTRING($current, "0") }[/color] of at most [color=lightblue]{ TOSTRING($required, "0") }[/color] playtime in the [color={ $departmentColor }]{ $department }[/color] department.
role-timer-department-too-high = Требуется на [color=yellow]{ $time }[/color] меньше игрового времени за [color={ $departmentColor }]{ $department }[/color], чтобы выбрать это. (Вы пытаетесь играть за роль для новичков?)

role-timer-overall-sufficient = You have [color=limegreen]{ TOSTRING($current, "0") }[/color] of the [color=lightblue]{ TOSTRING($required, "0") }[/color] total playtime required.
role-timer-overall-insufficient = Требуется ещё [color=yellow]{ $time }[/color] общего игрового времени, чтобы разблокировать это.
role-timer-overall-not-too-high = You have [color=limegreen]{ TOSTRING($current, "0") }[/color] of at most [color=lightblue]{ TOSTRING($required, "0") }[/color] total playtime.
role-timer-overall-too-high = Требуется на [color=yellow]{ $time }[/color] меньше общего игрового времени, чтобы выбрать это. (Вы пытаетесь играть за роль для новичков?)

role-timer-role-sufficient = You have [color=limegreen]{ TOSTRING($current, "0") }[/color] of the [color=lightblue]{ TOSTRING($required, "0") }[/color] playtime required as [color={ $departmentColor }]{ $job }[/color].
role-timer-role-insufficient = Требуется ещё [color=yellow]{ $time }[/color] игрового времени в качестве [color={ $departmentColor }]{ $job }[/color], чтобы разблокировать это.
role-timer-role-not-too-high = You have [color=limegreen]{ TOSTRING($current, "0") }[/color] of at most [color=lightblue]{ TOSTRING($required, "0") }[/color] playtime as [color={ $departmentColor }]{ $job }[/color].
role-timer-role-too-high = Требуется на [color=yellow]{ $time }[/color] меньше игрового времени в качестве [color={ $departmentColor }]{ $job }[/color], чтобы выбрать эту это. (Вы пытаетесь играть за роль для новичков?)

role-whitelisted = You [color=limegreen]are[/color] whitelisted to play this role.
role-not-whitelisted = Вы не включены в белый список на эту роль.

role-timer-age-old-enough = Your character's age must be at least [color=limegreen]{ $age }[/color] to play this role.
role-timer-age-not-old-enough = Your character's age must be at least [color=yellow]{ $age }[/color] to play this role.
role-timer-age-young-enough = Your character's age must be at most [color=limegreen]{ $age }[/color] to play this role.
role-timer-age-not-young-enough = Your character's age must be at most [color=yellow]{ $age }[/color] to play this role.

role-timer-whitelisted-species-pass = Your character [color=limegreen]must[/color] be one of the following species to play this role: [color=limegreen]{ $species }[/color]
role-timer-whitelisted-species-fail = Your character [color=yellow]must[/color] be one of the following species to play this role: [color=yellow]{ $species }[/color]
role-timer-blacklisted-species-pass = Your character [color=limegreen]must not[/color] be one of the following species to play this role: [color=limegreen]{ $species }[/color]
role-timer-blacklisted-species-fail = Your character [color=yellow]must not[/color] be one of the following species to play this role: [color=yellow]{ $species }[/color]

role-timer-whitelisted-traits-pass = Your character [color=limegreen]must[/color] have one of the following traits: [color=limegreen]{ $traits }[/color]
role-timer-whitelisted-traits-fail = Your character [color=yellow]must[/color] have one of the following traits: [color=yellow]{ $traits }[/color]
role-timer-blacklisted-traits-pass = Your character [color=limegreen]must not[/color] have one of the following traits: [color=limegreen]{ $traits }[/color]
role-timer-blacklisted-traits-fail = Your character [color=yellow]must not[/color] have one of the following traits: [color=yellow]{ $traits }[/color]

role-ban = Вам заблокировали эту роль.
