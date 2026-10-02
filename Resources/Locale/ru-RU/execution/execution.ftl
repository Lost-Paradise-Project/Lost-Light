execution-verb-name = Казнить
execution-verb-message = Используйте своё оружие, чтобы казнить кого-то.

suicide-verb-name = Самоубийство
suicide-verb-message = Используйте своё оружие, чтобы совершить самоубийство.

# All the below localisation strings have access to the following variables
# attacker (the person committing the execution)
# victim (the person being executed)
# weapon (the weapon used for the execution)

# STARLIGHT CONTROLLED
# God these need to move to their own file
execution-popup-melee-initial-internal = Вы прикладываете { $weapon } к горлу { $victim }.
execution-popup-gun-initial-internal = Вы приставляете дуло { THE($weapon) } к голове { THE($victim) }.

execution-popup-melee-initial-external = { CAPITALIZE($attacker) } прикладывает свой { $weapon } к горлу { $victim }.
execution-popup-gun-initial-external  = { CAPITALIZE(THE($attacker)) } приставляет дуло { $weapon } к голове { THE($victim) }.

execution-popup-melee-complete-internal = Вы перерезаете горло { $victim }!
execution-popup-gun-complete-internal = Вы стреляете { THE($victim) } в голову!

execution-popup-melee-complete-external = { CAPITALIZE($attacker) } перерезает горло { $victim }!
execution-popup-gun-complete-external = { CAPITALIZE(THE($attacker)) } стреляет { THE($victim) } в голову!

execution-popup-gun-clumsy-internal = Вы промахиваетесь по голове { THE($victim) } и стреляете себе в ногу!
execution-popup-gun-clumsy-external = { CAPITALIZE(THE($attacker)) } промахивается по { THE($victim) } и стреляет себе в ногу!

execution-popup-gun-empty = { CAPITALIZE(THE($weapon)) } щёлкает вхолостую.

execution-popup-self-melee-initial-internal = Вы приставляете { THE($weapon) } к собственному горлу.
execution-popup-self-gun-initial-internal = Вы засовываете дуло { THE($weapon) } себе в рот.

execution-popup-self-melee-initial-external = { CAPITALIZE(THE($attacker)) } приставляет { $weapon } к собственному горлу.
execution-popup-self-gun-initial-external = { CAPITALIZE(THE($attacker)) } засовывает дуло { $weapon } себе в рот.

execution-popup-self-melee-complete-internal = Вы перерезаете себе горло!
execution-popup-self-gun-complete-internal = Вы стреляете себе в голову!

execution-popup-self-melee-complete-external = { CAPITALIZE(THE($attacker)) } перерезает себе горло!
execution-popup-self-gun-complete-external = { CAPITALIZE(THE($attacker)) } стреляет себе в голову!
# Starlight end
