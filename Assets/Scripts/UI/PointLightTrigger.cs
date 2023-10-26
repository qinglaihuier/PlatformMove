
using UnityEngine;

namespace UI
{
    public class PointLightTrigger : MonoBehaviour
    {
        // Start is called before the first frame update
        public void OnClick()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }
    }
}

