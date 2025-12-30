using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NightSceneLoad : MonoBehaviour
{
    public TMP_Text timeText;

    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(NightClock());
    }

    IEnumerator NightClock()
    {
        string[] nightTimes =
        {
            "9 PM", "10 PM", "11 PM",
            "12 AM", "1 AM", "2 AM",
            "3 AM", "4 AM", "5 AM"
        };

        for (int i = 0; i < nightTimes.Length; i++)
        {
            timeText.text = nightTimes[i];
            yield return new WaitForSecondsRealtime(60f);
        }

        SceneManager.LoadScene("MorningScene");
    }
}
