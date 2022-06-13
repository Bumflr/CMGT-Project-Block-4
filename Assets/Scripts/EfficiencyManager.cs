using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EfficiencyManager : MonoBehaviour
{
    public Text[] texts;
    public Text finalText;
    public Vector2[] textsIndexes;
    public GameObject textPrefab;

    public float yOffset;

    public float[] total;
    public float[] secondaryTotal;

    public float totalElec;
    public float totalHungy;
    public float totalBored;
    public float totalClean;

    public bool motorOn;

    public void Starting(int length)
    {
        texts = new Text[length];
        textsIndexes = new Vector2[length];
        total = new float[length];
        secondaryTotal = new float[length];

        for (int i = 0; i < texts.Length; i++)
        {
            var t = Instantiate(textPrefab, gameObject.transform.position, textPrefab.transform.rotation, this.transform);

            t.gameObject.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            t.gameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 40 + -i * yOffset);

            texts[i] = t.GetComponent<Text>();
            texts[i].text = " ";

            textsIndexes[i] = new Vector2(69, 69);
        }
    }

    public void AddEnergy(ApplianceScript ass)
    {
        totalElec = 0;

        //you can probably guess what my mental state was around the time i wrote this code lol
        // i mean tbf i am losing my mind rigt now as well lololol
        Vector2 INToMyAss = new Vector2(AssignInt(), ass.index);

        textsIndexes[(int)INToMyAss.x] = INToMyAss;

        total[(int)INToMyAss.x] = ass.use == Uses.GeneratePower ? -ass.kwH[ass.level] : ass.kwH[ass.level];

        secondaryTotal[(int)INToMyAss.x] = ass.gains;

        texts[(int)INToMyAss.x].text = total[(int)INToMyAss.x].ToString();

        switch (ass.use)
        {
            case Uses.Boredom:
                totalBored += secondaryTotal[(int)INToMyAss.x];
                break;
            case Uses.Hunger:
                totalHungy += secondaryTotal[(int)INToMyAss.x];
                break;
            case Uses.Cleanliness:
                totalClean += secondaryTotal[(int)INToMyAss.x];
                break;
        }

        if (ass.use == Uses.Engine)
        {
            motorOn = true;
        }

        for (int i = 0; i < total.Length; i++)
        {
            totalElec += total[i];
        }

        float bruh = -totalElec;

        if (totalElec >= 0)
        {
            finalText.text = "- " + totalElec.ToString();
            finalText.color = Color.red;
        }
        else
        {
            finalText.text = "+ " + bruh.ToString();
            finalText.color = Color.green;
        }



    }

    public void RemoveEnergy(ApplianceScript ass)
    {
        totalElec = 0;

        for (int i = 0; i < textsIndexes.Length; i++)
        {
            if (textsIndexes[i].y == ass.index)
            {
                switch (ass.use)
                {
                    case Uses.Boredom:
                        totalBored -= secondaryTotal[(int)textsIndexes[i].x];
                        break;
                    case Uses.Hunger:
                        totalHungy -= secondaryTotal[(int)textsIndexes[i].x];
                        break;
                    case Uses.Cleanliness:
                        totalClean -= secondaryTotal[(int)textsIndexes[i].x];
                        break;
                }

                if (ass.use == Uses.Engine)
                {
                    motorOn = false;
                }

                total[(int)textsIndexes[i].x] = 0;
                secondaryTotal[(int)textsIndexes[i].x] = 0;

                for (int j = 0; j < total.Length; j++)
                {
                    totalElec += total[j];
                }

                finalText.text = totalElec.ToString();

                texts[(int)textsIndexes[i].x].text = " ";
                textsIndexes[i] = new Vector2(69, 69);
                break;
            }
        }
    }

    private int AssignInt()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].text == " ")
            {
                Debug.Log(i);

                return i;

            }
        }

        return 69;

    }
}
