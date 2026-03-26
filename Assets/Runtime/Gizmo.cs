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
    [ExecuteInEditMode]
    public class Gizmo<T> : MonoBehaviour where T : Renderer
    {
        protected const string NAME_GIZMO_CAMERA = "GizmoCamera";
        public new Camera camera;
        public new T renderer;
        public float visualSize = 0.01f;

        protected virtual void Reset()
        {
            camera = FindRenderCamera();
            renderer = GetComponent<T>();
        }

        protected virtual void Awake()
        {
            if (camera == null)
            {
                camera = FindRenderCamera();
            }
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
            UpdateGizmo();
        }

        protected virtual void UpdateGizmo()
        {
            transform.localScale = Vector3.one * CalAdaptiveSize();
        }

        protected virtual float CalAdaptiveSize()
        {
            if (camera)
            {
                var dis = Vector3.Distance(transform.position, camera.transform.position);
                return dis * visualSize;
            }
            return 1.0f;
        }

        protected Camera FindRenderCamera()
        {
            if (Camera.main)
            {
                var gizmoCam = Camera.main.transform.Find(NAME_GIZMO_CAMERA);
                if (gizmoCam)
                {
                    return gizmoCam.GetComponent<Camera>();
                }
                return Camera.main;
            }
            return FindObjectOfType<Camera>();
        }

        public virtual void SetColor(Color color)
        {
            if (renderer)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    return;
                }
#endif
                renderer.material.color = color;
            }
        }
    }
}