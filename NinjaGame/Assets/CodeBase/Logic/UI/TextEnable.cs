using Assets.CodeBase.Logic.Enemy;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.Logic.UI
{
    public class TextEnable : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private TriggerObserver _triggerObserver;
        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += OnText;
            _triggerObserver.TriggerExit += OffText;
        }
        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= OnText;
            _triggerObserver.TriggerExit -= OffText;
        }

        private void Start() =>
            _text.gameObject.SetActive(false);

        private void OffText(Collider obj) =>
            _text.gameObject.SetActive(false);

        private void OnText(Collider obj) =>
            _text.gameObject.SetActive(true);
    }
}