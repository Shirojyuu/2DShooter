using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour {

    public KeyCode jumpKey, shootKey;

    private PlayerController playerController;
    private float horizontal;
    private bool jumpKeyPressed, shootKeyPressed;

	void Start () {
        playerController = GetComponent<PlayerController>();
	}
	
	void Update () {
        horizontal = Input.GetAxisRaw("Horizontal");
        jumpKeyPressed = Input.GetKeyDown(jumpKey);
        shootKeyPressed = Input.GetKeyDown(shootKey);

        playerController.ProcessInput(horizontal, jumpKeyPressed, shootKeyPressed);
	}
}
