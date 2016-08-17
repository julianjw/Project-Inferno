using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Weapon
{
    public string name;
    private WeaponType weaponType;
    private float weaponDamage;

    public Weapon(string name, WeaponType type, float damage)
    {
        this.name = name;
        this.weaponType = type;
        this.weaponDamage = damage;
    }
}
