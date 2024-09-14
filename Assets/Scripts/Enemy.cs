using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //move towards player until in range
    [SerializeField] float attackRange;

    [SerializeField] float moveSpeed;
    GameObject player;

    [SerializeField]
    private int initialHealth;
    private int health;

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
        //transform.position += transform.forward * moveSpeed;
    }

    public void DecreaseHealth(int amount) {
        health -= amount; 

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
