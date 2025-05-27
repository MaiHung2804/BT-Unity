using UnityEngine;
using TMPro; // Sử dụng TMPro thay vì UnityEngine.UI nếu dùng TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Thay Text bằng TextMeshProUGUI
    private int score = 0;

    void Start()
    {
        UpdateText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateText();
    }

    void UpdateText()
    {
        if (scoreText != null) // Kiểm tra null để tránh lỗi
            scoreText.text = "Score: " + score.ToString();
    }
}