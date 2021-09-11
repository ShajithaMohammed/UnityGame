using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody _body;
    [SerializeField]private float speed = 10;
    [SerializeField] private float jumpLimit= 2f;
    private float jumpSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Jump");
        _body.AddForce(new Vector3(x, 0, z)*speed);
        if ( _body.transform.position.y <= jumpLimit)
        {
            _body.AddForce(new Vector3(0, y, 0) * jumpSpeed );
        }
    }
}
