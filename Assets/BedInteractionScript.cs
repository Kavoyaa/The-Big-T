using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BedInteractionScript : MonoBehaviour
{
    public Text textObject;
    public string interactionText = "Press E to sleep";
    private bool inTrigger = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        textObject.text = interactionText;
        inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        textObject.text = "";
        inTrigger = false;
    }
}
