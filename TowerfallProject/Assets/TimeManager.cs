using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {

    public float timer = 30f;
    public Text timerTxt;
    public StageChange stage;
    public Animator playerAnim;

    private GameMaster gm;
    private bool did;
	// Use this for initialization
	void Start () {
        gm = GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gm.gameStarted)
        {
            timer -= Time.deltaTime;
            timerTxt.text = Mathf.RoundToInt(timer).ToString();
        }

        if(timer <= 0)
        {
            ChangeStage();
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    void ChangeStage()
    {
        if (!did)
        {
            timer = 30f;
            stage.BonusStage();
            playerAnim.SetBool("Tele", true);
            did = true;
        }
    }
}
