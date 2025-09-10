/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  LineGizmo.cs
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
    [AddComponentMenu("MGS/Gizmo/Line Gizmo")]
    [RequireComponent(typeof(LineRenderer))]
    public class LineGizmo : Gizmo
    {
        [HideInInspector]
        public LineRenderer lineRenderer;
        public Transform start;
        public Transform end;

        protected override void Reset()
        {
            base.Reset();
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
        }

        protected override void UpdateGizmo()
        {
            UpdateGizmoSize();
            UpdateLinePosition();
        }

        protected void UpdateGizmoSize()
        {
            var width = CalAdaptiveSize();
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }

        protected void UpdateLinePosition()
        {
            if (start != null)
            {
                lineRenderer.SetPosition(0, start.position);
            }
            if (end != null)
            {
                lineRenderer.SetPosition(1, end.position);
            }
        }

        protected new float CalAdaptiveSize()
        {
            var pos = lineRenderer.GetPosition(0);
            var minDis = Vector3.Distance(pos, renderCamera.transform.position);

            pos = lineRenderer.GetPosition(1);
            var dis = Vector3.Distance(pos, renderCamera.transform.position);

            minDis = dis < minDis ? dis : minDis;
            return minDis * visualSize;
        }
    }
}