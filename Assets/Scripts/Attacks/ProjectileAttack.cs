using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;

public class ProjectileAttack : MonoBehaviour
{
    // the projectile prefab to instantialize
    [SerializeField]
    private Projectile projectile;
    private ControlsManager controlsManager;
    private GameManager gameManager;

    private int currentTentacle = 1;

    // the 4 end points of the tentacle
    private Vector2[] tentacleEnds = { new Vector2(-1.79f, 3.14f), new Vector2(2.12f, 2.19f), new Vector2(0.91f, -0.81f), new Vector2(-1.01f, -2.53f) };


    [SerializeField]
    private int projectileDamege;

    private void Awake() {
        this.controlsManager = FindObjectOfType<ControlsManager>();
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable() {
        // this.controlsManager = ControlsManager.Singleton;
        this.controlsManager.ShootProjectile += When_OnShootProjectile;
        this.controlsManager.ToggleTentacle += When_ToggleTentacle;
    }

    // function to shoot projectiles, shoots from the starting coordinates to the mouse coordinates
    private void ShootProjectile(Vector2 startingCoordinates) {
        Vector2 mouseCoordinates = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 shootingVector = (mouseCoordinates - startingCoordinates).normalized;

        Vector3 instantiateCoordinates = new Vector3(startingCoordinates.x, startingCoordinates.y, -3);


        Projectile projectileInstance = Instantiate(projectile, instantiateCoordinates, Quaternion.identity);
        projectileInstance.Setup(shootingVector, this.projectileDamege);
    }

    private void When_OnShootProjectile(object sender, EventArgs e) {
        if (this.gameManager.gamePaused) {
            return;
        }
        ShootProjectile(tentacleEnds[currentTentacle - 1]);
    }

    // change the current active tentacle
    private void When_ToggleTentacle(object sender, ControlsManager.ToggleTentacleEventArgs e) {    
        if (this.gameManager.gamePaused) {
            return;
        }
        this.currentTentacle = e.tentacle;
    }
}
