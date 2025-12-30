using UnityEngine;

public class NightSceneLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataManager.Instance.playerLocation = "NightScene";
        DataManager.Instance.playerStamina = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
