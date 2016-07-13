# uGaMa

C# MVC framework adapted for Unity3D projects.

## "uGaMa Scripts" Window
Window > uGaMa Scripts

![](http://i.imgur.com/PROoPz0.png)

## Context Example

Context is a GameObject and contains your GameObjects.

![](http://i.imgur.com/GM6cFgf.png)

Create your Context Script and add component to your context gameobject

![](http://i.imgur.com/FHtAY84.png)

```
using UnityEngine;
using uGaMa.Context;

public class MainSceneContext : Context
{
    public override void Init()
    {
    }

    public override void Bindings()
    {
    }
	
    public override void UnBindings()
    {
    }
}
```

If you want to specific ScriptExecutionOrder

Note : Your order value must greater than -990 and smaller than 0 ( -990 < yourOrder < 0)

```
using UnityEngine;
using uGaMa.Context;

[ScriptOrder(-900)]
public class MainSceneContext : Context
{
}
```

## Model Example

Create your Model Interface

```
using uGaMa.Model

public interface IGameModel : IModel
{
	// your model variable
    int scoreValue { get; set; }
}
```

Create your Model

```
using uGaMa.Model

class GameModel : IGameModel
{
	private int _scoreValue = 0;
	
	public int scoreValue
    {
        get { return _scoreValue; }
        set { _scoreValue = value; }
    }
}
```

Bind your model in your Context

```
public class MainSceneContext : Context
{
	public override void Bindings()
	{
		modelMap.Bind<IGameModel>().To<GameModel>();
	}
}
```

Get your model from commands or mediators

```

GameModel gameModel = uManager.GetModel<IGameModel>() as GameModel;

```

## Command Example

Create your command key

```
public enum GameEvents
{
    UPDATE_SCORE
    //Other keys
}
```

Execute your command in other commands or mediators

```
// single Command
dispatcher.Dispatch(GameEvents.UPDATE_SCORE);

// use param
dispatcher.Dispatch(GameEvents.UPDATE_SCORE, yourData);

//use message
dispatcher.Dispatch(GameEvents.UPDATE_SCORE, yourData, yourMessage);
```

Bind your commands in your Context

```
public class MainSceneContext : Context
{
	public override void Bindings()
	{
		commandMap.Bind(GameEvents.UPDATE_SCORE).To<UpdateScoreCMD>();
	}
}
```

If you want to Chain Commands

```
public class MainSceneContext : Context
{
	public override void Bindings()
	{
		commandMap.Bind(GameEvents.YOUR_KEY).To<CMD1>().To<CMD2>();
	}
}
```

Create your Command

```
public class UpdateScoreCMD : Command
{
    public override void Execute(NotifyParam notify)
    {
        YourData yourData = notify.data as YourData;
		YourMessage yourMessage = notify.msg as YourMessage;
    }
}
```

##Mediator Example

Create your View Script and add to a GameObject in hierarchy.

```
public class YourView : View
{
	
}
```

Create a Mediator Script 

```

public class YourViewMED : Mediator
{
    public override void OnRegister()
    {
    }
	
    public override void OnRemove()
    {
    }	
}
```

Bind your mediators in your Context

```
public class MainSceneContext : Context
{
	public override void Bindings()
	{
		mediatorMap.Bind<YourView>().To<YourViewMED>();
	}
}
```

Get Mediator

```

YourViewMED mediator = uManager.GetMediator<YourView>() as YourViewMED;

```

Handle any of the commands in the mediators.

```
public class YourViewMED : Mediator
{
    public override void OnRegister()
    {
		AddListener(GameEvents.UPDATE_SCORE, UpdateScore);
    }
	
    private void UpdateScore(NotifyParam param)
    {
        
    }	
}
```

Remove handle

```

RemoveListener(GameEvents.UPDATE_SCORE, UpdateScore);

```