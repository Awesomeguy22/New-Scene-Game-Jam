using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField] BaseAttack[] attacks;
    int activeAttack;

    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //attack 1
        if (Input.GetButtonDown("Q")){
            activeAttack = 0;
        }
        else if (Input.GetButtonDown("W")){
            activeAttack = 1;
        }
        else if (Input.GetButtonDown("E")){
            activeAttack = 2;
        }
        else if (Input.GetButtonDown("R")){
            activeAttack = 3;
        }
    }
}
