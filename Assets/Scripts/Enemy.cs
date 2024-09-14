using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //move towards player until in range
    [SerializeField] float attackRange;

    [SerializeField] float moveSpeed;
    [SerializeField] float health;
    Boolean inRange = false;
    GameObject player;

    [SerializeField]
    private int initialHealth;

    float attackCooldown = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = initialHealth;
    }



    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }

    void FixedUpdate() {
        if (Vector3.Distance(transform.position, player.transform.position) > attackRange) {
            transform.position += transform.forward * moveSpeed;
            inRange = false;
        } else {
            inRange = true;
        }
    }

    void takeDamage(int damage) {
        health -= damage;
    }
}
