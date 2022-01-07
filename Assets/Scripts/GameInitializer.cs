using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInitializer : IInitializable, ITickable
{
    private FlappyCubeGameStateChanger _stateChanger;
    private GameObject instructionPanelGO;
    
    public GameInitializer([Inject(Id = "InstructionPanel")] GameObject panelGO, FlappyCubeGameStateChanger stateChanger)
    {
        this._stateChanger = stateChanger;
        instructionPanelGO = panelGO;
    }
    
    public void Initialize()
    {
        _stateChanger.ChangeState(EnumGameState.Idle);
        instructionPanelGO.SetActive(true);
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _stateChanger.GameState == EnumGameState.Idle)
        {
            _stateChanger.ChangeState(EnumGameState.Play);
            instructionPanelGO.SetActive(false);
        }
    }
}
