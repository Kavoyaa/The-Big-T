using UnityEngine;
using System.Collections;

public class MenuAudioController : MonoBehaviour
{
    AudioSource source;
    AudioClip mainMusic;
    AudioClip whistle;

    // 🔧 TWEAKABLE
    public float whistleDuration = 8f;   // how long whistle plays
    public float whistlePitch = 0.7f;    // creepier if lower

    void Start()
    {
        // Ensure AudioSource exists
        source = GetComponent<AudioSource>();
        if (source == null)
            source = gameObject.AddComponent<AudioSource>();

        source.spatialBlend = 0f; // 2D
        source.playOnAwake = false;
        source.loop = false;
        source.volume = 1f;

        // Load audio from Resources/Audio
        mainMusic = Resources.Load<AudioClip>("Audio/main_music");
        whistle   = Resources.Load<AudioClip>("Audio/whistle");

        if (mainMusic == null || whistle == null)
        {
            Debug.LogError("❌ Audio files NOT found. Check Assets/Resources/Audio/");
            return;
        }

        StartCoroutine(AudioLoop());
    }

    IEnumerator AudioLoop()
    {
        while (true)
        {
            // ▶ MAIN MUSIC
            source.pitch = 1f;
            source.loop = false;
            source.clip = mainMusic;
            source.Play();
            yield return new WaitForSeconds(mainMusic.length);

            // ⏸ gap before whistle
            yield return new WaitForSeconds(1.5f);

            // 🧨 WHISTLE
            source.pitch = whistlePitch;
            source.loop = true;
            source.clip = whistle;
            source.Play();

            yield return new WaitForSeconds(whistleDuration);

            source.Stop();

            // ⏸ IMPORTANT: 1 SECOND SILENCE AFTER WHISTLE
            yield return new WaitForSeconds(1f);
        }
    }
}
