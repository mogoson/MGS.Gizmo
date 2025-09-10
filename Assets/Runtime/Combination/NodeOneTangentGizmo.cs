/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  NodeOneTangentGizmo.cs
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
    [AddComponentMenu("MGS/Gizmo/Node One Tangent Gizmo")]
    public class NodeOneTangentGizmo : MonoBehaviour
    {
        [SerializeField]
        protected MoveGizmo nodeGizmo;

        [SerializeField]
        protected LineGizmo lineGizmo;

        [SerializeField]
        protected MoveGizmo tangentGizmo;

        public event Action<Vector3> OnNodeMove;
        public event Action<Vector3> OnTangentMove;

        protected virtual void Awake()
        {
            nodeGizmo.OnMove += NodeGizmo_OnMove;
            tangentGizmo.OnMove += TangentGizmo_OnMove;
        }

        protected virtual void TangentGizmo_OnMove(Vector3 pos)
        {
            var tangent = pos - nodeGizmo.transform.position;
            OnTangentMove?.Invoke(tangent);
        }

        protected virtual void NodeGizmo_OnMove(Vector3 pos)
        {
            transform.position = pos;
            nodeGizmo.transform.localPosition = Vector3.zero;
            OnNodeMove?.Invoke(pos);
        }
    }
}