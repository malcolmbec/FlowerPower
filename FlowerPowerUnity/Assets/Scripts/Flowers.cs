using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour
{
    public List<GameObject> flowers;

    void Awake()
    {
        flowers = new List<GameObject>();
    }

    public void DuplicateFlowersForUnloading()
    {
        foreach(var flower in flowers)
        {
            flower.GetComponent<Draggable>().enabled = false;
        }
        GameObject duplicateFlowers = Instantiate(gameObject, GeneralManager.Gm.gameObject.transform);
        
        GeneralManager.Gm.currentFlowers = duplicateFlowers;

        
    }
}
