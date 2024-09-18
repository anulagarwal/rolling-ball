using System;
using UnityEngine.Events;

/// <summary>
/// Container class for Serializable Events in UnityEditor.
/// </summary>
public static class Events
{

    // Additional event-definitions...

    [Serializable]
    public class Vector2 : UnityEvent<UnityEngine.Vector2> { }
}