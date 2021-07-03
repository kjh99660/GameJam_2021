using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Character;
    private Vector3 pos;
    private Vector3 velo;
    void Start()
    {
        Character = GameObject.Find("Character").gameObject;
        velo = new Vector3(2f, 2f, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        pos = Character.transform.position;
        if(pos.x > -54f && pos.x < 55f)
        {
            if(pos.y > -57f && pos.y < 19f)
            {
                transform.position = Vector3.SmoothDamp(transform.position, pos, ref velo, 0.05f);
                transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
            }
        }       
    }
}
