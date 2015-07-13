using UnityEngine;
using System.Collections;

namespace thelab.mvc
{    
    /// <summary>
    /// View class that detects and notifies trigger related events.
    /// </summary>
    public class TriggerView : ColliderView
    {
        /// <summary>
        /// Callbacks when a Trigger Collider suffers interaction.
        /// </summary>
        /// <param name="p_collider"></param>
        void OnTriggerEnter(Collider p_collider) { if(enter) Notify(notification + ".trigger.enter",p_collider); }
        void OnTriggerExit(Collider p_collider)  { if(exit)  Notify(notification + ".trigger.exit", p_collider); }
        void OnTriggerStay(Collider p_collider)  { if(stay)  Notify(notification + ".trigger.stay", p_collider); }
    }

}