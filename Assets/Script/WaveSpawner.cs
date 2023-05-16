using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenWaves;
    [SerializeField] private float _countdown;
    [SerializeField] private int _waveIndex;
    [SerializeField] private float _waitTime;

    public Transform spawnPoint;
    public Transform enemyPrefab;
    public TextMeshProUGUI textTimer;

    private void Update()
    {
        if (_countdown <= 0f)
        {
            StartCoroutine(SpawnWave());

            _countdown = _timeBetweenWaves;
        }
        _countdown -= Time.deltaTime;
        _countdown = Mathf.Clamp(_countdown,0f,Mathf.Infinity);

        textTimer.text = string.Format("{0:00.00}",_countdown);
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Wave in comming");
        _waveIndex++;

        for (int i = 0; i < _waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_waitTime);

        }

    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position, spawnPoint.rotation);
    }
}
