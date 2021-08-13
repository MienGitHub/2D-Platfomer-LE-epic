using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Vector3 ballisticOffset = new Vector3(0, 0.5f, 0);

    public GameObject BallisticPrefab;

    public float fireDelay = 0.25f;

    float cooldownTimer = 0;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if( cooldownTimer <= 0 )
        {
            cooldownTimer = fireDelay;
            Vector3 offset = transform.rotation * ballisticOffset;
            Instantiate(BallisticPrefab, transform.position + offset, transform.rotation);
        }
    }
}
