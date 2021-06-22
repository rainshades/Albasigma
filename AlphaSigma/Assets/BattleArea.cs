using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Albasigma.TRPG
{
    public class BattleArea : MonoBehaviour
    {
        [SerializeField]
        GameObject PlayerArea_1, PlayerArea_2, PlayerArea_3, EnemyArea_1, EnemyArea_2, EnemyArea_3;


        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(PlayerArea_1.transform.position, 1.0f);
            Gizmos.DrawWireSphere(PlayerArea_2.transform.position, 1.0f);
            Gizmos.DrawWireSphere(PlayerArea_3.transform.position, 1.0f);
            Gizmos.DrawWireSphere(EnemyArea_1.transform.position, 1.0f);
            Gizmos.DrawWireSphere(EnemyArea_2.transform.position, 1.0f);
            Gizmos.DrawWireSphere(EnemyArea_3.transform.position, 1.0f);
        }

    }
}