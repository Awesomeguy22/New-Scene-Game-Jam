using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;
using UnityEngine.Video;
using Unity.VisualScripting;

public class ProjectileAttack : BaseAttack
{
    // the projectile prefab to instantialize
    [SerializeField]
    private Projectile projectile;
    [SerializeField]
    private Explosion explosion;
    // [SerializeField]
    private Vector2 startingCoordinates;
    [SerializeField]
    private int projectileDamege;
    [SerializeField]
    private string attackName;
    [SerializeField]
    private Projectile.ProjectileType type;
    [SerializeField]
    private float explosionSize;
    [SerializeField]
    private float explosionTimer;
    // [SerializeField]
    private float tentacleDistance = 3.5f;
    // private ControlsManager controlsManager;
    // private GameManager gameManager;

    private int currentTentacle = 1;

    // the 4 end points of the tentacle
    private Vector2[] tentacleEnds = { new Vector2(-1.79f, 3.14f), new Vector2(2.12f, 2.19f), new Vector2(0.91f, -0.81f), new Vector2(-1.01f, -2.53f) };



    // private void Awake() {
    //     this.controlsManager = FindObjectOfType<ControlsManager>();
    //     this.gameManager = FindObjectOfType<GameManager>();
    // }

    // private void OnEnable() {
    //     this.controlsManager = ControlsManager.Singleton;
    //     this.controlsManager.ShootProjectile += When_OnShootProjectile;
    //     this.controlsManager.ToggleTentacle += When_ToggleTentacle;
    // }

    public override void Attack() {
        if (CheckCooldown()) {
            return;
        }


        Vector2 mouseCoordinates = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float mouseAngle = Tentacle.Vector2Deg(mouseCoordinates);

         
        startingCoordinates = new Vector2(tentacleDistance * Mathf.Cos(mouseAngle * Mathf.Deg2Rad), tentacleDistance * Mathf.Sin(mouseAngle * Mathf.Deg2Rad));
        Vector2 shootingVector = (mouseCoordinates - startingCoordinates).normalized;

        Vector3 instantiateCoordinates = new Vector3(startingCoordinates.x, startingCoordinates.y, -3);


        Projectile projectileInstance = Instantiate(projectile, instantiateCoordinates, Quaternion.identity);
        projectileInstance.Setup(shootingVector, this.projectileDamege, this.type, this.explosion, this.explosionTimer);

    }
    // function to shoot projectiles, shoots from the starting coordinates to the mouse coordinates

    // private void When_OnShootProjectile(object sender, EventArgs e) {
    //     if (this.gameManager.gamePaused) {
    //         return;
    //     }
    //     ShootProjectile(tentacleEnds[currentTentacle - 1]);
    // }

    // change the current active tentacle
    // private void When_ToggleTentacle(object sender, ControlsManager.ToggleTentacleEventArgs e) {    
    //     if (this.gameManager.gamePaused) {
    //         return;
    //     }
    //     this.currentTentacle = e.tentacle;
    // }
}
