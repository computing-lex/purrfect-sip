using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : CatState
{
    public Following followState;

    public override CatState RunState(Cat cat)
    {
        CatState nextState = this;

        if (cat.CanSeeCustomer) {
            nextState = followState;
            Debug.Log("Following customer");
        }

        return nextState;
    }
}
