using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private enum State
    {
        BeforeSpawn,
        Spawn
    }
    [SerializeField] private EnemyWave[] waveArray;
    [SerializeField] private StartWaveDetection startWaveDetection;

    private State state;


    private void Awake()
    {
        state = State.BeforeSpawn;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        startWaveDetection.PlayerEnterBattle += StartWaveDetection_PlayerEnterBattle;
    }

    private void StartWaveDetection_PlayerEnterBattle(object sender, System.EventArgs e)
    {
        if(state == State.BeforeSpawn)
        {
            StartWave();
            startWaveDetection.PlayerEnterBattle -= StartWaveDetection_PlayerEnterBattle;
        }  

    }


    void StartWave()
    {
        Debug.Log("Spawn Enemy");
        state = State.Spawn;
        
        
    }

    private void Update()
    {
        if(state == State.Spawn)
        {
            foreach(EnemyWave enemyWave in waveArray)
            {
                enemyWave.Update();
            }
        }
    }


    [System.Serializable]
    private class EnemyWave
    {
        [SerializeField] private Enemy[] enemyArray;
        [SerializeField] private float timer;


        public void Update()
        {
            if(timer >= 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    spawnZombies();
                }
            }
            
        }
        private void spawnZombies()
        {
            foreach (Enemy enemy in enemyArray)
            {
                enemy.Spawn();
            }
        }

        //public bool WavesCleared()
        //{
        //    if(timer < 0)
        //    {
        //        //Enemies spawned
        //        foreach(Enemy enemy in enemyArray)
        //        {
        //            // check condition if enemy is alive
        //        }
        //    }
        //    else
        //    {
        //        //not spawned yet
        //        return false
        //    }
        //}
    }
}
