using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    GameManager gameManager;
    public float maxHealth = 100.0f;
    public float playerHealth;
    public float playerXP = 0;

    [SerializeField] Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        if (gameManager == null){
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
        if (!slider){
            slider = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<Slider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slider){
            ManageHealthBar();
        }

    }

    void ManageHealthBar(){
        slider.value = Mathf.InverseLerp(0,maxHealth, playerHealth);
    }
    public void DamagePlayer(float damage){
        playerHealth -= damage;
        
        //Debug.Log($"Player taking Damage! Health is now {playerHealth}");
    }

    public void GainXP(float xp) {
        playerXP += xp;
        gameManager.CheckGamePhase(playerXP);
    }



    void CheckDeath() {

        if (playerHealth < 0){
            gameManager.RestartGame();
        }
    }
}
