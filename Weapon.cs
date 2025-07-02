using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightreignWeaponScaling;

internal class Weapon
{
    public string Name { get; private set; }
    public ScalingSet Scalings { get; private set; }

    public Weapon(string name, char strength, char dexterity, char intelligence, char faith, char arcane)
    {
        Name = name;
        Scalings = new ScalingSet(strength, dexterity, intelligence, faith, arcane);

    } // end constructor

    /// <summary>
    /// Returns true if scalings are identical to another set of scalings.
    /// </summary>
    public bool AreScalingsSame(ScalingSet scalings)
    {
        return Scalings.Strength.Grade == scalings.Strength.Grade &&
            Scalings.Dexterity.Grade == scalings.Dexterity.Grade &&
            Scalings.Intelligence.Grade == scalings.Intelligence.Grade &&
            Scalings.Faith.Grade == scalings.Faith.Grade &&
            Scalings.Arcane.Grade == scalings.Arcane.Grade;

    } // end AreScalingsSame

} // end class Weapon