using UnityEngine;

public class Run : MonoBehaviour {

    void Start() {
        Game.InitPlayer();
        Game.InitControls();
        Game.InitEntities();
    }
}
