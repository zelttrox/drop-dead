using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // Creating variables
    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    [SerializeField] bool isGrounded;

    void Update() {

        GroundDetector();

        MovementHandler();
        JumpHandler();
        SneakHandler();

        PlayerState();

        if (velocity.x != 0f || velocity.z != 0f) {
            Game.player.IsStatic = false;
        }
        else Game.player.IsStatic = true;
    }

    public void GroundDetector() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    public void MovementHandler() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Game.player.WeightMinus = Game.player.Weight / Game.player.MaxWeight;
        controller.Move(move * (Game.player.Speed * ((3 / 2) - Game.player.WeightMinus)) * Time.deltaTime);

        velocity.y += Game.player.Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); }

    public void JumpHandler() {
        if (Input.GetKeyDown(Game.ctrl.Key_jump) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(Game.player.JumpHeight * -2f * Game.player.Gravity);
            if (Game.player.movingState == Player.MovingState.walking)
            {
                Game.player.airSpeed = Game.player.walkSpeed;
            }
            else if (Game.player.movingState == Player.MovingState.sprinting)
            {
                Game.player.airSpeed = Game.player.sprintSpeed;
            }
        }
    }

    public void SneakHandler() {
        if (Game.player.movingState == Player.MovingState.sneaking)
        {
            Game.player.airSpeed = Game.player.sneakSpeed;
        }
    }

    public void PlayerState() {
        if (isGrounded && Input.GetKey(Game.ctrl.Key_sprint))
        {
            Game.player.movingState = Player.MovingState.sprinting;
            Game.player.Speed = Game.player.sprintSpeed;
        }
        else if (isGrounded && Input.GetKey(Game.ctrl.Key_sneak))
        {
            Game.player.movingState = Player.MovingState.sneaking;
            Game.player.Speed = Game.player.sneakSpeed;
        }
        else if (isGrounded)
        {
            Game.player.movingState = Player.MovingState.walking;
            Game.player.Speed = Game.player.walkSpeed;
        }
        else
        {
            Game.player.movingState = Player.MovingState.air;
            Game.player.Speed = Game.player.airSpeed + Mathf.Round(Mathf.Sqrt(Game.player.Gravity * -1));
        }
    }
}
