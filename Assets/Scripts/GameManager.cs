using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player _player;
    private int _activeScene;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("_player is null.");
        }

        _activeScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(_activeScene);

    }

    private void StartGame()
    {

    }

    private void RestartGame() 
    {

    }

    private void QuitGame()
    {
        Application.Quit();
    }

    public void PlayerDied()
    {
        _player.UpdateLives();

        if (_player.PlayerLives <= 0)
        {
            RestartGame();
        }
        else
        {
            RestartLevel();
        }
    }
}
