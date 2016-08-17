using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroList : MonoBehaviour {

    public Simulator simulator;

    public RectTransform heroListRect;
    public GameObject heroDisplayPrefab;

    private int heroCount;

    //public GameObject playerList;

    static Color OddHeroColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    static Color EvenHeroColor = new Color(.94f, .94f, .94f, .94f);

    void Awake()
    {
        heroCount = 0;
    }
    
    public void AddHero(Player player, Hero hero)
    {
        GameObject o = Instantiate(heroDisplayPrefab) as GameObject;

        o.GetComponent<HeroDisplay>().Populate(hero, (heroCount % 2 == 0) ? OddHeroColor : EvenHeroColor);

        o.transform.SetParent(heroListRect, false);

        //should put this into function
        ColorBlock colorBlock = o.GetComponent<Button>().colors;

        colorBlock.highlightedColor = player.colour;

        o.GetComponent<Button>().colors = colorBlock;
        //

        heroCount++;
    }

    public void SelectHero(Hero hero)
    {
        Debug.Log("Hero Selected");


    }
}
