using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<string> elementSpawnerCode;
    public TextMeshProUGUI selectionIndicator;

    [Header("All Elements")]

    #region
    public GameObject hydrogen;
    public GameObject helium;
    public GameObject lithium;
    public GameObject beryllium;
    public GameObject boron;
    public GameObject carbon;
    public GameObject nitrogen;
    public GameObject oxygen;
    public GameObject flourine;
    public GameObject neon;

    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        defineChars();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string result = String.Join("", elementSpawnerCode);
            if (result != null)
            {
                Instantiate(defineElements(result), Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), transform.rotation);
            }
            elementSpawnerCode.Clear();
        }
        if (defineString(String.Join("", elementSpawnerCode)) != null)
        {
            selectionIndicator.text = defineString(String.Join("", elementSpawnerCode));
        }
        else if (defineString(String.Join("", elementSpawnerCode)) == null)
        {
            selectionIndicator.text = "Element not Found";
        }
    }

    void defineChars()
    {
        string chars = "ABCDEFGHIKLMNOPRSTUVWXYZ".ToLower();

        foreach (char c in chars)
        {
            // Convert the char to string because Input.GetKeyDown expects a string argument
            string key = c.ToString();

            if (Input.GetKeyDown(key))
            {
                elementSpawnerCode.Add(key.ToLower());
            }
        }
    }

    GameObject defineElements(string id)
    {
        switch (id)
        {
            case "h":
                return hydrogen;

            case "he":
                return helium;

            case "li":
                return lithium;

            case "be":
                return beryllium;

            case "b":
                return boron;

            case "c":
                return carbon;

            case "n":
                return nitrogen;

            case "o":
                return oxygen;

            case "f":
                return flourine;

            case "ne":
                return neon;
        }

        return null;
    }

    string defineString(string id)
    {
        switch (id)
        {
            case "h":
                return "Hydrogen";

            case "he":
                return "Helium";

            case "li":
                return "Lithium";

            case "be":
                return "Beryllium";

            case "b":
                return "Boron";

            case "c":
                return "Carbon";

            case "n":
                return "Nitrogen";

            case "o":
                return "Oxygen";

            case "f":
                return "Flourine";

            case "ne":
                return "Neon";
        }

        return null;
    }
}
