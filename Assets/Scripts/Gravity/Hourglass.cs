using System.Collections;
using System.Collections.Generic;
using PlayerControl;
using UnityEngine;

namespace Gravity
{
    public class Hourglass : MonoBehaviour
    {
        void Flip() // called by animation event
        {
            GravityControl.Switch();
        }
    }

}