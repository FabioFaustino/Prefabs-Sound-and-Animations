using System;
using System.Collections;
using System.Collections.Generic;
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
    private Transform firepoint;

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

        Ray ray = new Ray(firepoint.position, firepoint.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray,out hitInfo, 100))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
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
