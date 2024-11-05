using UnityEngine;

public class Movement : MonoBehaviour {

    // References
    public References obj;

    // Ground detection
    public LayerMask groundMask;
    private float groundDistance = 0.4f;
    private bool isGrounded;

    // Velocity
    Vector3 velocity;

    // Structs
    private Player player;
    private Controls ctrl;

    void Start () {
        player = Game.player;
        ctrl = Game.ctrl;
    }

    void Update() {

        PlayerState(); 
        GroundDetector();

        MovementHandler(); 
        JumpHandler(); 
        SneakHandler();

        Gravity();
    }

    // Checks if the player is grounded
    public void GroundDetector() {
        isGrounded = Physics.CheckSphere(obj.groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
    }

    // Applies gravity to the player
    public void Gravity() {
        velocity.y += player.Gravity * Time.deltaTime;
        obj.controller.Move(velocity * Time.deltaTime);
    }

    // Handles player movements on X and Z axis
    public void MovementHandler() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        obj.controller.Move(player.Speed * Time.deltaTime * move);
    }

    // Applies upforce to the player
    public void JumpHandler() {
        if (Input.GetKeyDown(ctrl.Key_jump) && isGrounded) {
            velocity.y = Mathf.Sqrt(player.JumpHeight * -2f * player.Gravity);
            if (player.movingState == Player.MovingState.walking) {
                player.airSpeed = player.walkSpeed;
            }
            else if (player.movingState == Player.MovingState.sprinting) {
                player.airSpeed = player.sprintSpeed;
            }
        }
    }

    // Called when MovingState = sneaking
    public void SneakHandler() {
        if (player.movingState == Player.MovingState.sneaking) {
            player.airSpeed = player.sneakSpeed;
        }
    }

    // Checks the player's state
    public void PlayerState() {
        // Is sprinting
        if (isGrounded && Input.GetKey(ctrl.Key_sprint)) {
            player.movingState = Player.MovingState.sprinting;
            player.Speed = player.sprintSpeed;
        }
        // Is sneaking
        else if (isGrounded && Input.GetKey(ctrl.Key_sneak)) {
            player.movingState = Player.MovingState.sneaking;
            player.Speed = player.sneakSpeed;
        }
        // Is walking
        else if (isGrounded) {
            player.movingState = Player.MovingState.walking;
            player.Speed = player.walkSpeed;
        }
        // Is in air
        else {
            player.movingState = Player.MovingState.air;
            player.Speed = player.airSpeed + Mathf.Round(Mathf.Sqrt(player.Gravity * -1));
        }
        
        // Is static
        if (velocity.x != 0f || velocity.z != 0f) {
            player.isStatic = false;
        }
            else player.isStatic = true;
    }
}
