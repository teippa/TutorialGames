using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureCommand : CommandManager.ICommand
{
    private Vector3Int m_From;
    private Vector3Int m_To;

    private Unit m_Captured;
    private Unit m_Capturing;

    public CaptureCommand(Vector3Int start, Vector3Int end)
    {
        m_From = start;
        m_To = end;
    }

    public void Execute()
    {
        m_Capturing = Gameboard.Instance.GetUnit(m_From);
        m_Captured = Gameboard.Instance.GetUnit(m_To);

        Gameboard.Instance.MoveUnit(m_Capturing, m_To);
        Gameboard.Instance.TakeOutUnit(m_Captured);
        Gameboard.Instance.SwitchTeam();
        
    }

    public void Undo()
    {
        Gameboard.Instance.MoveUnit(m_Capturing, m_From);
        Gameboard.Instance.MoveUnit(m_Captured, m_To);


        Gameboard.Instance.SwitchTeam();
    }

}
