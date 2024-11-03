using UnityEngine;

[System.Serializable]
public class Pool {
    public GameObject prefab;
    public int size;
    public Transform parent;

     public Pool(GameObject prefab, int size, Transform parent) {
        this.prefab = prefab;
        this.size = size;
        this.parent = parent;
    }
}

