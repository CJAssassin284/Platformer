using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarTrigger : MonoBehaviour {

    public SpikePillar pillar;
    bool done;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (!done)
            {
                pillar.Drop();
                done = true;
                Debug.Log("jj");
            }
        }
    }
}
