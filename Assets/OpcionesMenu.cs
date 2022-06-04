using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class OpcionesMenu : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    [SerializeField]
    GameObject TxtNumeroVolumen;
    TextMeshProUGUI textMesh;
    int valorVolumen;
    public TMP_Dropdown resolutionDropdown;
    public Toggle toggleFullscreen;
    Resolution[] resolutions;
    void Start()
    {
        

        textMesh = TxtNumeroVolumen.GetComponent<TextMeshProUGUI>();
        CambiarVolumen();
        resolutions= Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, toggleFullscreen.isOn);

    }
    public void CambiarVolumen()
    {
        valorVolumen = (int)(slider.value*100);
        textMesh.text = valorVolumen.ToString() + "%";
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
