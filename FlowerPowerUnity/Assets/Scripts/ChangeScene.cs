using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        // SceneManager.LoadScene("FlowerScene", LoadSceneMode.Additive);
        // SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("ShopScene");
        // SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
    }

    public void GoToFlower()
    {
        SceneManager.LoadScene("FlowerScene");
        // SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
    }

}
