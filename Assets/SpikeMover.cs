using UnityEngine;

// Nhóm 09 
// Script này cho gai lên xuống theo hình sin

public class GayLenXuong : MonoBehaviour
{
    public float khoangCach = 2f; // Độ lệch lên/xuống
    public float tocDoLenXuong = 2f; // Tốc độ di chuyển

    Vector3 viTriBanDau;

    void Start()
    {
        viTriBanDau = transform.position;
        //Debug.Log("Gai bắt đầu ở: " + viTriBanDau);
    }

    void Update()
    {
        // Tính độ lệch theo trục Y
        float lechY = Mathf.Sin(Time.time * tocDoLenXuong) * khoangCach;
        transform.position = viTriBanDau + new Vector3(0, lechY, 0);
        //Debug.Log("Gai đang ở: " + transform.position);
    }
}
