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

    void Shoot(Vector2 startingCoordinates) {
        Vector2 mouseCoordinates = Mouse.current.position.ReadValue();
        Vector2 shootingVector = (mouseCoordinates - startingCoordinates).normalized;

        // Projectile 
        

    }
}
