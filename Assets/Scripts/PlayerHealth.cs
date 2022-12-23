using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   pubic float fullHealth;
   
   float currentHealth;

   void Start()
   {
     currentHealth = fullHealth;
   }

   public void AddDamage(float damage)
   {

    if (damage <=0) return;
    currentHealth -= damage;

    if (currentHealth <= 0)
    {
      Death();
    }
   }

   public void Death()
   {
       StartCoroutine("MakeDead");
   }

   IEnumerator MakeDead()
   {
    Yield return new WaitForSeconds (1.5f);
    SceneManager.LoadScene("Home_Main");
   }
}
