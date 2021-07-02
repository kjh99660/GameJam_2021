using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float time = 30;
    //시간이 지남에 따라 점점 파도가 커지는 함수
    public void SizeUp()
    {
        transform.localScale += new Vector3(0.8f, 0.8f, 0f);
    }
    //특정 조건이 만족되면 파괴되기 - 육지에 도달 시 파괴
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Land")
        {
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SizeUp();
        time -= Time.deltaTime;
        if (time < 0f) Destroy(gameObject);
    }
}
