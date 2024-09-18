#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[ExecuteInEditMode]
public class LevelSet : MonoBehaviour
{
    public GameObject levelPrefab, trigger;
    [SerializeField]
    private int i;
    public string path;

    private void Start()
    {
        //for (i = 1; i < 88; i++)
        //{
        //    DoPrefabChanges();
        //}
    }

    public void DoPrefabChanges()
    {
        path = "Assets/MyAssets/Prefabs/Levels/lv"+i+".prefab";
        levelPrefab = PrefabUtility.LoadPrefabContents(path);

        Transform[] childs = levelPrefab.GetComponentsInChildren<Transform>();

        foreach (Transform tra in childs)
        {
            if (tra.gameObject.name == "Crate push" || tra.gameObject.name == "Crate push (1)")
            {
                tra.gameObject.GetComponent<Rigidbody>().mass = 0.125f;
            }
        }

        //foreach (Transform tra in childs)
        //{
        //    if (tra.gameObject.name == "pCube1 (1)")
        //    {
        //        if(!tra.gameObject.GetComponent<BoxCollider>())
        //            tra.gameObject.AddComponent<BoxCollider>();
        //    }
        //}

        //foreach(Transform tra in childs)
        //{
        //    if (tra.gameObject.CompareTag("Key"))
        //        tra.gameObject.SetActive(false);
        //}


        //foreach (Transform tra in childs)
        //{
        //    if (tra.gameObject.CompareTag("Coin"))
        //    {
        //        foreach (Rotate rot in tra.GetComponents<Rotate>())
        //        {
        //            DestroyImmediate(rot);
        //        }

        //        if (!tra.gameObject.GetComponent<Rotate>())
        //        {
        //            tra.gameObject.AddComponent<Rotate>();
        //            tra.gameObject.GetComponent<Rotate>().axis = new Vector3(0, 1, 0);
        //            tra.gameObject.GetComponent<Rotate>().speed = -150;
        //        }
        //    }
        //}

        //foreach (Transform tra in childs)
        //{
        //    if (tra.gameObject.CompareTag("Coin"))
        //    {
        //        tra.gameObject.AddComponent<Rotate>();
        //        tra.gameObject.GetComponent<Rotate>().axis = new Vector3(0, 1, 0);
        //        tra.gameObject.GetComponent<Rotate>().speed = -150;
        //    }
        //}

        //foreach (Transform tra in childs)
        //{
        //    if (tra.gameObject.name == "Checkpoint " || tra.gameObject.name == "Checkpoint (2)" || tra.gameObject.name == "Checkpoint")
        //    {
        //        tra.GetChild(1).gameObject.SetActive(true);
        //    }
        //}

        //foreach (Transform tra in childs)
        //{
        //    if (tra.gameObject.name == "Trigger" && tra.gameObject.CompareTag("Untagged"))
        //    {
        //        trigger = tra.gameObject;
        //        break;
        //    }
        //}

        //foreach(BoxCollider boxCo in trigger.GetComponents<BoxCollider>())
        //{
        //    if(boxCo.isTrigger == false)
        //    {
        //        DestroyImmediate(boxCo);
        //    }
        //}

        //foreach (Finish finish in trigger.GetComponents<Finish>())
        //{
        //    DestroyImmediate(finish);
        //}

        //trigger.AddComponent<Rigidbody>();
        //trigger.GetComponent<Rigidbody>().isKinematic = true;
        //trigger.AddComponent<Finish>();

        //BoxCollider boxCol = trigger.GetComponent<BoxCollider>();
        //boxCol.center = new Vector3(0, 2.227742f, 0.4794549f);
        //boxCol.size = new Vector3(1.8f, 5.455486f, 0.507521f);

        //BoxCollider boxColl = trigger.AddComponent<BoxCollider>();
        //boxColl.center = new Vector3(0, 2, 2);
        //boxColl.size = new Vector3(2, 2, 1);



        PrefabUtility.SaveAsPrefabAsset(levelPrefab, path);
        EditorUtility.SetDirty(levelPrefab);
        //EditorSceneManager.MarkSceneDirty(gameObject.scene);
    }
}
#endif

