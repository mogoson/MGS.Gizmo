/*************************************************************************
 *  Copyright © 2025 Mogoson All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  NodeTwoTangentGizmo.cs
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
    public class NodeTwoTangentGizmo : NodeOneTangentGizmo
    {
        [SerializeField]
        protected LineGizmo outLineGizmo;

        [SerializeField]
        protected MoveGizmo outTangentGizmo;

        [SerializeField]
        protected bool isSeparate;

        public event Action<Vector3> OnOutTangentMove;

        public bool IsSeparate
        {
            set
            {
                isSeparate = value;
                if (!isSeparate)
                {
                    var outTangentPos = 2 * nodeGizmo.transform.position - tangentGizmo.transform.position;
                    outTangentGizmo.transform.position = outTangentPos;
                    BaseOutTangentGizmo_OnMove(outTangentPos);
                }
            }
            get { return isSeparate; }
        }

        protected override void Awake()
        {
            base.Awake();
            outTangentGizmo.OnMove += OutTangentGizmo_OnMove;
        }

        protected override void TangentGizmo_OnMove(Vector3 pos)
        {
            base.TangentGizmo_OnMove(pos);
            if (!isSeparate)
            {
                var outTangentPos = 2 * nodeGizmo.transform.position - pos;
                outTangentGizmo.transform.position = outTangentPos;
                BaseOutTangentGizmo_OnMove(outTangentPos);
            }
        }

        protected virtual void OutTangentGizmo_OnMove(Vector3 pos)
        {
            BaseOutTangentGizmo_OnMove(pos);
            if (!isSeparate)
            {
                var inTangentPos = 2 * nodeGizmo.transform.position - pos;
                tangentGizmo.transform.position = inTangentPos;
                base.TangentGizmo_OnMove(inTangentPos);
            }
        }

        protected void BaseOutTangentGizmo_OnMove(Vector3 pos)
        {
            var tangent = pos - nodeGizmo.transform.position;
            OnOutTangentMove?.Invoke(tangent);
        }
    }
}