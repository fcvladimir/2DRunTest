using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/
        public Collider2D collider2d;
        /*internal new*/
        public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        float koef = 7.3f;
        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;
        float halfWidth = Screen.width / 2;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                if (Application.platform == RuntimePlatform.Android)
                {
                    UpdatePosition();
                }
                else
                {
                    move.x = Input.GetAxis("Horizontal");
                    if (jumpState == JumpState.Grounded && Input.GetButtonDown("Jump"))
                        jumpState = JumpState.PrepareToJump;
                    else if (Input.GetButtonUp("Jump"))
                    {
                        stopJump = true;
                        Schedule<PlayerStopJump>().player = this;
                    }
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdatePosition()
        {
            if (Input.touchCount > 0 && Input.touchCount < 3)
            {
                float screenWidth = Screen.width;
                float firstQuarter = screenWidth / 4;
                float secondQuarter = screenWidth / 2;
                float fourthQuarter = 3 * screenWidth / 4;

                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch touch = Input.GetTouch(i);

                    float touchX = touch.position.x;
                    TouchPhase touchPhase = touch.phase;
                    switch (touchPhase)
                    {
                        case TouchPhase.Ended:
                            if (touchX < secondQuarter)
                            {
                                move.x = 0;
                            }
                            if (touchX > fourthQuarter)
                            {
                                stopJump = true;
                                Schedule<PlayerStopJump>().player = this;
                            }
                            break;
                        case TouchPhase.Stationary:
                        case TouchPhase.Moved:
                            if (touchX < firstQuarter)
                            {
                                if (touchPhase == TouchPhase.Stationary || touchPhase == TouchPhase.Moved)
                                {
                                    move.x = -0.1f * koef;
                                }
                                else if (touchPhase == TouchPhase.Ended)
                                {
                                    return;
                                }
                            }
                            else if (touchX > firstQuarter && touchX < secondQuarter)
                            {
                                if (touchPhase == TouchPhase.Stationary || touchPhase == TouchPhase.Moved)
                                {
                                    move.x = +0.1f * koef;
                                }
                                else if (touchPhase == TouchPhase.Ended)
                                {
                                    return;
                                }
                            }
                            break;
                        case TouchPhase.Began:
                            if (touchX > fourthQuarter)
                            {
                                jumpState = JumpState.PrepareToJump;
                            }
                            break;
                    }
                }
            }
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }

        private void Log(string msg)
        {
            Debug.Log("DEBUG: " + msg);
        }
    }
}