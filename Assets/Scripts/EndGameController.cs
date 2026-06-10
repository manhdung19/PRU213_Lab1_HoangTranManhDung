using UnityEngine;
using TMPro; // Xài UI
using UnityEngine.SceneManagement; // Xài chuyển cảnh

public class EndGameController : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // Khi màn hình vừa mở lên, lấy điểm từ bộ nhớ (chìa khóa "FinalScore") ra để hiển thị
        // Nếu không tìm thấy thì mặc định là 0
        int score = PlayerPrefs.GetInt("FinalScore", 0);
        finalScoreText.text = "Final Score: " + score;
    }

    /// <summary>
    /// Quay lại Menu chính
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadScene(0); // Index 0 là MainMenu
    }

    /// <summary>
    /// Thoát khỏi game hoàn toàn
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Game đã thoát!"); // In ra console để biết nút có hoạt động trong Editor không
        Application.Quit(); // Lệnh này chỉ tắt game khi đã Build ra file .exe
    }
}
