using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.UI;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    ProjectileAttack attack;
    private Rigidbody2D rigidbody;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Vector2 direction) {
        this.rigidbody = this.GetComponent<Rigidbody2D>();

        this.rigidbody.velocity = direction * 10;

        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "enemy") {
            return;
        }



    }
}
