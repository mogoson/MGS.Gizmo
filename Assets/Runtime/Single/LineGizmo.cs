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
    public class LineGizmo : Gizmo<LineRenderer>
    {
        public Transform startNode;
        public Transform endNode;

        protected override void Reset()
        {
            base.Reset();
            renderer.positionCount = 2;
        }

        protected override void UpdateGizmo()
        {
            UpdateGizmoSize();
            UpdateLinePosition();
        }

        protected void UpdateGizmoSize()
        {
            CalAdaptiveSize(out float startSize, out float endSize);
            renderer.startWidth = startSize;
            renderer.endWidth = endSize;
        }

        protected void UpdateLinePosition()
        {
            if (startNode)
            {
                renderer.SetPosition(0, startNode.position);
            }
            if (endNode)
            {
                renderer.SetPosition(1, endNode.position);
            }
        }

        protected void CalAdaptiveSize(out float startSize, out float endSize)
        {
            startSize = endSize = 1.0f;
            if (camera)
            {
                var pos = renderer.GetPosition(0);
                var dis = Vector3.Distance(pos, camera.transform.position);
                startSize = dis * visualSize;

                pos = renderer.GetPosition(1);
                dis = Vector3.Distance(pos, camera.transform.position);
                endSize = dis * visualSize;
            }
        }
    }
}