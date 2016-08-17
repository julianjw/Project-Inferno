using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroClass
{

    public string name { get; set; }
    protected List<WeaponType> weaponsAllowed;
    protected List<ArmourType> armoursAllowed;

    public HeroClass(string name, List<WeaponType> weapons, List<ArmourType> armours)
    {
        this.name = name;
        weaponsAllowed = weapons;
        armoursAllowed = armours;
    }
}