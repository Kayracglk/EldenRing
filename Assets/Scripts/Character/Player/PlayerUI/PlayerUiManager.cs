using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerUiManager : MonoBehaviour
{
    public static PlayerUiManager instance;
    [Header("NETWORK JOIN")]
    [SerializeField] private bool startGameAsClient;

    [HideInInspector] public PlayerUiHudManager playerUiHudManager;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        playerUiHudManager = GetComponentInChildren<PlayerUiHudManager>();
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (startGameAsClient)
        {
            startGameAsClient = false;
            NetworkManager.Singleton.Shutdown();
            NetworkManager.Singleton.StartClient();
        }
    }
}
