using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CupSpawner : MonoBehaviour
{
    // Cup management
    public GameObject cupPrefab;
    [SerializeField] private GameObject currentCupObj;
    //private List<GameObject> activeCups;

    [SerializeField] private bool hasCup = true;

    // Debug values
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private bool respawnCup;
    [SerializeField] private bool killAllCups;
    public GameObject abyss;

    // Start is called before the first frame update
    void Start()
    {
        currentCupObj = SpawnCup();
        //activeCups = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCupObj.GetComponent<Rigidbody>().isKinematic = true;

        if (!hasCup)
        {
            currentCupObj = SpawnCup();
            hasCup = true;
        }

        if (respawnCup)
        {
            currentCupObj = SpawnCup();
            respawnCup = false;
        }

        //if (killAllCups) { KillAllCups(); }
    }

    // private void KillAllCups()
    // {
    //     foreach (GameObject item in activeCups)
    //     {
    //         Destroy(item);
    //     }

    //     activeCups.Clear();
    // }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Cup"))
        {
            hasCup = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private GameObject SpawnCup()
    {
        GameObject newCup = Instantiate(cupPrefab, spawnPoint.position, spawnPoint.rotation);
        newCup.GetComponent<Cup>().abyss = abyss;

        //activeCups.Add(newCup);
        newCup.name = "Drink";

        return newCup;
    }
}
