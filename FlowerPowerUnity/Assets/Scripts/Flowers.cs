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
        GameObject duplicateFlowers = Instantiate(gameObject, GeneralManager.Gm.gameObject.transform);
        GeneralManager.Gm.currentFlowers = duplicateFlowers;

    }
}
