/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  ButtonGizmo.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/09/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Gizmo
{
    [AddComponentMenu("MGS/Gizmo/Button Gizmo")]
    public class ButtonGizmo : InteractGizmo
    {
        public event Action OnClick;

        protected virtual void OnMouseUpAsButton()
        {
            Debug.Log("OnMouseUpAsButton");
            OnClick?.Invoke();
        }
    }
}