using UnityEngine;
using UnityEngine.UI;

/**
 * Saltar
 * apanhar merdas do chao
 * Backpack ????????
 * Agachar
 */


public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    public ProgressBar timeBar;
    public ProgressBarCircle hpBar;
    private Health health;
    public float forwardMoveSpeed = 7.5f;
    public GameOverScript gameOverScript;

    public float backMoveSpeed = 3f;
    public float turnSpeed = 15;
    private bool isDefeated;
    private int currentPoints;
    public Text scoreText;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        timeBar.BarValue = 30;
        health = GetComponentInChildren<Health>();
        Cursor.lockState = CursorLockMode.Locked;
        currentPoints = 0;
        scoreText.text = "Score: " + currentPoints;
        isDefeated = false;
        Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);

        ControlTime(0);

        animator.SetFloat("Speed", vertical);

        if (!health.isDead && !isDefeated)
        {
            transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

            if (vertical != 0)
            {
                float moveSpeed = vertical > 0 ? forwardMoveSpeed : backMoveSpeed;

                characterController.SimpleMove(transform.forward * moveSpeed * vertical);
            }
        }
        else
        {
            GameOver();
        }
    }

    public void updateHPBar(float hp)
    {
        hpBar.BarValue = hp;
    }

    public void ControlTime(int seconds)
    {
        timeBar.BarValue += seconds;

        timeBar.BarValue -= Time.deltaTime;

        if (timeBar.BarValue <= 0)
        {
            animator.SetTrigger("Defeated");
            isDefeated = true;

        }
    }

    public void increasePoints(int points)
    {
        currentPoints += points;
        scoreText.text = "Score: " + currentPoints;
    }

    public void GameOver()
    {
        gameOverScript.Setup(currentPoints);
        Debug.Log("GameOver");
    }
}
