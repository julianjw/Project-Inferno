using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Player
{
    public string name;
    public Color colour;

    private List<Hero> heroes;

    public Player(string name, Color colour)
    {
        this.name = name;
        this.colour = colour;
        this.heroes = new List<Hero>();
    }

    public void AddHero(Hero hero)
    {
        heroes.Add(hero);
    }

    public void RemoveHero(Hero hero)
    {
        heroes.Remove(hero);
    }

    public List<Hero> GetHeroes()
    {
        return heroes;
    }

    public void Attack(Player player)
    {
        List<Hero> temp = player.GetHeroes();

        int attacked = 0;

        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i].GetHealth() != 0f)
            {
                if (attacked == 0) 
                {
                    temp[i].TakeDamage(this.heroes[0].GetDamage());
                    break;
                }
            }
        }
    }
}
