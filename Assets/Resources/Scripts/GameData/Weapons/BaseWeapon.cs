using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        public void SetCenter()
        {
            transform.position = transform.parent.position;
        }
    }

}