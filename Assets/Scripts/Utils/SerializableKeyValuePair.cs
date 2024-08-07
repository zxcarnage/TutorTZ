using System;

namespace Utils
{
    [Serializable]
    public struct SerializableKeyValuePair <TKey, TValue>
    {
        public TKey Key;
        public TValue Value;
    }

}