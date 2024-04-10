using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameObjOrganizer;

public class GameobjectOrganizer : MonoBehaviour
{

    public List<ParentAndChild> parentAndChildList = new List<ParentAndChild>();


}
namespace GameObjOrganizer
{
    [System.Serializable]
    public struct ParentAndChild
    {
        public Transform parentTransform;
        public GameObject childPrefab;
    }
} 

