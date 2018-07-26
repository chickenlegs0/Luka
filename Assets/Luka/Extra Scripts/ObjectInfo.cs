using UnityEngine;

/// <summary>
/// Stores info about the transform of an object, as well as if its been destroyed
///
/// Ruben Sanchez
/// 7/19/18
/// </summary>
[System.Serializable]
public class ObjectInfo 
{
    public Vector2 savedPosition;
    public Vector3 savedEulerAngles;
    public bool hasBeenDestroyed;

    public ObjectInfo(Vector2 newPosition, Vector3 newEulerAngles, bool newHasBeenDestroyed)
    {
        savedPosition = newPosition;
        savedEulerAngles = newEulerAngles;
        hasBeenDestroyed = newHasBeenDestroyed;
    }
}
