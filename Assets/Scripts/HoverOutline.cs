using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOutline : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    private Renderer outlineRenderer;

    public bool flipIfModelFucked;

    void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial);
    }

    Renderer CreateOutline(Material outlineMat)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.localPosition, transform.localRotation, transform);
        outlineObject.transform.localScale = new Vector3(1, 1, 1);
        outlineObject.transform.localPosition = Vector3.zero;

        if (flipIfModelFucked)
        {
            outlineObject.transform.localRotation = new Quaternion(0, -180f, 0, 0);
        }
        outlineObject.tag = "Untagged";

        Renderer rend = outlineObject.GetComponent<Renderer>();

        Material[] outlineMats = new Material[rend.materials.Length];
        for (int i = 0; i < rend.materials.Length; i++)
        {
            outlineMats[i] = outlineMat;
        }
        rend.materials = outlineMats;
        //rend.material.SetColor("_OutlineColor", color);
        //rend.material.SetFloat("_Scale", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        outlineObject.GetComponent<HoverOutline>().enabled = false;
        outlineObject.GetComponent<Collider>().enabled = false;

        rend.enabled = false;

        return rend;
    }

    private void OnMouseEnter()
    {
        outlineRenderer.enabled = true;
    }
    private void OnMouseExit()
    {
        outlineRenderer.enabled = false;
    }
}
