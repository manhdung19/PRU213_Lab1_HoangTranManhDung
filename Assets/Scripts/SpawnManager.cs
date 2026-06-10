using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Các đối tượng cần tạo")]
    public GameObject asteroidPrefab; // Kéo thả prefab Thiên thạch vào đây
    public GameObject starPrefab;     // Kéo thả prefab Ngôi sao vào đây

    [Header("Cài đặt vị trí")]
    public float spawnLimitX = 8f; // Giới hạn mép trái/phải màn hình (Từ -8 đến 8)
    public float spawnPosY = 7f;   // Vị trí trục Y (Nằm tuốt trên cùng màn hình)

    [Header("Thời gian xuất hiện")]
    public float startDelay = 1f;           // Chờ 1 giây trước khi thả đợt đầu tiên
    public float asteroidSpawnInterval = 1.5f; // Cứ 1.5 giây rớt 1 thiên thạch
    public float starSpawnInterval = 3f;       // Cứ 3 giây rớt 1 ngôi sao

    void Start()
    {
        // Lệnh InvokeRepeating: Gọi hàm ("Tên Hàm", Chờ bao lâu mới bắt đầu, Khoảng cách giữa các lần gọi)
        InvokeRepeating("SpawnAsteroid", startDelay, asteroidSpawnInterval);

        // Ngôi sao thì rớt chậm hơn một chút
        InvokeRepeating("SpawnStar", startDelay + 1f, starSpawnInterval);
    }

    /// <summary>
    /// Hàm sinh ra thiên thạch ở vị trí ngẫu nhiên
    /// </summary>
    void SpawnAsteroid()
    {
        // Random.Range(-8f, 8f) sẽ chọn ngẫu nhiên một tọa độ X trên màn hình
        Vector3 spawnPos = new Vector3(Random.Range(-spawnLimitX, spawnLimitX), spawnPosY, 0);
        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }

    /// <summary>
    /// Hàm sinh ra ngôi sao ở vị trí ngẫu nhiên
    /// </summary>
    void SpawnStar()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnLimitX, spawnLimitX), spawnPosY, 0);
        Instantiate(starPrefab, spawnPos, Quaternion.identity);
    }
}
