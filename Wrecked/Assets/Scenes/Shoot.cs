using UnityEngine;
using TMPro; // 添加对 TextMesh Pro 的引用
using UnityEngine.SceneManagement; // 用于场景管理

public class CannonController : MonoBehaviour
{
    public GameObject cannonballPrefab;    // 炮弹 Prefab
    public Transform firePoint;             // 炮口位置
    public float launchForce = 500f;        // 发射力度
    public float rotationSpeed = 100f;      // 转向速度

    public TMP_Text ammoCountText;          // 显示弹药数量的 TextMesh Pro 文本

    private int ammoCount = 10;             // 初始弹药数量
    private bool isCountingDown = false;    // 是否正在倒计时

    void Update()
    {
        HandleRotation();                   // 处理炮管转向
        if (Input.GetKeyDown(KeyCode.Space) && ammoCount > 0)
        {
            FireCannonball();               // 发射炮弹
        }

        UpdateAmmoCountText();             // 更新弹药计数显示

        // 检查弹药数量是否为零
        if (ammoCount <= 0 && !isCountingDown)
        {
            isCountingDown = true;
            StartCoroutine(CountdownAndSwitchScene());
        }
    }

    void HandleRotation()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 获取水平输入
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        // 直接更新炮口的旋转角度，无限制
        firePoint.Rotate(0, rotationAmount, 0);
    }

    void FireCannonball()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * launchForce);

        ammoCount--;                         // 发射后减少弹药数量
    }

    void UpdateAmmoCountText()
    {
        ammoCountText.text = "Ammo: " + ammoCount; // 更新 UI 文本
    }

    private System.Collections.IEnumerator CountdownAndSwitchScene()
    {
        yield return new WaitForSeconds(5f); // 计时 5 秒

        // 存储分数（假设有一个 scoreManager 变量）
        PlayerPrefs.SetInt("FinalScore", 0); // 这里你可以根据需要设置分数
        PlayerPrefs.Save();

        // 切换场景
        SceneManager.LoadScene("NewScene"); // 替换为新场景的名称
    }
}