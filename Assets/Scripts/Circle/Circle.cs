using UnityEngine;

public class Circle : MonoBehaviour {
    
    [SerializeField] private float upForce = 1.0f;
    [SerializeField] private float sideForce = 0.1f;
    [SerializeField] private float lifeTime = 5f;

    private Rigidbody rb;
    private Vector3 force;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        force = new Vector3(xForce, yForce, zForce);

        rb.AddForce(force, ForceMode.Impulse);
    }

    private void OnDisable() {
        rb.linearVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        lifeTime = 5f;
    }

    private void FixedUpdate() {
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime <= 0) {
            PoolingSystem.Instance.ReturnToPool(SpawnerManager.Instance.GetCubePrefab(), gameObject);
        }
    }
}
