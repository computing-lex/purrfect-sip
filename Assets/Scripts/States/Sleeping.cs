using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeping : CatState
{
    public override CatState RunState(Cat cat)
    {
        return this;
    }
}
