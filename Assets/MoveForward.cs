using UnityEngine;

// Nhóm 09 - 
// Script cho vật cản tự di chuyển qua lại

public class DiChuyenTuDong : MonoBehaviour
{
    public float tocDo = 2f;
    Rigidbody2D rb;

    void Start()
    {
        // Lấy Rigidbody2D (nếu chưa có báo lỗi)
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log("Đã lấy Rigidbody2D");
    }

    void FixedUpdate()
    {
        // Cho vật cản chạy theo hướng đang nhìn
        rb.linearVelocity = new Vector2(transform.localScale.x * tocDo, rb.linearVelocity.y);
        //Debug.Log("Vật cản di chuyển: " + rb.linearVelocity);
    }

    // Hàm đảo hướng khi ra khỏi mép
    public void DaoHuong()
    {
        Vector3 scaleMoi = transform.localScale;
        scaleMoi.x = scaleMoi.x * -1;
        transform.localScale = scaleMoi;
        //Debug.Log("Đã đổi hướng vật cản");
    }
}
