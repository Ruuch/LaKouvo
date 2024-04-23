using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{

    public int mainMenuun;

    public void MainMenuuseen()
    {
        SceneManager.LoadScene(mainMenuun);
    }
      
}
