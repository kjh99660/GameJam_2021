using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float time = 30;
    [SerializeField] public float WaveSpeed;
    CircleCollider2D CircleCollider;
    //시간이 지남에 따라 점점 파도가 커지는 함수
    public void SizeUp()
    {
        transform.localScale += new Vector3(1f, 1f, 1f) * WaveSpeed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            Vector3 WavePosition = CircleCollider.gameObject.transform.position;
            Vector3 ObjectPosition = collision.gameObject.transform.position;
            float Distance = Vector3.Distance(ObjectPosition, WavePosition);
            if (Distance < Vector3.Magnitude(CircleCollider.radius * gameObject.transform.localScale) * 0.5)
            {
                CircleCollider.enabled = false;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CircleCollider = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SizeUp();
        time -= Time.deltaTime;
        if (time < 0f) Destroy(gameObject);
    }
}
