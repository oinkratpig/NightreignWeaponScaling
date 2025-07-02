# Nightreign Weapon Scaling
Outputs a ranking of weapons' scaling based on the chosen Nightfarer.

Right now, this is the following algorithm for determining a weapon's score:
`NightfarerGradeSTR*WeaponGradeSTR + NightfarerGradeDEX*WeaponGradeDEX + NightfarerGradeINT*WeaponGradeINT + NightfarerGradeFAI*WeaponGradeFAI + NightfarerGradeARC*WeaponGradeARC`
The grade is converted to a numerical value (S being the highest number, no scaling being zero) for calculation purposes.

Right now this has a clear bias towards the bigger scaling, meaning balance characters like Wylder have strange rankings. These are still a good reference point, but the algorithm could be immensely improved. Please let me know if you know of a better way to calculate this.

_See "nightreign_weapon_scaling.txt" for the info file listing all weapon scalings._