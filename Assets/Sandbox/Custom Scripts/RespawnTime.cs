using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RespawnTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Respawn), 30, 30);
    }

    private void Respawn()
    {
        Destroy(this.gameObject);

        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Sandbox/Prefabs/Destructables.prefab");
        var instance = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
        
        PrefabUtility.UnpackPrefabInstance(instance, PrefabUnpackMode.Completely, InteractionMode.AutomatedAction);
    }
}
