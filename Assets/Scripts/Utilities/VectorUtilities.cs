using UnityEngine;

namespace Utilities
{
    public class VectorUtilities
    { 
        //Return a normalized vector with a 2D random direction
        public static Vector3 RandomDirection2D()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        }
    }
}