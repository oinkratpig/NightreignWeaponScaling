using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightreignWeaponScaling;

internal class WeaponCategory
{
    public string Name { get; private set; }
    /// <summary>
    /// Weapons with scaling that does not match the average scaling within the weapon category.
    /// </summary>
    public List<Weapon> UniquelyScaledWeapons { get; set; }
    public ScalingSet AverageScalings { get; private set; }

    public WeaponCategory(string name, char avgStrength, char avgDexterity, char avgIntelligence, char avgFaith, char avgArcane)
    {
        Name = name;
        AverageScalings = new ScalingSet(avgStrength, avgDexterity, avgIntelligence, avgFaith, avgArcane);
        UniquelyScaledWeapons = new List<Weapon>();

    } // end constructor

} // end class WeaponCategory