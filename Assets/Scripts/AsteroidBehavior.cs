using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    public float speed = 3f; // Tốc độ rơi của thiên thạch

    void Update()
    {
        // Trôi dạt từ trên xuống dưới (Vector3.down)
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Nếu rớt quá sâu khỏi màn hình (Tọa độ Y < -10) thì tự hủy để nhẹ máy
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
