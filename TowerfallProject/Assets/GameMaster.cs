using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    
    //Game has not started in beginning, choose characters etc.
    public bool gameStarted = false;
    public int coins = 30;

    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameMenu;




    public void StartGame()
    {
        coins = 30;
        gameStarted = true;
        cameraFollow.ChangeToGame();
        mainMenu.SetActive(false);
      //  gameMenu.SetActive(true);
    }
}
