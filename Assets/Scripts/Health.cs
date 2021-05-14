using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int startingHealth = 5;

    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
