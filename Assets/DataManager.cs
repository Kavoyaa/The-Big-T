using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    // GLOBAL VARIABLES
    // Use DataManager.instance.variableName to access/modify
    public string playerLocation = "MainMenu";
    public float playerStamina = 100f;
    public bool pillActive = false;

    // These are the items that can be obtained by
    // searching bags in the classrooms
    public string[] classroomItems = {"Sussy Pill"};
    public List<string> playerInventory = new List<string>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
