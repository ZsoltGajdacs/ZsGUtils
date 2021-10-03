using System;
using System.Collections.Generic;

namespace ZsGUtils.Keys
{
    public class KeyPair<O, T> : IEquatable<KeyPair<O, T>>
    {
        public O KeyOne { get; private set; }
        public T KeyTwo { get; private set; }

        public KeyPair(O keyOne, T keyTwo)
        {
            KeyOne = keyOne;
            KeyTwo = keyTwo;
        }

        public void UpdateKeyOne(O keyOne)
        {
            KeyOne = keyOne;
        }

        public void UpdateKeyTwo(T keyTwo)
        {
            KeyTwo = keyTwo;
        }

        #region Support methods
        public override bool Equals(object obj)
        {
            return Equals(obj as KeyPair<O, T>);
        }

        public bool Equals(KeyPair<O, T> other)
        {
            return other != null &&
                   EqualityComparer<O>.Default.Equals(KeyOne, other.KeyOne) &&
                   EqualityComparer<T>.Default.Equals(KeyTwo, other.KeyTwo);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(KeyOne, KeyTwo);
        }

        public static bool operator ==(KeyPair<O, T> left, KeyPair<O, T> right)
        {
            return EqualityComparer<KeyPair<O, T>>.Default.Equals(left, right);
        }

        public static bool operator !=(KeyPair<O, T> left, KeyPair<O, T> right)
        {
            return !(left == right);
        }
        #endregion
    }
}
