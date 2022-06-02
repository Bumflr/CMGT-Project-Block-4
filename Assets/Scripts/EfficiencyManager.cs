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
    public float totallest;
    // Start is called before the first frame update
    public void StartYoShit(int length)
    {
        texts = new Text[length];
        textsIndexes = new Vector2[length];
        total = new float[length];

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
        totallest = 0;

        Vector2 INToMyAss = new Vector2(AssignInt(), ass.index);

        texts[(int)INToMyAss.x].text = ass.kwH.ToString();

        textsIndexes[(int)INToMyAss.x] = INToMyAss;

        total[(int)INToMyAss.x] = ass.kwH;
        for (int i = 0; i < total.Length; i++)
        {
            totallest += total[i];
        }
        finalText.text = totallest.ToString();
    }

    public void RemoveEnergy(ApplianceScript ass)
    {
        totallest = 0;

        for (int i = 0; i < textsIndexes.Length; i++)
        {
            if (textsIndexes[i].y == ass.index)
            {
                total[(int)textsIndexes[i].x] = 0;

                for (int j = 0; j < total.Length; j++)
                {
                    totallest += total[j];
                }
                finalText.text = totallest.ToString();

                texts[(int)textsIndexes[i].x].text = " ";
                textsIndexes[i] = new Vector2(69 , 69);
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
