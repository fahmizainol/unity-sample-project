using UnityEngine;
public interface IBaseState
{
    void Enter();
    void Exit();
    void Update();
    void Transition();
}