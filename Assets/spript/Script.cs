using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections; // Để dùng Coroutine
//Nhom09
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    // Tham chiếu UI
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject restartButton;
    public TMP_Text scoreText;      // Kéo ScoreText từ Canvas vào đây

    private Rigidbody2D rb;
    private Animator anim;

    private float horizontal;
    private bool isGrounded;
    private bool isJumping;

    private int score = 0;          // Biến đếm điểm

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UpdateScoreUI();           // Hiện "Điểm: 0" khi bắt đầu game
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        HandleJumpInput();
        UpdateAnimation();
    }

    void FixedUpdate()
    {
        HandleMovement();
        CheckGrounded();
    }

    void HandleMovement()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);

        // Lật hướng nhân vật
        if (horizontal != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontal) * Mathf.Abs(transform.localScale.x), transform.localScale.y, 1f);
        }
    }

    void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            isGrounded = false;
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
            isJumping = false;
    }

    void UpdateAnimation()
    {
        anim.SetBool("Run", Mathf.Abs(rb.linearVelocity.x) > 0.1f && isGrounded);
        anim.SetBool("Jump", isJumping);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    // ======= ĂN XU, ĐIỂM, THUA, WIN, HIỆN UI ==========
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ăn đồng xu (tag "Coin")
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            score++;
            UpdateScoreUI();
        }
        // Thua (tag "Spike" hoặc "Arrow")
        else if (collision.CompareTag("Spike") || collision.CompareTag("Arrow"))
        {
            GameOver();
        }
        // Win (tag "Finish")
        else if (collision.CompareTag("Finish"))
        {
            WinGame();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Điểm: " + score;
    }

    void GameOver()
    {
        if (gameOverText != null) gameOverText.SetActive(true);
        if (restartButton != null) restartButton.SetActive(true);
        StartCoroutine(PauseGameAfterUI());
    }

    void WinGame()
    {
        if (winText != null) winText.SetActive(true);
        if (restartButton != null) restartButton.SetActive(true);
        StartCoroutine(PauseGameAfterUI());
    }

    IEnumerator PauseGameAfterUI()
    {
        yield return null; // Chờ 1 frame để UI update rồi mới dừng game
        Time.timeScale = 0;
    }

    // Hàm này sẽ gắn cho nút Chơi lại (Restart)
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
