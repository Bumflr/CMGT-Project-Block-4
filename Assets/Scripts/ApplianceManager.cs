using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ApplianceManager : MonoBehaviour
{
    public GameManager gm;
    //This script holds all of the Appliances
    public GameObject applianceIndicatorPrefab;

    public ApplianceScript[] appliances;
    private Image[] applianceIndicators;
    private TextMeshProUGUI[] applianceText;
    private Slider[] applianceSlider;

    

    // Start is called before the first frame update
    void Start()
    {
        appliances = FindAppliances();
        applianceIndicators = new Image[appliances.Length];
        applianceText = new TextMeshProUGUI[appliances.Length];
        applianceSlider = new Slider[appliances.Length];


        gm.em.Starting(appliances.Length);

        for (int i = 0; i < appliances.Length; i++)
        {
            var a = Instantiate(applianceIndicatorPrefab, new Vector3(appliances[i].gameObject.transform.position.x + 1, appliances[i].gameObject.transform.position.y + 3, appliances[i].gameObject.transform.position.z), applianceIndicatorPrefab.transform.rotation, this.transform);

            applianceIndicators[i] = a.GetComponent<Image>();
            applianceText[i] = a.GetComponentInChildren<TextMeshProUGUI>();
            applianceSlider[i] = a.GetComponentInChildren<Slider>();

            applianceText[i].text = appliances[i].kwH[appliances[i].level].ToString() + " kwH";

            appliances[i].IsOn += gm.em.AddEnergy;
            appliances[i].IsOff += gm.em.RemoveEnergy;

            appliances[i].Begin();
        }


    }

    ApplianceScript[] FindAppliances()
    {
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("Appliance");
        ApplianceScript[] scripts = new ApplianceScript[gameObject.Length];

        for (int i = 0; i < gameObject.Length; i++)
        {
            scripts[i] = gameObject[i].GetComponent<ApplianceScript>();
            scripts[i].index = i;
            scripts[i].applianceManager = this;
        }

        return scripts;
    }

    public void SetSliderValues(float value)
    {
        for (int i = 0; i < applianceSlider.Length; i++)
        {
            if (appliances[i].state == ApplianceState.ON)
            {
                applianceSlider[i].value = value;
            }
        }
    }

    public void SetSymbol(ApplianceState state, int index)
    {
        switch (state)
        {
            case ApplianceState.OFF:
                applianceIndicators[index].color = Color.grey;

                applianceSlider[index].gameObject.SetActive(false);
                applianceText[index].enabled = false;
                break;
            case ApplianceState.ON:

                applianceIndicators[index].color = Color.yellow;

                applianceSlider[index].gameObject.SetActive(true);

                applianceText[index].enabled = true;
                break;
            case ApplianceState.NO_POWER:
                applianceIndicators[index].color = Color.black;
                applianceText[index].enabled = true;
                break;
        }
    }
}
