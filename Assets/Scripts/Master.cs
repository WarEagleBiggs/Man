using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using Slider = UnityEngine.UIElements.Slider;

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

    public GameObject PagesUI;
    public GameObject SettingsUI;
    public GameObject ArchiveUI;

    public float Brightness;
    public Volume Vol;
    public VolumeProfile volpro;
    public UnityEngine.UI.Slider slider;
    private ColorAdjustments colo;

    public void UpdateBrigh()
    {
        if (slider == null)
        {
            Debug.LogError("Slider is not assigned.");
            return;
        }

        if (volpro == null) // Assuming you want to use volpro directly for some reason
        {
            Debug.LogError("VolumeProfile is not assigned.");
            return;
        }

        Brightness = slider.value;
        // Assuming volpro is the correct profile to modify
        ColorAdjustments colo2;
        if (volpro.TryGet<ColorAdjustments>(out colo2))
        {
            colo2.postExposure.value = Brightness;
        }
        else
        {
            Debug.LogError("ColorAdjustments component not found in the provided VolumeProfile.");
        }
    }

    void Update()
    {
        countTxt.SetText(NotesCollected + "/20");

        if (currSection == 0)
        {
            //pages
            PagesUI.SetActive(true);
            SettingsUI.SetActive(false);
            ArchiveUI.SetActive(false);
        } else if (currSection == 1)
        {
            //settings
            SettingsUI.SetActive(true);
            PagesUI.SetActive(false);
            ArchiveUI.SetActive(false);
        } else if (currSection == 2)
        {
            //archive
            ArchiveUI.SetActive(true);
            PagesUI.SetActive(false);
            SettingsUI.SetActive(false);
        }
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
    public void rightSection()
    {
        if (currSection == SectionWordings.Count - 1)
        {

            currSection = 0;
            SectionTxt.SetText(SectionWordings[currSection]);
            
        }
        else
        {
            
            currSection++;
            SectionTxt.SetText(SectionWordings[currSection]);
        }
        

    }
}
