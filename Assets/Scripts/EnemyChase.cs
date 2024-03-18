using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float speed = 2f; 
    public float fireRate = 0.5f; 
    public GameObject bulletPrefab; 
    public Transform firePoint;
    private float timeSinceLastShot = 1f; 
   private void OnTriggerStay2D(Collider2D coll)
   {
       ChasePlayer();
   }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.player.position, speed * Time.deltaTime);

       
        timeSinceLastShot += Time.deltaTime;

       
        if (timeSinceLastShot > fireRate )
        {
            FireBullet();
            timeSinceLastShot = 0f;
        }

    }
    


   
  
 
    void FireBullet()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

     
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = (Player.Instance.player.position - firePoint.position).normalized * 5f;
    }
   
}
