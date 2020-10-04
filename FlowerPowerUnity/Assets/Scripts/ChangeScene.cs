using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToShop()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void GoToFlower()
    {
        SceneManager.LoadScene("FlowerScene");
    }

}
