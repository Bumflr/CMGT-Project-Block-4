using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    
    private RaycastHit savedHit;
    public RectTransform popUpPrefab;
    private bool interactedWith = false;

    public UpgradeManager upgrade;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("what");
            PauseController.Pausing();
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (savedHit.transform != hit.transform)
            {
                popUpPrefab.GetComponent<PopUpPanel>().SetAlpha(0);
                savedHit = hit;
                interactedWith = false;
            }
            else
            {
                if (interactedWith)
                {
                    popUpPrefab.GetComponent<PopUpPanel>().SetAlphaSmooth(new Color(1, 1, 1, 1), upgrade.upgradeModeOn);
                }
                else
                {
                    popUpPrefab.GetComponent<PopUpPanel>().SetAlpha(0);

                    /*Vector2 ViewportPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                    Vector2 proportionalPosition = new Vector2(ViewportPosition.x * CanvasRect.sizeDelta.x, ViewportPosition.y * CanvasRect.sizeDelta.y);

                    // Set the position and remove the screen offset
                    popUpPrefab.localPosition = proportionalPosition + offset - uiOffset;*/
                }
            }

            if (hit.transform.tag == "Appliance")
            {
                ApplianceScript script = hit.transform.gameObject.GetComponent<ApplianceScript>();
                popUpPrefab.GetComponent<PopUpPanel>().SetData(hit.transform.name, script.kwH[script.level],
                    script.gains, script.use,
                    script.level, script.level == 2 ? script.kwH[script.level] : script.kwH[script.level + 1], upgrade.upgradeModeOn);

                interactedWith = true;
            }
            else
                interactedWith = false;


            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.tag == "Appliance")
                {
                    if (upgrade.upgradeModeOn && hit.transform.GetComponent<ApplianceScript>().level != 2)
                    {
                        hit.transform.GetComponent<ApplianceScript>().UpgradeState();
                    }
                    else
                    {
                        hit.transform.GetComponent<ApplianceScript>().RotateState();
                    }
                    return;
                }
            }

        }
        else
        {
            interactedWith = false;
            popUpPrefab.GetComponent<PopUpPanel>().SetAlpha(0);
        }
    }
}
