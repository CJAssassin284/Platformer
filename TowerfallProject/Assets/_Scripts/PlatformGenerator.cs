using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] bonusPlatforms;
    public GameObject[] thePlatform;
    public GameObject[] nightPlatforms;
    public Transform generationPoint;
    public float distanceBetween;
    public GameMaster gameMaster;
    public GameObject platformParent;
    public int num = 1;
    private float platformWidth;
    public StageChange stage;
    public int stageNum;
    public GameObject firstBonusPlat;
    bool sendBonus = false;
    // Use this for initialization
    void Start()
    {
        platformWidth = thePlatform[0].GetComponent<BoxCollider2D>().size.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameMaster.gameStarted)
        {
            if (transform.position.x < generationPoint.position.x)
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
                Platform(num);
            }
        }
        else
        {
            if (transform.position.x < generationPoint.position.x)
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
                MenuPlatform(num);
            }
        }
    }

    public void MoveGenerator(Transform c)
    {
        transform.position = new Vector3(transform.position.x, c.position.y, transform.position.z);
    }

    public void Platform(int number)
    {
        if(number == 0)
        {
          GameObject c = Instantiate(thePlatform[Random.Range(0, thePlatform.Length)], transform.position, transform.rotation);
            c.transform.parent = platformParent.transform;


        }
        if (number == 1)
        {
         GameObject c = Instantiate(nightPlatforms[Random.Range(0, nightPlatforms.Length)], transform.position, transform.rotation);
            c.transform.parent = platformParent.transform;

        }
        if (number == 420)
        {
            GameObject c = Instantiate(bonusPlatforms[Random.Range(0, bonusPlatforms.Length)], transform.position, transform.rotation);
            c.transform.parent = platformParent.transform;

            if (!sendBonus)
            {
                stage.firstBonus = c.transform;
                sendBonus = true;
            }
        }
    }

    void MenuPlatform(int number)
    {
        if (number == 0)
        {
          GameObject c = Instantiate(thePlatform[Random.Range(0, 5)], transform.position, transform.rotation);
            c.transform.parent = platformParent.transform;
        }
        if (number == 1)
        {
            GameObject c = Instantiate(nightPlatforms[Random.Range(0, 5)], transform.position, transform.rotation);
            c.transform.parent = platformParent.transform;

        }
    }

    public void MoveOver()
    {
        transform.position += Vector3.right * 7;
    }
}