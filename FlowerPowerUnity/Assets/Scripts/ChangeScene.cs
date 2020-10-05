using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Yarn.Unity;

public class ChangeScene : MonoBehaviour
{
    public GameObject ShopScene;
    public GameObject GoToFlowerButton;
    public GameObject SpeechBubble;
    public GameObject GoToShopButton;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneChange;
    }


    public void OnSceneChange(Scene scene, LoadSceneMode mode)
    {
        
        if(scene.name == "ShopScene") 
        {
            ShopScene = GameObject.FindGameObjectWithTag("ShopScene");
            
        }
        else if (scene.name == "FlowerScene")
        {
            //We have to set the onClick events in code, since they won't have a reference to the Manager
            GoToShopButton = GameObject.FindGameObjectWithTag("GoToShopButton");
            GoToShopButton.GetComponent<Button>().onClick.AddListener(GoToShop);


            //We should have loaded flower scene by now.
            ShopScene.SetActive(false);
            GameObject.FindGameObjectWithTag("FlowerRunner").GetComponent<DialogueRunner>().startNode = GeneralManager.Gm.currentNode.ToString();

        
        }
    }

    public void GoToShop()
    {
        SceneManager.UnloadSceneAsync("FlowerScene");
        
        ShopScene.SetActive(true);
        GeneralManager.Gm.changedSceneToShop = true;

        //SceneManager.LoadScene("ShopScene");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }

    public void GoToFlower()
    {
        SceneManager.LoadScene("FlowerScene", LoadSceneMode.Additive);
        
        //We should check to make sure scene is loaded, but for now, we're gonna assume it
        DisableShopTextBoxAndButton();
        
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));   
    }

    void DisableShopTextBoxAndButton()
    {
        //On loading Flower scene we call this.
        GoToFlowerButton.SetActive(false);
        SpeechBubble.SetActive(false);
    }

    public void SetupFlowerButton()
    {
        //We can assume bubble is active if this got called
        //But we should make a new function normally
        GoToFlowerButton = GameObject.FindGameObjectWithTag("GoToFlowerButton");
        GoToFlowerButton.GetComponent<Button>().onClick.AddListener(GoToFlower);
    
        SpeechBubble = GameObject.FindGameObjectWithTag("SpeechBubble");
    }

}
