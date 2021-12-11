using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayerControl
{
    public static class GravityControl
    {
        private static List<Rigidbody2D> _rigids = new List<Rigidbody2D>();
        private static bool _top;
        
        private static void CollectAllBodies()
        {
            _rigids = Object.FindObjectsOfType<Rigidbody2D>().ToList();
            ChangeGravity();
        }

        private static void ChangeGravity()
        {
            foreach (var rb in _rigids)
            {
                rb.gravityScale *= -1;
                if (_top == false)
                    rb.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);
                else
                    rb.gameObject.transform.eulerAngles = Vector3.zero;
            }

            _top = !_top;
        }

        public static void Switch()
        {
            CollectAllBodies();
        }
    }
}