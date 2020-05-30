using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public string collectableName;
    public string description;
    public GameObject player;

    public abstract void Use();

    //day 3 -------------------------------------------------------
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
