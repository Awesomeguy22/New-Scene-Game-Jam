using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button creditsButton;

    private GameManager gameManager;

    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();
        this.startButton.onClick.AddListener(() => { StartGame(); });
        this.creditsButton.onClick.AddListener(() => { OpenCredits(); });
    }

    private void StartGame() {
        this.gameManager.StartGame();
        
        this.startMenu.SetActive(false);
    }

    private void OpenCredits() {

    }
}