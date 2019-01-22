using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour {

    public Transform player;
    public StageList stageList;
    public int number;
    // Update is called once per frame

    private void Start()
    {
       // GetComponent<BoxCollider2D>().enabled = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stageList = GameObject.FindGameObjectWithTag("StageList").GetComponent<StageList>();
    }

    void Update () {
		
        if(transform.position.x < player.position.x - 10)
        {
            stageList.platforms.Remove(gameObject);
            stageList.platformNumber.Remove(number);
            stageList.platTransform.Remove(gameObject.transform.position);

            Destroy(gameObject);
        }
	}
}
