using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    //SerializedField es para que la variable sea editable unicamente en Unity
    [SerializeField]
    public float gameTime;
    public float currentTime;
    public bool isPlaying;
    public TMP_Text TimerText;
    public TMP_Text scoreText;
    public GameObject gameOverPanel;
    public int score;


    public float maxTime;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlaying = true;
        maxTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime ;
        ////if (currentTime < maxTime)
        ////    isPlaying = false;
        //while (gameTime > 0)
        //    gameTime -= Time.deltaTime;
        //if (gameTime <= 0)
        //    isPlaying = false;
        if(gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            int min = (int)gameTime / 60;
            int seg = (int)gameTime % 60;
            TimerText.text = min.ToString("00") + ":" + seg.ToString();
        }
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
    public void AddTime(float time)
    {
        gameTime += time;
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score: "+ score.ToString();
    }
}
