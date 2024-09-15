using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    ProjectileAttack attack;
    private Rigidbody rigidbody;

    private float damage;

    private bool showDebug = false;

    // setup the velocity, duration and damage of the projectile 
    public void Setup(Vector2 direction, int damage) {
        this.rigidbody = this.GetComponent<Rigidbody>();

        this.rigidbody.velocity = new Vector3(direction.x, direction.y, 0) * 10;
        this.damage = damage;


        Destroy(gameObject, 5);
    }

    // projectile collision detect
    private void OnTriggerEnter(Collider collision) {
        if (showDebug) {
            Debug.Log(collision.gameObject.name);
        }
        
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponentInParent<Enemy>().takeDamage(this.damage);
            Destroy(gameObject);
        }
    }
}
