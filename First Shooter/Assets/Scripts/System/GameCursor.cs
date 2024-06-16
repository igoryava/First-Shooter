using UnityEngine;
using System;

public class GameCursor : MonoBehaviour
{
    private void OnEnable()
    {
        HideCursor();
    }

    public void HideCursor()
    {
        SetCursorVisiblle(CursorLockMode.Locked, false);
    }

    public void ShowCursor()
    {
        SetCursorVisiblle(CursorLockMode.None, true);
    }

    private void SetCursorVisiblle(CursorLockMode lockMode, bool cursorVisible)
    {
        Cursor.lockState = lockMode;
        Cursor.visible = cursorVisible;
    }
}
