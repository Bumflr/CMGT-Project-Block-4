using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailScreen : MonoBehaviour
{
    float alpha;

    public void Update()
    {
        alpha = Mathf.Lerp(alpha, 1, 5 / 5 * Time.deltaTime);

        this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, alpha);
    }

    public void RestartButton() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
