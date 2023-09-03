using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager instance;

    private PlayerControls playerControls;

    [Header("MOVEMENT INPUT")]
    [SerializeField] private Vector2 movementInput;
    public float verticalInput;
    public float horizontalInput;
    public float moveAmount;

    [Header("CAMERA MOVEMENT INPUT")]
    [SerializeField] private Vector2 cameraInput;
    public float cameraVerticalInput;
    public float cameraHorizontalInput;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerCamera.Movement.performed += i => cameraInput = i.ReadValue<Vector2>();
        }
        playerControls.Enable();
    }

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.activeSceneChanged += OnSceneChanged; // Sahne degistigi zaman bu methodu cagiriyor.
        instance.enabled = false;
    }
    private void Update()
    {
        HandlePlayerMovementInput();
        HandleCameraMovementInput();
    }
    private void OnApplicationFocus(bool focus)
    {
        if(enabled)
        {
            if(focus)
            {
                playerControls.Enable();
            }
            else
            {
                playerControls.Disable();
            }
        }
    }
    private void OnSceneChanged(Scene oldScene, Scene newScene)
    {
        if (newScene.buildIndex == WorldSaveGameManager.instance.worldSceneIndex)
        {
            instance.enabled = true;
        }
        else
        {
            instance.enabled = false;
        }
    }
    private void HandlePlayerMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(verticalInput) + Mathf.Abs(horizontalInput));

        if(moveAmount <= 0.5f && moveAmount > 0)
        {
            moveAmount = 0.5f;
        }
        else if(moveAmount > 0.5f && moveAmount <= 1.0f)
        {
            moveAmount = 1;
        }
    } 
    private void HandleCameraMovementInput()
    {
        cameraVerticalInput = cameraInput.y;
        cameraHorizontalInput = cameraInput.x;

    }
    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
    }
}
