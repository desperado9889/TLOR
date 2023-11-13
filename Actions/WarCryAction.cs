using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarCryAction : BaseAction
{

    public event EventHandler OnWarCry;

    [SerializeField] private Transform warCryProjectilePrefab;


    private int maxThrowDistance = 1;

    private void Update()
    {
        if (!isActive)
        {
            return;
        }
    }


    public override string GetActionName()
    {
        return "WarCry";
    }

    public override EnemyAIAction GetEnemyAIAction(GridPosition gridPosition)
    {
        Unit targetUnit = LevelGrid.Instance.GetUnitAtGridPosition(gridPosition);

        return new EnemyAIAction
        {
            gridPosition = gridPosition,
            actionValue = 200,
        };
    }

    public override List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosition = unit.GetGridPosition();

        for (int x = -maxThrowDistance; x <= maxThrowDistance; x++)
        {
            for (int z = -maxThrowDistance; z <= maxThrowDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridPosition + offsetGridPosition;

                if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                int testDistance = Mathf.Abs(x) + Mathf.Abs(z);
                if (testDistance > maxThrowDistance)
                {
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }

    public override void TakeAction(GridPosition gridPosition, Action onActionComplete)
    {
        Transform warCryProjectileTransform = Instantiate(warCryProjectilePrefab, unit.GetWorldPosition(), Quaternion.identity);
        WarCryProjectile warCryProjectile = warCryProjectileTransform.GetComponent<WarCryProjectile>();
        OnWarCry?.Invoke(this, EventArgs.Empty);
        warCryProjectile.Setup(gridPosition, OnWarCryBehaviourComplete);

        ActionStart(onActionComplete);
    }

    private void OnWarCryBehaviourComplete()
    {
        ActionComplete();
    }

}
