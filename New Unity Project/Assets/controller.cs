using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private int CoolDown;
    [SerializeField] private int JumpFrame;

    BoxCollider2D Bc;
    SpriteRenderer Sr;
    bool Jumping = false;
    int JumpedFrame = 0;
    int CoolDownFrame = 5;

    // Start is called before the first frame update
    void Start()
    {
        Bc = gameObject.GetComponent<BoxCollider2D>();
        Sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // 기본 상하좌우 이동
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(X, Y) * Time.deltaTime * Speed);

        // 점프 구현
        // 점프한 뒤 JumpFrame 동안 점프 불가
        if (CoolDownFrame>0)
        {
            CoolDownFrame -= 1;
        }
        else if(!Jumping)
        {
            //점프 시작시 색상 회색으로 바뀜 + Collider 비활성화
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("점프 함");
                Jumping = true;
                JumpedFrame += 1;
                Bc.enabled = false;
                Sr.material.color = Color.gray;
            }
        }  
        else
        {
            // 프레임 16개까지 점프키 계속 누를 수 있음
            if(Input.GetButton("Jump") && JumpedFrame <= JumpFrame)
            {
                JumpedFrame += 1;
            }
            //종료조건 1. 프레임이 16개가 되는경우
            //종료조건 2. 점프키가 떼진경우 
            //둘 중 하나만 만족해도 점프는 풀림
            else if (Input.GetButtonUp("Jump")||JumpedFrame > JumpFrame)
            {
                Debug.Log("점프풀림");
                Jumping = false;
                JumpedFrame = 0;
                Bc.enabled = true;
                Sr.material.color = Color.white;
                CoolDownFrame = CoolDown;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.name == "sq")
        {
            Debug.Log("충돌함");
        }
    }
}