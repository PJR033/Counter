using System;
using UnityEngine;

public class ClickTracker : MonoBehaviour
{
    public event Action IsClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsClicked?.Invoke();
        }
    }
}
