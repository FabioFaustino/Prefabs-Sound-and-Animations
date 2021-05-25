using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float firerate = 0.3f;

    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunFireAudio;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FireGun()
    {
        AnimateShot();

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
                if (health.GetComponentInParent<Enemy>() != null)
                {
                    if (health.isDead)
                    {
                        GetComponentInParent<PlayerController>().increasePoints(10);
                        GetComponentInParent<PlayerController>().ControlTime(2);
                    }
                }
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= firerate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    void AnimateShot()
    {
        muzzleParticle.Play();
        gunFireAudio.Play();
    }
}
