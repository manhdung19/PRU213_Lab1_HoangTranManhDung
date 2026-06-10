using UnityEngine;
using TMPro; // Thư viện để xài UI TextMeshPro

public class GameManager : MonoBehaviour
{
    // Singleton pattern: Giúp truy cập GameManager từ bất kỳ script nào khác dễ dàng
    public static GameManager Instance;

    [Header("Điểm số")]
    public int score = 0;
    public TextMeshProUGUI scoreText; // Biến chứa cái UI Text hiển thị điểm

    void Awake()
    {
        // Thiết lập Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Hàm cộng điểm, sẽ được gọi khi phi thuyền ăn sao
    /// </summary>
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "Score: " + score; // Cập nhật chữ trên màn hình
    }
}
