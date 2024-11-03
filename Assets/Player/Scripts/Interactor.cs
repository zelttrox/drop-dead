using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour {

    private bool activeRayast = false;

    public Transform cam;
    public GameObject hitObject;
    private RaycastHit hit;
    private GameObject lastOutlinedObject = null;

    public Text ObjectNameText;

    void Update() {
        activeRayast = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Game.player.Reach);

        if (activeRayast && hit.collider.tag == "Interactable" && !Game.player.isInsideMenu) {
            hitObject = hit.collider.gameObject;

            EnableHover();
        }

        else {
            DisableHover();
        }
    }

    void EnableHover() {

        Outline outline = hitObject.GetComponent<Outline>();
    
        if (outline == null) {
            outline = hitObject.AddComponent<Outline>();
        }

        outline.enabled = true;

        if (lastOutlinedObject != null && lastOutlinedObject != hitObject) {
            Outline lastOutline = lastOutlinedObject.GetComponent<Outline>();

            if (lastOutline != null) {
                lastOutline.enabled = false;
            }
        }

        lastOutlinedObject = hitObject;

    }
    void DisableHover() {

        ObjectNameText.text = "";

        if (lastOutlinedObject != null) {
            Destroy(lastOutlinedObject.GetComponent<Outline>());
            lastOutlinedObject = null;
            }
        }

    }
