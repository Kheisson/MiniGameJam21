using System;
using System.Collections.Generic;
using System.Linq;
using Audio;
using Gravity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PlayerControl
{
    public static class GravityControl
    {
        private static IEnumerable<IImpactable> _impactables;

        private static void CollectAllBodies()
        {
            _impactables = Object.FindObjectsOfType<MonoBehaviour>().OfType<IImpactable>();
            ChangeGravity();
        }

        private static void ChangeGravity()
        {
            foreach (var body in _impactables)
            {
                body.Flip();
            }
        }

        public static void Switch()
        {
            CollectAllBodies();
            AudioManager.Instance.PlaySFX(SFX.GravitationChangeSfx);
        }
    }
}