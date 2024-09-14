using UnityEngine;
using System;
using UnityEngine.UIElements;


public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject settingsMenu;

    private GameManager gameManager;

    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();

    }

    private void OnEnable() {
        this.gameManager.Pause += When_Pause;
    }

    private void OnDisable() {
        this.gameManager.Pause -= When_Pause;
    }

    private void When_Pause(object sender, EventArgs e) {
        if (this.gameManager.gamePaused) {
            pauseMenu.SetActive(true);
        } else {
            pauseMenu.SetActive(false);
        }
    }

    public void Resume() {
        this.gameManager.When_Pause(this, EventArgs.Empty);    
    }

    public void OpenSettings() {
        this.settingsMenu.SetActive(true);
    }
}