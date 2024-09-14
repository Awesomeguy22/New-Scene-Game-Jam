using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class ProjectileAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Projectile projectile;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShootProjectile(Vector2 startingCoordinates) {
        Vector2 mouseCoordinates = Mouse.current.position.ReadValue();
        Vector2 shootingVector = (mouseCoordinates - startingCoordinates).normalized;

        Projectile projectileInstance = Instantiate(projectile, startingCoordinates, Quaternion.identity);
        projectileInstance.Setup(shootingVector);
    }

    public void OnShootProjectile(InputAction.CallbackContext context) {
        Vector2 vector = new Vector2(0, 0);
        ShootProjectile(vector);
    }
}
