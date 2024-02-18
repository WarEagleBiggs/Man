using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Master : MonoBehaviour
{
    public List<GameObject> Manholes;
    public int NotesCollected;
    public bool isEscape;
    public bool isChase;

    public TextMeshProUGUI SectionTxt;
    
    public List<GameObject> Images;
    public int currImage;

    public TextMeshProUGUI countTxt;
    

    void Update()
    {
        countTxt.SetText(NotesCollected + "/20");
    }

    public void leftImage()
    {
        Images[currImage].SetActive(false);
        currImage--;
        Images[currImage].SetActive(true);

    }
    public void rightImage()
    {
        Images[currImage].SetActive(false);
        currImage++;
        Images[currImage].SetActive(true);

    }
}
