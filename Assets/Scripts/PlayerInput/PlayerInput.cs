using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInput : MonoBehaviour
{
    public abstract MovementInput GetMovementInput();
    //public abstract InteractionInput GetInteractionInput();
    //public abstract ItemInput GetItemInput();
    //public abstract MenuInput GetMenuInput();

    //Information about how the player wants to move.
    public struct MovementInput
    {
        public float DirX;
        public bool DoJump;
    }

    //Information about how the player wants to interact with the environment.
    public struct InteractionInput
    {
        public bool DoItemInteraction;
        public bool DoLightBulbInteraction;
    }
    
    //Information about how the player wants to use their items.
    public struct ItemInput
    {
        public bool DoItemStatusToggle;
    }
    
    //Information about how the player wants to interact with the menu.
    public struct MenuInput
    {
        public bool DoToggleEscapeMenu;
    }
}
