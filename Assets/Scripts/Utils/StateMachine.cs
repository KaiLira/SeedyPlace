using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// State machine that works by enabling and disabling objects in the scene
/// 
/// Each object must contain the desired behavior for that specific state
/// </summary>
public class StateMachine : MonoBehaviour
{
    [SerializeField]
    private GameObject _defaultState;
    public Stack<GameObject> _states = new();

    void Start()
    {
        PushState(_defaultState);
    }

    public void PushState(GameObject state)
    {
        if (_states.TryPeek(out var last))
            last.SetActive(false);

        state.SetActive(true);
        _states.Push(state);
    }

    public void PopStates(int count = 1)
    {
        if (count <= 0)
            return;

        var last = _states.Pop();
        last.SetActive(false);

        if (_states.TryPeek(out last))
            last.SetActive(true);

        PopStates(count - 1);
    }

    public void SetState(GameObject state)
    {
        if (_states.TryPop(out var last))
            last.SetActive(false);

        state.SetActive(true);
        _states = new(new GameObject[1] {state});
    }
}
