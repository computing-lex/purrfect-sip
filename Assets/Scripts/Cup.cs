using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    // Select drink from drink list
    private DrinkParser.Drink randomDrink;

    // The drink currently in the cup
    [SerializeField] private DrinkParser.Drink drink;
    [SerializeField] private bool cupInDispenser;

    // Debug settings
    [SerializeField] private Vector3 respawnPoint;
    public bool respawn = false;
    public bool randomizeDrink;

    // Respawn objects if beyond the abyss
    public GameObject abyss;

    void Awake()
    {
        drink = new DrinkParser.Drink();

        RandomizeDrink(DrinkParser.parser.drinkList);
        randomizeDrink = false;
    }

    void Update()
    {

        if (respawn || !CheckOOB())
        {
            transform.position = respawnPoint;
            respawn = false;
        }

        if (randomizeDrink)
        {
            RandomizeDrink(DrinkParser.parser.drinkList);
            randomizeDrink = false;
        }
    }

    private void RandomizeDrink(DrinkParser.DrinkList options)
    {
        randomDrink = options.drinks[Random.Range(0, (options.drinks.Length - 1))];
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
