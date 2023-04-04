using UnityEditor.Callbacks;
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
        public Vector3 RandomWorldEdgePosition()
        {
            switch (Random.Range(0,4))
            {
                case 0:
                {
                    return new Vector3(xMin, Random.Range(yMin, yMax), 0);
                }
                case 1:
                {
                    return new Vector3(xMax, Random.Range(yMin, yMax), 0);
                }
                case 2:
                {
                    return new Vector3(Random.Range(xMin, xMax), yMin, 0);
                }
                case 3:
                {
                    return new Vector3(Random.Range(xMin, xMax), yMax, 0);
                }
                default:
                {
                    return Vector3.zero;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector3(xMax, yMin, 0), new Vector3(xMax, yMax, 0));
            Gizmos.DrawLine(new Vector3(xMin, yMin, 0), new Vector3(xMin, yMax, 0));
            Gizmos.DrawLine(new Vector3(xMin, yMax, 0), new Vector3(xMax, yMax, 0));
            Gizmos.DrawLine(new Vector3(xMin, yMin, 0), new Vector3(xMax, yMin, 0));
        }
    }
}