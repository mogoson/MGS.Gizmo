/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  NodeIOTangentGizmo.cs
 *  Description  :  Default.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  1.0.0
 *  Date         :  09/10/2025
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace MGS.Gizmo
{
    [AddComponentMenu("MGS/Gizmo/Node IO Tangent Gizmo")]
    public class NodeIOTangentGizmo : NodeTangentGizmo
    {
        public event Action<Vector3> OnOutTangentMoveEvent;
        public LineGizmo outLineGizmo;
        public MoveGizmo outTangentGizmo;
        public bool isSeparate;

        protected override void Awake()
        {
            base.Awake();
            outTangentGizmo.OnMoveEvent += OutTangentGizmo_OnMove;
        }

        protected override void TangentGizmo_OnMove(Vector3 pos)
        {
            OnInTangentGizmoMove(pos);
            if (!isSeparate)
            {
                var outTanPos = 2 * nodeGizmo.transform.position - pos;
                outTangentGizmo.transform.position = outTanPos;
                OnOutTangentGizmoMove(outTanPos);
            }
        }

        protected virtual void OutTangentGizmo_OnMove(Vector3 pos)
        {
            OnOutTangentGizmoMove(pos);
            if (!isSeparate)
            {
                var inTanPos = 2 * nodeGizmo.transform.position - pos;
                tangentGizmo.transform.position = inTanPos;
                OnInTangentGizmoMove(inTanPos);
            }
        }

        protected void OnInTangentGizmoMove(Vector3 pos)
        {
            var tangent = nodeGizmo.transform.position - pos;
            InvokeOnTangentMoveEvent(tangent);
        }

        protected void OnOutTangentGizmoMove(Vector3 pos)
        {
            var outTangent = pos - nodeGizmo.transform.position;
            InvokeOnOutTangentMoveEvent(outTangent);
        }

        protected void InvokeOnOutTangentMoveEvent(Vector3 outTangent)
        {
            OnOutTangentMoveEvent?.Invoke(outTangent);
        }

        public override void SetPosition(Vector3 node, Vector3 inTangent)
        {
            base.SetPosition(node, inTangent);
            tangentGizmo.transform.position = node - inTangent;
        }

        public void SetPosition(Vector3 node, Vector3 inTangent, Vector3 outTangent)
        {
            SetPosition(node, inTangent);
            outTangentGizmo.transform.position = node + outTangent;
        }

        public override void SetInteractive(bool interactive)
        {
            base.SetInteractive(interactive);
            outTangentGizmo.interactive = interactive;
        }

        public override void SetTangentActive(bool isActive)
        {
            SetInTangentActive(isActive);
            SetOutTangentActive(isActive);
        }

        public virtual void SetInTangentActive(bool isActive)
        {
            lineGizmo.gameObject.SetActive(isActive);
            tangentGizmo.gameObject.SetActive(isActive);
        }

        public virtual void SetOutTangentActive(bool isActive)
        {
            outLineGizmo.gameObject.SetActive(isActive);
            outTangentGizmo.gameObject.SetActive(isActive);
        }
    }
}