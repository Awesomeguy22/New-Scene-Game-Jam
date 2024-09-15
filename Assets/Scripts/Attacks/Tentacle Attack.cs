using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class TentacleAttack : BaseAttack
{

    [SerializeField] GameObject spinningTentacle;
    [SerializeField] float lifetime;

    [SerializeField] float spinSpeed;
    [SerializeField] float damage;


    public override void Attack() {
        if (CheckCooldown()) {
            return;
        }

        Vector2 mouseCoordinates = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        GameObject attack = Instantiate(spinningTentacle, new Vector3(mouseCoordinates.x, mouseCoordinates.y, 0), Quaternion.identity);
        SpinningTentacle attackScript = attack.GetComponent<SpinningTentacle>();
        attackScript.damage = damage;
        attackScript.spinSpeed = spinSpeed;
        Destroy(attack, lifetime);

    }
}
