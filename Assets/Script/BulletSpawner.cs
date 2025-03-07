using UnityEditor.Timeline;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{    
    public GameObject bulletPrefab; // ������ ź���� ����������
    public float spawnRateMin = 0.5f; // �ּ� �����ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target; // �߻��� ���
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� �����ð�

    void Start()
    {
        timeAfterSpawn = 0f; //�ֱ� ���������� �����ð��� 0���� �ʱ�ȭ
        // ź�˻��������� �ΰ� �ƽ����̿� ��������
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); 
        // �÷��̾� ��Ʈ�ѷ� ������Ʈ������ ���ӿ�����Ʈ�� ã�� ���ش������ ����
        target = FindAnyObjectByType<PlayerController>().transform;
    }

    void Update()
    {
        // �ð�����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� �������� ������ �ð��� �����ð����� ũ�ų� ���ٸ�
        if(timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��ʱ�ȭ
            timeAfterSpawn = 0f;
            // �Ѿ˺������� ����ġ�� ȸ�������� ������ ����
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //�Ѿ� ������Ʈ�� Ÿ���� �ٶ󺸰� ����
            bullet.transform.LookAt(target);
            // ���� ���� ������ �ΰ� �ƽ����� �������� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
