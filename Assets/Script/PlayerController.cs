using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동속력
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xinput = Input.GetAxis("Horizontal");
        float zinput = Input.GetAxis("Vertical");

        float xSpeed = xinput * speed;
        float zSpeed = zinput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        rb.linearVelocity = newVelocity;
    }

    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 게임매니저 타입의 오브젝트를찾아서 가져오기
        GameManager gamemanager = FindAnyObjectByType<GameManager>();

        // 가져온 게임매니저 오브젝트의 엔드게임 매서드 실행
        gamemanager.endGame();
    }
}
