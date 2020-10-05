using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{
    public GameObject flower_list;
    public GameObject flowerPrefab;

    public void SpawnFlowerOnClick()
    {
        Debug.Log("Spawn " + flowerPrefab.name + "!");

        if(flowerPrefab != null)
        {
            Vector2 pos = transform.position;
            GameObject flwr = (GameObject)Instantiate(flowerPrefab, pos, Quaternion.identity, flower_list.transform);
            flower_list.GetComponent<Flowers>().flowers.Add(flwr);
        }
    }

}
