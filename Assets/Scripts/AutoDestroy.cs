using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    private void Awake()
    {
        Destroy(gameObject, lifeTime);

        kmckdmc;
    }
}
