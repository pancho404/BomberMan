using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    public void LoadGameplay()
    {
        SceneManager.LoadScene("MainGameplay");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Went to credits");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");        
    }
    
    public void LoadOneWins()
    {
        SceneManager.LoadScene("OneWins");
    }

    public void LoadTwoWins()
    {
        SceneManager.LoadScene("TwoWins");
    }
}
