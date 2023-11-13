using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarCryProjectile : MonoBehaviour
{
    public static event EventHandler OnAnyWarCryExploded;

    [SerializeField] private Transform warCryExplodeVfxPrefab;

    private Vector3 targetPosition;
    private Action onWarCryBehaviourComplete;

    private bool hasExploded = false;

    private void Update()
    {
        if (hasExploded)
        {
            // 이미 폭발한 경우, Update를 더 이상 실행하지 않습니다.
            return;
        }

        // 이 부분을 수정하여 필요한 폭발 및 피해 처리 로직을 추가합니다.
        // 예: 주변의 유닛에게만 피해를 입히고 폭발 이펙트를 재생합니다.

        float damageRadius = 4f;
        Collider[] colliderArray = Physics.OverlapSphere(targetPosition, damageRadius);

        foreach (Collider collider in colliderArray)
        {
            if (collider != gameObject) // 자신에게는 데미지를 입히지 않도록 체크
            {
                if (collider.TryGetComponent<Unit>(out Unit targetUnit))
                {
                    // 주변 유닛에게만 데미지를 입히도록 유닛 체크
                    targetUnit.Damage(30);
                }
            }
        }

        OnAnyWarCryExploded?.Invoke(this, EventArgs.Empty);

        Instantiate(warCryExplodeVfxPrefab, targetPosition + Vector3.up * 1f, Quaternion.identity);

        // 폭발 및 피해 처리 후 동작 완료를 알립니다.
        hasExploded = true; // 폭발 상태로 변경

        Debug.Log("WarCryProjectile: 폭발 및 피해 처리가 완료되었습니다.");
    
        onWarCryBehaviourComplete(); // 동작 완료 함수 호출
    }

    public void Setup(GridPosition targetGridPosition, Action onWarCryBehaviourComplete)
    {
        this.onWarCryBehaviourComplete = onWarCryBehaviourComplete;
        targetPosition = LevelGrid.Instance.GetWorldPosition(targetGridPosition);
    }
}
