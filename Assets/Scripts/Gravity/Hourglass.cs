using System;
using System.Collections;
using System.Collections.Generic;
using PlayerControl;
using UnityEngine;

namespace Gravity
{
    public class Hourglass : MonoBehaviour, IImpactable
    {
        
        [SerializeField] private float fillPerSecond = 0.15f;
        private int direction = 1; // 1 for down, -1 for up.
        private float flow = 0.5f; // how much the bottom is full;

        private Animator _anim;

        private void Awake()
        {
            _anim = GetComponent<Animator>();
        }

        private void Start()
        {
            _anim.SetInteger("direction", direction);
        }

        private void Update()
        {
            flow += fillPerSecond * direction * Time.deltaTime;
            _anim.SetFloat("flow", flow);
        }


        public void Flip()
        {
            direction *= -1;
            _anim.SetInteger("direction", direction);
        }

        public void TimeOut() // called by animation event
        {
            var player = FindObjectOfType<PlayerInput>();
            if (player != null)
            {
                player.enabled = false;
            }

            Time.timeScale = Mathf.Epsilon;
            StartCoroutine(SceneLoader.Instance.GameOver());
        }
    }

}