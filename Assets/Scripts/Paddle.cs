using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    [SerializeField] private float screenWidthInUnits = 16f;

    private GameSession _gameSession;
    private Ball _ball;

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        var paddle = transform;
        var paddlePos = new Vector2(paddle.position.x, paddle.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        paddle.position = paddlePos;
    }

    private float GetXPos()
    {
        if (_gameSession.IsAutoPlayEnabled())
        {
            return _ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}