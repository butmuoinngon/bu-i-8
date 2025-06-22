using UnityEngine;

// Code by nhóm 9, debug xong rồi
public class NhinKhoangCach : MonoBehaviour
{
    public MoveForward chuongNgaiVat;

    // Cái này để đổi hướng khi ra khỏi mặt đất
    private void OnTriggerExit2D(Collider2D vaCham)
    {
        // Nếu va chạm với Ground thì đảo hướng
        if (vaCham.gameObject.tag == "Ground")
        {
            chuongNgaiVat.Flip();
        }
        // Có thể thêm log test ở đây
        // Debug.Log("Đã rời khỏi Ground");
    }
}
