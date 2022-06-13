using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfDayResultsScript : MonoBehaviour
{
    public TextMeshProUGUI elec, hungy, bored, clean, scrap, days, elec2, hungy2, bored2, clean2, scrap2, title;

    public bool pressAnywhere;

    public void GetData(float e, float h, float b,float c, float s, float d, float currentDay)
    {
        this.gameObject.SetActive(true);

        title.text = "Day " + currentDay + " results!" ;

        elec2.text = e.ToString("F2");
        hungy2.text = h.ToString("F0");
        bored2.text = b.ToString("F0");
        clean2.text = c.ToString("F0");
        scrap2.text = s.ToString("F0");
        days.text = d.ToString("F0") + " Days remain!";
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            this.gameObject.SetActive(false);
        }
    }
}
