using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour {

    public static PoolingSystem Instance { get; private set; }

    [SerializeField] private List<Pool> pools = new List<Pool>();

    private Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }

        InitializePools();
    }

    private void InitializePools() {
        foreach (Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(pool.parent);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.prefab, objectPool);
        }
    }

    public GameObject SpawnFromPool(GameObject prefab) {
        if (!poolDictionary.ContainsKey(prefab)) {
            Debug.LogWarning($"Pool with prefab {prefab.name} does not exist.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[prefab].Dequeue();

        objectToSpawn.SetActive(true);
        poolDictionary[prefab].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public void ReturnToPool(GameObject prefab, GameObject obj) {
        if (!poolDictionary.ContainsKey(prefab)) return;

        obj.SetActive(false);
        poolDictionary[prefab].Enqueue(obj);
    }
}
