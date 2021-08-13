using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    public int maxHealth = 2;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            //Die();
        }
        else if(currentHealth <= 0)
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            //Die();
        }
        else if (currentHealth <= 0)
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            Die();
        }


    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        deathSoundEffect.Play();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
