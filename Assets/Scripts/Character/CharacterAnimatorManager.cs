using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorManager : MonoBehaviour
{
    private CharacterManager character;
    private float vertical;
    private float horizontal;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
    }

    public void UpdateAnimatorMovementParameters(float horizontalValue, float verticalValue)
    {
        character.animator.SetFloat("Horizontal", horizontalValue, 0.1f, Time.deltaTime);
        character.animator.SetFloat("Vertical", verticalValue, 0.1f, Time.deltaTime);
    }

    public virtual void PlayTargetActionAnimation(string targetAnimation, bool isPerforminAction, bool applyRootMotion = true, bool canRotate = false, bool canMove = false)
    {
        character.applyRootMotion = applyRootMotion;
        character.animator.CrossFade(targetAnimation, 0.2f);
        character.isPerformingAction = isPerforminAction;
        character.canRotate = canRotate;
        character.canMove = canMove;
    }
}
