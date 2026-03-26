/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  HoverGizmo.cs
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
    [AddComponentMenu("MGS/Gizmo/Hover Gizmo")]
    [RequireComponent(typeof(Collider))]
    public class HoverGizmo : Gizmo<Renderer>
    {
        public bool interactive = true;
        public Color normalColor = Color.white;
        public Color highlightColor = Color.yellow;

        protected override void Awake()
        {
            base.Awake();
            SetColor(normalColor);
        }

        protected virtual void OnMouseEnter()
        {
            if (interactive)
            {
                OnEnter();
            }
        }

        protected virtual void OnMouseExit()
        {
            if (interactive)
            {
                OnExit();
            }
        }

        protected virtual void OnEnter()
        {
            SetColor(highlightColor);
        }

        protected virtual void OnExit()
        {
            SetColor(normalColor);
        }

        public override void SetColor(Color color)
        {
            base.SetColor(color);
        }
    }
}