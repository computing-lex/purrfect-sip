using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    

    // Debug settings
    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private bool respawn = false;

    // Respawn objects if beyond the abyss
    public GameObject abyss;

    void Start()
    {

    }

    void Update()
    {
        if (respawn || !CheckOOB())
        {
            transform.position = respawnPoint;
            respawn = false;
        }
    }

    /// <summary>
    /// Check if object is above the warp point
    /// </summary>
    /// <returns>True if object is within bounds</returns>
    private bool CheckOOB()
    {
        bool inBounds = true;

        if (transform.position.y <= abyss.transform.position.y)
        {
            inBounds = false;
        }

        return inBounds;
    }
}
