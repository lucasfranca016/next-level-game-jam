using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    public PlayerMovement mov;
    public PlayerJump jump;
    public PlayerWeapon gun;
    public PlayerCollision col;
    public GameObject gameOverMenu;

    public void GameOver()
    {
        mov.enabled = false;
        jump.enabled = false;
        gun.enabled = false;
        col.enabled = false;
        gameOverMenu.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
