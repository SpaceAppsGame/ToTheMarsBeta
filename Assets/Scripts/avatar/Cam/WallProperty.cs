using System;
using UnityEngine;

//Apply to walls 
public class WallProperty: MonoBehaviour 
{
    private Renderer render;
    Color renderColor;
    private bool transparent = false;

    private void Start()
    {
        render = this.GetComponent<Renderer>();
        renderColor = render.material.color;
    }
    public void ChangeTransparency(bool transparent)
    {
        if (this.transparent == transparent) return; 
        this.transparent = transparent;
        if (transparent)
        {
            renderColor.a = 0.3f;
        }
        else
        {
            renderColor.a = 1.0f;
        }
        render.material.color = renderColor;
    }
}
