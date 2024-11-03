using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {

    public static SpawnerManager Instance;

    [SerializeField] private List<PrefabData> objectPrefabs = new List<PrefabData>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        foreach (PrefabData obj in objectPrefabs) {
            PoolingSystem.Instance.SpawnFromPool(obj.prefab);
        }
    }

    private GameObject GetPrefab(string name) {
        foreach (PrefabData obj in objectPrefabs) {
            if (obj.name == name) {
                return obj.prefab;
            }
        }
        return null;
    }
    
    public GameObject GetCubePrefab() {
        return GetPrefab("Cube");
    }

    public GameObject GetCirclePrefab() {
        return GetPrefab("Circle");
    }
}