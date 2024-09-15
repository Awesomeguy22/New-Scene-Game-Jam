using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
//using UnityEditor.UI;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Explosion explodingArea;
    private Rigidbody projRigidbody;
    private AudioManager audioManager;

    private float damage; 
    private ProjectileType type;
    private float explosionSize;
    private float explosionTimer = 1f;

    private bool showDebug = false;

    public enum ProjectileType {
        regular, 
        explodingImpact,
        timedExploding,
    }

    private void Update() {

        if (this.type != ProjectileType.timedExploding) {
            return;
        }

        explosionTimer -= Time.deltaTime;

        if (explosionTimer < 0) {
            Explode();
            Destroy(this);
        }
    }

    // setup the velocity, duration and damage of the projectile 
    public void Setup(Vector2 direction, int damage, ProjectileType type, Explosion explodingArea = null, float explosionTimer = 0) {
        this.projRigidbody = this.GetComponent<Rigidbody>();
        this.audioManager = FindObjectOfType<AudioManager>();
        this.transform.LookAt(new Vector3(direction.x, direction.y, 0));
        this.projRigidbody.velocity = new Vector3(direction.x, direction.y, 0) * 10;
        this.damage = damage;
        this.type = type;
        this.explodingArea = explodingArea;
        this.explosionTimer = explosionTimer;


        Destroy(gameObject, 5);
    }

    // projectile collision detect
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag != "Enemy") {
            return;
        }

        switch (this.type) {
            case ProjectileType.regular: 
                collision.gameObject.GetComponentInParent<Enemy>().takeDamage(this.damage);
                audioManager.PlayAudioClip(AudioManager.ClipName.projectileHit);
                break;

            case ProjectileType.explodingImpact:
                Explode();
                break;

            case ProjectileType.timedExploding:
                return;
            default: break;
        }

        Destroy(gameObject);
    }

    private void Explode() {
        Explosion explosion = Instantiate(this.explodingArea, transform.position, Quaternion.identity);
        explosion.Explode();
        Destroy(gameObject);
    }
}
