using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpPanel : MonoBehaviour
{
    public TextMeshProUGUI title, level, info, gains, levelUpInfo, levelUpGains;

    private Color oldColor;
    public Color newColor;
    private Color oldColorText;
    public Color newColorText;

    private bool firstTime = false;

    float timer;
    private void Start()
    {
        SetAlpha(0);
    }

    public void SetData(string name, float info, float gains, Uses uses, int level, float levelUpInfo, bool upgradeModeOn)
    {
        this.title.text = name;
        if (upgradeModeOn)
        {
            this.level.text = "Lvl " + level.ToString() + " >> Lvl " + (level+1).ToString();
        }
        else
            this.level.text = "Lvl " + level.ToString();

        this.info.text = "Uses "+ info.ToString() + " kwH";
        this.gains.text = uses == Uses.Cleanliness ? "Provides " + gains + " " + uses.ToString() : "Alleviates " + gains +" " + uses.ToString();


        this.levelUpInfo.text = ">> " + levelUpInfo.ToString() + " kwH";

    }

    public void SetAlphaSmooth(Color alpha, bool upgradeModeOn)
    {
        if (!firstTime)
        {
           /*oldColor = self.color;
            newColor = self.color;*/

            oldColorText = title.color;
            newColorText = title.color;

            timer = 0;
            firstTime = true;
        }

        timer += Time.deltaTime * 4;

        //newColor = Color.Lerp(oldColor, alpha, timer);
        newColorText = Color.Lerp(oldColorText, new Color(oldColorText.r, oldColorText.g, oldColorText.b,alpha.a), timer);

        //self.color = newColor;

        title.color = newColorText;
        info.color = newColorText;
        gains.color = newColorText;
        level.color = newColorText;

        if (upgradeModeOn)
        {
            levelUpInfo.color = newColorText;
        }

    }


    public void SetAlpha(float alpha)
    {
        firstTime = false;

        //var tempColor = self.color;
        var tempColorText = title.color;

       // tempColor.a = alpha;
        tempColorText.a = alpha;

        //self.color = tempColor;

        title.color = tempColorText;
        info.color = tempColorText;
        gains.color = tempColorText;


        level.color = tempColorText;
        levelUpInfo.color = tempColorText;

    }
}
