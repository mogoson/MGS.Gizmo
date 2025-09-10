/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  Gizmo.cs
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
    [AddComponentMenu("MGS/Gizmo/Gizmo")]
    [ExecuteInEditMode]
    public class Gizmo : MonoBehaviour
    {
        public Camera renderCamera;
        public float visualSize = 0.02f;

        protected virtual void Reset()
        {
            renderCamera = Camera.main;
        }

        protected virtual void OnBecameVisible()
        {
            enabled = true;
        }

        protected virtual void OnBecameInvisible()
        {
            enabled = false;
        }

        protected virtual void Update()
        {
            if (renderCamera != null)
            {
                UpdateGizmo();
            }
        }

        protected virtual void UpdateGizmo()
        {
            transform.localScale = Vector3.one * CalAdaptiveSize();
        }

        protected float CalAdaptiveSize()
        {
            var dis = Vector3.Distance(transform.position, renderCamera.transform.position);
            return dis * visualSize;
        }
    }
}