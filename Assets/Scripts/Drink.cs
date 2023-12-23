using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This handles grabbing the drink data from the Drinks.json file.
// It holds all the info about individual drinks as well.
public class DrinkParser : MonoBehaviour
{
    public static DrinkParser parser;
    public TextAsset drinkText;
    public DrinkList drinkList;

    void Start()
    {
        parser = this;
        drinkList = JsonUtility.FromJson<DrinkList>(drinkText.text);
        Debug.Log("Drinks read!");
    }

    // Classes ------------------------------------------------
    [Serializable]
    public class DrinkList
    {
        public Drink[] drinks;
    }

    [Serializable]
    public class Drink
    {
        public string name;
        public float price;
        public DrinkAttributes attributes;

        public Drink()
        {
            name = "Empty";
            price = 0;
        }

        // CopyValues exists to duplicate a drink, so that we can then
        // allow the player to modify a drink (sweeten, heat, cool down, etc.)
        public void CopyValues(Drink existingDrink)
        {
            name = existingDrink.name;
            price = existingDrink.price;
            attributes = existingDrink.attributes;
        }
    }

    [Serializable]
    public class DrinkAttributes
    {
        public float sweetness;
        public float caffeine;
        public float bubbles;
        public float creamy;
        public float temp;

        public DrinkAttributes()
        {
            sweetness = 0f;
            caffeine = 0f;
            bubbles = 0f;
            creamy = 0f;
            temp = 0.5f;
        }

        // Because we are reading from JSON, I will probably remove this
        public DrinkAttributes(float sweetness, float caffeine, float bubbly, float creamy, float temp)
        {
            this.sweetness = sweetness;
            this.caffeine = caffeine;
            this.bubbles = bubbly;
            this.creamy = creamy;
            this.temp = temp;
        }

        public float Sweeten(float amt)
        {
            sweetness += amt;

            if (sweetness > 1)
            {
                Debug.Log("Sweetness out of range. Max is 1");
                sweetness = 1;
            }

            return sweetness;
        }

        public float Bubble(float amt)
        {
            bubbles += amt;

            if (bubbles > 1)
            {
                Debug.Log("Bubbly out of range. Max is 1");
                bubbles = 1;
            }

            return bubbles;
        }

        public float Cool(float amt)
        {
            temp -= amt;

            if (temp < 0)
            {
                Debug.Log("Temperature out of range. Min is 0");
                temp = 0;
            }

            return temp;
        }

        public float Heat(float amt)
        {
            temp += amt;

            if (temp > 1)
            {
                Debug.Log("Temperature out of range. Max is 1");
                temp = 1;
            }

            return temp;
        }
    }
}