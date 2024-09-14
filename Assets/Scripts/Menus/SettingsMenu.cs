using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

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
        Exit();
    }

    public void Exit() {
        this.settingsMenu.SetActive(false);
    }
}