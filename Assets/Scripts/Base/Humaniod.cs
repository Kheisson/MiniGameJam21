using Gravity;
using UnityEngine;

namespace Base
{
    public abstract class Humaniod : MonoBehaviour, IImpactable
    {
        private bool _top;
        protected bool _facingRight = true;
        protected Rigidbody2D rb;
        protected Transform body;

        public virtual void Flip()
        {
            rb.gravityScale *= -1;
            if (_top == false)
                rb.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
            else
                rb.gameObject.transform.eulerAngles = Vector3.zero;

            _top = !_top;
            _facingRight = !_facingRight;
        }
    
        protected void FlipDirection()
        {
            _facingRight = !_facingRight;
            var newScale = body.localScale;
            newScale.x *= -1;
            body.localScale = newScale;
        }

    }
}
