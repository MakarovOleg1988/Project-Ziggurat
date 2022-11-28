using UnityEngine;

namespace Ziggurat
{
    public class PlayerController : PlayerComponentAssistant
    {

        public Rigidbody _rb;
        public NewControls _controller;

        private void Awake()
        {
            _controller = new NewControls();
        }

        private void OnEnable()
        {
            _controller.Enable();
        }

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            OnMovement();
        }

        private void OnMovement()
        {
            var valueUp = _controller.Actionmap.MovementUp.ReadValue<float>();
            transform.Translate(Vector3.forward * valueUp * _speedMovement * Time.deltaTime);
            var valueRight = _controller.Actionmap.MovementRight.ReadValue<float>();
            transform.Translate(Vector3.right * valueRight * _speedMovement * Time.deltaTime);
            var valueHeight = _controller.Actionmap.MovementHeight.ReadValue<float>();
            transform.Translate(Vector3.up * valueHeight * _speedMovement * Time.deltaTime);
        }
    }
}
