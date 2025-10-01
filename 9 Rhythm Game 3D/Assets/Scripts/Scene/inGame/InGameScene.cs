using UnityEngine;

public class inGameScene : BaseScene
{
    
    protected override void Init()
    {
        SceneType = EnumData.Scene.Game;
        base.Init();
        GameManager._isGameStart = true;
    }
   

    void Update()
    {
        
    }
    public override void Clear()
    {
       
    }
}
