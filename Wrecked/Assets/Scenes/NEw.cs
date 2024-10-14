using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 拖入 TextMeshProUGUI 组件
    public TextMeshProUGUI resultText; // 拖入显示结果的 TextMeshProUGUI 组件

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.score;

        // 检测分数并更新结果文本
        if (ScoreManager.Instance.score > 100)
        {
            resultText.text = "YOU DID IT"; // 显示成功
        }
        else
        {
            resultText.text = "BRO GOT WRECKED"; // 显示失败
        }
    }
}