using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour {

    public bool isBeingWorn = false;
    public Transform hatPoint;


    private void Update()
    {
        if (isBeingWorn)
            transform.position = hatPoint.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            hatPoint = collision.transform.GetChild(0).transform;
            isBeingWorn = true;
        }
    }
}
