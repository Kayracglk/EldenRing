using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorManager : CharacterAnimatorManager
{
    private PlayerManager player;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<PlayerManager>();
    }
    private void OnAnimatorMove()
    {
        if(player.applyRootMotion)
        {
            Vector3 velocity = new Vector3(player.animator.deltaPosition.x, 0, player.animator.deltaPosition.z);
            player.characterController.Move(velocity);
            player.transform.rotation *= player.animator.deltaRotation;
        }
    }
}
