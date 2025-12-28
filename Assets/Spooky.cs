using UnityEngine;
using TMPro;

public class SubtleFlicker : MonoBehaviour
{
    TextMeshProUGUI text;
    float timer;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > Random.Range(0.15f, 0.4f))
        {
            text.alpha = Random.Range(0.7f, 0.95f);
            timer = 0f;
        }
    }
}
