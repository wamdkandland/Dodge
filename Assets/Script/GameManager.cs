using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ���ӿ����� Ȱ��ȭ���ؽ�Ʈ
    public GameObject gameovertext;
    //���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text timeText;
    //�ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recodeText;

    //�����ð�
    private float suviveTime;
    //���ӿ��� ����
    private bool isGameover;

    void Start()
    {
        // ���� �ð��� ���ӿ��� ���� �ʱ�ȭ
        suviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        // ���ӿ����� �ƴѵ���
        if (!isGameover)
        {
            // ���� �ð� ����
            suviveTime += Time.deltaTime;
            // ������ ���� �ð��� Ÿ���ؽ�Ʈ ������Ʈ���̿��� ǥ��
            timeText.text = "Time : " + (int)suviveTime;
        }
        else
        {
            // ���ӿ��� ���¿��� r�� ������
            if (Input.GetKeyDown(KeyCode.R))
            {
                // ���ý��� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    // ���� ������ ���ӿ��� ���·� �����ϴ� �޼���
    public void endGame()
    {
        // ���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;
        // ���ӿ��� �ؽ�Ʈ�� Ȱ��ȭ
        gameovertext.SetActive(true);

        // ����ƮŸ�� Ű�� ����� ������ �ְ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        //���������� �ְ� ��Ϻ��� ���� �����ð��� ��ũ�ٸ�
        if (suviveTime > bestTime)
        {
            // �ְ��ϰ��� ���� �����ð����� ����
            bestTime = suviveTime;
            //����� �ְ����� ����ƮŸ������ ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        //�ְ� ����� ���ڵ� �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
        recodeText.text = "BestTime" + (int)bestTime;
    }
}
