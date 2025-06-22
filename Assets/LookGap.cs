using UnityEngine;

// Code nhóm 09 
// Class này để xử lý khi vật cản chạy ra khỏi mặt đất thì đảo chiều

public class NhinKhoangTrong : MonoBehaviour
{
    public MoveForward vatCanDiChuyen; // Đối tượng vật cản trên map

    // Khi rời khỏi collider có tag "Ground" thì đổi hướng vật cản
    private void OnTriggerExit2D(Collider2D col)
    {
        // Nếu là mặt đất thì gọi hàm đổi hướng bên MoveForward
        if (col.tag == "Ground") // dùng .tag cho đời thường
        {
            vatCanDiChuyen.Flip();
            //Debug.Log("Vật cản đã ra khỏi Ground và đảo hướng");
        }
        // else để đây lỡ sau có thêm chức năng khác
    }
}
