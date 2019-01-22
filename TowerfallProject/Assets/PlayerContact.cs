using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerContact : MonoBehaviour {
    
    public GameMaster gm;
    public bool invincible;
    public Text coinTxt;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            if(!invincible)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddValue(int amount)
    {
        gm.coins -= amount;
        coinTxt.text = gm.coins.ToString();

    }

    public void StarPower()
    {
        invincible = true;
        StartCoroutine(Invincible());
    }

    IEnumerator Invincible()
    {
        yield return new WaitForSeconds(5);
        invincible = false;

        yield break;
    }
    

}
