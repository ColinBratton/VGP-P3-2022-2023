using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    public TextMeshProUGUI livesText;
    private int lives;
    public GameObject pauseScreen;
    private bool paused;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player has pressid the P key
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    
    public void UpdateScore(int scoreToAdd) 
    {
        score += scoreToAdd;
          scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToChange)
    {                                                       // This section makes the game end when the lives go down to 0
        lives += livesToChange;
        livesText.text = "Lives:" + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
         gameOverText.gameObject.SetActive(true);
         isGameActive = false;
         restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        UpdateLives(3);
    }

    void ChangePaused()
    {
        if(!paused)     //if game is NOT currently paused
        {               //then pause it
            paused = true;
            // checks the box next to the Pause Panel to make it active
            pauseScreen.SetActive(true);
            Time.timeScale = 0; 
        }
        else                //if it's currently paused
        {                   //then unpause it
            paused = false;
            // unchecks the box next to the Pause Panel to make it inactive
            pauseScreen.SetActive(false); 
            Time.timeScale = 1;
        }
    }
}
