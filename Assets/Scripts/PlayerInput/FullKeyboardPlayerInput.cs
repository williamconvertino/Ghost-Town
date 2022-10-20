
using UnityEngine;

public class FullKeyboardPlayerInput : PlayerInput
{
    public override MovementInput GetMovementInput()
    {
        return new MovementInput()
        {
            DirX = Input.GetAxis("Horizontal"),
            DoJump = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)|| Input.GetButton("Jump")
        };
    }
}
