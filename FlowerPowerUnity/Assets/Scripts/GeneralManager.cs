using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//usage:
public class GeneralManager : MonoBehaviour
{
    //TODO: Maybe utilize the lazy singleton we've seen. That will be 
    //Thread safe, but we shouldn't have an issue with this one anyways...

    private static GeneralManager _gm;

    public static GeneralManager Gm {get { return _gm; }}

    //public GameObject currentPatron;
    public GameObject currentFlowers;
    public GameObject vase;

    public bool checkForLoadedScene;

    void Awake() {
        if (_gm != null && _gm != this) {
            Destroy(this.gameObject);
        } else {
            _gm = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    void Update()
    {
        //Okay we know we should be done
        if (checkForLoadedScene)
        {
            //Okay, this may not be right, but the general check may be...
            if(SceneManager.GetActiveScene().name == "ShopScene")
            {
                //Okay not needed but may be useful...
                ResetListForFlowers();

                checkForLoadedScene = false;
                currentFlowers.transform.parent = GameObject.FindGameObjectWithTag("Canvas").transform;
            }
        }
    }

    void ResetListForFlowers()
    {
        currentFlowers.GetComponent<Flowers>().flowers = new List<GameObject> (GameObject.FindGameObjectsWithTag("Flower") );
    }

}