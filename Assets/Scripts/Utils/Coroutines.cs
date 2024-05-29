using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public sealed class Coroutines : MonoBehaviour
    {
        private const string IEnumeratorException = "IEnumerator is null";
        private static Coroutines Instance
        {
            get
            {
                if (m_instance == null)
                {
                    var go = new GameObject("COROUTINES");
                    m_instance = go.AddComponent<Coroutines>();
                    DontDestroyOnLoad(go);
                }

                return m_instance;
            }
        }

        private static Coroutines m_instance;

        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            if (enumerator == null)
                throw new ArgumentNullException(IEnumeratorException);
            return Instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine(Coroutine coroutine)
        {
            if (coroutine == null)
                throw new ArgumentNullException(IEnumeratorException);
            Instance.StopCoroutine(coroutine);
        }
    }
}