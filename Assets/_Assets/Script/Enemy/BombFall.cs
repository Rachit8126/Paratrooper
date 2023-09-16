using UnityEngine;

public class BombFall : MonoBehaviour
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject blastEffect;

    private Vector3 moveDirection;

    private void OnEnable()
    {
        moveDirection = targetPosition - transform.position;
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition += moveSpeed * Time.deltaTime * moveDirection;
        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDestructibleByEnemy destructibleByEnemy))
        {
            destructibleByEnemy.Kill();
            AudioManager.Instance.PlayExplosion();
            GameObject blast = Instantiate(blastEffect);
            blast.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
