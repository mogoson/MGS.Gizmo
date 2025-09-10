/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  MoveGizmo.cs
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
    [AddComponentMenu("MGS/Gizmo/Move Gizmo")]
    public class MoveGizmo : InteractGizmo
    {
        protected float deep = 0;
        protected Vector3 offset;

        public event Action<Vector3> OnMove;

        protected virtual void OnMouseDown()
        {
            deep = GetTransScreenPoint().z;
            offset = transform.position - GetMouseWorldPoint();
        }

        protected virtual void OnMouseDrag()
        {
            transform.position = offset + GetMouseWorldPoint();
            OnMove?.Invoke(transform.position);
        }

        protected Vector3 GetTransScreenPoint()
        {
            return renderCamera.WorldToScreenPoint(transform.position);
        }

        protected Vector3 GetMouseWorldPoint()
        {
            var msPos = Input.mousePosition;
            msPos.z = deep;
            return renderCamera.ScreenToWorldPoint(msPos);
        }
    }
}