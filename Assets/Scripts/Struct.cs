using System;
using UnityEngine;

public struct Player {

    // Vitals
    public float Health;
    public int Damage;

    // Abilities
    public int Reach;

    // Speed & velocity
    public float sprintSpeed;
    public float walkSpeed;
    public float sneakSpeed;
    public float airSpeed;
    public float Speed;
    public MovingState movingState;
    public enum MovingState { walking, sprinting, sneaking, air, swiming }
    public bool isStatic;

    // Gravity
    public float Gravity;
    public float JumpHeight;

    // Logic
    public bool isInsideMenu;
    public bool objectInReach; // Unassigned
}

public struct Controls {

    // Mouse
    public float Mse_Sensitivity;
    public KeyCode Mse_Primary;
    public KeyCode Mse_Secondary;

    // Movements
    public KeyCode Key_goForward;
    public KeyCode Key_goBackward;
    public KeyCode Key_goRight;
    public KeyCode Key_goLeft;

    // Actions
    public KeyCode Key_sprint;
    public KeyCode Key_jump;
    public KeyCode Key_sneak;
    public KeyCode Key_interact;

    // Openers
    public KeyCode Key_inventory;
}

public struct Entities {

    // Ennemy type
    public Type type;
    public enum Type { Sentinel, Fetcher, Juggernaut }

    // Stats
    public float Speed;
    public float AttackSpeed;

    // Pathing
    public float targetUpdateDelay;

    // Shooting
    public float shootingRange;
}

public class Game : MonoBehaviour {

    public static Player player;
    public static Controls ctrl;
    public static Entities entity;

    // Initialize player variables
    public static void InitPlayer() {

        // Initialize player structure
        Debug.Log("<color=cyan>~ Instancing Player</color>");

        player.sprintSpeed = 35f;
        player.walkSpeed = 15f;
        player.sneakSpeed = 8f;
        player.airSpeed = 10f;
        player.Speed = 0f;
        player.Gravity = -22f;
        player.JumpHeight = 3f;
        player.Reach = 20;
        player.Damage = 5;
    }

    // Initialize controls 
    public static void InitControls() {

        // Initialize player structure
        Debug.Log("<color=cyan>~ Instancing Controls</color>");
        
        ctrl.Key_goForward = KeyCode.I;
        ctrl.Key_goBackward = KeyCode.K;
        ctrl.Key_goRight = KeyCode.L;
        ctrl.Key_goLeft = KeyCode.T;

        ctrl.Key_sprint = KeyCode.P;
        ctrl.Key_jump = KeyCode.Space;
        ctrl.Key_sneak = KeyCode.O;
        ctrl.Key_inventory = KeyCode.M;
        ctrl.Key_interact = KeyCode.U;

        ctrl.Mse_Primary = KeyCode.Mouse0;
        ctrl.Mse_Secondary = KeyCode.Mouse1;
        ctrl.Mse_Sensitivity = 100f;
    }

    // Initialize controls 
    public static void InitEntities() {

        // Initialize entities structure
        Debug.Log("<color=cyan>~ Instancing Entity </color>");

        entity.Speed = 10f;
        entity.AttackSpeed = 1f;
        entity.shootingRange = 2f;
        entity.targetUpdateDelay = 0.2f;

    }
}
