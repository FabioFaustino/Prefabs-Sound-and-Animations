using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 5;

    public int CurrentHealth { get; private set; }

    public bool isDead { get; private set; }

    Animator m_Animator;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponentInChildren<Animator>();
        playerController = GetComponentInParent<PlayerController>();
        if (playerController != null)
            playerController.updateHPBar(CurrentHealth);
        isDead = false;
    }

    private void OnEnable()
    {
        CurrentHealth = startingHealth;

    }
    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (playerController != null)
            playerController.hpBar.BarValue = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    private void Die()
    {
        m_Animator.SetTrigger("Death");
        StartCoroutine(waiter(5));
        //
    }


    IEnumerator waiter(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }


}
