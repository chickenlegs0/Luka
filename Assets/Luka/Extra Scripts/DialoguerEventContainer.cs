using DialoguerCore;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Holds unity events to be used for the dialoguer Send Message tool
///
/// Ruben Sanchez
/// 7/18/18
/// </summary>
public class DialoguerEventContainer : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDialogueAction;



    private void OnEnable()
    {
        DialoguerEventManager.onMessageEvent += HandleEvent;
    }

    private void HandleEvent(string name, string meta)
    {
        OnDialogueAction.Invoke();
    }

    private void OnDisable()
    {
        DialoguerEventManager.onMessageEvent -= HandleEvent;
    }
}
