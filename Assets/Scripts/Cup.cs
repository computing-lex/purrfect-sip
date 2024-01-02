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

    //Assign all renderers here for highlighting, and the color of the highlight

    [SerializeField] private List<Renderer> renderers;
    [SerializeField] Color color = Color.white;

    //Cache all Materials of the object
    private List<Material> materials;

    // Debug settings
    [SerializeField] private Vector3 respawnPoint;
    public bool respawn = false;
    public bool randomizeDrink;

    // Respawn objects if beyond the abyss
    public GameObject abyss;

    //Gets the materials from each renderer
    void Awake()
    {
        materials = new List<Material>();
        foreach(var renderer in renderers)
        {
            //Adding all materials with an 's' because each child-object might have several materials
            materials.AddRange(new List<Material>(renderer.materials));
        }
    }

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
        
        //Highlights the drink when hand is close to it
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Sensed Button Push! Highlighting Cup");
            ToggleHighlight(true);
        }
        if (OVRInput.GetUp(OVRInput.Button.One))
        {
            Debug.Log("Sensed Button Lift! Unhighlighting Cup");
            ToggleHighlight(false);
        }

        if (randomizeDrink) {
            RandomizeDrink(drinkParser.drinkList);
            randomizeDrink = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "RightHand")
        {
            ToggleHighlight(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "RightHand")
        {
            ToggleHighlight(false);
        }
    }

    private void RandomizeDrink(DrinkParser.DrinkList options) {
        randomDrink = options.drinks[Random.Range(0,(options.drinks.Length - 1))];
        drink.CopyValues(randomDrink);
        Debug.Log("Drink randomized! New drink is " + drink.name);
    }

    private void ToggleHighlight(bool val)
    {
        if (val)
        {
            foreach(var material in  materials)
            {
                //Set Outline width to 0.05
                material.SetFloat("_Outline_Width", 0.05f);
            }
        }
        else
        {
            foreach(var material in materials)
            {
				//Disable EMISSION
				material.SetFloat("_Outline_Width", 0.00f);
			}
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
