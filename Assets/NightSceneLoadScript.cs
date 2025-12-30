using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NightSceneLoadScript : MonoBehaviour
{

    public Text timeText;

    public GameObject enemy;
    public GameObject wine;
    //public Transform wineTransform;
    private Vector3[] spawnPoints =
    {
        new Vector3(950, 216.5f, 611),
        new Vector3(660, 216.5f, 437),
        new Vector3(889, 216.5f, 294),
    };
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Hard reset — retry safe
        Time.timeScale = 1f;

        if (DataManager.Instance != null)
        {
            DataManager.Instance.playerLocation = "NightScene";
        }

        int r = Random.Range(0 , spawnPoints.Length);
        Debug.Log(r);
        Debug.Log(spawnPoints);
        wine.transform.position = spawnPoints[r];
        enemy.transform.position = spawnPoints[r];

        // Restart coroutine every time scene loads
        StopAllCoroutines();
        StartCoroutine(SwitchToGameOver());
    }

    IEnumerator SwitchToGameOver()
    {
        if (timeText == null)
        {
            Debug.LogError("timeText NOT ASSIGNED");
            yield break;
        }

        timeText.text = "11PM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "12AM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "1AM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "2AM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "3AM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "4AM";

        yield return new WaitForSecondsRealtime(60f);
        timeText.text = "5AM";

        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("MainMenu");
    }
}
