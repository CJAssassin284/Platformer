using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;
    public Vector3 offset;
    public Camera cam;
    public Transform zoomOut, zoomIn, zoomGameOut;
    public float moveDuration = 2f;
    bool change;
    public GameObject controller;

    void Update()
    {
        if(change)
        transform.position = new Vector3(player.position.x + offset.x, transform.position.y, offset.z); // Camera follows the player with specified offset position
        else
            transform.position = new Vector3(player.position.x, transform.position.y, offset.z); // Camera follows the player with specified offset position

    }

    public void ChangeToGame()
    {
        StartCoroutine(TransferGame(zoomGameOut));
        StartCoroutine(SetControlsActive());
        change = true;
    }

    public void TransferToCharacter()
    {
        StartCoroutine(Transfer(zoomOut));
    }

    public void MainMenu()
    {
        StartCoroutine(TransferBack(zoomIn));
    }

    IEnumerator Transfer(Transform target)
    {
        float t = 0.0f;
        Vector3 start = transform.position;
        Vector3 end = target.position;
        while( t < moveDuration)
        {
            t += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(start.y, end.y, t / moveDuration), transform.position.z);
            yield return null;
        }
    }

    IEnumerator TransferGame(Transform target)
    {
        float t = 0.0f;
        Vector3 start = transform.position;
        Vector3 end = target.position;
        while (t < moveDuration + .5f)
        {
            t += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(start.y, end.y, t / (moveDuration + .5f)), transform.position.z);
            cam.orthographicSize = Mathf.Lerp(3, 5, t / (moveDuration + .5f));
            yield return null;
        }
    }

    IEnumerator TransferBack(Transform target)
    {
        float t = 0.0f;
        Vector3 start = transform.position;
        Vector3 end = target.position;
        while (t < moveDuration)
        {
            t += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(start.y, end.y, t / moveDuration), transform.position.z);
            yield return null;
        }
    }

    IEnumerator SetControlsActive()
    {
        yield return new WaitForSeconds(.1f);
        controller.SetActive(true);
        yield break;
    }
}
