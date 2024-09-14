using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;

public class ProjectileAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Projectile projectile;
    private ControlsManager controlsManager;


    [SerializeField]
    private int projectileDamege;

    private void Awake() {
        this.controlsManager = FindAnyObjectByType<ControlsManager>();
    }

    private void OnEnable() {
        // this.controlsManager = ControlsManager.Singleton;
        this.controlsManager.ShootProjectile += When_OnShootProjectile;
    }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShootProjectile(Vector2 startingCoordinates) {
        Vector2 mouseCoordinates = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 shootingVector = (mouseCoordinates - startingCoordinates).normalized;

        Vector3 instantiateCoordinates = new Vector3(startingCoordinates.x, startingCoordinates.y, -3);


        Projectile projectileInstance = Instantiate(projectile, instantiateCoordinates, Quaternion.identity);
        projectileInstance.Setup(shootingVector, this.projectileDamege);
    }

    private void When_OnShootProjectile(object sender, EventArgs e) {
        Vector2 vector = new Vector2(0, 0);
        ShootProjectile(vector);
    }
}
