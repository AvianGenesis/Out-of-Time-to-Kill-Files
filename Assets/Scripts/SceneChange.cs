using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void LoadBattlefield()
    {
        SceneManager.LoadScene("Battlefield");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }
}

