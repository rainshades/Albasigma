using UnityEngine;

namespace Albasigma.ARPG
{
    public interface IThreshHold
    {
        public void ActivateThreshhold();
    }

    public class BoxTransitionThreshHold : MonoBehaviour, IThreshHold
    {
        public void ActivateThreshhold()
        {
            if (!GameManager.Instance.BoxTransitionAnimation.gameObject.activeSelf)
            {
                GameManager.Instance.BoxTransitionAnimation.Play(); 
            }
            else
            {
                GameManager.Instance.BoxTransitionAnimation.gameObject.SetActive(true); 
            }
        }
    }
}