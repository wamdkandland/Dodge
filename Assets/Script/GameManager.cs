using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 게임오버시 활성화할텍스트
    public GameObject gameovertext;
    //생존 시간을 표시할 텍스트 컴포넌트
    public Text timeText;
    //최고 기록을 표시할 텍스트 컴포넌트
    public Text recodeText;

    //생존시간
    private float suviveTime;
    //게임오버 상태
    private bool isGameover;

    void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        suviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        // 게임오버가 아닌동안
        if(!isGameover)
        {
            // 생존 시간 갱신
            suviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 타임텍스트 컴포넌트를이용해 표시
            timeText.text = "Time" + (int)suviveTime;
        }
        else
        {
            // 게임오버 상태에서 r을 누를시
            if(Input.GetKeyDown(KeyCode.R))
            {
                // 샘플신을 로드
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void endGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameover = true;
        // 게임오버 텍스트를 활성화
        gameovertext.SetActive(true);
    }
}
