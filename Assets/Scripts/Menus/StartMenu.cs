using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject startMenu;

    [SerializeField]
    private GameObject creditsMenu;

    private GameManager gameManager;

    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();
    }

    public void StartGame() {
        this.gameManager.StartGame();
        
        this.startMenu.SetActive(false);
        this.creditsMenu.SetActive(false);
    }

    public void ShowCredits() {
        this.startMenu.SetActive(false);
        this.creditsMenu.SetActive(true);
    }

    public void BackToStart() {
        this.startMenu.SetActive(true);
        this.creditsMenu.SetActive(false);
    }
}