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
    [SerializeField] float health = 50;
    private float cooldown = 1.0f;

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

        StartCoroutine(Float());
    }

    IEnumerator Float() {
        while (!isDead) {
            //move up and down, but make sure to calculate with rotation
            transform.position += new Vector3(0, Mathf.Sin(Time.time) * 0.005f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Renderer renderer = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        Renderer renderer2 = transform.GetChild(1).gameObject.GetComponent<Renderer>();
        while (isDead && transform.position.y < 8) {
            renderer.material.color = new Color(1, 0, 0);
            renderer2.material.color = new Color(1, 0, 0);
            transform.eulerAngles = new Vector3(0, 90, 180);
            transform.position += new Vector3(0, 0.02f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) {
            return;
        }

        if (inRange && cooldown <= 0){
            lazerBeam.SetActive(true);
            playerScript.DamagePlayer(dps * Time.deltaTime);
        }
        else {
            lazerBeam.SetActive(false);
            cooldown -= Time.deltaTime;
        }
    }

    void FixedUpdate() {
        if (isDead) {
            return;
        }
        transform.LookAt(player.transform);

        lazerBeam.transform.parent.transform.localScale = new Vector3(1, 1, Vector3.Distance(transform.position, player.transform.position) / 2);

        if (Vector3.Distance(transform.position, player.transform.position) > Math.Max(3.0f, attackRange * health) - 0.2f) {
            transform.position += transform.forward * (moveSpeed * health * UnityEngine.Random.Range(0.9f, 2.0f));
            inRange = false;
        } else {
            inRange = true;
        }
    }

    public void takeDamage(float damage) {
        cooldown = 1.0f;

        // Flash red
        StartCoroutine(FlashRed());


        health -= damage;
        if (health <= 0){
            Die();
        }
    }

    IEnumerator FlashRed() {
        Renderer renderer = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>();
        Renderer renderer2 = transform.GetChild(1).gameObject.GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        renderer.material.color = new Color(1, 0, 0);
        renderer2.material.color = new Color(1, 0, 0);

        // Lerp back to original color
        for (float t = 0.0f; t <= 1.0f; t += 0.1f) {
            renderer.material.color = Color.Lerp(renderer.material.color, originalColor, t);
            renderer2.material.color = Color.Lerp(renderer2.material.color, originalColor, t);
            yield return new WaitForSeconds(0.02f);
        }
    }

    void Die(){
        isDead = true;
    }
}
