using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Albasigma.ARPG{
    /// <summary>
    /// Methods for the player animations 
    /// </summary>
    public class PlayerAnimationController : MonoBehaviour
    {
        Animator ani;

        public bool isRunning { get => ani.GetBool("Running"); }

        public Animator animator => ani; 

        private void Awake()
        {
            ani = GetComponentInChildren<Animator>();
        }

        public void AttackAniTrigger()
        {
            if (!GetComponent<PlayerInteractionController>().InInteractableInRange)
            {
                ani.SetTrigger("Attack");
            }
        }

        public void LedgeGrab()
        {
            if (!ani.GetCurrentAnimatorStateInfo(0).IsName("LedgeGrab") && !ani.GetCurrentAnimatorStateInfo(0).IsName("Standing up"))
            {
                ani.Play("LedgeGrab");
            }
        }

        public void UpFromLedge()
        {
            ani.SetTrigger("UpFromLedge");
        }

        public void ComboNumber(int HitNum)
        {
            ani.SetInteger("Combo_Number", HitNum);
        }

        public void StartRunning()
        {
            ani.SetBool("Running", true);
        }

        public void StopRunning()
        {
            ani.SetBool("Running", false);
        }

        public void isGrounded(bool grounded)
        {
            ani.SetBool("Grounded", grounded);
        }

        public void GlideTrigger()
        {
            ani.SetTrigger("Glide");
        }

        public void Block()
        {
            ani.SetBool("Blocking", true);
        }

        public void StopBlock()
        {
            ani.SetBool("Blocking", false);
        }

        public void CastSpell()
        {
            ani.SetTrigger("Casting");
        }
    }
}