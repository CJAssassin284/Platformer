using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageChange : MonoBehaviour
{
    public int number;

    public Transform playerGO;
    public PlayerMovement player;
    public Animator playerAnim;
    public PlatformGenerator platformGenerator;
    public Image transitionScreen;
    public GameObject transitionObj;
    public Sprite[] backgrounds;
    public SpriteRenderer currentBackground;
    public Button nextButton;
    public int screenTime = 2;
    public Transform firstBonus;
    public Vector3 offset;
    public int backNum;

    private int m_savedNum;

   public void NextStage()
    {
        nextButton.interactable = false;
        if (backNum < backgrounds.Length - 1)
        {
            platformGenerator.num++;
            backNum++;
        }
        else
        {
            platformGenerator.num = 0;
            backNum = 0;
        }
            StartCoroutine(StageTransition());
    }


    public void BonusStage()
    {
       m_savedNum = platformGenerator.num;
        platformGenerator.num = 420;
        player.runSpeed = 0;
        platformGenerator.MoveOver();
        platformGenerator.Platform(420);
        StartCoroutine(BonusTransition());
    }

    IEnumerator StageTransition()
    {
        player.runSpeed *= 10;
        transitionObj.SetActive(true);
        yield return new WaitForSeconds(1);
        float t = 0;
        player.runSpeed /= 10;
        currentBackground.sprite = backgrounds[backNum];

        while (t < screenTime)
        {
            t += Time.deltaTime;

            transitionScreen.color = new Color(transitionScreen.color.r, transitionScreen.color.b, transitionScreen.color.g, Mathf.Lerp(1, 0, t / screenTime));
            yield return null;
        }
        transitionObj.SetActive(false);
        transitionScreen.color = new Color(transitionScreen.color.r, transitionScreen.color.b, transitionScreen.color.g, 1);
        nextButton.interactable = true;

        yield break;
    }

    IEnumerator BonusTransition()
    {
     //   player.runSpeed *= 10;
       // transitionObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        playerAnim.SetBool("Tele", false);
        playerGO.position = firstBonus.position + offset;
        player.isRunning = false;
        yield return new WaitForSeconds(1f);
        player.runSpeed = 10;


        /*   float t = 0;
           player.runSpeed /= 10;
           currentBackground.sprite = backgrounds[backNum];

           while (t < screenTime)
           {
               t += Time.deltaTime;

               transitionScreen.color = new Color(transitionScreen.color.r, transitionScreen.color.b, transitionScreen.color.g, Mathf.Lerp(1, 0, t / screenTime));
               yield return null;
           }
           transitionObj.SetActive(false);
           transitionScreen.color = new Color(transitionScreen.color.r, transitionScreen.color.b, transitionScreen.color.g, 1);
           nextButton.interactable = true;
           */
        yield break;
    }

}
