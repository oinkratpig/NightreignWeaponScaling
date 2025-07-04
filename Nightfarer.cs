using System;
using System.Collections.Generic;
using System.Drawing.Text;
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
    public float ScalingScore(ScalingSet scalings)
    {
        // L2 Normalization
        double[] norm(float[] stats)
        {
            double len = Math.Sqrt(stats.Sum(s => s * s));
            return stats.Select(s => s / len).ToArray();
        }

        float[] nightfarerStats = { Scalings.Strength.Score, Scalings.Dexterity.Score, Scalings.Intelligence.Score, Scalings.Faith.Score, Scalings.Arcane.Score };
        float[] weaponStats = { scalings.Strength.Score, scalings.Dexterity.Score, scalings.Intelligence.Score, scalings.Faith.Score, scalings.Arcane.Score };

        return (float) norm(nightfarerStats).Zip(norm(weaponStats), (a, b) => a * b).Sum();

    } // end WeaponScore

} // end class Nightfarer