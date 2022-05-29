using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverOutline : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    private Renderer outlineRenderer;

    void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial/*, outlineScaleFactor, outlineColor*/);
    }

    Renderer CreateOutline(Material outlineMat/*, float scaleFactor, Color color*/)
    {
        GameObject outlineObject = Instantiate(this.gameObject, transform.localPosition, transform.localRotation, transform);
        outlineObject.transform.localScale = new Vector3(1, 1, 1);
        outlineObject.transform.localPosition = Vector3.zero;

        Renderer rend = outlineObject.GetComponent<Renderer>();

        rend.material = outlineMat;
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
