using UnityEngine;
using System.Collections;
using thelab.mvc;

/// <summary>
/// Class that handles the application data.
/// </summary>
public class BounceModel : Model<BounceApplication>
{
    /// <summary>
    /// Bounce counter.
    /// </summary>
    public int bounces;

    /// <summary>
    /// Win condition.
    /// </summary>
    public int winCondition;
	
}
