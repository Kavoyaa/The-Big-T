using UnityEngine;
using System.Collections;

public class SimpleMenuAudio : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 0f; // 2D sound
        source.loop = false;
        source.volume = 1f;

        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        AudioClip music = Resources.Load<AudioClip>("main_music");
        AudioClip whistle = Resources.Load<AudioClip>("whistle");

        if (music == null || whistle == null)
        {
            Debug.LogError("Audio files not found in Resources folder");
            yield break;
        }

        source.PlayOneShot(music);
        yield return new WaitForSeconds(music.length);

        yield return new WaitForSeconds(1f); // silence gap

        source.PlayOneShot(whistle);
        yield return new WaitForSeconds(whistle.length);

        source.clip = music;
        source.loop = true;
        source.Play();
    }
}
