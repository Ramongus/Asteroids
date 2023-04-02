using Managers;
using UnityEngine;

namespace MonoBehaviours
{
    public class WrapAroundWorldBounds : MonoBehaviour
    {
        private void Update()
        {
            var position = transform.position;
            if (position.x > WorldBoundsManager.Instance.XMax)
            {
                position.x = WorldBoundsManager.Instance.XMin;
            }
            else if (position.x < WorldBoundsManager.Instance.XMin)
            {
                position.x = WorldBoundsManager.Instance.XMax;
            }
            if (position.y > WorldBoundsManager.Instance.YMax)
            {
                position.y = WorldBoundsManager.Instance.YMin;
            }
            else if (position.y < WorldBoundsManager.Instance.YMin)
            {
                position.y = WorldBoundsManager.Instance.YMax;
            }
            transform.position = position;
        }
    }
}