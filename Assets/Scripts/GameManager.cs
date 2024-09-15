using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    //int from 1-4 representing the phase of the game
    //Used by spawner and attack logic
    public int currentGameStage = 1;
    public bool gamePaused = true;

    [SerializeField] bool pauseOnStart = false;

    [SerializeField] int winStage = 4;
    [SerializeField] String winScreenName;

    [SerializeField] int[] expThresholds = {};

    [SerializeField] GameObject[] chains;
    [SerializeField] GameObject[] brokenChains;

    [SerializeField] Player player;    
    
    private ControlsManager controlsManager;
    private AudioManager audioManager;


    public event EventHandler Pause;
    public event EventHandler<ChainBreakEventArgs> ChainBreak;

    public class ChainBreakEventArgs: EventArgs {
        public int tentacle;
    }

    private void Awake() {
        this.controlsManager = FindObjectOfType<ControlsManager>();
        this.audioManager = FindObjectOfType<AudioManager>();
        if (pauseOnStart) {

        Time.timeScale = 0;
        }
    }

    private void OnEnable() {
        this.controlsManager.Pause += When_Pause;
    }

    private void OnDisable() {
        this.controlsManager.Pause -= When_Pause;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CheckGamePhase(float playerXP) {
        Debug.Log("Current stage: " + currentGameStage);
        
        if (currentGameStage == winStage){
            Debug.Log("win");
            Win();
            return;
        }

        if (playerXP > expThresholds[currentGameStage - 1]) {
            currentGameStage += 1;
            player.playerHealth = player.maxHealth;
            //Break Chain
            BreakChain(currentGameStage - 1);
        }

    }

    void BreakChain(int i){
        if (i >= 3) {
            return;
        }
        
        chains[i - 1].SetActive(false);
        if (brokenChains[i - 1]){
            brokenChains[i - 1].SetActive(true);
        }
        
        audioManager.PlayAudioClip(AudioManager.ClipName.chainBreak);
        this.ChainBreak?.Invoke(this, new ChainBreakEventArgs { tentacle = i + 1 });
    }

    public void StartGame() {

        this.gamePaused = false;
        Time.timeScale = 1;

        this.audioManager.PlayBGM(AudioManager.ClipName.bgm);
            this.Pause?.Invoke(this, EventArgs.Empty);

    }
    public void RestartGame() {
        Debug.Log("You Lost, Restarting Current Scene");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win(){
        SceneManager.LoadScene(winScreenName);
    }

    public void When_Pause(object sender, EventArgs e) {
        this.gamePaused = !this.gamePaused;

        if (this.gamePaused) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }

        this.Pause?.Invoke(this, EventArgs.Empty);
    }



}
