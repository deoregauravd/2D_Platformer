using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public float fullHealth;
    float currentHealth;  
    private static PlayerHealth instance;

        public static PlayerHealth Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<PlayerHealth>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    


    void Start()
    {
        currentHealth = fullHealth;
    }

    public void AddDamage(float damage)
    {

        if (damage <= 0) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        StartCoroutine(MakeDead());
    }

    IEnumerator MakeDead()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Home_Main");
    }
}
