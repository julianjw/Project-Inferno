using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

public class Simulator
{
    private bool player1Selected = false;
    private bool player2Selected = false;

    private Player player1;
    private Player player2;

    private List<Hero> heroes;

    private enum SimulationState { ready, playing }

    private SimulationState gameState;

    public GameObject heroDisplay;

    private Sprite[] heroMugSprites;

    //void Awake()
    //{
    //    heroMugSprites = Resources.LoadAll<Sprite>("mugshot_sprites");
    //}

    public void SetupSimulation(GameObject player1List, GameObject player2List)
    {

        heroMugSprites = Resources.LoadAll<Sprite>("mugshot_sprites");

        //btnAttackPlayer1.Enabled = false;
        //btnAttackPlayer2.Enabled = false;
        //btnReset.Enabled = false;

        gameState = SimulationState.ready;

        //player1 = new Player("Player1");
        //player2 = new Player("Player2");

        heroes = new List<Hero>();

        heroes.Add(new Hero("Hero1", new HeroClass("Generic1", new List<WeaponType>() { WeaponType.Sword, WeaponType.Lance }, new List<ArmourType>() { ArmourType.Heavy }), heroMugSprites[180]));
        heroes.Add(new Hero("Hero2", new HeroClass("Generic1", new List<WeaponType>() { WeaponType.Staff, WeaponType.Book }, new List<ArmourType>() { ArmourType.Light }), heroMugSprites[350]));
        heroes.Add(new Hero("Hero3", new HeroClass("Generic3", new List<WeaponType>() { WeaponType.Axe, WeaponType.Polearm }, new List<ArmourType>() { ArmourType.Medium }), heroMugSprites[265]));
        heroes.Add(new Hero("Hero4", new HeroClass("Generic4", new List<WeaponType>() { WeaponType.Bow }, new List<ArmourType>() { ArmourType.Light }),heroMugSprites[396]));

        //cmbPlayer1.Items.Clear();
        //cmbPlayer2.Items.Clear();

        //cmbPlayer1.ResetText();
        //cmbPlayer2.ResetText();

        player1Selected = false;
        player2Selected = false;

        for (int i = 0; i < heroes.Count; i++)
        {

            //player1List.AddComponent<>();
            //player1List.gameObject.AddComponent<heroDisplay>();
            //cmbPlayer1.Items.Add(heroes[i]);
            //cmbPlayer2.Items.Add(heroes[i]);
        }

        //lblStatus.Text = string.Empty;

        //uiHealthPlayer1.Value = 0;
        //uiHealthPlayer2.Value = 0;
    }

    private void btnAttackPlayer1_Click(object sender, EventArgs e)
    {
        //btnAttackPlayer1.Enabled = false;
        //btnAttackPlayer2.Enabled = true;

        if (gameState == SimulationState.ready)
        {
            gameState = SimulationState.playing;
        }

        player1.Attack(player2);

        //uiHealthPlayer2.Value = (int)player2.GetHeroes()[0].GetHealth();
        //uiHealthPlayer2.Update();

        CheckPlayerStatus();
    }

    private void btnAttackPlayer2_Click(object sender, EventArgs e)
    {
        //btnAttackPlayer1.Enabled = true;
        //btnAttackPlayer2.Enabled = false;

        player2.Attack(player1);

        //uiHealthPlayer1.Value = (int)player1.GetHeroes()[0].GetHealth();
        //uiHealthPlayer1.Update();

        CheckPlayerStatus();
    }

    private void cmbPlayer1_SelectedIndexChanged(object sender, EventArgs e)
    {
        player1Selected = true;

        //cmbPlayer2.Items.Remove(cmbPlayer1.SelectedItem);

        //player1.AddHero((Hero)cmbPlayer1.SelectedItem);

        CheckSelectionStatus();
    }

    private void cmbPlayer2_SelectedIndexChanged(object sender, EventArgs e)
    {
        player2Selected = true;

        //cmbPlayer1.Items.Remove(cmbPlayer2.SelectedItem);

        //player2.AddHero((Hero)cmbPlayer2.SelectedItem);

        CheckSelectionStatus();
    }

    private void CheckSelectionStatus()
    {
        if (player1Selected && player2Selected && gameState == SimulationState.ready)
        {
            //btnAttackPlayer1.Enabled = true;
            //uiHealthPlayer1.Value = (int)player1.GetHeroes()[0].GetHealth();
            //uiHealthPlayer2.Value = (int)player2.GetHeroes()[0].GetHealth();
        }
    }

    private void CheckPlayerStatus()
    {
        //if (uiHealthPlayer1.Value == 0)
        //{
        //    lblStatus.Text = "Player 2 Wins!";
        //    gameState = SimulationState.ready;
        //} 
        //if (uiHealthPlayer2.Value == 0)
        //{
        //    lblStatus.Text = "Player 1 Wins!";
        //    gameState = SimulationState.ready;
        //}
        //if (uiHealthPlayer1.Value == 0 && uiHealthPlayer2.Value == 0)
        //{
        //    lblStatus.Text = "It's a draw!";
        //    gameState = SimulationState.ready;
        //}

        //if (gameState == SimulationState.ready)
        //{
        //    btnReset.Enabled = true;
        //    btnAttackPlayer1.Enabled = false;
        //    btnAttackPlayer2.Enabled = false;
        //}
    }

    //private void btnReset_Click(object sender, EventArgs e)
    //{
    //    SetupSimulation();
    //}
}