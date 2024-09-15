using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] BaseAttack[] attacks;

    private GameManager gameManager;
    private ControlsManager controlsManager;


    private int currentAttackMode;

    private void Awake() {
        this.controlsManager = FindObjectOfType<ControlsManager>();
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable() {
        this.controlsManager.ToggleAttack += When_ToggleAttack;
        this.controlsManager.Attack += When_Attack;
    }

    private void OnDisable() {
        this.controlsManager.ToggleAttack -= When_ToggleAttack;
        this.controlsManager.Attack -= When_Attack;
    }

    private void When_ToggleAttack(object sender, ControlsManager.ToggleAttackEventArgs e) {
        this.currentAttackMode = e.attack - 1;
    }

    private void When_Attack(object sender, EventArgs e) {
        this.attacks[this.currentAttackMode].Attack();
    }
}
