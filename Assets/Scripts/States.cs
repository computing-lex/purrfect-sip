using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CatState : MonoBehaviour
{
    public abstract CatState RunState(Cat cat);
}