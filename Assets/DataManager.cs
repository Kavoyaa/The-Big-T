using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    // GLOBAL VARIABLES
    // Use DataManager.instance.variableName to access/modify
    public string playerLocation = "MainMenu";

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
