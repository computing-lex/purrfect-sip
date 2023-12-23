using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : CatState
{
    public Wandering wanderState;
    public bool canSeeCustomer;
    public bool canSeeCat;

    public override CatState RunState(Cat cat)
    {
        CatState nextState = this;

        if (!canSeeCustomer) {
            nextState = wanderState;
            Debug.Log("Wandering.");
        }

        return nextState;
    }
}
