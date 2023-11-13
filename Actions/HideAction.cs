using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAction : BaseAction
{
    private bool isHiding = false; // 숨은 상태 여부를 나타내는 변수

    public override string GetActionName()
    {
        return "Hide";
    }

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = 0,
        };
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        GridPosition unitGridPosition = unit.GetGridPosition();

        return new List<GridPosition>
        {
            unitGridPosition
        };
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        if (isHiding)
        {
            // 이미 숨은 상태라면 숨음을 해제하고 레이어를 "Units"로 변경
            unit.gameObject.layer = LayerMask.NameToLayer("Units");
            isHiding = false;
        }
        else
        {
            // 아직 숨지 않은 상태라면 숨음을 시작하고 레이어를 "Obstacles"로 변경
            unit.gameObject.layer = LayerMask.NameToLayer("Obstacles");
            isHiding = true;
        }
    }

    public void EndHideAction()
    {
        if (isHiding)
        {
            // 숨은 상태에서 숨음을 해제하고 레이어를 "Units"로 변경
            unit.gameObject.layer = LayerMask.NameToLayer("Units");
            isHiding = false;
            ActionComplete();
        }
    }
}
