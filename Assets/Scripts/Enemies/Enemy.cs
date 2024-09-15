using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //move towards player until in range
    [SerializeField] GameObject[] lazerBeams;
    [SerializeField] float attackRange;

    [SerializeField] float moveSpeed;
    [SerializeField] float floatSpeed = 0.02f;
    [SerializeField] float health = 50;
    
    [SerializeField] float xp = 10;

    //take damage cooldown
    private float cooldown = 1.0f;

    [SerializeField] Renderer enemyRenderer;
    [SerializeField] Collider[] enemyColiders;

    [SerializeField] float dps;
    Boolean inRange = false;
    GameObject player;
    Player playerScript;

    Boolean isDead = false;

    //float attackCooldown = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        if (!enemyRenderer){
            //default position for Sub
            enemyRenderer = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        }
        StartCoroutine(Float());
    }

    IEnumerator Float() {
        while (!isDead) {
            //move up and down, but make sure to calculate with rotation
            transform.position += new Vector3(0, Mathf.Sin(Time.time) * 0.005f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        //Renderer renderer = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        //Renderer renderer2 = transform.GetChild(1).gameObject.GetComponent<Renderer>();
        while (isDead && transform.position.y < 8) {
            enemyRenderer.material.color = new Color(1, 0, 0);
            //renderer2.material.color = new Color(1, 0, 0);
           
            transform.position += new Vector3(0, floatSpeed, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) {
            SetLazerBeams(false);
            return;
        }

        if (inRange){
            SetLazerBeams(true);
            playerScript.DamagePlayer(dps * Time.deltaTime);
        }
        else {
            SetLazerBeams(false);
            //cooldown -= Time.deltaTime;
        }
    }

    void SetLazerBeams(bool active){
        for (int i = 0; i < lazerBeams.Length; i++){
            lazerBeams[i].SetActive(active);

        }

    }
    void FixedUpdate() {
        if (isDead) {
            return;
        }
        transform.LookAt(player.transform);


        //What is this?
        for (int i = 0; i < lazerBeams.Length; i++){
            lazerBeams[i].transform.parent.transform.localScale = new Vector3(1, 1, Vector3.Distance(transform.position, player.transform.position) / 2);
        }        
        /*
        if (Vector3.Distance(transform.position, player.transform.position) > Math.Max(3.0f, attackRange * health) - 0.2f) {
            transform.position += transform.forward * (moveSpeed * health * UnityEngine.Random.Range(0.9f, 2.0f));
            inRange = false;
        } else {
            inRange = true;
        }
        */
        if (Vector3.Distance(transform.position, player.transform.position) > attackRange) {
            transform.position += transform.forward * moveSpeed / 50;
            inRange = false;
        } else {
            inRange = true;
        }
    }

    public void takeDamage(float damage) {
        //cooldown = 1.0f;

        // Flash red
        StartCoroutine(FlashRed());


        health -= damage;
        if (health <= 0){
            Die();
        }
    }

    IEnumerator FlashRed() {
        //Renderer renderer = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        //Renderer renderer2 = transform.GetChild(1).gameObject.GetComponent<Renderer>();
        Color originalColor = enemyRenderer.material.color;
        enemyRenderer.material.color = new Color(1, 0, 0);
        //renderer2.material.color = new Color(1, 0, 0);

        // Lerp back to original color
        for (float t = 0.0f; t <= 1.0f; t += 0.1f) {
            enemyRenderer.material.color = Color.Lerp(enemyRenderer.material.color, originalColor, t);
            //renderer2.material.color = Color.Lerp(renderer2.material.color, originalColor, t);
            yield return new WaitForSeconds(0.02f);
        }
    }

    void Die(){
        for (int i = 0; i < enemyColiders.Length; i++){
            enemyColiders[i].enabled = false;
        }
        transform.rotation = transform.rotation * Quaternion.Euler(180, 0, 0);
        playerScript.GainXP(xp);
        isDead = true;
    }
}
