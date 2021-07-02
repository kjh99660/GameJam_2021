using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfACircle : MonoBehaviour
{
    public GameObject wave;
    public Vector3[] wayPoint; 
    private Vector3 pos;
    private float temp;
    [SerializeField]
    private float coolDown = 1f;

    private int where = 0;
    private bool leftToRight = true;
    void Start()
    {
        temp = 20f * Time.deltaTime;
        wayPoint = new Vector3[18];
        for(int i = 0; i < 9; i++)
        {
            wayPoint.SetValue(new Vector3(-45 + 5 * i,2.5f * i, 0), i);
        }
        for (int i = 0; i < 9; i++)
        {
            wayPoint.SetValue(new Vector3(5 * i, 22f - 2.5f * i, 0), i+9);
        }

    }
    //원 생성하는 함수
    public void CreateWave()
    {
        coolDown -= Time.deltaTime;
        if(coolDown < 0f)
        {
            Instantiate(wave, pos, Quaternion.identity);
            coolDown = 3f;
        }
        
    }

    //이동하는 함수
    private void Move()
    {      
        pos = transform.position;// 현재 위치 받기
        if (leftToRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint[where], temp);
            if (Vector3.Distance(wayPoint[where], pos) == 0f) where++;
            if (where == wayPoint.Length - 1) leftToRight = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint[where], temp);
            if (Vector3.Distance(wayPoint[where], pos) == 0f) where--;
            if (where == 0) leftToRight = true;
        }
    }
      
    void Update()
    {
        Move();
        CreateWave();
    }
}
