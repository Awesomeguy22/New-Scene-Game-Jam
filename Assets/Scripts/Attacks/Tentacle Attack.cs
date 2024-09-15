using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TentacleAttack : BaseAttack
{
    [SerializeField] GameObject TentacleGraphics;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack() {
        if (CheckCooldown()) {
            return;
        }

        Vector2 mouseCoordinates = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        

    }
}
