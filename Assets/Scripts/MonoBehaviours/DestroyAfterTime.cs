using UnityEngine;

namespace MonoBehaviours
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField] private float lifetime = 5f;
        
        private float _timer;
        private void FixedUpdate()
        {
            _timer += Time.fixedDeltaTime;
            if (_timer >= lifetime)
            {
                Destroy(gameObject);
            }
        }
    }
}