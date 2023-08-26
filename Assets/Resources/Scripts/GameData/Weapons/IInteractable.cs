using System.Collections;
using System.Collections.Generic;
using GameJam;
using UnityEngine;

public interface IInteractable
{
    void PickUp(TestWeapon item);
    void Drop(TestWeapon item);
}
