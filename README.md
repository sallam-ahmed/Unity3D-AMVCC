![logo](http://thelaborat.org/unity/mvc/img/header-128.png)
# Model-View-Controller for Unity3D
  
Minimalistic C# MVC framework adapted for Unity3D projects.

# Features

* Separate your game in Data, Features and Workflow.
* Parallelize work and improve code production.
* Standardize your projects and keep a consistent workflow even for different teams.
* Easy to learn and follow. Don't suffer with a myriad of coding styles between projects. 
* Legacy projects will still be readable for future audiences!  

# Asset Store

https://www.assetstore.unity3d.com/#!/content/41487

# Install  
  
* Clone this repository into your machine
* Check the `unity5/Deploy/` folder
* Double click the `.unitypackage` file with your desired version

# Usage

* Create the main Application, Model, View and Controller classes.
 * `class MyModel : Model<MyApp> {}`
 * `class MyView : View<MyApp> {}`
 * `class MyController : Controller<MyApp> {}`
 * `class MyApp : BaseApplication<MyModel,MyView,MyController> {}`


Create your basic hierarchy setup in the **Inspector Panel**  

```
  - application [MyApp]
   - model [MyModel]
   - controller [MyController]
   - view [MyView]
    + player [PlayerView]
```

Adjust your `View` class to give access to the `PlayerView`.  

```
#!c#
public class MyView : View<MyApp>
{
  //Searches in the hierarchy for a 'PlayerView' and store its reference.
  public PlayerView player { get { return m_player = Assert<PlayerView>(m_player); } }
  private PlayerView m_player;
}
```

Create the `PlayerView` class.

```
#!c#
public class PlayerView : View<MyApp>
{
  //Player features
  public void Attack();
  public void Jump();
  public void Damage();
  public void Die();

  //Player Events
  void OnCollisionEnter(Collision c)
  {
    //Will notify all controllers about this event
    Notify("player.collision",c.transform);
  } 
}
```

Update the `MyModel` class to handle some game data.

```
#!c#
public class MyModel : Model<MyApp>
{
  //Some player life
  public float life;

  //Some damage constant
  public float damage;

  //Player lives
  public int lives;
}

```


Update the `MyController` class to handle notifications.

```
#!c#
public class MyController : Controller<MyApp>
{
  //Override this method to handle notifications emmited during execution.
  override public void OnNotification(string p_event,UnityEngine.Object p_target,params object[] p_data)
  {
    switch(p_event)
    {

      case "scene.load":
        //Notification called after the scene is loaded.
        Log("Scene name["+p_data[0]+"] id["+p_data[1]+"] loaded!");
      break;

      case "player.collision":
        PlayerView p  = (PlayerView)p_target;
        Transform obj = (Transform)p_data[0];
        //Handle collision for the given 'obj'
        app.model.life -= app.model.damage;
        p.Damage(); //Play some damage animation.
        if(app.model.life <= 0f)
        {
          app.model.lives--;
          if(app.model.lives>0)
          {
            app.model.life = 100f;           
          }
          else
          {
            p.Die(); //Play death animation.
            Notify("game.fail");
          }  
        }
      break;

      case "game.fail":
        //Show a Game Over modal...
      break;
 
    }
  }
}
```

# Documentation  

Link [http://goo.gl/307V5J]


# Examples  

* After installing the `.unitypackage`, the folder `thelab` should be available in your project.  
* Open the scene `thelab/mvc/examples/bounce/bounce.unity3d` and check how the this scene's MVC was created.