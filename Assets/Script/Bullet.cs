using UnityEngine;
using UnityEngine.WSA;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 이동속도
    private Rigidbody brb; // 이동에 사용할 리지드바디
    void Start()
    {
        brb = GetComponent<Rigidbody>(); // 게임오브젝트에서 리지드바디 컴포넌트를찾아 할당
        brb.linearVelocity = transform.forward * speed; // 리지드바디의 속도=앞쪽방향*속도

        Destroy(gameObject, 3f); // 3초뒤 자기자신을 파괴
    }

    private void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방오브젝트의 태그가 플레이어일경우
        if (other.tag == "Player")
        {
            // 상대방 오븢게트에서 플레이어 컨트롤러 가져오가
            PlayerController playerController = other.GetComponent<PlayerController>();
            //가져오는데 성공했다면
            if (playerController != null)
            {
                // 가져온 컴포넌트의 다이메서드 실행
                playerController.Die();
            }
        }
    }
}
