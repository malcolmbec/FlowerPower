using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject ShopScene;

    public void Start()
    {
        ShopScene = GameObject.FindGameObjectWithTag("ShopScene");
    }

    public void GoToShop()
    {
        SceneManager.UnloadSceneAsync("FlowerScene");
        //SceneManager.LoadScene("ShopScene");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        ShopScene.SetActive(true);
    }

    public void GoToFlower()
    {
        SceneManager.LoadScene("FlowerScene", LoadSceneMode.Additive);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
        
        //We should check to make sure scene is loaded, but for now, we're gonna risk it
        ShopScene.SetActive(false);
        
    }

}
