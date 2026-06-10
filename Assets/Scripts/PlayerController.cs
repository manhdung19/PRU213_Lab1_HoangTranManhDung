using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    // Tốc độ di chuyển của phi thuyền, có thể chỉnh sửa trực tiếp bên ngoài Unity
    public float moveSpeed = 5f;

    // Biến chứa mẫu tia Laser để bắn ra
    public GameObject laserPrefab;

    /// <summary>
    /// Hàm Update được Unity gọi liên tục mỗi khung hình (frame).
    /// Rất thích hợp để kiểm tra người chơi có bấm phím hay không.
    /// </summary>
    void Update()
    {
        // 1. Lấy giá trị trục ngang (Bấm mũi tên Trái/Phải hoặc A/D sẽ trả về -1 đến 1)
        float horizontalInput = Input.GetAxis("Horizontal");

        // 2. Lấy giá trị trục dọc (Bấm mũi tên Lên/Xuống hoặc W/S sẽ trả về -1 đến 1)
        float verticalInput = Input.GetAxis("Vertical");

        // 3. Tạo hướng di chuyển tổng hợp trong không gian 2D (trục X và Y)
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        // 4. Di chuyển phi thuyền bằng cách dời vị trí (Translate)
        // Công thức: Hướng * Tốc độ * Thời gian của 1 frame (Time.deltaTime)
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // MỚI THÊM: Ép toạ độ X và Y không được vượt qua giới hạn của màn hình
        // Giả sử mép màn hình của bạn có toạ độ X từ -8.5 đến 8.5, Y từ -4.5 đến 4.5
        float clampedX = Mathf.Clamp(transform.position.x, -11.5f, 11.5f);
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        // Gán lại vị trí mới sau khi đã bị "kẹp"
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

        // Kiểm tra nếu người chơi nhấn phím Space (Phím cách)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Tính toán vị trí sinh ra tia laser (nằm cao hơn phi thuyền một chút)
            Vector3 spawnPosition = transform.position + new Vector3(0f, 0.5f, 0f);

            // Lệnh Instantiate dùng để tạo (nhân bản) đối tượng ra ngoài màn chơi
            Instantiate(laserPrefab, spawnPosition, Quaternion.identity);
        }
    }
    /// <summary>
    /// Hàm này tự động chạy khi Phi thuyền chạm vào bất kỳ vật thể nào có đánh dấu Is Trigger
    /// </summary>
    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Kiểm tra nếu vật vừa chạm vào có Tag là "Star"
        if (other.CompareTag("Star"))
        {
            // Gọi GameManager cộng 10 điểm
            GameManager.Instance.AddScore(10);

            // Phá hủy ngôi sao đó đi (tạo cảm giác "ăn" sao)
            Destroy(other.gameObject);
        }
        // 2. Kiểm tra nếu vật vừa chạm vào có Tag là "Asteroid"
        else if (other.CompareTag("Asteroid"))
        {
            // Lệnh này lưu điểm số hiện tại vào bộ nhớ máy tính với tên chìa khóa là "FinalScore"
            PlayerPrefs.SetInt("FinalScore", GameManager.Instance.score);
            // Chuyển sang scene EndGame
            SceneManager.LoadScene(2);
        }
    }
}
