using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NightreignWeaponScaling;

/// <summary>
/// A set of scaling info and a total <see cref="Score"/>.
/// </summary>
internal class ScalingSet
{
    public Scaling Strength { get; private set; }
    public Scaling Dexterity { get; private set; }
    public Scaling Intelligence { get; private set; }
    public Scaling Faith { get; private set; }
    public Scaling Arcane { get; private set; }

    public ScalingSet(char strength, char dexterity, char intelligence, char faith, char arcane)
    {
        Strength = new Scaling(strength);
        Dexterity = new Scaling(dexterity);
        Intelligence = new Scaling(intelligence);
        Faith = new Scaling(faith);
        Arcane = new Scaling(arcane);

    } // end constructor

} // end class ScalingSet