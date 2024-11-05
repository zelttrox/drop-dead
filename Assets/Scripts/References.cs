using UnityEngine;
using UnityEngine.AI;

public class References : MonoBehaviour {

    [Header("Player")]
    public Transform Character;
    public CharacterController controller;
    public Transform groundCheck;
    public Transform cam;

    [Header("Entities")]
    public NavMeshAgent agent;
    public Transform target;

}
