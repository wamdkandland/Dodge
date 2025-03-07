using UnityEditor.Timeline;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{    
    public GameObject bulletPrefab; // 생성할 탄알의 원본프리팹
    public float spawnRateMin = 0.5f; // 최소 생성주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난시간

    void Start()
    {
        timeAfterSpawn = 0f; //최근 생성이후의 누적시간을 0으로 초기화
        // 탄알생성간격을 민과 맥스사이에 랜덤지정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax); 
        // 플레이어 컨트롤러 컴포넌트를가진 게임오브젝트를 찾아 조준대상으로 설정
        target = FindAnyObjectByType<PlayerController>().transform;
    }

    void Update()
    {
        // 시간갱신
        timeAfterSpawn += Time.deltaTime;

        // 최근 생성 시점에서 누적된 시간이 생성시간보다 크거나 같다면
        if(timeAfterSpawn >= spawnRate)
        {
            // 누적된 시간초기화
            timeAfterSpawn = 0f;
            // 총알복제본을 내위치와 회전값으로 설정후 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //총알 오브젝트가 타겟을 바라보게 설정
            bullet.transform.LookAt(target);
            // 다음 생성 간격을 민과 맥스사이 랜덤으로 설정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
