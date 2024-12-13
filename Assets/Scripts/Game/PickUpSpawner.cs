using System;
using System.Collections;
using System.Collections.Generic;
using Catch.Game.PickUps;
using Catch.Services;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Catch.Game
{
    public class PickUpSpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<PickUpAndProbability> _pickUpsVariants;
        [SerializeField] private float _baseSpawnRate = 2f;
        [SerializeField] private float _spawnRateGain = 15f;
        [SerializeField] private float _spawnRateGainDelay = 2f;

        [SerializeField] private float _spawnRate;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _spawnRate = _baseSpawnRate;
            StartSpawning();
            StartIncreasingSpawnRate();
        }

        #endregion

        #region Private methods

        private float GetRandomDelayBasedOnRate()
        {
            return Random.Range(1f / _spawnRate, 2f / _spawnRate);
        }

        private PickUp GetRandomDrop()
        {
            float sum = 0f;

            foreach (PickUpAndProbability p in _pickUpsVariants)
            {
                sum += p.probability;
            }

            float cumulative = 0f;
            float randomValue = Random.Range(0f, sum);

            foreach (PickUpAndProbability pickup in _pickUpsVariants)
            {
                cumulative += pickup.probability;
                if (randomValue < cumulative)
                {
                    return pickup.dropPrefab;
                }
            }

            return null;
        }

        private Vector3 GetRandomPos()
        {
            float randomShiftX = gameObject.transform.lossyScale.x;
            randomShiftX = Random.Range(-randomShiftX / 2, randomShiftX / 2);
            Vector3 vector3 = gameObject.transform.position;
            vector3.x += randomShiftX;
            return vector3;
        }

        private IEnumerator IncreaseSpawnrate()
        {
            yield return new WaitForSeconds(_spawnRateGainDelay);
            _spawnRate *= _spawnRateGain/100f + 1;
            StartCoroutine(IncreaseSpawnrate());
        }
        
        private void SpawnDrop()
        {
            PickUp dropPrefab = GetRandomDrop();
            Instantiate(dropPrefab, GetRandomPos(), quaternion.identity);
        }

        private IEnumerator SpawnWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (GameService.Instance.IsGameOver)
            {
                yield break;
            }
            SpawnDrop();
            StartCoroutine(SpawnWithDelay(GetRandomDelayBasedOnRate()));
        }

        private void StartIncreasingSpawnRate()
        {
            StartCoroutine(IncreaseSpawnrate());
        }

        private void StartSpawning()
        {
            StartCoroutine(SpawnWithDelay(GetRandomDelayBasedOnRate()));
        }

        #endregion

        #region Local data

        [Serializable] private struct PickUpAndProbability
        {
            #region Variables

            [SerializeField] public PickUp dropPrefab;
            [Header("relative probability, not actual percentage")]
            [Range(0f, 100f)]
            [SerializeField] public float probability;

            #endregion
        }

        #endregion

        //private float _timeToNext;
    }
}