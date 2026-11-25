using UnityEngine;
using VContainer.Unity;

public class PlayerControllerInputRead : ITickable
{
    private readonly IMoveReadInput _moveInput;

    public PlayerControllerInputRead(IMoveReadInput moveInput)
    {
        _moveInput = moveInput;
    }

    public void Tick()
    {
        Vector2 move = _moveInput.ReadValue;

        if (move.sqrMagnitude < 0.0001f)
            return;   

        Debug.Log($"[Input] Move: ({move.x:F2}, {move.y:F2})  |mag={move.magnitude:F2}");
    }
}
