using System;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(HitPointsComponent))]
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private HitPointsComponent hitPoints;
        [SerializeField] private GameObject character; 
        [SerializeField] private GameManager gameManager;

        private void OnValidate()
        {
            this.hitPoints = GetComponent<HitPointsComponent>();
        }

        private void OnEnable()
        {
            this.hitPoints.hpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            this.hitPoints.hpEmpty -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => this.gameManager.FinishGame();
    }
}