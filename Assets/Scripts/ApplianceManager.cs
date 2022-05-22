using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ApplianceManager : MonoBehaviour
{
    public GameObject applianceIndicatorPrefab;

    public ApplianceScript[] appliances;
    private Image[] applianceIndicators;
    private TextMeshProUGUI[] applianceText;

    public Image onSymbol, offSymbol;


    // Start is called before the first frame update
    void Start()
    {
        appliances = FindAppliances();
        applianceIndicators = new Image[appliances.Length];
        applianceText = new TextMeshProUGUI[appliances.Length];

        for (int i = 0; i < appliances.Length; i++)
        {
            var a = Instantiate(applianceIndicatorPrefab, new Vector3(appliances[i].gameObject.transform.position.x + 1, appliances[i].gameObject.transform.position.y + 3, appliances[i].gameObject.transform.position.z), applianceIndicatorPrefab.transform.rotation, this.transform);

            applianceIndicators[i] = a.GetComponent<Image>();
            applianceText[i] = a.GetComponentInChildren<TextMeshProUGUI>();
            applianceText[i].text = appliances[i].kwH.ToString() + " kwH";
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
            scripts[i].symbolCanvas = this;
        }

        return scripts;
    }

    // Update is called once per frame
    public void SetSymbol(ApplianceState state, int index)
    {
        switch (state)
        {
            case ApplianceState.OFF:
                applianceIndicators[index].color = Color.red;
                applianceText[index].enabled = false;
                break;
            case ApplianceState.ON:
                applianceIndicators[index].color = Color.blue;
                applianceText[index].enabled = true;
                break;
            case ApplianceState.NO_POWER:
                applianceIndicators[index].color = Color.black;
                applianceText[index].enabled = true;
                break;
        }
    }
}