using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {


    public GameObject player1List;
    public GameObject player2List;

    private GameObject[] playerLists;

    public EventSystem eventSys;

    public Color playerColour;
    public Color computerColour;

    private Player player1;
    private Player player2;

    private int currentPlayer;

    private List<Hero> heroesList;

    private enum SimulationState { ready, heroSelection, playing }

    private SimulationState gameState;

    private Sprite[] heroMugSprites;

    const int COMPUTER = 1;
    const int PLAYER = 0;

    //void Awake()
    //{
        
    //}

    // Use this for initialization
    void Start()
    {
        heroMugSprites = Resources.LoadAll<Sprite>("mugshot_sprites");

        currentPlayer = PLAYER;

        playerLists = new GameObject[2];

        playerLists[0] = player1List;
        playerLists[1] = player2List;

        SetupSimulation();
    }

    public void SetupSimulation()
    {
        //heroMugSprites = Resources.LoadAll<Sprite>("mugshot_sprites");

        gameState = SimulationState.heroSelection;

        player1 = new Player("Player1", playerColour);
        player2 = new Player("Player2", computerColour);

        heroesList = new List<Hero>();

        //need to build random hero generator
        heroesList.Add(new Hero("Hero1", new HeroClass("Generic1", new List<WeaponType>() { WeaponType.Sword, WeaponType.Lance }, new List<ArmourType>() { ArmourType.Heavy }), heroMugSprites[180]));
        heroesList.Add(new Hero("Hero2", new HeroClass("Generic1", new List<WeaponType>() { WeaponType.Staff, WeaponType.Book }, new List<ArmourType>() { ArmourType.Light }), heroMugSprites[350]));
        heroesList.Add(new Hero("Hero3", new HeroClass("Generic3", new List<WeaponType>() { WeaponType.Axe, WeaponType.Polearm }, new List<ArmourType>() { ArmourType.Medium }), heroMugSprites[265]));
        heroesList.Add(new Hero("Hero4", new HeroClass("Generic4", new List<WeaponType>() { WeaponType.Bow }, new List<ArmourType>() { ArmourType.Light }), heroMugSprites[396]));



        for (int i = 0; i < heroesList.Count; i++)
        {
            playerLists[PLAYER].GetComponent<HeroList>().AddHero(player1, heroesList[i]);
            playerLists[COMPUTER].GetComponent<HeroList>().AddHero(player2, heroesList[i]);

            if (i == 0)
            {
                eventSys.SetSelectedGameObject(playerLists[PLAYER].GetComponentInChildren<HeroDisplay>().GetComponent<Button>().gameObject);
            }
        }

        DisableHeroes(COMPUTER);
    }

    public void EndSimulation()
    {

    }

    public void SelectHero(GameObject hero)
    {
        Debug.Log("Hero Selected: " + hero.GetComponent<HeroDisplay>().GetHero().name);

        DisableHeroes(currentPlayer);

        hero.GetComponent<Image>().color = hero.GetComponent<Button>().colors.highlightedColor;

        hero.GetComponent<Button>().colors = ChangeDisabledColour(hero.GetComponent<Button>().colors, Color.white);

        if (currentPlayer == PLAYER)
        {
            player1.AddHero(hero.GetComponent<HeroDisplay>().GetHero());
        } else
        {
            player2.AddHero(hero.GetComponent<HeroDisplay>().GetHero());
        }

        EndTurn();
    }

    private void PlayAI()
    {
        int randomNum = 0;
        //int result = 0;
        //int.TryParse(Time.time.ToString(), out result);
        //Random.seed = result;
        randomNum = Random.Range(0, playerLists[COMPUTER].GetComponentInChildren<RectTransform>().GetComponentsInChildren<HeroDisplay>().Length);

        int counter = 0;

        foreach (HeroDisplay display in playerLists[COMPUTER].GetComponentInChildren<RectTransform>().GetComponentsInChildren<HeroDisplay>())
        {

            if (counter == randomNum)
            {
                display.SelectHero();
            }


            counter++;
        }

        //EndTurn();
        EndSimulation();
    }

    private void SetHeroColours(Player player)
    {

    }

    public void EnableUnselectedHeroes(int player)
    {
        foreach (HeroDisplay display in playerLists[player].GetComponentInChildren<RectTransform>().GetComponentsInChildren<HeroDisplay>())
        {
            //display.gameObject.SetActive(false);
            display.GetComponent<Button>().interactable = true;
        }
    }

    //public void DisableUnselectedHeroes(GameObject hero, int player)
    //{
    //    foreach (HeroDisplay display in playerLists[player].GetComponentInChildren<RectTransform>().GetComponentsInChildren<HeroDisplay>())
    //    {
    //        //Debug.Log(display.name);
    //        if (display.gameObject != hero)
    //        {
    //            //display.gameObject.SetActive(false);
    //            display.GetComponent<Button>().interactable = false;
    //        }
    //    }
    //}

    public void DisableHeroes(int player)
    {
        foreach (HeroDisplay display in playerLists[player].GetComponentInChildren<RectTransform>().GetComponentsInChildren<HeroDisplay>())
        {
            display.GetComponent<Button>().interactable = false;
        }
    }

    public void EndTurn()
    {
        if (currentPlayer == PLAYER)
        {
            currentPlayer = COMPUTER;

            if (gameState == SimulationState.heroSelection)
            {
                PlayAI();
            }
            
        } else
        {
            currentPlayer = PLAYER;
            Debug.Log("Player 1 Hero: " + player1.GetHeroes()[0].name + " | Player 2 Hero: " + player2.GetHeroes()[0].name);
        }
    }

    //private ColorBlock ChangeButtonColours(ColorBlock colourBlock, Color normalColour = new Color(), Color pressedColour = new Color(), Color highlightedColour = new Color(), Color disabledColour = new Color())
    //{
    //    ColorBlock colours = colourBlock;

    //    if (normalColour != new Color())
    //    {
    //        colours.normalColor = normalColour;
    //    }

    //    if (pressedColour != new Color())
    //    {
    //        colours.pressedColor = pressedColour;
    //    }

    //    if (highlightedColour != new Color())
    //    {
    //        colours.highlightedColor = highlightedColour;
    //    }

    //    if (disabledColour != new Color())
    //    {
    //        colours.disabledColor = disabledColour;
    //    }

    //    return colours;
    //}

    private ColorBlock ChangeDisabledColour(ColorBlock colourBlock, Color disabledColour)
    {
        ColorBlock colours = colourBlock;

        colours.disabledColor = disabledColour;

        return colours;
    }

    //   // Update is called once per frame
    //   void Update () {

    //}
}
