using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;
using System.Collections;
using UnityEngine.SceneManagement;

public class HeroDisplay : MonoBehaviour
{
    //public Button heroButton;

    public Image heroImage;

    public Text heroName;
    public Text className;

    public Text levelStat;

    public Text statsStr;
    public Text statsDex;
    public Text statsAgi;
    public Text statsVit;
    public Text statsInt;
    public Text statsLuk;

    private Hero hero;

    private GameObject battleCanvas;

    void Awake()
    {
        //parentList = GetComponentInParent<HeroDisplay>().gameObject;

        foreach (GameObject gameObj in SceneManager.GetActiveScene().GetRootGameObjects()) {
            if (gameObj.name == "BattleCanvas")
            {
                battleCanvas = gameObj;
            }
        }
    }

    public void Populate(Hero hero, Color c)
    {
        this.hero = hero;

        heroImage.sprite = hero.GetSprite();

        heroName.text = hero.name;
        className.text = hero.GetClassName();

        levelStat.text = hero.GetLevel().ToString();

        statsStr.text = hero.GetStats().STR.ToString();
        statsDex.text = hero.GetStats().DEX.ToString();
        statsAgi.text = hero.GetStats().AGI.ToString();
        statsVit.text = hero.GetStats().VIT.ToString();
        statsInt.text = hero.GetStats().INT.ToString();
        statsLuk.text = hero.GetStats().LUK.ToString();

        GetComponent<Image>().color = c;
    }

    public void SelectHero()
    {
        battleCanvas.GetComponent<BattleManager>().SelectHero(gameObject);
    }

    public Hero GetHero()
    {
        return hero;
    }
}