using UnityEngine;
using System.Collections;

namespace thelab.mvc
{
    /// <summary>
    /// 
    /// </summary>
    public class ColliderView : ColliderView<BaseApplication> { }

    /// <summary>
    /// Base class for collision related classes.
    /// </summary>
    public class ColliderView<T> : NotificationView<T> where T : BaseApplication
    {
        /// <summary>
        /// This View's Collider.
        /// </summary>
        new public Collider collider { get { return m_collider = AssertLocal<Collider>(m_collider); } }
        private Collider m_collider;

        /// <summary>
        /// Flags indicating the sub-category of notification.
        /// </summary>        
        public bool enter=true;
        public bool exit=false;
        public bool stay=false;
    }
}