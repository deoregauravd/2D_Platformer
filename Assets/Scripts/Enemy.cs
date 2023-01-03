using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // The speed of the enemy
    public float fireRate = 0.5f; // The rate at which the enemy can fire bullets
    public GameObject bulletPrefab; // The prefab for the enemy's bullets
    public Transform firePoint; // The point at which the bullets will be instantiated
    private float timeSinceLastShot = 1f; // The time since the enemy last fired a bullet
    
    
    // Update is called once per frame
    void Update()
    {
        // Move the enemy towards the player
        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.player.position, speed * Time.deltaTime);

        // Increment the time since the last shot by the time since the last frame
        timeSinceLastShot += Time.deltaTime;

        // If the time since the last shot is greater than the fire rate and the player is within range, fire a bullet
        if (timeSinceLastShot > fireRate && PlayerInRange())
        {
            FireBullet();
            timeSinceLastShot = 0f; // Reset the time since the last shot
        }
    }

    // Returns true if the player is within range of the enemy
    bool PlayerInRange()
    {
        // Get the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, Player.Instance.player.position);

        // Return true if the distance to the player is less than a certain value
        return distanceToPlayer < 10f;
    }

    // Fires a bullet from the enemy's fire point
    void FireBullet()
    {
        // Instantiate a bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the bullet's rigidbody and set its velocity towards the player
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = (Player.Instance.player.position - firePoint.position).normalized * 5f;
    }
}
