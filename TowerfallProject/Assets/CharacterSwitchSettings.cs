using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitchSettings : MonoBehaviour {

    public CharacterAnimations[] controller;
    public Animator anim;
    int number = 0;
	// Use this for initialization
	public void Next () {

        if (number < controller.Length - 1)
        {
            number++;
        }
        else
            number = 0;

        anim.runtimeAnimatorController = controller[number].controller;

	}

    public void Previous()
    {

        if (number > 0)
        {
            number--;
        }
        else
            number = controller.Length - 1;

        anim.runtimeAnimatorController = controller[number].controller;

    }
}
