using UnityEngine;
using UnityEngine.SceneManagement;

// Nhóm 09 - 
// Script này để chuyển scene khi bấm nút

public class ChuyenMan : MonoBehaviour
{
    // Chuyển sang màn chơi chính (Level 1)
    public void SangGame()
    {
        // Đặt tên scene đúng trong Build Settings nha
        SceneManager.LoadScene("GameSceneLevel1");
        //Debug.Log("Đã chuyển qua GameSceneLevel1");
    }

    // Về lại menu chính
    public void VeMenu()
    {
        SceneManager.LoadScene("Mainmenu");
        //Debug.Log("Về main menu");
    }

    // Đến màn Game Over
    public void ThuaGame()
    {
        SceneManager.LoadScene("GameOverScene");
        //Debug.Log("Chuyển qua Game Over scene");
    }

    // Thoát luôn game
    public void ThoatGame()
    {
        Application.Quit();
        // Note: Khi chạy trong Unity Editor thì không out được đâu
        Debug.Log("Đã nhấn thoát game (Editor không out)");
    }
}
