using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Prompt;
    public Master MasterScript;
    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f))
        {
            if (hit.collider.CompareTag("Sheet"))
            {
                Prompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //hit
                    MasterScript.NotesCollected++;
                    hit.transform.gameObject.SetActive(false);
                }
                
            }
            else
            {
                Prompt.SetActive(false);
            }
        }
    }
}
