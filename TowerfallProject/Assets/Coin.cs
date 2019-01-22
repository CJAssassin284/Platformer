using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    bool added = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!added)
            {
                collision.GetComponent<PlayerContact>().AddValue(1);
                Destroy(transform.parent.gameObject);
                added = true;
            }
        }
    }
}
