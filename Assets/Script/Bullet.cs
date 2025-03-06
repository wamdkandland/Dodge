using UnityEngine;
using UnityEngine.WSA;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // ź�� �̵��ӵ�
    private Rigidbody brb; // �̵��� ����� ������ٵ�
    void Start()
    {
        brb = GetComponent<Rigidbody>(); // ���ӿ�����Ʈ���� ������ٵ� ������Ʈ��ã�� �Ҵ�
        brb.linearVelocity = transform.forward * speed; // ������ٵ��� �ӵ�=���ʹ���*�ӵ�

        Destroy(gameObject, 3f); // 3�ʵ� �ڱ��ڽ��� �ı�
    }

    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ���������Ʈ�� �±װ� �÷��̾��ϰ��
        if (other.tag == "Player")
        {
            // ���� ������Ʈ���� �÷��̾� ��Ʈ�ѷ� ��������
            PlayerController playerController = other.GetComponent<PlayerController>();
            //�������µ� �����ߴٸ�
            if (playerController != null)
            {
                // ������ ������Ʈ�� ���̸޼��� ����
                playerController.Die();
            }
        }
    }
}
