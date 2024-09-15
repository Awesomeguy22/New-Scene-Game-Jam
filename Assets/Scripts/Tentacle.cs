using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tentacle : MonoBehaviour {

    [SerializeField]
    private int tentacleIndex;

    private AttackManager attackManager;
    private int currentTentacle;

    private void Awake() {
        this.attackManager = FindObjectOfType<AttackManager>();

        this.currentTentacle = 1;
    }

    private void OnEnable() {
        this.attackManager.ChangeAttack += When_ChangeAttack;
    }

    private void OnDisable() {
        this.attackManager.ChangeAttack -= When_ChangeAttack;
    }

    void Update() {
        if (this.currentTentacle != this.tentacleIndex) {
            return;
        }

        RotateTentacle();
    }

    // rotate tentacle according to mouse, lerp not working
    private void RotateTentacle() {
        Vector2 mouseCoordinates = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 tentacleCoordinates = gameObject.transform.position;

        // Vector3 pointingVector = new Vector3(mouseCoordinates.x, mouseCoordinates.y, 0) - new Vector3(tentacleCoordinates.x, tentacleCoordinates.y, 0);
        Vector2 pointingVector = mouseCoordinates - new Vector2(tentacleCoordinates.x, tentacleCoordinates.y);
        // Debug.Log(Mathf.Atan(pointingVector.y / pointingVector.x) * Mathf.Rad2Deg);

        float angle = Vector2Deg(pointingVector) + 90;




        Quaternion pointingAngle = Quaternion.Euler(0, 0, angle);

        Quaternion currentAngle = Quaternion.Euler(0, 0, transform.rotation.z);
        // gameObject.transform.rotation = Quaternion.Lerp(currentAngle, pointingAngle, Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        // Debug.Log("Pointing: " + pointingAngle.eulerAngles + " Current: " + currentAngle.eulerAngles + " lerp: " + transform.rotation.eulerAngles);
    }

    // calculate angle in degrees from vector 2
    public static float Vector2Deg(Vector2 vector) {
        float angle = Mathf.Atan(vector.y / vector.x) * Mathf.Rad2Deg;

        if (vector.x < 0 && vector.y > 0) {
            angle += 180;
        };
        
        if (vector.x < 0 && vector.y < 0) {
            angle -= 180;
        }

        return angle;
    }

    private void When_ChangeAttack(object sender, AttackManager.ChangeAttackEventArgs e) {
        this.currentTentacle = e.attack; 
        Debug.Log(this.currentTentacle);
    }
}
