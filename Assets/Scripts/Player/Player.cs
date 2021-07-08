using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Singleton;

    // PLAYER COMPONENTS
    //[HideInInspector]
    public PlayerMovement movement;
    //[HideInInspector]
    public PlayerAnimations animations;
    [HideInInspector]
    public PlayerSpawning spawning;
    [HideInInspector]
    public PlayerCollision collision;

    // PHYSICS
    //[HideInInspector]
    public Rigidbody rb;
    //[HideInInspector]
    public CapsuleCollider capsColl;

    // CAMERA
    [HideInInspector]
    public Camera cam;

    void Awake()
    {
        Singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // PLAYER COMPONENTS
        movement = GetComponent<PlayerMovement>();
        animations = GetComponent<PlayerAnimations>();
        spawning = GetComponent<PlayerSpawning>();
        collision = GetComponent<PlayerCollision>();

        // PHYSICS
        rb = GetComponent<Rigidbody>();
        capsColl = GetComponent<CapsuleCollider>();

        // CAMERA
        cam = Camera.main;

        // INPUTS
        InputManager.Singleton.EnableInputs();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerFell();
    }

    void CheckIfPlayerFell()
    {
        if (transform.position.y < -20f)
        {
            spawning.FadeForSpawn();

            print("respawn!");
        }
    }

    public void UnParent()
    {
        transform.parent = null;
    }
    
}
