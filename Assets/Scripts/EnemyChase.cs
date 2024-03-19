using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public float speed = 2f;
    public float fireRate = 0.5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    private float timeSinceLastShot = 1f;

    private void Start()
    
    {
        InvokeRepeating("GetEnemyInRangeOfPlayer", 10f, 5f);
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.Instance.player.position, speed * Time.deltaTime);


        timeSinceLastShot += Time.deltaTime;


        if (timeSinceLastShot > fireRate)
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

    private void GetEnemyInRangeOfPlayer()
    {
        // calculate distance if already is in range then skip the changing positon
        Debug.Log("GetEnemyInRange");
      this.gameObject.transform.position = new Vector3 (playerTransform.transform.position.x, playerTransform.transform.position.y-5f, playerTransform.transform.position.z);  
    }

}
