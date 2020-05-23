using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePotions : Collectable
{
    public override void Use()
    {
        player.GetComponent<NinjaController.NinjaController>().PhysicsParams.jumpUpForce += 0.5f;
    }
}
