using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightreignWeaponScaling;

internal class Scaling
{
    public char Grade { get; private set; }

    /// <summary>
    /// Bigger <see cref="Grade"/> means bigger Score.<br/>
    /// Used for comparisons.
    /// </summary>
    public int Score
    {
        get
        {
            switch (Grade)
            {
                case 'S': return 6;
                case 'A': return 5;
                case 'B': return 4;
                case 'C': return 2;
                case 'D': return 2;
                case 'E': return 1;
                default: return 0;
            }
        }
    }

    public float ScoreNormalized => Score / 6f;

    public Scaling(char grade)
    {
        Grade = char.ToUpper(grade);

    } // end constructor

} // end class Scaling