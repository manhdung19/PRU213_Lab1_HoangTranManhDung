using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    public float speed = 2f; // Sao thường trôi chậm hơn thiên thạch 1 chút

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
