using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script can be found in the Component section under the option Game Systems/Player/Movement
[AddComponentMenu("Game Systems/Player/Movement")]
//This script requires the component Character controller to be attached to the Game Object
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Character")]
    //vector3 called moveDir //we will use this to apply movement in worldspace
    public Vector3 moveDir;
    //Character controller called _charC CharacterController.html) 
    private CharacterController _charC;
    [Header("Character Speeds")]
    //public float variables jumpSpeed 8 & speed 5 & gravity 20 
    public float speed = 5;
    //[Header("AHHHH EWWWW")]
    public float jumpSpeed = 8, gravity = 20, crouch = 2.5f, walk = 5, run = 10;
    #endregion
    #region Start
    // Start is called before the first frame update
    void Start()
    {
        //_charc is set to the Character controller on this GameObject
        _charC = GetComponent<CharacterController>();
    }
    #endregion
    #region Update
    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameManagerInstance.gameState == GameStates.GameState)
        {
            //if our character is grounded
            if (_charC.isGrounded)
            {
                //set moveDir to the inputs direction
                moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                //moveDir's forward is changed from global z (forward) to the Game Objects local Z (forward)//allows us to move where player is facing
                moveDir = transform.TransformDirection(moveDir);
                //moveDir is multiplied by speed so we move at a decent pace
                moveDir *= speed;
                //if the input button for jump is pressed then   
                if (Input.GetButton("Jump"))
                {
                    //our moveDir.y is equal to our jump speed
                    moveDir.y = jumpSpeed;
                }
            }
            //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed my time.deltaTime to normalize it
            moveDir.y -= gravity * Time.deltaTime;
            //we then tell the character Controller that it is moving in a direction multiplied Time.deltaTime  
            _charC.Move(moveDir * Time.deltaTime);
        }
    }
    #endregion
}
