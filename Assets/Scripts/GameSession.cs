using TMPro;
using UnityEngine;
using System.Collections;

public class GameSession : MonoBehaviour
{
    // config
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI gameLevelText;
    [SerializeField] private TextMeshProUGUI playerLivesText;
    [SerializeField] bool paddleSizeIncreased = false;
    [SerializeField] float paddleSizeIncreaseTime = 10f;
    [SerializeField] float paddleSpeedIncreaseTime = 10f;

    // state
    private static GameSession _instance;
    private Paddle _paddle;
    public static GameSession Instance => _instance;

    public int GameLevel { get; set; }
    public int PlayerScore { get; set; }
    public int PlayerLives { get; set; }
    public int PointsPerBlock { get; set; }
    public float GameSpeed { get; set; }
    
    
    /**
     * Singleton implementation.
     */
    private void Awake() 
    { 
        // this is not the first instance so destroy it!
        if (_instance != null && _instance != this)
        { 
            Destroy(this.gameObject);
            return;
        }
        
        // first instance should be kept and do NOT destroy it on load
        _instance = this;

        

        DontDestroyOnLoad(this.gameObject);
    }
    
    /**
     * Before first frame.
     */
    void Start()
    {
        playerScoreText.text = this.PlayerScore.ToString();
        gameLevelText.text = this.GameLevel.ToString();
        playerLivesText.text = this.PlayerLives.ToString();
    }

    /**
     * Update per-frame.
     */
    void Update()
    {

        if(GameObject.Find("Paddle") != null)
        {
            _paddle = GameObject.Find("Paddle").GetComponent<Paddle>();
        }
        
        Time.timeScale = this.GameSpeed;
        
        // UI updates
        playerScoreText.text = this.PlayerScore.ToString();
        gameLevelText.text = this.GameLevel.ToString();
        playerLivesText.text = this.PlayerLives.ToString();
    }

    /**
     * Updates player score with given points and also updates the UI score. The total points that are
     * calculated is based on the basis value (this.PointsPerBlock).
     */
    public void AddToPlayerScore(int blockMaxHits)
    {
        this.PlayerScore += blockMaxHits * this.PointsPerBlock;
        playerScoreText.text = this.PlayerScore.ToString();
    }

    public void IncreasePaddleSize()
    {
        if (paddleSizeIncreased)
        {
            StopCoroutine(ReduceSizeToNormal());
            StartCoroutine(ReduceSizeToNormal());
        }
        else if (!paddleSizeIncreased)
        {
            _paddle.transform.localScale *= new Vector2(2f, 1f);
            paddleSizeIncreased = true;
            StartCoroutine(ReduceSizeToNormal());
        }
    }

    IEnumerator ReduceSizeToNormal()
    {
        yield return new WaitForSeconds(paddleSizeIncreaseTime);
        _paddle.transform.localScale = new Vector2(1f, 1f);
        paddleSizeIncreased = false;
    }

    public void IncreasePaddleSpeed()
    {
        _paddle.speedMultiplier *= 1.3f;
        StartCoroutine(ReduceSpeedToNormal());
    }

    IEnumerator ReduceSpeedToNormal()
    {
        yield return new WaitForSeconds(paddleSpeedIncreaseTime);
        if(_paddle.speedMultiplier / 1.3f >= 1)
        {
            _paddle.speedMultiplier /= 1.3f;
        }
        else
        {
            _paddle.speedMultiplier = 1f;
        }
        
    }

    public void RemoveAllEffect()
    {
        _paddle.speedMultiplier = 1f;
        _paddle.transform.localScale = new Vector2(1f, 1f);
    }
}
