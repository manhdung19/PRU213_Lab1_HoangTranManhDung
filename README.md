# TÀI LIỆU DỰ ÁN LAB 1: SPACE EXPLORER

**Sinh viên thực hiện:** Hoang Tran Manh Dung (Điền mã số SV vào đây)
**Môn học:** PRU213
**Dự án:** 2D Unity Game - Space Explorer

## I. Tổng quan dự án (Game Concept)
Người chơi điều khiển một phi thuyền trong không gian 2D, mục tiêu là thu thập các ngôi sao rơi xuống để ghi điểm, đồng thời phải bắn tia laser hoặc né tránh các thiên thạch. Trò chơi kết thúc (Game Over) nếu phi thuyền va chạm với thiên thạch.

## II. Danh sách Scenes (Quản lý luồng chơi)
1. **`MainMenu` (Index 0):** Giao diện màn hình chính. 
   - Nút **Play**: Chuyển sang màn hình chơi game.
   - Nút **Instructions**: Hiển thị bảng hướng dẫn cách chơi (Dùng mũi tên di chuyển, Space để bắn).
2. **`Gameplay` (Index 1):** Màn hình chơi chính. Quản lý việc sinh quái ngẫu nhiên, hệ thống điểm số và xét va chạm.
3. **`EndGame` (Index 2):** Màn hình kết thúc. Hiển thị tổng điểm cuối cùng (Final Score) thông qua `PlayerPrefs`. Cung cấp tuỳ chọn quay lại Menu hoặc Thoát game.

## III. Danh sách Đối tượng (Prefabs)
1. **`Spaceship` (Player):** Được gắn `Rigidbody2D` (trọng lực = 0) và `PolygonCollider2D`.
2. **`Laser`:** Tia đạn do người chơi bắn ra. Cài đặt `CapsuleCollider2D` (Is Trigger) để xét va chạm phá hủy thiên thạch.
3. **`Asteroid`:** Thiên thạch kẻ thù. Di chuyển từ trên xuống, gắn `CircleCollider2D` (Is Trigger). Đụng vào phi thuyền sẽ gây Game Over.
4. **`Star`:** Ngôi sao điểm thưởng. Rơi từ trên xuống, gắn `CircleCollider2D` (Is Trigger). Đụng vào phi thuyền sẽ được cộng 10 điểm.

## IV. Danh sách Mã nguồn (Scripts)
Tất cả các file C# đều đã được comment chi tiết theo đúng tiêu chí chấm điểm Tài liệu (30 points).
1. **`SceneController.cs`**: Xử lý logic chuyển từ Menu sang Gameplay, bật/tắt bảng hướng dẫn.
2. **`PlayerController.cs`**: 
   - Nhận input phím mũi tên/WASD để di chuyển phi thuyền.
   - Giới hạn (Clamp) toạ độ không cho phi thuyền ra khỏi màn hình.
   - `Instantiate` tia laser khi nhấn phím Space.
   - Xử lý va chạm `OnTriggerEnter2D`: Chuyển scene khi đụng Asteroid, cộng điểm khi đụng Star.
3. **`LaserBehavior.cs`**: Điều khiển tia laser bay thẳng lên trên theo trục Y, xét va chạm để phá hủy thiên thạch, và tự hủy sau 3 giây.
4. **`AsteroidBehavior.cs` / `StarBehavior.cs`**: Di chuyển vật thể rơi thẳng xuống dưới. Tự hủy khi toạ độ Y vượt quá mép dưới màn hình (Y < -10) để giải phóng bộ nhớ.
5. **`SpawnManager.cs`**: Sử dụng `InvokeRepeating` và `Random.Range` để sinh ngẫu nhiên thiên thạch và ngôi sao một cách liên tục ở mép trên màn hình.
6. **`GameManager.cs`**: Áp dụng mẫu thiết kế **Singleton** để quản lý game tập trung. Cung cấp hàm cộng điểm, cập nhật lên giao diện Text và lưu điểm vào `PlayerPrefs` trước khi chết.
7. **`EndGameController.cs`**: Đọc điểm từ `PlayerPrefs` hiển thị lên UI Text. Xử lý logic cho nút Main Menu (`SceneManager.LoadScene`) và nút Quit (`Application.Quit()`).
