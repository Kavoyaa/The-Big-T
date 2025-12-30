using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MorningSceneLoad : MonoBehaviour
{
    public Text timeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DataManager.Instance.playerLocation = "MorningScene";
        StartCoroutine(switchToNight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator switchToNight()
    {
        // I KNOW THERES BETTER WAYS TO DO THIS BUT IDC
        yield return new WaitForSeconds(60f);
        timeText.text = "3PM";

        yield return new WaitForSeconds(60f);
        timeText.text = "4PM";

        yield return new WaitForSeconds(60f);
        timeText.text = "5PM";

        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("MainScene");
    }
}
