using System;
using UnityEngine;

public class UpgradeScreen : Screen
{
    [SerializeField, Tooltip("Higher positive value equals faster fade in/out animation.")] private float _time;

    public event Action ShowCanvas;

    public override void Close()
    {
        CanvasGroup.InstantClose();
    }

    public override void Open()
    {
        ShowCanvas?.Invoke();
        CanvasGroup.InstantOpen();
    }
}
