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
    public class MoveGizmo : HoverGizmo
    {
        public event Action<Vector3> OnMoveEvent;
        protected float deep = 0f;
        protected Vector3 offset;

        protected virtual void OnMouseDown()
        {
            if (interactive)
            {
                OnDown();
            }
        }

        protected virtual void OnMouseDrag()
        {
            if (interactive)
            {
                OnDrag();
            }
        }

        protected virtual void OnDown()
        {
            deep = GetTransScreenPoint().z;
            offset = transform.position - GetMouseWorldPoint();
        }

        protected virtual void OnDrag()
        {
            transform.position = offset + GetMouseWorldPoint();
            OnMoveEvent?.Invoke(transform.position);
        }

        protected Vector3 GetTransScreenPoint()
        {
            return camera.WorldToScreenPoint(transform.position);
        }

        protected Vector3 GetMouseWorldPoint()
        {
            var msPos = Input.mousePosition;
            msPos.z = deep;
            return camera.ScreenToWorldPoint(msPos);
        }
    }
}