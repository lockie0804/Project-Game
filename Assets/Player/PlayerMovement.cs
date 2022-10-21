using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //reference to the animator 
    //this allows us o manipulate this characters animations
    public Animator anim;
    //vector3 called moveDir // we will use this to apply movement in worldspace 
    public Vector3 moveDir;
    //charater controller called _charC
    private CharacterController _charC;
    //speed Floats
    public float speed, jumpSpeed = 8, gravity = 20, crouch = 2.5f, walk = 5, run = 10;

    // Start is called before the first frame update
    void Start()
    {
        //the animator we are manipulating is the animator connected to the object this script is on 
        anim = GetComponent<Animator>();
        anim.SetFloat("isCrouching", 1);
        _charC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if our character is grounded 
        if (_charC.isGrounded)
        {
            anim.SetFloat("isCrouching", 1);
            //set moveDir to the inputs direction
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //if we have 0 direction
            if (moveDir == Vector3.zero)
            {
                speed = 0;
            }
            //if sprint
            if (Input.GetKey(KeyCode.LeftShift))
            {
                    speed = run;
            }
            //if crouch
            else if(Input.GetKey(KeyCode.LeftControl))
            {
                    speed = crouch;
                    anim.SetFloat("isCrouching", 0);
            }
            //esle we walking here 
            else
            {
                    speed = walk;
            }
            anim.SetFloat("moveSpeed", speed);
            anim.SetFloat("horizontal", moveDir.x);
            anim.SetFloat("vertical", moveDir.z);
            ///moveDir forward is changed from global z (forward) to the game objects local z (forward)/ allows us to move where the player is facing 
            moveDir = transform.TransformDirection(moveDir);
            //moveDir is multiplied by speed so we move at a decent pace 
            moveDir *= speed;
        }
        //regardless of it we are grounded or not the players moveDir.y is always affected by gravity timsesd my time.detlatime to normalize it 
        moveDir.y -= gravity * Time.deltaTime;
        //we them tell the character controller that it is moving in a direction multipled time.detlatime
        _charC.Move(moveDir * Time.deltaTime);
    }
}
