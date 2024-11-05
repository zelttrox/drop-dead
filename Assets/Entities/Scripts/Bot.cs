using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour {

    public References obj;
    public Entities entity;

    [SerializeField] Entities.Type type;
    [SerializeField] Transform target;

    private bool isAlive = true;
    private bool inRange;
    private float targetUpdateDeadline;

    void Update() {
        BrainAI();
    }

    private void BrainAI() {

        if (obj.target != null && isAlive) {
            // Loop
            CheckRange();

            // if player in shooting range
            if (inRange) {
                AimTarget();
            }
            // if player out of shooting range
            else {
                if (type == Entities.Type.Fetcher) {
                    MoveTo(target);
                }
                else if (type == Entities.Type.Sentinel) {
                    //
                }
                else if (type == Entities.Type.Juggernaut) {
                    //
                }
            }
        }
    }

    private void CheckRange() {
        inRange = Vector3.Distance(obj.target.position, obj.agent.transform.position) <= Game.entity.shootingRange;
    }

    private void AimTarget() {
        // Vector3 viewPos = obj.target.position - transform.position;
        // viewPos.y = 0;
        // Quaternion sight = Quaternion.LookRotation(viewPos);
        // transform.rotation = Quaternion.Slerp(transform.rotation, sight, 0.2f);
    }

    private void MoveTo(Transform interestPoint) {
        if (Time.time >= targetUpdateDeadline) {
            targetUpdateDeadline = Time.time + entity.targetUpdateDelay;
            obj.agent.SetDestination(interestPoint.position);
        }
    }
}
