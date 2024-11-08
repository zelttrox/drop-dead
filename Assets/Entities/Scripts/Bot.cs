using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour {

    public References obj;
    public Entities entity;

    [SerializeField] Entities.Type type;
    [SerializeField] Transform target;
    [SerializeField] Transform spawn;

    private bool isAlive;
    private bool inRange;
    private bool inSoundRange;

    private float targetUpdateDeadline;

    void Start() {
        isAlive = true;
    }

    void Update() {
        if (obj.target != null && isAlive) {
            UpdateAI(); }
    }

    private void UpdateAI() {

            // Loop
            CheckRanges();

            // Player in sound range
            if (inSoundRange) {
                ListenTo(obj.audioListener); }

            // Specific type functions
            switch (type) {

                case Entities.Type.Fetcher :
                Fetcher();
                break;

                case Entities.Type.Sentinel :
                break;

                case Entities.Type.Juggernaut :
                break; 
                
                } 
    }

    private void Fetcher() {

            // Shooting range logic
            if (inRange) { 
                AimTarget(); }
            else { 
                MoveTo(target); } 

    }

    private void CheckRanges() {
        inRange = Vector3.Distance(obj.target.position, obj.agent.transform.position) <= Game.entity.shootingRange;
        inSoundRange = Vector3.Distance(obj.target.position, obj.agent.transform.position) <= Game.entity.hearDistance;
    }

    private void ListenTo(AudioListener audio) {
        // if a sound is heard
        // Game.player.isSpoted = true
    }

    private void AimTarget() {
        Vector3 viewPos = obj.target.position - transform.position; viewPos.y = 0;
        Quaternion sight = Quaternion.LookRotation(viewPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, sight, 0.2f);
    }

    private void MoveTo(Transform interestPoint) {
        if (Time.time >= targetUpdateDeadline) {
            targetUpdateDeadline = Time.time + Game.entity.targetUpdateDelay;
            obj.agent.SetDestination(interestPoint.position);
        }
    }
}
