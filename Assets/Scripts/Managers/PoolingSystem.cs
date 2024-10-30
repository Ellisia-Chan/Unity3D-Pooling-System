using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour {

    public static PoolingSystem Instance { get; private set; }

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform cubeParent;
    [SerializeField] private int amountToPool = 20;

    private List<GameObject> pooledObjects = new List<GameObject>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        for (int i = 0; i < amountToPool; i++) {
            GameObject obj = Instantiate(cubePrefab, cubeParent);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy) {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
