using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

namespace Albasigma
{
    public class LockOnCameraController : MonoBehaviour
    {
        [SerializeField]
        GameObject LockOnCenterPoint;
        [SerializeField]
        CinemachineTargetGroup TargetGroup;
        [SerializeField]
        float LockOnRange;
        [SerializeField]
        LayerMask HitLayer;

        [SerializeField]
        CinemachineFreeLook FreeLook;
        [SerializeField]
        CinemachineFreeLook LockOnCamera;

        bool LockedOn = false;
        bool inLockOnRange = false;

        GameObject LockOnTarget; 

        PlayerControls inputs;

        private void Awake()
        {
            inputs = new PlayerControls();
            inputs.Camera.LockOn.performed += LockOn_performed;
        }

        private void LockOn_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (inLockOnRange)
            {
                LockedOn = !LockedOn;
            }
            else
            {
                LockedOn = false; 
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(LockOnCenterPoint.transform.position + new Vector3(0,1), LockOnRange);
        }

        private void Update()
        {
            inLockOnRange = Physics.CheckSphere(LockOnCenterPoint.transform.position + new Vector3(0, 1), LockOnRange, HitLayer);


            if (!inLockOnRange)
            {
                LockOnCamera.gameObject.SetActive(false);
                FreeLook.gameObject.SetActive(true);
                LockedOn = false; 
            }
            else
            {
                LockOnTarget = Physics.OverlapSphere(LockOnCenterPoint.transform.position + new Vector3(0, 1), LockOnRange, HitLayer)[0].gameObject;

                if (LockedOn)
                {
                    LockOnCamera.gameObject.SetActive(true);
                    FreeLook.gameObject.SetActive(false);
                    TargetGroup.m_Targets[2].target = LockOnTarget.transform;
                }
                else
                {
                    LockOnCamera.gameObject.SetActive(false);
                    FreeLook.gameObject.SetActive(true);
                }

            }
        }

        private void OnEnable()
        {
            inputs.Enable(); 
        }

        private void OnDisable()
        {
            inputs.Disable(); 
        }
    }
}