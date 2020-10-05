using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Character : MonoBehaviour
{
    public GameObject speechBubble;
    public DialogueRunner dR;
    public Animator animator;


    public void ActivateSpeech()
    {

        dR.StartDialogue();
        speechBubble.SetActive(true);

        animator.SetBool("EnteredScene",true);
    }

    public void OnEnable()
    {
        Debug.Log("Current value of entered scene " + animator.GetBool("EnteredScene"));
        animator.SetBool("EnteredScene", GeneralManager.Gm.CharacterHasEnteredScene);


        //Resetting it since we are out.
        GeneralManager.Gm.CharacterHasEnteredScene = false;

        
    }

    public void OnDisable()
    {
        GeneralManager.Gm.CharacterHasEnteredScene = true;
    }
}
