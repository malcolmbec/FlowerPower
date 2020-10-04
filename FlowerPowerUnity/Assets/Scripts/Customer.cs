using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Customer : MonoBehaviour
{
    public YarnProgram script;
    public DialogueRunner dialogueRunner;

    void Start()
    {
        dialogueRunner.Add(script);
    }

}
