using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class TurretAI : BehaviorTree
{
    public float TurnSpeed = 100.0f;
    private void Start()
    {
        Selector TreeRoot = new Selector();
        Sequence RotateTurret = new Sequence();
        Spin turn = new Spin();

        SetValue("TurnSpeed", TurnSpeed);

        RotateTurret.children.Add(turn);
        TreeRoot.children.Add(RotateTurret);
        RotateTurret.tree = this;
        TreeRoot.tree = this;
        turn.tree = this;
        root = TreeRoot;
    }

    // we don't need an update - the base class will deal with that.
    // but, since we have one, we can use it to set some of the moveto parameters on the fly
    // which lets us tweak them in the inspector
}
