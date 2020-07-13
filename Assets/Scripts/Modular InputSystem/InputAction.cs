public enum InputAction
{
    None = 0,
    MoveHorizontal = 1,
    MoveVertical = 2,
    Interact = 3, //Note: There could be multiple action for this one (PickUp, Steal)
    Throw = 4,
    Jump = 5,
}