using UnityEngine;

public class Cube : MonoBehaviour {

    [SerializeField] private float upForce = 1.0f;
    [SerializeField] private float sideForce = 0.1f;
    [SerializeField] private float lifeTime = 10f;

    private Rigidbody rb;
    private Vector3 force;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        rb.linearVelocity = Vector3.zero;

        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce / 2f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);

        force = new Vector3(xForce, yForce, zForce);

        rb.AddForce(force, ForceMode.Impulse);
    }

    private void FixedUpdate() {
        lifeTime -= Time.fixedDeltaTime;
        if (lifeTime <= 0) {
            lifeTime = 10f;
            gameObject.SetActive(false);
        }
    }
}
