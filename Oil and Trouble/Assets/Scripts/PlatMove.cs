using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatMove : MonoBehaviour
{
     public float lr = 3f; 
     public float speed = .6f; 
     private Vector3 startPos;
 
     void Start () {
         startPos = transform.position;
     }
     
     void Update () {
         Vector3 v = startPos;
         v.x += lr * Mathf.Sin (Time.time * speed);
         transform.position = v;
     }
 }
