using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace thelab.mvc
{
    [CustomEditor(typeof(AudioComponent), true)]
    public class AudioComponentInspector : Editor
    {


        /// <summary>
        /// Reference to the desired object.
        /// </summary>
        new public AudioComponent target { get { return (AudioComponent)base.target; } }

        /// <summary>
        /// Draws the inspector.
        /// </summary>
        public override void OnInspectorGUI()
        {
            Type t = target.GetType();
            //Type[] tl = t.GetGenericArguments();

            while (t.Name.IndexOf("AudioComponent") < 0) t = t.BaseType;
            if (t.GetGenericArguments().Length <= 0)
            {
                base.DrawDefaultInspector();
                return;
            }

            t = t.GetGenericArguments()[0];

            Array el = Enum.GetValues(t);
            int sid = -1;
            for (int i = 0; i < el.Length; i++)
            {
                int en = (int)el.GetValue(i);
                if (en == target.type) { sid = i; break; }
            }
            Enum prev = (sid >= 0) ? (Enum)el.GetValue(sid) : default(Enum);

            Enum next = EditorGUILayout.EnumPopup("Audio Type", prev);

            int id_prev = ((int)(object)prev);
            int id_next = ((int)(object)next);

            if (id_next != id_prev)
            {
                //Debug.Log(target.type + " prev[" + prev + "," + id_prev + "]  next[" + next + "," + id_next + "]" + sid);
                target.type = id_next;
            }

        }

    }

}