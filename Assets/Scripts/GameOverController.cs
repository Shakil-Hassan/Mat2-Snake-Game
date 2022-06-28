using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public SnakeScoreController scoreController;
    public void SnakeDied()
    {
        //SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);
        scoreController.FinalScoreWhenDie();

    }
    public void goRetry()
    {
        //LevelSelection.SetActive(true);
        //SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goHome()
    {
        
        //SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }

    public void goQuitGame()
    {
        Debug.Log("Game Quit successfully");
        Application.Quit();
    }
}
