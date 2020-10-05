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

    public bool changedSceneToShop;

    public ChangeScene cs;

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
    }


    void Update()
    {
        if(changedSceneToShop)
        {   
            changedSceneToShop = false;
            ResetListForFlowers();
            //Set flowers into vase...            
            currentFlowers.transform.parent = GameObject.FindGameObjectWithTag("Vase_Position").transform;
            currentFlowers.transform.localScale = new Vector3(1,1,1);
            currentFlowers.transform.localPosition = Vector3.zero;
        }
    }

    void ResetListForFlowers()
    {
        //Don't know why there are fake flowers inside here...
        currentFlowers.GetComponent<Flowers>().flowers = new List<GameObject> (GameObject.FindGameObjectsWithTag("Flower"));
    }

    void DestroyFlowersForReset()
    {

    }

    public void SetupFlowerShopButton()
    {
        cs.SetupFlowerButton();
    }

}