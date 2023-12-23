using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Cat : MonoBehaviour
{
    // Info
    public GameObject titleBox;
    public GameObject descriptionBox;

    private TextMeshProUGUI titleText;
    private TextMeshProUGUI descriptionText;

    // Personality
    [SerializeField] private Cattributes attr;

    public bool CanSeeCustomer { get; private set; }
    public bool canSeeCat;

    // Navigation
    private NavMeshAgent agent;

    void Awake()
    {
        titleText = titleBox.GetComponent<TextMeshProUGUI>();
        descriptionText = descriptionBox.GetComponent<TextMeshProUGUI>();

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        titleText.text = attr.Name;
        descriptionText.text =
            "Age: " + attr.Age + " ( " + attr.AgeName() + ")" +
            "\nFriendship: " + attr.Friendship.ToString() +
            "\nEnergy: " + attr.Energy.ToString() +
            "\nNoise: " + attr.Noise.ToString() +
            "\nGluttony: " + attr.Gluttony.ToString();


    }

    public Cat()
    {

    }
}

[Serializable]
public class Cattributes
{
    public string Name { get; set; }
    public bool IsResident { get; set; }
    public float Age { get; private set; }

    // Personality traits
    public float Friendship { get; private set; }
    public float Energy { get; private set; }
    public float Bravery { get; private set; }
    public float Noise { get; private set; }
    public float Gluttony { get; private set; }

    public Cattributes()
    {
        Name = "Fluffypants";
        Age = 2;
        Friendship = 0.5f;
        Energy = 0.5f;
        Noise = 0.5f;
        Gluttony = 0.5f;
    }

    public float AgeUp()
    {
        Age++;
        Debug.Log(Name + " is now " + Age + "!");
        return Age;
    }

    public string AgeName()
    {
        string ageName = "empty";

        if (Age < 1)
        {
            ageName = "Kitten";
        }
        else if (Age >= 1 && Age < 8)
        {
            ageName = "Cat";
        }
        else
        {
            ageName = "Senior";
        }

        return ageName;
    }
}