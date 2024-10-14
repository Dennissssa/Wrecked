using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ���� TextMeshProUGUI ���
    public TextMeshProUGUI resultText; // ������ʾ����� TextMeshProUGUI ���

    void Start()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.score;

        // �����������½���ı�
        if (ScoreManager.Instance.score > 100)
        {
            resultText.text = "YOU DID IT"; // ��ʾ�ɹ�
        }
        else
        {
            resultText.text = "BRO GOT WRECKED"; // ��ʾʧ��
        }
    }
}