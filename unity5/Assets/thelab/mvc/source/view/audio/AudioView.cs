using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using thelab.mvc;
using UnityEngine;

namespace thelab.mvc
{
    /*

    /// <summary>
    /// Class that implements sound playing features.
    /// </summary>
    public class AudioView : View
    {
        /// <summary>
        /// List of audios.
        /// </summary>
        public List<AudioComponent> audios
        {
            get { return m_audios == null ? (m_audios = new List<AudioComponent>(GetComponentsInChildren<AudioComponent>())) : m_audios; }
        }
        private List<AudioComponent> m_audios;

        /// <summary>
        /// Procura por um determinado audio de acordo com seu tipo.
        /// </summary>
        /// <param name="p_type"></param>
        /// <returns></returns>
        public AudioComponent Find<T>(T p_type) where T : IComparable
        {
            return
            audios.Find(delegate(AudioComponent it)
            {
                if (it is AudioComponent<T>) { AudioComponent<T> cit = (AudioComponent<T>)it; return cit.type.CompareTo(p_type) == 0; }
                return false;
            });
        }

        /// <summary>
        /// Finds an AudioComponent by name.
        /// </summary>
        /// <param name="p_name"></param>
        /// <returns></returns>
        public AudioComponent Find(string p_name)
        {
            Transform t = transform.Find(p_name);
            if (!t) return null;
            return t.GetComponent<AudioComponent>();
        }

        /// <summary>
        /// Plays an audio based on its type.
        /// </summary>
        /// <param name="p_type"></param>
        public void Play<T>(T p_type, float p_time = -1f, float p_volume = -1f) where T : IComparable { Play(Find<T>(p_type), p_time, p_volume); }

        /// <summary>
        /// Plays an audio based on its name.
        /// </summary>
        /// <param name="p_name"></param>
        /// <param name="p_time"></param>
        /// <param name="p_volume"></param>
        public void Play(string p_name, float p_time = -1f, float p_volume = -1f) { Play(Find(p_name), p_time, p_volume); }

        /// <summary>
        /// Plays the audio component reference.
        /// </summary>
        /// <param name="p_audio"></param>
        /// <param name="p_time"></param>
        /// <param name="p_volume"></param>
        public void Play(AudioComponent p_audio, float p_time = -1f, float p_volume = -1f)
        {
            if (p_audio == null)
            {
                Debug.LogWarning("AudioView> Tried to play null sound!");
                return;
            }
            //Log("Playing ["+p_type+"]");        
            AudioSource src = p_audio.source;
            src.Play();
            if (p_time >= 0f) src.time = p_time;
            if (p_volume >= 0f) src.volume = p_volume;
        }

        /// <summary>
        /// Stops the audio by its type and reset its time.
        /// </summary>
        /// <param name="p_type"></param>
        public void Stop<T>(T p_type) where T : IComparable { Stop(Find<T>(p_type)); }

        /// <summary>
        /// Stops the audio by its name and reset its time.
        /// </summary>
        /// <param name="p_type"></param>
        public void Stop(string p_name) { Stop(Find(p_name)); }

        /// <summary>
        /// Pause the audio
        /// </summary>
        /// <param name="p_audio"></param>
        public void Stop(AudioComponent p_audio) { if (p_audio == null) return; p_audio.source.Stop(); }

        /// <summary>
        /// Stops the audio by its type and reset its time.
        /// </summary>
        /// <param name="p_type"></param>
        public void Pause<T>(T p_type) where T : IComparable { Pause(Find<T>(p_type)); }

        /// <summary>
        /// Stops the audio by its name and reset its time.
        /// </summary>
        /// <param name="p_type"></param>
        public void Pause(string p_name) { Pause(Find(p_name)); }

        /// <summary>
        /// Stops the audio
        /// </summary>
        /// <param name="p_audio"></param>
        public void Pause(AudioComponent p_audio) { if (p_audio == null) return; p_audio.source.Pause(); }

        /// <summary>
        /// Fades the audio volume.
        /// </summary>
        /// <param name="p_type"></param>
        /// <param name="p_volume"></param>
        /// <param name="p_time"></param>
        public void Fade<T>(T p_type, float p_volume, float p_time = 0.8f) where T : IComparable { Fade(Find<T>(p_type), p_volume, p_time); }

        /// <summary>
        /// Fades the audio volume.
        /// </summary>
        /// <param name="p_type"></param>
        /// <param name="p_volume"></param>
        /// <param name="p_time"></param>
        public void Fade(string p_name, float p_volume, float p_time = 0.8f) { Fade(Find(p_name), p_volume, p_time); }

        /// <summary>
        /// Fades the audio volume.
        /// </summary>
        /// <param name="p_type"></param>
        /// <param name="p_volume"></param>
        /// <param name="p_time"></param>
        public void Fade(AudioComponent p_audio, float p_volume, float p_time = 0.8f) { if (p_audio == null) return; Tween.Add<float>(p_audio.source, "volume", p_volume, p_time, null); }

        /// <summary>
        /// Fades the audio pitch.
        /// </summary>
        /// <param name="p_type"></param>
        /// <param name="p_pitch"></param>
        /// <param name="p_time"></param>
        public void FadePitch<T>(T p_type, float p_pitch, float p_time = 0.8f) where T : IComparable { FadePitch(Find<T>(p_type), p_pitch, p_time); }

        /// <summary>
        /// Fades the audio pitch.
        /// </summary>
        /// <param name="p_type"></param>
        /// <param name="p_pitch"></param>
        /// <param name="p_time"></param>
        public void FadePitch(string p_name, float p_pitch, float p_time = 0.8f) { FadePitch(Find(p_name), p_pitch, p_time); }

        /// <summary>
        /// Fades the audio pitch.
        /// </summary>
        /// <param name="p_type"></param>
        /// <param name="p_pitch"></param>
        /// <param name="p_time"></param>
        public void FadePitch(AudioComponent p_audio, float p_pitch, float p_time = 0.8f)
        {
            if (p_audio == null) return;
            if (p_time <= 0f) { p_audio.source.pitch = p_pitch; }
            else { Tween.Add<float>(p_audio.source, "pitch", p_pitch, p_time, Cubic.Out); }
        }
    }
    //*/
}