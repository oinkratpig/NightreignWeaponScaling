using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightreignWeaponScaling;

/// <summary>
/// A <see cref="Weapon"/> that has been scored according to a <see cref="Nightfarer"/>'s scalings.
/// </summary>
internal class ScoredWeapon
{
    public int Score { get; private set; }
    public string Name { get; private set; }

    public ScoredWeapon(string weaponName, ScalingSet scalings, Nightfarer nightfarer)
    {
        Score = nightfarer.ScalingScore(scalings);
        Name = weaponName;

    } // end constructor

} // end ScoredWeapon