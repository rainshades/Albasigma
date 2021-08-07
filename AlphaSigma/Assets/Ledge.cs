using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Albasigma.ARPG;

/*
 * CODE FROM: 
 * https://bootcamp.uxdesign.cc/tip-of-the-day-ledge-grab-for-platformers-in-unity-the-easy-way-215e5ddd0a2
 */
public class Ledge : MonoBehaviour
{

    [SerializeField]
    Transform _handPosition, _standPosition;
    [SerializeField]
    float yOffset = 6.5f;

    Vector3 newHandPos;
    public Vector3 NewPos => newHandPos; 

    private void Start()
    {
        newHandPos = new Vector3(_handPosition.position.x, _handPosition.position.y - yOffset, _handPosition.position.z); 
    }

    public Vector3 GetStandUpPos()
    {
        return _standPosition.position; 
    }
}
