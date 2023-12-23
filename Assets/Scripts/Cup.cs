using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    // Select drink from drink list
    [SerializeField] private DrinkParser drinkParser;
    private DrinkParser.Drink randomDrink;
    
    // The drink currently in the cup
    [SerializeField] private DrinkParser.Drink drink;

    // Debug settings
    [SerializeField] private Vector3 respawnPoint;
    public bool respawn = false;
    public bool randomizeDrink;

    // Respawn objects if beyond the abyss
    public GameObject abyss;

    void Start()
    {
        drink = new DrinkParser.Drink();
    }

    void Update()
    {
        if (respawn || !CheckOOB())
        {
            transform.position = respawnPoint;
            respawn = false;
        }

        if (randomizeDrink) {
            RandomizeDrink(drinkParser.drinkList);
            randomizeDrink = false;
        }
    }

    private void RandomizeDrink(DrinkParser.DrinkList options) {
        randomDrink = options.drinks[Random.Range(0,(options.drinks.Length - 1))];
        drink.CopyValues(randomDrink);
        Debug.Log("Drink randomized! New drink is " + drink.name);
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
