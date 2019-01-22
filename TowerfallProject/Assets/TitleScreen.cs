using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

    public Animator camAnim;
    public GameObject characterCanvas;




    void ZoomOut()
    {
        camAnim.SetBool("zoomOut", true);
    }

    void ZoomIn()
    {
        camAnim.SetBool("zoomOut", false);
    }

    public void CharacterSelect()
    {
        ZoomOut();
        characterCanvas.SetActive(true);
    }
}
