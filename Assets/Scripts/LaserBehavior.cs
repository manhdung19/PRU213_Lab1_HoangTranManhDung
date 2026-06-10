using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    [Header("Laser Settings")]
    public float speed = 10f; // Tốc độ bay của laser
    public float lifetime = 3f; // Thời gian sống trước khi tự biến mất

    void Start()
    {
        // Tự động hủy tia laser sau 3 giây để không bị rác bộ nhớ game
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Di chuyển tia laser thẳng lên trên (Vector3.up tương đương trục Y)
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    /// <summary>
    /// Hàm xử lý va chạm của tia laser
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem vật laser vừa chạm vào có phải là Thiên thạch không
        if (other.CompareTag("Asteroid"))
        {
            // (Tuỳ chọn) Cộng thêm 5 điểm cho người chơi vì bắn trúng đích
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(5);
            }

            // Phá hủy thiên thạch
            Destroy(other.gameObject);

            // Phá hủy luôn tia laser (vì đạn trúng đích thì nổ)
            Destroy(gameObject);
        }
    }

}
