using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class ControlsManager : MonoBehaviour, Controls.IKeyboardActions
{
    public static ControlsManager Singleton;
    public Controls controls;
    
    public event EventHandler ShootProjectile;



    private void OnEnable(){
        controls.Keyboard.Enable();
    }

    private void OnDisable(){
        controls.Keyboard.Disable();
    }
    
    private void Awake(){
        controls = new Controls();
        controls.Keyboard.SetCallbacks(this);

        MakeSingleton();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MakeSingleton() {
        if (Singleton != null) {
            Destroy(gameObject); 
        } else {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Made singleton");
        }
    }

    // public static ControlsManager GetSingleton() {
    //     if (Singleton == null) {
            
    //     } else {
    //         Singleton = this;
    //         DontDestroyOnLoad(gameObject);
    //         Debug.Log("Made singleton");
    //     }
    //     return Singleton;
    // }

    public void OnShootProjectile(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            ShootProjectile?.Invoke(this, EventArgs.Empty);
        }
    }
}
