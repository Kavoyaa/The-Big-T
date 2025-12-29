using UnityEngine;
using System.Collections;

public class MenuAudioController : MonoBehaviour
{
    AudioSource source;
    AudioClip mainMusic;
    AudioClip whistle;

    void Start()
    {
        source = GetComponent<AudioSource>();

        // Load audio from Resources (NO Inspector needed)
        mainMusic = Resources.Load<AudioClip>("Audio/main_music");
        whistle = Resources.Load<AudioClip>("Audio/whistle");

        StartCoroutine(AudioLoop());
    }

    IEnumerator AudioLoop()
    {
        while (true)
        {
            // Play main music
            source.PlayOneShot(mainMusic);
            yield return new WaitForSeconds(mainMusic.length);

            // Silence
            yield return new WaitForSeconds(1.5f);

            // Play whistle ONCE
            source.PlayOneShot(whistle);
            yield return new WaitForSeconds(whistle.length);

            // Silence
            yield return new WaitForSeconds(1f);
        }
    }
}
