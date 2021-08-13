using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG
{
    /// <summary>
    /// Key items are used as quest material to turn in
    /// </summary>
    [CreateAssetMenu(fileName = "Item", menuName = "Key Item")]
    public class KeyItem : ScriptableObject
    {
        public new string name;
        public string description; 
    }
}