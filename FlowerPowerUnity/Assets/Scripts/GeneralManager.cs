﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

//usage:
public class GeneralManager : MonoBehaviour
{
    //TODO: Maybe utilize the lazy singleton we've seen. That will be 
    //Thread safe, but we shouldn't have an issue with this one anyways...

    private static GeneralManager _gm;

    public static GeneralManager Gm {get { return _gm; }}


    public GameObject currentFlowers;
    public GameObject vase;

    public bool changedSceneToShop;
    public bool changedSceneToFlowers;

    public ChangeScene cs;

    public int currentNode;

    public DialogueRunner shop_dR;

    //Animator Information
    public bool CharacterHasEnteredScene;

    public int currentVase;


    public GameObject character; 

    void Awake() {
        if (_gm != null && _gm != this) {
            Destroy(this.gameObject);
        } else {
            _gm = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    void Start()
    {
        //Get ref to ChangeScene
        cs = GameObject.FindGameObjectWithTag("ChangeScene").GetComponent<ChangeScene>();
        currentNode = 1;

        currentVase = 0;

    }


    void Update()
    {
        if(changedSceneToShop)
        {   
            changedSceneToShop = false;
            ResetListForFlowers();
            //Set flowers into vase...   

            vase = GameObject.FindGameObjectWithTag("Vase_White");
            vase.GetComponent<ChangeVase>().SetSpriteFromGeneral();
                     
            currentFlowers.transform.parent = GameObject.FindGameObjectWithTag("Vase_Position").transform;
            currentFlowers.transform.localScale = new Vector3(1,1,1);
            currentFlowers.transform.localPosition = Vector3.zero;

           
            //Should do this somewhere else...
            shop_dR = GameObject.FindGameObjectWithTag("ShopRunner").GetComponent<DialogueRunner>();
            //have it say thank you...
            shop_dR.StartDialogue("ThankYou");

            character = GameObject.FindGameObjectWithTag("Character"); 
            character.GetComponent<Character>().SetCharacterToExit();
        }

        if(changedSceneToFlowers)
        {
            changedSceneToFlowers = false;

            DestroyFlowersForReset();
        }

    }

    void ResetListForFlowers()
    {
        //Don't know why there are fake flowers inside here...
        currentFlowers.GetComponent<Flowers>().flowers = new List<GameObject> (GameObject.FindGameObjectsWithTag("Flower"));
    }

    void DestroyFlowersForReset()
    {
        //Okay we should now destroy the flowers...
        if(currentFlowers != null)
        {
            foreach(var flower in currentFlowers.GetComponent<Flowers>().flowers)
            {
                Destroy(flower);
            }
        
            Destroy(currentFlowers);
        }
       
    }

    public void SetupFlowerShopButton()
    {
        cs.SetupFlowerButton();
    }

    public void ChangeCurrentNode()
    {
        //Currently just add 1 to current Node;

        currentNode += 1;
    }

    public void ChangeCharacter()
    {
        character.SetActive(false);
        character.SetActive(true);
    }

}