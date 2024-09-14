using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEditor.UI;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    ProjectileAttack attack;
    private Rigidbody rigidbody;

    private int damage;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Vector2 direction, int damage) {
        this.rigidbody = this.GetComponent<Rigidbody>();

        this.rigidbody.velocity = direction * 10;
        this.damage = damage;

        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "Enemy") {
            Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
            //enemy.DecreaseHealth(damage);
            Destroy(gameObject);
        }



    }
}
