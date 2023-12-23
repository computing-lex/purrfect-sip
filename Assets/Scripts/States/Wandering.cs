using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandering : CatState
{
    public Following followState;
    public bool canSeeCustomer;
    public bool canSeeCat;

    public override CatState RunState(Cat cat)
    {
        CatState nextState = this;

        if (canSeeCustomer) {
            nextState = followState;
            Debug.Log("Following customer");
        }

        return nextState;
    }
}
