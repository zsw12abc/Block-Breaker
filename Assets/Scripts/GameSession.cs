using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlockDestroyed = 10;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private bool isAutoPlayEnabled;

    [SerializeField] private int currentScore = 0;

    private void Awake()
    {
        var gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
//        Debug.Log(currentScore);
    }

    public void RestGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled() => isAutoPlayEnabled;
}