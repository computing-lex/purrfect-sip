using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatStateManager : MonoBehaviour
{
    [SerializeField] private CatState currentState;
    [SerializeField] private Cat cat;

    void Update() {
        RunState();
    }

    private void RunState()
    {
        CatState nextState = currentState?.RunState(cat);

        if (nextState != null) {
            UpdateState(nextState);
        }
    }

    private void UpdateState(CatState nextState)
    {
        currentState = nextState;
    }
}