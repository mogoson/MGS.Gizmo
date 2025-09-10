/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  InteractGizmo.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/09/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace MGS.Gizmo
{
    [AddComponentMenu("MGS/Gizmo/Interact Gizmo")]
    [RequireComponent(typeof(Collider), typeof(Renderer))]
    public class InteractGizmo : Gizmo
    {
        [HideInInspector]
        public Renderer render;
        public Color normalColor = Color.white;
        public Color highlightColor = Color.yellow;

        protected override void Reset()
        {
            base.Reset();
            render = GetComponent<Renderer>();
        }

        protected virtual void OnMouseEnter()
        {
            SetRendererColor(highlightColor);
        }

        protected virtual void OnMouseExit()
        {
            SetRendererColor(normalColor);
        }

        protected void SetRendererColor(Color color)
        {
            render.sharedMaterial.color = color;
        }
    }
}