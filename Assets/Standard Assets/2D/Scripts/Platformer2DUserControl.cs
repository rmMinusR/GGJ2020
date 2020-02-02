using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    [RequireComponent(typeof (AudioSource))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

        public string xAxis = "Horizontal";
        public string yAxis = "Vertical";
        public string jumpAxis = "Jump";

        public AudioSource jumpSound;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown(jumpAxis);
                if (m_Jump) jumpSound.Play();
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = false;// CrossPlatformInputManager.GetAxis(yAxis) < -0.1f;
            float h = CrossPlatformInputManager.GetAxis(xAxis);
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
