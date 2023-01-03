using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
     Rigidbody2D bulletRed;

     void Start()
    {
        bulletRed = GetComponent<Rigidbody2D>();
        Vector2 pushDirection = new Vector2(10, 0);
        bulletRed.AddForce(pushDirection, ForceMode2D.Impulse);
    }

}
