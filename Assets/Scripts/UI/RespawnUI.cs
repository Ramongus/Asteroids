using TMPro;
using UnityEngine;

namespace UI
{
    public class RespawnUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text label;
        
        public void UpdateLabel(string text)
        {
            label.text = text;
        }

        public void Enable()
        {
            label.gameObject.SetActive(true);
        }
        
        public void Disable()
        {
            label.gameObject.SetActive(false);
        }
    }
}