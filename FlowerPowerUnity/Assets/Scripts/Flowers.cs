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

}
