using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPathsPlat : MonoBehaviour {

    public Transform topSpawn;
    public Transform bottomSpawn;
    public GameObject[] items;
    bool did = false;
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!did)
            {
                Instantiate(items[Random.Range(0, items.Length)], topSpawn.position, transform.rotation);
                Instantiate(items[Random.Range(0, items.Length)], bottomSpawn.position, transform.rotation);
                did = true;
            }
        }
    }
}
