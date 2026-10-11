# Menu
social-interaction-component-verb = Социальное взаимодействие

pet-verb = Погладить

# Wave
wave-verb = Помахать
waving-success = Вы машете { THE($target) }.
waving-success-others = { CAPITALIZE(THE($user)) } машет { THE($target) }.
waving-emote = машет { THE($target) }.
waving-emote-self = машет.

# Look
look-verb = Посмотреть
looking-success = Вы смотрите на { THE($target) }.
looking-success-others = { CAPITALIZE(THE($user)) } смотрит на { THE($target) }.
looking-emote = смотрит на { THE($target) }.
looking-emote-self = смотрит на { REFLEXIVE($target) }.

# Sniff - for animals with noses
sniff-verb = Обнюхать
sniffing-success = Вы обнюхиваете { THE($target) }.
sniffing-success-others = { CAPITALIZE(THE($user)) } обнюхивает { THE($target) }.
sniffing-emote = обнюхивает { THE($target) }.
sniffing-emote-self = обнюхивает { REFLEXIVE($target) }.

# Palpate - 'sniffing' but for creatures with antennae
palpate-antennae-verb = Ощупать усиками
palpate-antennae-success = Вы ощупываете { THE($target) } усиками.
palpate-antennae-success-others = { CAPITALIZE(THE($user)) } ощупывает { THE($target) } усиками.
palpate-antennae-emote = ощупывает { THE($target) } { GENDER($user) ->
    *[other] своими
} усиками.
palpate-antennae-emote-self = ощупывает { REFLEXIVE($target) } { GENDER($user) ->
    *[other] своими
} усиками.

# Pat
pat-verb = Похлопать
patting-success = Вы похлопываете { THE($target) }.
patting-success-others = { CAPITALIZE(THE($user)) } похлопывает { THE($target) }.
patting-emote = похлопывает { THE($target) }.

# Pat alt. - you can pet dogs
petting-success = Вы гладите { THE($target) } по голове.
petting-success-others = { CAPITALIZE(THE($user)) } гладит { THE($target) } по голове.
petting-emote = гладит { THE($target) } по голове.

# Boop (nose)
boop-verb = Бупнуть
booping-success = Вы бупаете { THE($target) } по носу.
booping-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } по носу.
booping-emote = бупает { THE($target) } по носу.

# Boop alt. - Resomi/Avali and Shadekin don't have noses
booping-snoot-success = Вы бупаете { THE($target) } по мордочке.
booping-snoot-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } по мордочке.
booping-snoot-emote = бупает { THE($target) } по мордочке.

# Boop alt. - Moths don't have noses
booping-moth-success = Вы бупаете { THE($target) } между фасеточными глазами.
booping-moth-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } между фасеточными глазами.
booping-moth-emote = бупает { THE($target) } между фасеточными глазами.

# Boop alt. - Laspi are squishy
booping-laspi-success = Вы бупаете { THE($target) }, и лицо забавно колышется.
booping-laspi-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) }, и лицо забавно колышется.
booping-laspi-emote = бупает { THE($target) }, и лицо забавно колышется.

# Boop alt. - Generic slimes don't have noses
booping-slime-success = Вы бупаете { THE($target) } туда, где должен быть нос, и остаётся вмятинка.
booping-slime-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } туда, где должен быть нос, и остаётся вмятинка.
booping-slime-emote = бупает { THE($target) } туда, где должен быть нос, и остаётся вмятинка.

# Boop alt. - Cyclorites don't have noses
booping-rocky-success = Вы бупаете { THE($target) } по каменному лбу.
booping-rocky-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } по каменному лбу.
booping-rocky-emote = бупает { THE($target) } по каменному лбу.

# Boop alt. - Cyborgs and IPCs don't have noses
booping-borg-success = Вы бупаете { THE($target) } по металлическому лицу.
booping-borg-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } по металлическому лицу.
booping-borg-emote = бупает { THE($target) } по металлическому лицу.

# Boop alt. - AI Cores have screens, not noses
booping-screen-success = Вы бупаете { THE($target) } по ЭЛТ-экрану.
booping-screen-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } по ЭЛТ-экрану.
booping-screen-emote = бупает { THE($target) } по ЭЛТ-экрану.

# Boop alt. - Parrots and birds have beaks
booping-beak-success = Вы бупаете { THE($target) } по клюву.
booping-beak-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } по клюву.
booping-beak-emote = бупает { THE($target) } по клюву.

# Boop alt. - Diona and plants don't have noses
booping-plant-success = Вы тянетесь сквозь ветви { THE($target) } и бупаете по коре.
booping-plant-success-others = { CAPITALIZE(THE($user)) } тянется сквозь ветви { THE($target) } и бупает по коре.
booping-plant-emote = тянется сквозь ветви { THE($target) } и бупает по коре.

# Boop alt. - Arachnids and spiders don't have noses
booping-spider-success = Вы бупаете { THE($target) } между множеством глаз.
booping-spider-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } между множеством глаз.
booping-spider-emote = бупает { THE($target) } между множеством глаз.

# Boop alt. - Tesla (good luck)
booping-tesla-success = Вы опрометчиво бупаете { THE($target) } по электрическому горизонту событий.
booping-tesla-success-others = { CAPITALIZE(THE($user)) } опрометчиво бупает { THE($target) } по электрическому горизонту событий.
booping-tesla-emote = опрометчиво бупает { THE($target) } по электрическому горизонту событий.

# Boop alt. - Generic fallback for creatures with no noses.
booping-generic-success = Вы бупаете { THE($target) } по лицу.
booping-generic-success-others = { CAPITALIZE(THE($user)) } бупает { THE($target) } по лицу.
booping-generic-emote = бупает { THE($target) } по лицу.
