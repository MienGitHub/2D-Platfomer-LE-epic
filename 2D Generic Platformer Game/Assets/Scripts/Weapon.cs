using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BallisticPrefab;

    [SerializeField] private AudioSource GunSoundEffect;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GunSoundEffect.Play();
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(BallisticPrefab, firePoint.position, firePoint.rotation);
    }
}
