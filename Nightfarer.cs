using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightreignWeaponScaling;

/// <summary>
/// Holds data for an individual Nightfarer.
/// </summary>
internal class Nightfarer
{
    public string Name { get; private set; }
    public ScalingSet Scalings { get; private set; }

    public Nightfarer(string name, char strength, char dexterity, char intelligence, char faith, char arcane)
    {
        Name = name;
        Scalings = new ScalingSet(strength, dexterity, intelligence, faith, arcane);

    } // end constructor

    /// <summary>
    /// Calculate a "score" for the weapon (or set of scalings) based on Nightfarer's scalings.
    /// </summary>
    public int ScalingScore(ScalingSet scalings)
    {
        return Scalings.Strength.Score * scalings.Strength.Score +
            Scalings.Dexterity.Score * scalings.Dexterity.Score +
            Scalings.Intelligence.Score * scalings.Intelligence.Score +
            Scalings.Faith.Score * scalings.Faith.Score +
            Scalings.Arcane.Score * scalings.Arcane.Score;

    } // end WeaponScore

} // end class Nightfarer