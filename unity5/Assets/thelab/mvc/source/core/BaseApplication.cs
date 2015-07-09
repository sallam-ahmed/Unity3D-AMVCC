using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Extension of the BaseApplication class to handle different types of Model View Controllers.
/// </summary>
/// <typeparam name="M"></typeparam>
/// <typeparam name="V"></typeparam>
/// <typeparam name="C"></typeparam>
public class BaseApplication<M,V,C> : BaseApplication where M : Element where V : Element where C : Element
{
    /// <summary>
    /// Model reference using the new type.
    /// </summary>
    new public M model { get { return (M)(object)base.model; } }

    /// <summary>
    /// View reference using the new type.
    /// </summary>
    new public V view { get { return (V)(object)base.view; } }

    /// <summary>
    /// Controller reference using the new type.
    /// </summary>
    new public C controller { get { return (C)(object)base.controller; } }
}

/// <summary>
/// Root class for the scene's scripts.
/// </summary>
public class BaseApplication : Element
{
    /// <summary>
    /// Arguments to be passed between scenes.
    /// </summary>
    static List<string> _args { get { return m_args == null ? (m_args = new List<string>()) : m_args; } }
    static List<string> m_args;

    /// <summary>
    /// Flag that indicates the first scene was loaded.
    /// </summary>
    static bool m_first_scene;

    /// <summary>
    /// Little static init.
    /// </summary>
    static BaseApplication() { m_first_scene = true; }

    /// <summary>
    /// Arguments passed between scenes.
    /// </summary>
    public List<string> args { get { return m_args; } }

    /// <summary>
    /// Verbose Level.
    /// </summary>
    public int verbose;

    /// <summary>
    /// Fetches the root Model instance.
    /// </summary>
    public Model model { get { return m_model = Assert<Model>(m_model); } }
    private Model m_model;

    /// <summary>
    /// Fetches the root View instance.
    /// </summary>
    public View view { get { return m_view = Assert<View>(m_view); } }
    private View m_view;

    /// <summary>
    /// Fetches the root Controller instance.
    /// </summary>
    public Controller controller { get { return m_controller = Assert<Controller>(m_controller); } }
    private Controller m_controller;

    /// <summary>
    /// Initialization.
    /// </summary>
    virtual protected void Awake()
    {
        if (m_first_scene) { m_first_scene = false; OnLevelWasLoaded(Application.loadedLevel); }
    }

    /// <summary>
    /// Capture the level loaded event and notify controllers for 'starting' purposes.
    /// </summary>
    /// <param name="p_level"></param>
    private void OnLevelWasLoaded(int p_level)
    {
        Notify("scene.load", Application.loadedLevelName, Application.loadedLevel);
    }

    /// <summary>
    /// Notifies all application's controllers.
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_target"></param>
    /// <param name="p_data"></param>
    public void Notify(string p_event,Object p_target,params object[] p_data)
    {
        Controller root   = transform.GetComponentInChildren<Controller>();
        Controller[] list = root.GetComponentsInChildren<Controller>();
        for (int i = 0; i < list.Length; i++) list[i].OnNotification(p_event, p_target, p_data);
    }
	
}
