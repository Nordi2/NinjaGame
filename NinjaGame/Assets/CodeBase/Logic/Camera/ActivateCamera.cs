using Assets.CodeBase.Logic.Player;
using UnityEngine;

namespace Assets.CodeBase.Logic.Camera
{
    public class ActivateCamera : MonoBehaviour
    {
        public PlayerAttack _player;
        public GameObject _cameraCinemaVirtual;
        private void Start()
        {
            _player.OnAttack += OnActiveCamera;
            OffActiveCamera();
        }

        private void OnDestroy() =>
            _player.OnAttack -= OnActiveCamera;
        private void OnActiveCamera()
        {
            _cameraCinemaVirtual.SetActive(true);
        }
        private void OffActiveCamera() 
        {
            _cameraCinemaVirtual.SetActive(false);
        }
    }
}