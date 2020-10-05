using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Character : MonoBehaviour
{
    public GameObject speechBubble;
    public DialogueRunner dR;

    public void ActivateSpeech()
    {
        dR.StartDialogue();
        speechBubble.SetActive(true);
    }
}
