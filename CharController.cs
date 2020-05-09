using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour 
{
    [SerializeField]
    float moveSpeed = 4f;
    
    Vector3 forward,right;

    void Start()
    {
        //Forward Vector = Forward Camera dan Forward Vector = Upward dan Downward vector
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0,90,0)) * forward;
    }

    void Update()
    {
        if (Input.anyKey)
            Move();
        
    }
    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"),0,Input.GetAxis("VerticalKey"));
        Vector3 rightmovement = right*moveSpeed*Time.deltaTime*Input.GetAxis("HorizontalKey");
        Vector3 upmovement = forward*moveSpeed*Time.deltaTime*Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightmovement + upmovement);

        transform.forward = heading;
        transform.position += rightmovement;
        transform.position += upmovement;
    }
}
