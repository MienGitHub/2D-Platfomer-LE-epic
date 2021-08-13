using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallistic : MonoBehaviour
{
    public float speed = 40f;
    public int damage = 5;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerLife playerlife = hitInfo.GetComponent<PlayerLife>();
        if (playerlife != null)
        {
            playerlife.PlayerTakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
