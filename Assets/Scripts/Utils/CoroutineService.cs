using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public sealed class CoroutineService : MonoBehaviour
    {
        public Coroutine StartRoutine(IEnumerator enumerator)
        {
            InvariantChecker.CheckObjectInvariant(enumerator);
            return StartCoroutine(enumerator);
        }

        public void StopRoutine(Coroutine coroutine)
        {
            InvariantChecker.CheckObjectInvariant(coroutine);
            StopCoroutine(coroutine);
        }
    }
}