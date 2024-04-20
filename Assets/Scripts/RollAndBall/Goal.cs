using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject GameClearPanel;

	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            GameClearPanel.SetActive(true);
            // 플레이어의  PlayerBall CanMove변수를 false로 수정하는 코드
            PlayerBall playerBall = other.gameObject.GetComponent<PlayerBall>();
            playerBall.canMove = false;
        }
    }
}
