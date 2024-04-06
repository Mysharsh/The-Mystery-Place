using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Joystick.Scripts
{
    public class Charactermove : MonoBehaviour
    {
        public FloatingJoystick joystick;
        public CharacterController controller;
        public float MovSpeed;
        public float RotSpeed;
        public Canvas inputCanvas;
        public bool isJoystick;


        public Animator panimate;

        public AudioClip[] FootstepAudioClips;
        [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

        // animation IDs
        private int _animIDSpeed;
        private int _animIDMotionSpeed;


        private void Start()
        {
            EnableJoystickInput();
            AssignAnimationIDs();
        }
        public void EnableJoystickInput()
        {
            isJoystick = true;
            inputCanvas.gameObject.SetActive(true);

        }


        private void AssignAnimationIDs()
        {
            _animIDSpeed = Animator.StringToHash("Speed");
            _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        }
        // Update is called once per frame
        private void Update()
        {
            if (isJoystick)
            {
                var movementDir = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
                controller.SimpleMove(movementDir * MovSpeed);

                var targetDir = Vector3.RotateTowards(controller.transform.forward, movementDir, RotSpeed * Time.deltaTime, 0.0f);
                controller.transform.rotation = Quaternion.LookRotation(targetDir);


                panimate.SetFloat(_animIDSpeed, movementDir.magnitude * 6f);
                panimate.SetFloat(_animIDMotionSpeed, 1f);


            }

        }
        private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, FootstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(controller.center), FootstepAudioVolume);
                }
            }
        }
    }
}




