using UnityEngine;

public class Ball : MonoBehaviour
{
    // configuration parameters
    [SerializeField] private Paddle paddle;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.2f;

    // state
    private Vector2 _paddleToBallVector;
    private bool _hasStart = false;

    // Cached component references
    private AudioSource _myAudioSource;
    private Rigidbody2D _myRigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        var ball = transform;
        _paddleToBallVector = ball.position - paddle.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
        _myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_hasStart) return;
        LockBallToPaddle();
        LaunchOnMouseClick();
    }

    private void LockBallToPaddle()
    {
        var ball = transform;
        var position = paddle.transform.position;
        var paddlePos = new Vector2(position.x, position.y);
        ball.position = paddlePos + _paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        _myRigidbody2D.velocity = new Vector2(xPush, yPush);
        _hasStart = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (!_hasStart) return;
        var clip = ballSounds[Random.Range(0, ballSounds.Length)];
        _myAudioSource.PlayOneShot(clip);
        _myRigidbody2D.velocity += velocityTweak;
    }
}