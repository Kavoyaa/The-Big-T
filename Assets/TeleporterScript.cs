using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleporterScript : MonoBehaviour
{
    public string destinationScene;
    public string interactionText;
    public Text textObject;
    private bool inTrigger = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger && SceneManager.GetActiveScene().name == DataManager.Instance.playerLocation)
        {
            textObject.text = "";
            SceneManager.LoadScene(destinationScene, LoadSceneMode.Additive);
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
