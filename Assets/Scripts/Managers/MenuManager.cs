using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public void StartCampaign()
    {
        Debug.Log("Clicked Campaign Button");

        SceneManager.LoadScene("Campaign");
    }

    public void CustomBattle()
    {
        //netMan.StartHost();

        //SceneManager.LoadScene("Lobby");
        SceneManager.LoadScene("CustomBattle");
    }

    public void OptionsMenu()
    {
        Debug.Log("Clicked OptionsMenu Button");

        //SceneManager.LoadScene("OptionsMenu");
    }

    public void ExitGame()
    {
        Debug.Log("Clicked ExitGame Button");

        Application.Quit();
    }


    private Button FindButton(string buttonName)
    {
        Button emptyButton;
        emptyButton = null;

        foreach (Button buttonObj in gameObject.GetComponentsInChildren<Button>())
        {
            if (buttonObj.name == buttonName)
            {
                return buttonObj;
            }
        }

        return emptyButton;
    } 

}
