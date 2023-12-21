using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Info
    [SerializeField] new private string name = "Kitty";
    public GameObject textbox;
    private TextMeshProUGUI nameText;

    // Personality
    //  ranges from 0 to 1
    [SerializeField] private float friendship;
    [SerializeField] private float energy;
    [SerializeField] private float noise;
    [SerializeField] private float gluttony;

    private string description;

    void Awake() {
        nameText = textbox.GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        description = name + 
                    "\nFriendship: " + friendship.ToString() + 
                    "\nEnergy: " + energy.ToString() +
                    "\nNoise: " + noise.ToString() +
                    "\nGluttony: " + gluttony.ToString();
        nameText.text = description;
    }

    public Cat()
    {
        
    }
}
