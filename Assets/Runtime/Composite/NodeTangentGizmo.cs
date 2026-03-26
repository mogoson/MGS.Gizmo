/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  NodeTangentGizmo.cs
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
    [AddComponentMenu("MGS/Gizmo/Node Tangent Gizmo")]
    public class NodeTangentGizmo : MonoBehaviour
    {
        public MoveGizmo nodeGizmo;
        public LineGizmo lineGizmo;
        public MoveGizmo tangentGizmo;

        public event Action<Vector3> OnNodeMoveEvent;
        public event Action<Vector3> OnTangentMoveEvent;

        protected virtual void Awake()
        {
            nodeGizmo.OnMoveEvent += NodeGizmo_OnMove;
            tangentGizmo.OnMoveEvent += TangentGizmo_OnMove;
        }

        protected virtual void NodeGizmo_OnMove(Vector3 pos)
        {
            transform.position = pos;
            nodeGizmo.transform.position = pos;
            InvokeOnNodeMoveEvent(pos);
        }

        protected virtual void TangentGizmo_OnMove(Vector3 pos)
        {
            var tangent = pos - nodeGizmo.transform.position;
            InvokeOnTangentMoveEvent(tangent);
        }

        public virtual void SetPosition(Vector3 node, Vector3 tangent)
        {
            transform.position = node;
            nodeGizmo.transform.position = node;
            tangentGizmo.transform.position = node + tangent;
        }

        public virtual void SetInteractive(bool interactive)
        {
            nodeGizmo.interactive = interactive;
            tangentGizmo.interactive = interactive;
        }

        public virtual void SetTangentActive(bool isActive)
        {
            lineGizmo.gameObject.SetActive(isActive);
            tangentGizmo.gameObject.SetActive(isActive);
        }

        protected void InvokeOnNodeMoveEvent(Vector3 position)
        {
            OnNodeMoveEvent?.Invoke(position);
        }

        protected void InvokeOnTangentMoveEvent(Vector3 tangent)
        {
            OnTangentMoveEvent?.Invoke(tangent);
        }
    }
}