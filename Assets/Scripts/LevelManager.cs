using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool isShowingGameOverScreen;
    public GameObject gameOverScreen;


    public void GameOver()
    {
        // if the player health is 0 and the gamneoverscreen is not showing, set the game over screen showing as true and show the game over screen
        if (FindObjectOfType<PlayerController>().currentHealth == 0 && !isShowingGameOverScreen)
        {
            isShowingGameOverScreen = true;
            gameOverScreen.SetActive(true);

            // set the player and enemies to deactivate
            GetComponentInChildren<PlayerController>().gameObject.SetActive(false);
            GetComponentInChildren<CircleController>().gameObject.SetActive(false);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("Main Menu"); 
    }

}
