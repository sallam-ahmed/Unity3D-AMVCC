using UnityEngine;
using System.Collections;

/// <summary>
/// Class that describes the falling ball.
/// </summary>
public class BallView : View<BounceApplication> 
{

    /// <summary>
    /// Callback called upon collision.
    /// </summary>
    /// <param name="p_collision"></param>
    public void OnCollisionEnter(Collision p_collision)
    {
        Notify("ball.hit", "ground");
    }
	
}
