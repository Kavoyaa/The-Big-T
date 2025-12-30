using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MorningSceneLoad : MonoBehaviour
{
    public Text timeText;

    void OnEnable()
    {
        // Hard reset — retry safe
        Time.timeScale = 1f;

        if (DataManager.Instance != null)
        {
            DataManager.Instance.playerLocation = "MorningScene";
        }

        // Restart coroutine every time scene loads
        StopAllCoroutines();
        StartCoroutine(SwitchToNight());
    }

    IEnumerator SwitchToNight()
    {
        if (timeText == null)
        {
            Debug.LogError("timeText NOT ASSIGNED");
            yield break;
        }

        timeText.text = "2PM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "3PM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "4PM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "5PM";

        yield return new WaitForSecondsRealtime(6f);
        SceneManager.LoadScene("MainScene");
    }
}
