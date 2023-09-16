using UnityEngine;

public class DestructibleByBullet : MonoBehaviour, IDestructible
{
    [SerializeField] private int scoreValue;

    public void Kill()
    {
        GameManager.Instance.AddScore(scoreValue);
        AudioManager.Instance.PlayExplosion();
        Destroy(gameObject);
    }
}
