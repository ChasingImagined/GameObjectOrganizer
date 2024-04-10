using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameObjOrganizer;



[CustomEditor(typeof(GameobjectOrganizer))]
public class GameObjectOrganizerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameobjectOrganizer organizer = (GameobjectOrganizer)target;

       
        if (GUILayout.Button("Organizeing"))
        {
            if(Application.isPlaying)
            {
                Debug.LogWarning("The organizing tool cannot be used while the game is running....");
            }
            else Organizing(organizer);
        }
    }



    public void Organizing(GameobjectOrganizer Organiztor)
    {

        if (Organiztor.parentAndChildList.Count != 0)
        {

            GameObject[] allObj = SceneManager.GetActiveScene().GetRootGameObjects();

            foreach (GameObject obj in allObj)
            {


                foreach (ParentAndChild p_c in Organiztor.parentAndChildList)
                {
                    if (ControlPrefab(p_c.childPrefab, obj))
                    {

                        obj.transform.parent = p_c.parentTransform;
                        break;
                    }
                }


            }
        }


    }




    public bool ControlPrefab(GameObject prefab, GameObject obj)
    {
        PrefabAssetType assetType = PrefabUtility.GetPrefabAssetType(obj);
        if (assetType == PrefabAssetType.Regular || assetType == PrefabAssetType.Variant)
        {
            GameObject prefabRoot = PrefabUtility.GetCorrespondingObjectFromSource(obj);

            if (prefabRoot != null)
            {
                if (prefab == prefabRoot) { return true; }
            }
            else
            {
                Debug.LogWarning("Source prefab not found for " + obj.name);

            }
        }



        return false;
    }
}
