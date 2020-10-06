using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ThankYouButtonHide : MonoBehaviour
{
    public GameObject button;
    public DialogueRunner dR;

    public void DisableButton()
    {
        if (dR.CurrentNodeName != "ThankYou")
        {
            button.SetActive(true);
        }

    }
}
