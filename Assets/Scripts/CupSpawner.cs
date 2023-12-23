using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSpawner : MonoBehaviour
{
    public GameObject cupPrefab;
    private GameObject currentCupObj;
    private Cup currentCup;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool respawnCup;
    public GameObject abyss;

    // Start is called before the first frame update
    void Start()
    {
        currentCupObj = SpawnCup();
    }

    // Update is called once per frame
    void Update()
    {
        currentCup = currentCupObj.GetComponent<Cup>();

        if (!currentCup.IsInDispenser())
        {
            currentCupObj = SpawnCup();
        }

        if (respawnCup) {
            currentCupObj = SpawnCup();
            respawnCup = false;
        }
    }

    void OnCollisionExit(Collision other) {
            
    }

    private GameObject SpawnCup()
    {
        GameObject newCup = Instantiate(cupPrefab, spawnPoint.position, spawnPoint.rotation);
        newCup.GetComponent<Cup>().abyss = abyss;
        newCup.name = "Drink";

        return newCup;
    }
}
