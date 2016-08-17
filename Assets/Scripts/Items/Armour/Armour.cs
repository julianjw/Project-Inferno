using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Armour
{
    public string name;
    private ArmourType armourType;
    private float armourResistance;

    public Armour(string name, ArmourType type, float resistance)
    {
        this.name = name;
        this.armourType = type;
        this.armourResistance = resistance;
    }

}
