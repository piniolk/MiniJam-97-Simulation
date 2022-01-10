using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public GameObject endScreen;
    // Start is called before the first frame update
    public void StartGame() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void TitleScreen() {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }

    public void Replay() {
        Time.timeScale = 1;
        endScreen.SetActive(false);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void EndGame() {
        Time.timeScale = 0;
        endScreen.SetActive(true);
    }


}
