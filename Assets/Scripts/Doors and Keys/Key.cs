using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool wasUsed = false;
    private Animator animator;
    public event Action OnKeyUsed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !wasUsed)
        {
            UseKey();
        }
    }

    private void UseKey()
    {
        wasUsed = true;
        OnKeyUsed?.Invoke();
        animator.SetTrigger("used");
    }

    private void DestroyKey() // Used by animation event.
    {
        Destroy(gameObject);
    }
}
