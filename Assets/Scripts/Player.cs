using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    public float maxHealth = 100.0f;
    
    public float playerHealth;
    public float playerXP = 0;

    [SerializeField] Slider slider;

    [SerializeField] HeadWiggle headWiggle;
    [SerializeField] GameObject[] tentacles;



    private bool showDebug = false;
    
    private void Awake() {
        this.gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable() {
        this.gameManager.ChainBreak += When_ChainBreak;
    }

    private void OnDisable() {
        this.gameManager.ChainBreak -= When_ChainBreak;
    }

    void Start()
    {
        playerHealth = maxHealth;
        if (gameManager == null){
            gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
        if (!slider){
            GameObject healthbar = GameObject.FindGameObjectWithTag("Health Bar");
            if (healthbar){
                //Debug.Log("found health bar");
                slider = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<Slider>();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (slider){
            ManageHealthBar();
        }
        if (headWiggle){
            ManageWiggle();
        }
    }

    void ManageWiggle(){
        float healthPercent = Mathf.InverseLerp(0,maxHealth, playerHealth);
        headWiggle.amplitude = Mathf.Lerp(headWiggle.baseAmplitude, headWiggle.maxAmplitude, healthPercent);
    }
    void ManageHealthBar(){
        slider.value = Mathf.InverseLerp(0,maxHealth, playerHealth);
    }
    public void DamagePlayer(float damage){
        playerHealth -= damage;
        CheckDeath();
        if (showDebug) {
            Debug.Log($"Player taking Damage! Health is now {playerHealth}");
        }
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

    private void When_ChainBreak(object sender, GameManager.ChainBreakEventArgs e) {
        this.tentacles[e.tentacle - 1].SetActive(true);
    }
}
