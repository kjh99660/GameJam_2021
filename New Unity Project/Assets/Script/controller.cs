using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private int CoolDown;
    [SerializeField] private int JumpFrame;
    [SerializeField] private GameObject LeftJumpImage;
    [SerializeField] private GameObject RightJumpImage;
    [SerializeField] private GameObject NormalImage;
    public GameObject Panel;

    BoxCollider2D Bc;
    bool Jumping = false;
    int JumpedFrame = 0;
    int CoolDownFrame = 5;

    // Start is called before the first frame update
    void Start()
    {
        Bc = gameObject.GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.CompareTag("Wave"))
        {
            Debug.Log("파도와 충돌함");
        }
        if (o.gameObject.CompareTag("Land"))
        {
            Panel.SetActive(true);
            Time.timeScale = 0;

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wave"))
        {
            Vector3 WavePosition = collision.gameObject.transform.position;
            Vector3 ObjectPosition = Bc.gameObject.transform.position;
            Vector3 Component = (ObjectPosition - WavePosition);
            Component.Normalize();
            transform.Translate(Component * Time.deltaTime * collision.gameObject.GetComponent<Wave>().WaveSpeed * Speed * 4f);
        }
    }

    private void LeftJump()
    {
        // 점프 구현
        // 왼쪽 위로 이동

        // 점프한 뒤 JumpFrame 동안 점프 불가
        if (CoolDownFrame > 0)
        {
            NormalImage.gameObject.SetActive(true);
            LeftJumpImage.gameObject.SetActive(false);
            CoolDownFrame -= 1;
        }
        else if (!Jumping)//점프 시작
        {
            //점프 시작시 색상 회색으로 바뀜 + Collider 비활성화 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Jumping = true;
                JumpedFrame += 1;
                Bc.enabled = false;

                NormalImage.gameObject.SetActive(false);
                LeftJumpImage.gameObject.SetActive(true);               
            }
        }
        else
        {
            // 프레임 16개까지 점프키 계속 누를 수 있음 + 점프 
            if (Input.GetKey(KeyCode.Q) && JumpedFrame <= JumpFrame)
            {
                JumpedFrame += 1;
                transform.Translate(new Vector2(-0.5f, 0.25f) * Time.deltaTime * Speed);
            }
            //종료조건 1. 프레임이 16개가 되는경우 - ?????
            //종료조건 2. 점프키가 떼진경우 
            //둘 중 하나만 만족해도 점프는 풀림
            else if (Input.GetKeyUp(KeyCode.Q) || JumpedFrame > JumpFrame)
            {
                NormalImage.gameObject.SetActive(true);
                LeftJumpImage.gameObject.SetActive(false);
                Jumping = false;
                JumpedFrame = 0;
                Bc.enabled = true;
                CoolDownFrame = CoolDown;
                
            }
        }
    }
    private void RightJump()
    {
        // 점프 구현
        // 오른쪽 위쪽으로 이동

        // 점프한 뒤 JumpFrame 동안 점프 불가
        if (CoolDownFrame > 0)
        {
            NormalImage.gameObject.SetActive(true);
            RightJumpImage.gameObject.SetActive(false);
            CoolDownFrame -= 1;
        }
        else if (!Jumping)
        {
            //점프 시작시 색상 회색으로 바뀜 + Collider 비활성화
            if (Input.GetKeyDown(KeyCode.E))
            {
                Jumping = true;
                JumpedFrame += 1;
                Bc.enabled = false;
                NormalImage.gameObject.SetActive(false);
                RightJumpImage.gameObject.SetActive(true);
            }
        }
        else
        {
            // 프레임 16개까지 점프키 계속 누를 수 있음
            if (Input.GetKey(KeyCode.E) && JumpedFrame <= JumpFrame)
            {
                JumpedFrame += 1;
                transform.Translate(new Vector2(0.5f, 0.25f) * Time.deltaTime * Speed);
            }
            //종료조건 1. 프레임이 16개가 되는경우
            //종료조건 2. 점프키가 떼진경우 
            //둘 중 하나만 만족해도 점프는 풀림
            else if (Input.GetKeyUp(KeyCode.E) || JumpedFrame > JumpFrame)
            {
                NormalImage.gameObject.SetActive(true);
                RightJumpImage.gameObject.SetActive(false);
                Jumping = false;
                JumpedFrame = 0;
                Bc.enabled = true;
                CoolDownFrame = CoolDown;
                
            }
        }
    }
    private void Move()
    {
        // 기본 상하좌우 이동
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        Y /= 2;
        if (Y > 0) Y = 0;
        transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);
    }

    // Update is called once per frame
    void Update()
    {
        Move();        
        LeftJump();
        RightJump();
    }
    
}