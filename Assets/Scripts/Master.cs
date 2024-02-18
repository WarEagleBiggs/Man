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
    public List<string> SectionWordings;
    public int currSection;
    
    public List<GameObject> Images;
    public int currImage;

    public TextMeshProUGUI countTxt;
    

    void Update()
    {
        countTxt.SetText(NotesCollected + "/20");
    }

    public void leftImage()
    {
        if (currImage == 0)
        {
            Images[currImage].SetActive(false);
            currImage = Images.Count - 1;
            Images[currImage].SetActive(true);
        }
        else
        {
            Images[currImage].SetActive(false);
            currImage--;
            Images[currImage].SetActive(true);
        }
        

    }
    public void rightImage()
    {
        if (currImage == Images.Count - 1)
        {
            Images[currImage].SetActive(false);
            currImage = 0;
            Images[currImage].SetActive(true);
        }
        else
        {
            Images[currImage].SetActive(false);
            currImage++;
            Images[currImage].SetActive(true);
        }

    }
    
    public void leftSection()
    {
        if (currSection == 0)
        {
            
            currSection = SectionWordings.Count - 1;
            SectionTxt.SetText(SectionWordings[currSection]);
            
        }
        else
        {
            
            currSection--;
            SectionTxt.SetText(SectionWordings[currSection]);
        }
        

    }
}
