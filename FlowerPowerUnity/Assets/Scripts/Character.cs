using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class Character : MonoBehaviour
{
    public GameObject speechBubble;
    public DialogueRunner dR;
    public Animator animator;

    public bool currentEntered;

    public List<Sprite> characterSprites;
    public List<Sprite> ShuffledSprites;

    private Image img;
    
    public int idx = 0;

    private void Awake()
    {
        img = GetComponent<Image>();
    }
    public void ActivateSpeech()
    {

        dR.StartDialogue(GeneralManager.Gm.currentNode.ToString());
        speechBubble.SetActive(true);

        animator.SetBool("EnteredScene",true);
        currentEntered = true;
    }

    public void OnEnable()
    {
        //Debug.Log("Current value of entered scene " + animator.GetBool("EnteredScene"));
        animator.SetBool("EnteredScene", GeneralManager.Gm.CharacterHasEnteredScene);

        //Resetting it since we are out.
        GeneralManager.Gm.CharacterHasEnteredScene = false;
    }

    public void ChangeCharacter()
    {
        Debug.Log("We have changed character");
        GeneralManager.Gm.ChangeCurrentNode();
        //Update Character image to random
        //Reset Entered Scene after delay (ADD COROUTINE FOR THIS)

        GeneralManager.Gm.CharacterHasEnteredScene = false;
        animator.SetBool("EnteredScene", false);
        animator.SetBool("ShouldExitScene", false);
        speechBubble.SetActive(false);

        ChangeSprite();
        //jesus okay
        currentEntered = false;
        GeneralManager.Gm.ChangeCharacter();
        
    }

    public void OnDisable()
    {
        GeneralManager.Gm.CharacterHasEnteredScene = currentEntered;
    }

    public void SetCharacterToExit()
    {
        animator.SetBool("ShouldExitScene", true);
    }

    public void ChangeSprite()
    {
        idx += 1;
        if (idx > characterSprites.Count - 1)
        {
            idx = 0;
        }
        img.sprite = characterSprites[idx];
    }
}
