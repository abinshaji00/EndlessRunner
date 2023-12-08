using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private CharacterController characterController;
    public float speed = 5f;
    private float Gravity = 12f;
    private float VerticalVelocity = 0f;
    private float animationDuration = 2f;
    private bool isDeath=false;
    private Vector3 moveVector;
    public Score sc;
    private float Increment = 10f;
    Animator anim;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (isDeath)
        {
            return;
        }

        if (Time.time < animationDuration)
        {
            characterController.Move(Vector3.forward*speed*Time.deltaTime);
            return;
        }
        if (characterController.isGrounded)
        {
            VerticalVelocity = -0.5f;
        }
        else
        {
            VerticalVelocity-= Gravity*Time.deltaTime;
        }
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        moveVector.y = VerticalVelocity;
        moveVector.z = speed;
        characterController.Move(moveVector*Time.deltaTime);
    }
    public void setSpeed(float modifier)
    {
        speed = 5 + modifier;
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + characterController.radius)
        {
            death();
        }
    }
    private void death()
    {
        isDeath = true;
        anim.SetBool("death", true);
        Invoke("fall", 1.5f);
      
    }
    void fall()
    {
        GetComponent<Score>().onDeth();
    }

    public void OnTriggerEnter(Collider other)
    {
        other.gameObject.CompareTag("Gems");
        Destroy(other.gameObject);
    }
}
