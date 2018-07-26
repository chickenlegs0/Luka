using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Serializes ObjectInfo
///
/// Ruben Sanchez
/// 7/19/18
/// </summary>
public class SaveObjectState : MonoBehaviour
{
    void OnDisable()
    {
        SaveState(false);
    }

    void OnEnable()
    { 
        LoadState();
    }

    public void Reset(ObjectInfo info)
    {
        if (info.hasBeenDestroyed)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = info.savedPosition;
        transform.eulerAngles = info.savedEulerAngles;
    }

    public void SaveState(bool destroyed)
    {
        ObjectInfo newInfo = new ObjectInfo(transform.position, transform.eulerAngles, destroyed);

        string serialized = JsonUtility.ToJson(newInfo); 
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name + gameObject.name, serialized);
    }

    public void LoadState()
    {
        string serialized = PlayerPrefs.GetString(SceneManager.GetActiveScene().name + gameObject.name);

        if (!string.IsNullOrEmpty(serialized))
        {
            Reset(JsonUtility.FromJson<ObjectInfo>(serialized));
        }
    }
}
