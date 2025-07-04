# Nightreign Weapon Scaling
![image](https://i.imgur.com/NWeRfWg.png)

Outputs a ranking of weapons' scaling based on the chosen Nightfarer.

Weapon categories are listed in square brackets. All specific weapons listed have different scaling than the average weapon within their category.

Right now, this is the following algorithm for determining a weapon's score:
`NightfarerGradeSTR*WeaponGradeSTR + NightfarerGradeDEX*WeaponGradeDEX + NightfarerGradeINT*WeaponGradeINT + NightfarerGradeFAI*WeaponGradeFAI + NightfarerGradeARC*WeaponGradeARC`
The grade is converted to a numerical value (S being the highest number, no scaling being zero) for calculation purposes.

Right now this has a clear bias towards the bigger scaling, meaning balance characters like Wylder have strange rankings. These are still a good reference point and not necessarily "wrong," but the algorithm could be immensely improved. Please let me know if you know of a better way to calculate this.

The algorithm for calculating the weapons' "score" is located in Nightfarer.ScalingScore.

_See "nightreign_weapon_scaling.txt" for the info file listing all weapon scalings._
