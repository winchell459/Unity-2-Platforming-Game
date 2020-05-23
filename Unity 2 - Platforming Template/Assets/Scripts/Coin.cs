using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    public int value = 10;
    // Start is called before the first frame update
    void Start()
    {
        collectableName = "Coin";
        description = "increase score by " + value.ToString();
    }

    public override void Use()
    {
        player.GetComponent<playerManager>().ChangeScore(value);
    }
}
