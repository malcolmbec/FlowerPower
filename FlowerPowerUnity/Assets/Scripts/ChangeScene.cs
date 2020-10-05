using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToShop()
    {
        SceneManager.LoadScene("ShopScene");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        GeneralManager.Gm.checkForLoadedScene = true;
    }

    public void GoToFlower()
    {
        SceneManager.LoadScene("FlowerScene");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
    }

}
