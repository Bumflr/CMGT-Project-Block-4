using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpPanel : MonoBehaviour
{
    public Image self;
    public TextMeshProUGUI title, info, type;

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

    public void SetData(string name, float info, bool type)
    {
        this.title.text = name;
        this.info.text = "Uses "+ info.ToString() + " kwH";
        this.type.text = type ? "(Continious)" : "(Single Use)";
    }

    public void SetAlphaSmooth(Color alpha)
    {
        if (!firstTime)
        {
            oldColor = self.color;
            newColor = self.color;

            oldColorText = title.color;
            newColorText = title.color;

            timer = 0;
            firstTime = true;
        }

        timer += Time.deltaTime * 4;

        newColor = Color.Lerp(oldColor, alpha, timer);
        newColorText = Color.Lerp(oldColorText, new Color(oldColorText.r, oldColorText.g, oldColorText.b,alpha.a), timer);

        self.color = newColor;

        title.color = newColorText;
        info.color = newColorText;
        type.color = newColorText;
    }
    public void FadeOut()
    {
        self.CrossFadeAlpha(0, 1f, false);
    }

    public void SetAlpha(float alpha)
    {
        firstTime = false;

        var tempColor = self.color;
        var tempColorText = title.color;

        tempColor.a = alpha;
        tempColorText.a = alpha;

        self.color = tempColor;

        title.color = tempColorText;
        info.color = tempColorText;
        type.color = tempColorText;

    }
}
