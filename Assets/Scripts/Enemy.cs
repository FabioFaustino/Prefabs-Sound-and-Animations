using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private float attackRefreshrate = 1.5f;
    private float attackTimer;

    private AggroDetection aggroDetection;
    private Health healthTarget;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireAudio;



    private void Awake()
    {
        aggroDetection = GetComponent<AggroDetection>();
        aggroDetection.OnAggro += AggroDetection_OnAggro;
    }

    private void AggroDetection_OnAggro(Transform target)
    {
        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            healthTarget = health;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (healthTarget != null)
        {
            attackTimer += Time.deltaTime;
            if (CanAttack())
            {
                Attack();
            }
        }
    }

    private bool CanAttack()
    {

        return attackTimer >= attackRefreshrate && !healthTarget.isDead;
    }

    private void Attack()
    {
        AnimateShot();
        attackTimer = 0;
        healthTarget.TakeDamage(1);
    }

    public void OnObjectSpawn()
    {
        Debug.Log("Spawned");
    }

    void AnimateShot()
    {
        muzzleParticle.Play();
        gunFireAudio.Play();
    }

}