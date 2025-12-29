using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BackpackInteractionScript : MonoBehaviour
{
    public string interactionText;
    public Text textObject;
    public Text notifText;
    private bool inTrigger = false;
    private bool bagHasBeenChecked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger && !bagHasBeenChecked)
        {
            CheckBag();
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

    void CheckBag()
    {
        bagHasBeenChecked = true;
        interactionText = "";
        textObject.text = "";
        
        int r1 = UnityEngine.Random.Range(1, 101);

        if (r1 > 60)
        {
            string[] items = DataManager.Instance.classroomItems;
            int r2 = UnityEngine.Random.Range(0, items.Length);
            string item = items[r2];

            if (!DataManager.Instance.playerInventory.Contains(item))
            {
               DataManager.Instance.playerInventory.Add(item);
               notifText.text = "You found a " + item + "!";
            }
            else
            {
                notifText.text = "You didn't find anything of use.";
            }
        }
        else
        {
            notifText.text = "You didn't find anything of use.";
        }

        StartCoroutine(RemoveNotification());
    }

    IEnumerator RemoveNotification()
    {
        yield return new WaitForSeconds(2f);
        notifText.text = "";
    }
}
