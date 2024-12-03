using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlatformerPosition : MonoBehaviour
{
  [SerializeField] private Transform playerTansform;
  private GameObject platform;
  private Vector3 pos;
  private float spawnMargin = -15f;

  private Transform endPoint;


  private void Start()
  
  {
     InvokeRepeating("ChangePlatPosition", 5f, 5f);
  }

  private void ChangePlatPosition()
  {
   pos = this.gameObject.transform.position;
   pos.x = playerTansform.transform.position.x + spawnMargin; 
   this.gameObject.transform.position = pos;
  }
  
}
