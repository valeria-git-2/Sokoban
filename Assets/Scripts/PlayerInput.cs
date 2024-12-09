using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;

    public bool IsMovingUp { get; private set; }
    public bool IsMovingDown { get; private set; }
    public bool IsMovingLeft { get; private set; }
    public bool IsMovingRight { get; private set; }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        IsMovingUp = Input.GetKeyDown(upKey);
        if(IsMovingUp )
        {
            GameMap.ChangeMovable(deltaX: 0, deltaY: 1);
            return;
        }
        IsMovingDown = Input.GetKeyDown(downKey);
        if (IsMovingDown)
        {
            GameMap.ChangeMovable(deltaX: 0, deltaY: -1);
            return;
        }
        IsMovingLeft = Input.GetKeyDown(leftKey);
        if (IsMovingLeft)
        {
            GameMap.ChangeMovable(deltaX: -1, deltaY: 0);
            return;
        }
        IsMovingRight = Input.GetKeyDown(rightKey);
        if (IsMovingRight)
        {
            GameMap.ChangeMovable(deltaX: 1, deltaY: 0);
            return;
        }
    }
}
