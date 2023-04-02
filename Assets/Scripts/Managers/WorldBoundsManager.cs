using UnityEngine;

namespace Managers
{
    public class WorldBoundsManager : MonoBehaviour
    {
        public static WorldBoundsManager Instance;

        [SerializeField] private float xMin;
        [SerializeField] private float xMax;
        [SerializeField] private float yMin;
        [SerializeField] private float yMax;
        
        public float XMin => xMin;
        public float XMax => xMax;
        public float YMin => yMin;
        public float YMax => yMax;

        private void Awake()
        {
            if (Instance)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(xMax, yMin, 0), new Vector3(xMax, yMax, 0));
            Gizmos.DrawLine(new Vector3(xMin, yMin, 0), new Vector3(xMin, yMax, 0));
            Gizmos.DrawLine(new Vector3(xMin, yMax, 0), new Vector3(xMax, yMax, 0));
            Gizmos.DrawLine(new Vector3(xMin, yMin, 0), new Vector3(xMax, yMin, 0));
        }
    }
}