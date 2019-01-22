using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTreasure : MonoBehaviour {

    Transform _transform;
    Animator _anim;


	// Use this for initialization
	void Start () {
       _transform = GetComponent<Transform>();
        _anim = transform.GetChild(0).GetComponent<Animator>();
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            OnContact();
        }
    }



    void OnContact()
    {
        _anim.SetBool("Hit", true);
        _transform.position += new Vector3(0, .175f, 0);
    }
}
