using UnityEngine;
using TMPro; // ��Ӷ� TextMesh Pro ������
using UnityEngine.SceneManagement; // ���ڳ�������

public class CannonController : MonoBehaviour
{
    public GameObject cannonballPrefab;    // �ڵ� Prefab
    public Transform firePoint;             // �ڿ�λ��
    public float launchForce = 500f;        // ��������
    public float rotationSpeed = 100f;      // ת���ٶ�

    public TMP_Text ammoCountText;          // ��ʾ��ҩ������ TextMesh Pro �ı�

    private int ammoCount = 10;             // ��ʼ��ҩ����
    private bool isCountingDown = false;    // �Ƿ����ڵ���ʱ

    void Update()
    {
        HandleRotation();                   // �����ڹ�ת��
        if (Input.GetKeyDown(KeyCode.Space) && ammoCount > 0)
        {
            FireCannonball();               // �����ڵ�
        }

        UpdateAmmoCountText();             // ���µ�ҩ������ʾ

        // ��鵯ҩ�����Ƿ�Ϊ��
        if (ammoCount <= 0 && !isCountingDown)
        {
            isCountingDown = true;
            StartCoroutine(CountdownAndSwitchScene());
        }
    }

    void HandleRotation()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // ��ȡˮƽ����
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        // ֱ�Ӹ����ڿڵ���ת�Ƕȣ�������
        firePoint.Rotate(0, rotationAmount, 0);
    }

    void FireCannonball()
    {
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = cannonball.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * launchForce);

        ammoCount--;                         // �������ٵ�ҩ����
    }

    void UpdateAmmoCountText()
    {
        ammoCountText.text = "Ammo: " + ammoCount; // ���� UI �ı�
    }

    private System.Collections.IEnumerator CountdownAndSwitchScene()
    {
        yield return new WaitForSeconds(5f); // ��ʱ 5 ��

        // �洢������������һ�� scoreManager ������
        PlayerPrefs.SetInt("FinalScore", 0); // ��������Ը�����Ҫ���÷���
        PlayerPrefs.Save();

        // �л�����
        SceneManager.LoadScene("NewScene"); // �滻Ϊ�³���������
    }
}