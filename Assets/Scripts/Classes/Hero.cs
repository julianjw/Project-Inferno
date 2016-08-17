using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Hero
{

    public struct Stats
    {
        public int STR;
        public int DEX;
        public int AGI;
        public int INT;
        public int VIT;
        public int LUK;
    }

    public string name;
    private float health;
    private Weapon weapon;
    private Armour armour;
    private Stats stats;

    private int level;

    private HeroClass heroClass;
    private Sprite sprite;

    public Hero(string name, HeroClass heroClass, Sprite sprite, Stats stats, int level)
    {
        this.name = name;
        this.heroClass = heroClass;
        health = 100f;
        this.sprite = sprite;
        this.stats = stats;
        this.level = level;
    }

    public Hero(string name, HeroClass heroClass, Sprite sprite)
    {
        this.name = name;
        this.heroClass = heroClass;
        health = 100f;
        this.sprite = sprite;
        InitialiseStats();
        this.level = 1;
    }

    private void InitialiseStats()
    {
        stats = new Hero.Stats();

        stats.STR = 1;
        stats.DEX = 1;
        stats.AGI = 1;
        stats.INT = 1;
        stats.VIT = 1;
        stats.LUK = 1;
    }

    public override string ToString()
    {
        return name;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetDamage()
    {
        float damage = 0f;

        damage = 25f;

        return damage;
    }

    public void TakeDamage(float damage)
    {
        this.health -= damage;

        if (health < 0f)
        {
            health = 0f;
        }
    }

    public string GetClassName()
    {
        return heroClass.name;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public Stats GetStats()
    {
        return stats;
    }

    public int GetLevel()
    {
        return level;
    }
}
