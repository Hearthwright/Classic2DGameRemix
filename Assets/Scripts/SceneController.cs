using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Loads the Main Menu
    public void MainMenu ()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Loads the Game Level Scene
    public void Play()
    {
        SceneManager.LoadScene("Game Level");
    }

    // Loads the Tutorial Scene
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    // Loads the Win Screen
    public void Win()
    {
        SceneManager.LoadScene("Win Screen");
    }

    // Loads the Game Over Screen
    public void GameOver()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    // Closes out of the Game
    // Only works in built project, not Unity Editor
    public void Quit()
    {
        Application.Quit();
    }
}
