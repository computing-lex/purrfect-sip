using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : CatState
{
    public Wandering wanderState;

    public override CatState RunState(Cat cat)
    {
        CatState nextState = this;

        if (!cat.CanSeeCustomer) {
            nextState = wanderState;
            Debug.Log("Wandering.");
        }

        return nextState;
    }
}
