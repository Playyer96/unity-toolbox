using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeS.Toolbox.Cam
{
    public class ResponsiveOrthoCamera : MonoBehaviour
    {
        #region Properties
        [SerializeField] private Camera _camera;
        [SerializeField, Range(0f, 99f)] private float _buffer = 0.5f;
        #endregion

        #region Unity Functions
        private void Awake()
        {
            _camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            var (center, size) = CalculateOrthoSize();

            if (_camera)
            {
                _camera.transform.position = center;
                _camera.orthographicSize = size;
            }
        }
        #endregion

        #region Functions
        private (Vector3 center, float size) CalculateOrthoSize()
        {
            var bounds = new Bounds();

            foreach (var col in FindObjectsOfType<Collider2D>()) bounds.Encapsulate(col.bounds);

            bounds.Expand(_buffer);

            var vertical = bounds.size.y;
            var horizontal = bounds.size.x * _camera.pixelHeight / _camera.pixelWidth;

            var size = Mathf.Max(horizontal, vertical) * 0.5f;
            var center = bounds.center + new Vector3(0, 0, -10);

            return (center, size);
        }
        #endregion
    }
}
