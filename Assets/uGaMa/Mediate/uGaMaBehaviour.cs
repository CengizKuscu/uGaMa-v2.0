using System;
using uGaMa.Command;
using UnityEngine;

public class uGaMaBehaviour : MonoBehaviour
{
    internal void OnHandlerNotify(NotifyParam notify, Action<NotifyParam> callback)
    {
        callback(notify);
    }
}
