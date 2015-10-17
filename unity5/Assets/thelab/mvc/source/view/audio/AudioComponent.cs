using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace thelab.mvc
{

    /// <summary>
    /// Class that represents a single audio.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AudioComponent<T> : AudioComponent where T : IComparable
    {
        /// <summary>
        /// Enumaration or othe identifier of this audio.
        /// </summary>
        new public T type
        {
            get
            {
                Array el = Enum.GetValues(typeof(T));
                if (base.type < 0) return el.Length <= 0 ? default(T) : ((T)(object)el.GetValue(0));
                return (T)(object)el.GetValue(base.type);
            }
            set { base.type = (int)(object)value; }
        }
    }

    /// <summary>
    /// Base class of the audio component.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AudioComponent : MonoBehaviour
    {
        /// <summary>
        /// Enumeration value of this audio for identification.
        /// </summary>
        public int type;

        /// <summary>
        /// Returns the audio source of this component.
        /// </summary>
        public AudioSource source { get { return GetComponent<AudioSource>(); } }
    }

}