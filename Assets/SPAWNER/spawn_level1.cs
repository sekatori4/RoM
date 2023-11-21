using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawn_level1 : MonoBehaviour
{
    public float SpawnInterval = 20.0f;

    public int mobsPerWave = 5;
    public int wavesHardermobs = 3;
    private int waveCount = 0;
    public float delayBerweenNPC;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNPC());  
    }

    private IEnumerator SpawnNPC()
    {
        while (true)
        {
            waveCount++;

            if(waveCount % wavesHardermobs == 0)

            {
                for (int i = 0; i < mobsPerWave; i++)
                {
                    SpawnWave1();
                    yield return new WaitForSeconds(delayBerweenNPC);
                }
                yield return new WaitForSeconds(SpawnInterval - delayBerweenNPC * mobsPerWave);



                StartCoroutine(SpawnNPC2());
                waveCount = 0;
                break;
            }
            



            else
            {
                for (int i = 0; i < mobsPerWave; i++)
                {
                    SpawnWave1();
                    yield return new WaitForSeconds(delayBerweenNPC);
                }
                yield return new WaitForSeconds(SpawnInterval - delayBerweenNPC * mobsPerWave);
            }
        }
     }

    private IEnumerator SpawnNPC2()
    {
        while (true)
        {
            waveCount++;

            if (waveCount % wavesHardermobs == 0)

            {
                //StartCoroutine(SpawnNPC2());
                //waveCount = 0;
                break;
            }
            else
            {
                for (int i = 0; i < mobsPerWave; i++)
                {
                    SpawnWave2();
                    yield return new WaitForSeconds(delayBerweenNPC);
                }
                yield return new WaitForSeconds(SpawnInterval - delayBerweenNPC * mobsPerWave);
            }
        }
    }





    private void SpawnWave1()
    {
        GameObject skeletik = Instantiate(gameObject.GetComponent<SPAWNER>().NPC1,gameObject.GetComponent<SPAWNER>().spawnPoint2.transform);
       
        skeletik.transform.parent = null;


    }
    private void SpawnWave2()
    {
        GameObject skeletik = Instantiate(gameObject.GetComponent<SPAWNER>().NPC2, gameObject.GetComponent<SPAWNER>().spawnPoint2.transform);

        skeletik.transform.parent = null;


    }
    void Update()
    {
        
    }
}
