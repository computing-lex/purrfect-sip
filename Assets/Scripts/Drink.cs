using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink
{
    public string Name { get; private set; }
    public float Price { get; private set; }
    private DrinkAttributes attr = new();

    public Drink(float price, string name)
    {
        Name = name;
        Price = price;
    }

}

// Attributes are:
//      0. Sweet
//      1. Caffeine
//      2. Bubbly
//      3. Creamy
//      4. Hot
public class DrinkAttributes
{
    public float sweetness;
    public float caffeine;
    public float bubbly;
    public float creamy;
    public float temp;

    public DrinkAttributes()
    {
        sweetness = 0f;
        caffeine = 0f;
        bubbly = 0f;
        creamy = 0f;
        temp = 0.5f;
    }

    public DrinkAttributes(float sweetness, float caffeine, float bubbly, float creamy, float temp)
    {
        this.sweetness = sweetness;
        this.caffeine = caffeine;
        this.bubbly = bubbly;
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
        bubbly += amt;

        if (bubbly > 1)
        {
            Debug.Log("Bubbly out of range. Max is 1");
            bubbly = 1;
        }

        return bubbly;
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