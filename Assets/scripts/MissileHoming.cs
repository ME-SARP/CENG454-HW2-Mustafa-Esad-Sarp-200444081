using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float turnSpeed = 5f;
    
    [Header("Task 3.2 & 3.3 Assets")]
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private AudioClip launchSound;
    [SerializeField] private AudioClip explosionSound;

    private Transform target;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();

        if (launchSound != null)
        {
            audioSource.PlayOneShot(launchSound);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null) return;

        
        Vector3 direction = target.position - transform.position;
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            AircraftHealth health = collision.gameObject.GetComponent<AircraftHealth>();
            if (health != null)
            {
                health.TakeDamage(25f); 
            }

            
            if (explosionPrefab != null)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            }

            if (explosionSound != null)
            {
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            }

            Destroy(gameObject);
        }
    }
}