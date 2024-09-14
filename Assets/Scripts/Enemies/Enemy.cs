using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //move towards player until in range
    [SerializeField] GameObject lazerBeam;
    [SerializeField] float attackRange;

    [SerializeField] float moveSpeed;
    [SerializeField] float health = 1;

    [SerializeField] float dps;
    Boolean inRange = false;
    GameObject player;
    Player playerScript;

    //float attackCooldown = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
    }



    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if (inRange){
            lazerBeam.SetActive(true);
            playerScript.DamagePlayer(dps * Time.deltaTime);
        }
        else{
            lazerBeam.SetActive(false);
        }
    }

    void FixedUpdate() {
        if (Vector3.Distance(transform.position, player.transform.position) > attackRange) {
            transform.position += transform.forward * moveSpeed;
            inRange = false;
        } else {
            inRange = true;
        }
    }

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0){
            Die();
        }
    }

    void Die(){
        
        Destroy(gameObject);
    }
}
