using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    //int from 1-4 representing the phase of the game
    //Used by spawner and attack logic
    public int currentGameStage = 1;
    public bool gamePaused = false;

    [SerializeField] int winStage = 5;
    [SerializeField] Scene winScreen;

    [SerializeField] int[] ExpThresholds = {};

    private ControlsManager controlsManager;


    public event EventHandler Pause;

    private void Awake() {
        this.controlsManager = FindObjectOfType<ControlsManager>();
    }

    private void OnEnable() {
        this.controlsManager.Pause += When_Pause;
    }

    private void OnDisable() {
        this.controlsManager.Pause -= When_Pause;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void CheckGamePhase(float playerXP) {
        if (playerXP > ExpThresholds[currentGameStage - 1]) {
            currentGameStage += 1;
        }

        if (currentGameStage == winStage){
            Win();
        }
    }


    public void RestartGame() {
        Debug.Log("You Lost, Restarting Current Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win(){
        SceneManager.LoadScene(winScreen.name);
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
