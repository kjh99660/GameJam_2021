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
    private float coolDown = 3;

    private int where = 0;
    private bool leftToRight = true;
    void Start()
    {
        temp = 5f * Time.deltaTime;
        wayPoint = new Vector3[4];
        wayPoint.SetValue(new Vector3(0, 0, 0), 0);
        wayPoint.SetValue(new Vector3(0, 10, 0), 1);
        wayPoint.SetValue(new Vector3(10, 10, 0), 2);
        wayPoint.SetValue(new Vector3(10, 0, 0), 3);

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
