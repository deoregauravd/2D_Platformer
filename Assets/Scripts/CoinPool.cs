using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    public static CoinPool CoinPoolInstance;
    [SerializeField] private GameObject[] coinPoolObj;
    [SerializeField] private int coinPoolSize;
    [SerializeField] private GameObject coinPrefab;

    private void Awake()
    {
        CoinPoolInstance = this;
    }

    public void Start()
    {
        
        for ( int i=0; i < coinPoolSize; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = new Vector3(0,0,i * 10);
            coin.gameObject.SetActive(true);
        }
    }
}