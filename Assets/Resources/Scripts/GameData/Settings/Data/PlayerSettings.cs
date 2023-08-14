using System;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Settings/PlayerSettings", order = 1)]
    [Serializable]
    public class PlayerSettings : ScriptableObject
    {
        public KeyCode keyMoveLeft;
        public KeyCode keyMoveRight;
        public KeyCode keyMoveUp;
        public KeyCode keyMoveDown;
    }
}
