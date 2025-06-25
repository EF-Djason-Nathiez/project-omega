using UnityEngine;

namespace Utilities
{

    public static class Transform
    {
        public static void NullifyY(this UnityEngine.Transform transform)
        {
            if (transform == null)
            {
                Debug.LogWarning("Transform is null, cannot nullify Y position.");
                return;
            }

            Vector3 position = transform.position;
            position.y = 0f; // Set Y position to 0
            transform.position = position;
        }

        public static void NullifyX(this UnityEngine.Transform transform)
        {
            if (transform == null)
            {
                Debug.LogWarning("Transform is null, cannot nullify X position.");
                return;
            }

            Vector3 position = transform.position;
            position.x = 0f; // Set X position to 0
            transform.position = position;
        }

        public static void NullifyZ(this UnityEngine.Transform transform)
        {
            if (transform == null)
            {
                Debug.LogWarning("Transform is null, cannot nullify Z position.");
                return;
            }

            Vector3 position = transform.position;
            position.z = 0f; // Set Z position to 0
            transform.position = position;
        }

        
        

    }
}
