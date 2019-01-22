using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePillar : MonoBehaviour {

    public float duration = 3;
    public GameObject target;
    Vector3 pos;
	
	// Update is called once per frame
	void Start () {
        pos = transform.position;
	}

    public void Drop()
    {
        StartCoroutine(PillarStomp());
    }

    IEnumerator PillarStomp()
    {
        float t = 0.0f;
        Vector3 start = transform.position;
        Vector3 end = target.transform.position;
       // yield return new WaitForSeconds(wait);
        while (t<duration)
        {
            t += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(start.y, end.y + 2, t / duration), transform.position.z);
            yield return null;
        }
        yield return StartCoroutine(PillarRecover());
    }

    IEnumerator PillarRecover()
    {
        float t = 0.0f;
        Vector3 start = transform.position;
        Vector3 end = target.transform.position;
        while (t < duration)
        {
            t += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(start.y, pos.y, t / (duration + .5f)), transform.position.z);
            yield return null;
        }
    }

}
