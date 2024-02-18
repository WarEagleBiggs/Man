using System.Collections;
using System.Collections.Generic;
using FullscreenEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Prompt;
    public Master MasterScript;

    public GameObject HUD;
    public GameObject Pause;

    public SimplePlayerController SPC;
    public GameObject Man;

    public bool isPaused;
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
        
        
        //pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                
            }
            
            HUD.SetActive(!HUD.activeSelf);
            Pause.SetActive(!Pause.activeSelf);
            SPC.enabled = !SPC.isActiveAndEnabled;
            Man.SetActive(!Man.activeSelf);
            
            isPaused = !isPaused;

            
        }
        
    }
}
