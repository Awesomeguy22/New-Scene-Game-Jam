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

    public event EventHandler<ChangeAttackEventArgs> ChangeAttack;

    public class ChangeAttackEventArgs: EventArgs {
        public int attack;
    }

    private int currentAttackMode;

    private void Awake() {
        this.controlsManager = FindObjectOfType<ControlsManager>();
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable() {
        this.controlsManager.ToggleAttack += When_ToggleAttack;
        this.controlsManager.Attack += When_Attack;
        this.gameManager.ChainBreak += When_ChainBreak;
    }

    private void OnDisable() {
        this.controlsManager.ToggleAttack -= When_ToggleAttack;
        this.controlsManager.Attack -= When_Attack;
        this.gameManager.ChainBreak -= When_ChainBreak;
    }

    private void When_ToggleAttack(object sender, ControlsManager.ToggleAttackEventArgs e) {
        if (!this.attacks[e.attack - 1].attackEnabled) {
            return;
        }
        
        this.currentAttackMode = e.attack - 1;
        this.ChangeAttack?.Invoke(this, new ChangeAttackEventArgs { attack = e.attack });
    }

    private void When_Attack(object sender, EventArgs e) {
        if (this.gameManager.gamePaused) {
            return;
        }
        this.attacks[this.currentAttackMode].Attack();
    }

    private void When_ChainBreak(object sender, GameManager.ChainBreakEventArgs e) {
        this.attacks[e.tentacle - 1].attackEnabled = true;
    }
}
