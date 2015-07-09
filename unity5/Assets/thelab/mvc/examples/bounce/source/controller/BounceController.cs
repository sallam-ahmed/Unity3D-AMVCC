using UnityEngine;
using System.Collections;
using thelab.mvc;

public class BounceController : Controller<BounceApplication>
{
    
    /// <summary>
    /// Handle notifications from the application.
    /// </summary>
    /// <param name="p_event"></param>
    /// <param name="p_target"></param>
    /// <param name="p_data"></param>
    public override void OnNotification(string p_event, Object p_target, params object[] p_data)
    {
        switch(p_event)
        {
            case "scene.load":                
                Log("Scene [" + p_data[0] + "]["+p_data[1]+"] loaded");
                break;
            case "ball.hit":
                string who = (string)p_data[0];
                if(who=="ground")
                {
                    app.model.bounces++;
                    Log("Hit " + app.model.bounces);
                    if(app.model.bounces>=app.model.winCondition)
                    {
                        app.view.ball.enabled = false;
                        app.view.ball.GetComponent<Rigidbody>().isKinematic = true;
                        Notify("game.complete");
                    }
                }
                break;

            case "game.complete":
                Log("Victory!");
                break;
        }
    }
	
}
