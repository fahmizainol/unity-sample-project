using UnityEngine;
using UnityEngine.InputSystem;

public interface IBaseState
{
    void Enter(Animator animator);
    void Exit();
    IBaseState Update(PlayerInput input, Rigidbody2D rb);

}