using UnityEngine;
// Cần thêm thư viện này để thao tác với Scene (Chuyển cảnh)
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Header("UI References")]
    // Biến lưu trữ bảng hướng dẫn để script biết cần ẩn/hiện cái nào
    public GameObject instructionPanel;

    /// <summary>
    /// Hàm này gọi khi bấm nút Play. Nó sẽ chuyển sang màn chơi chính.
    /// </summary>
    public void PlayGame()
    {
        // Tải Scene có Index = 1 (Trong Build Profiles thì Index 1 là Gameplay)
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Hàm này gọi khi bấm nút Instructions.
    /// Kích hoạt (bật) bảng hướng dẫn lên.
    /// </summary>
    public void ShowInstructions()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true); // true = Bật hiển thị
        }
    }

    /// <summary>
    /// Hàm này gọi khi bấm nút Đóng/Back trong bảng hướng dẫn.
    /// Tắt hiển thị bảng hướng dẫn đi.
    /// </summary>
    public void HideInstructions()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false); // false = Ẩn đi
        }
    }
}
