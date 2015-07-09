using UnityEngine;
using System.Collections;

/// <summary>
/// Root class for all views.
/// </summary>
public class BounceView : View<BounceApplication>
{

    /// <summary>
    /// Reference to the Ball view.
    /// </summary>
    public BallView ball { get { return m_ball = Assert<BallView>(m_ball); } }
    private BallView m_ball;
}
