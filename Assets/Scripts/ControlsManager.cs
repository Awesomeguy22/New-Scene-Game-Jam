using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Data;
using UnityEngine.Rendering;

public class ControlsManager : MonoBehaviour, Controls.IKeyboardActions
{
    // public static ControlsManager Singleton;
    public Controls controls;
    
    public event EventHandler ShootProjectile;
    public event EventHandler<ToggleAttackEventArgs> ToggleAttack;
    public event EventHandler Pause;
    public event EventHandler Attack;

    public class ToggleAttackEventArgs: EventArgs {
        public int attack;
    }

    private void OnEnable(){
        controls.Keyboard.Enable();
    }

    private void OnDisable(){
        controls.Keyboard.Disable();
    }
    
    private void Awake(){
        controls = new Controls();
        controls.Keyboard.SetCallbacks(this);

        // MakeSingleton();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void MakeSingleton() {
    //     if (Singleton != null) {
    //         Destroy(gameObject); 
    //     } else {
    //         Singleton = this;
    //         DontDestroyOnLoad(gameObject);
    //         Debug.Log("Made singleton");
    //     }
    // }

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

    public void OnAttack1(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            ToggleAttack?.Invoke(this, new ToggleAttackEventArgs { attack = 1 });
        }
    }

    public void OnAttack2(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            ToggleAttack?.Invoke(this, new ToggleAttackEventArgs { attack = 2 });
        }
    }

    public void OnAttack3(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            ToggleAttack?.Invoke(this, new ToggleAttackEventArgs { attack = 3 });
        }
    }

    public void OnAttack4(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            ToggleAttack?.Invoke(this, new ToggleAttackEventArgs { attack = 4 });
        }
    }

    public void OnPause(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            Pause?.Invoke(this, EventArgs.Empty);
        }
    }

    public void OnAttack(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            Attack?.Invoke(this, EventArgs.Empty);        
        }
    }
}
