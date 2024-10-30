using UnityEngine;

public class CubeSpawnerManager : MonoBehaviour {
    public static CubeSpawnerManager Instance;

    [SerializeField] private Transform spawnPosition;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        GameObject cube = PoolingSystem.Instance.GetPooledObject();

        if (cube != null) {
            cube.transform.position = spawnPosition.position;
            cube.SetActive(true);
        }
    }
}
