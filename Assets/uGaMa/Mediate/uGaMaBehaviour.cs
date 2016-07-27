using UnityEngine;
using System.Collections;
using System;
using uGaMa.Command;

public class uGaMaBehaviour : MonoBehaviour
{
    internal void OnHandlerNotify(NotifyParam notify, Action<NotifyParam> callback)
    {
        callback(notify);
    }
}
