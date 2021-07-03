using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject Wavespawner;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        Instantiate(Wavespawner);
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > 30)
        {
            time = 0;
            Spawn();
        }
    }
}
