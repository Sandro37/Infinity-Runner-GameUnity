using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    public float speedCamera;
    public float offSet;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 newCampPos = new Vector3(player.position.x + offSet, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCampPos, speedCamera * Time.deltaTime);
    }
}
