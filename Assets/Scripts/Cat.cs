using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Info
    [SerializeField] new private string name;

    // Personality
    //  ranges from 0 to 1
    [SerializeField] private float friendship;
    [SerializeField] private float energy;
    [SerializeField] private float noise;
    [SerializeField] private float gluttony;

    public Cat()
    {

    }
}
