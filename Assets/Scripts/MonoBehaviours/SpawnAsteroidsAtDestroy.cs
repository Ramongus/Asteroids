using Enums;
using Factories;
using UnityEngine;

namespace MonoBehaviours
{
    public class SpawnAsteroidsAtDestroy : MonoBehaviour
    {
        [SerializeField] private int count = 2;
        [SerializeField] private AsteroidsSize size;
        private void OnDestroy()
        {
            for (int i = 0; i < count; i++)
            {
                var asteroid = AsteroidsFactory.Instance.CreateAsteroid(size);
                asteroid.transform.position = transform.position;
            }
        }
    }
}