using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int Health;

    public bool isDead;

    public GameOverManager gameManager;

    void Start()
    {
        Health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.PlayerDeath();
            Debug.Log("Dead");
        }
    }

   /* void Update()
    {
        if (Health <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            gameManager.PlayerDeath();
            Debug.Log("Dead");
        }
    }
    */
}
