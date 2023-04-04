using MonoBehaviours;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class MySceneManager : SingletonMonoBehaviour<MySceneManager>
    {
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}