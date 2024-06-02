using Assets.CodeBase.Logic.Player;
using UnityEngine;

public class PlayerAnimationsEvent : MonoBehaviour
{
    private PlayerMovement _player;
    private void Start() =>
        _player = GetComponentInParent<PlayerMovement>();
    public void AnimationTriggerOn() =>
        _player.AnimationTriggerOn();
    public void AnimationTriggerOff() =>
       _player.AnimatiomTriggerOff();

}
