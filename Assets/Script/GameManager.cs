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
        if(!isGameover)
        {
            // ���� �ð� ����
            suviveTime += Time.deltaTime;
            // ������ ���� �ð��� Ÿ���ؽ�Ʈ ������Ʈ���̿��� ǥ��
            timeText.text = "Time" + (int)suviveTime;
        }
        else
        {
            // ���ӿ��� ���¿��� r�� ������
            if(Input.GetKeyDown(KeyCode.R))
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
    }
}
