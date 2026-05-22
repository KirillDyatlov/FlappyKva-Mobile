using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColumnes : MonoBehaviour
{
    public GameObject column_up;
    public GameObject column_down;
    public GameObject add_points;
    public bool isHard = false;
    float posx_up;
    
    private void Start()
    {
        if(isHard == true)
        {
            StartCoroutine(HardSpawn());
        }

        if(isHard == false)
        {
            StartCoroutine(ClassicSpawn());
        }
    }

    IEnumerator HardSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.9f);
            posx_up = Random.Range(1.47f, 5.42f);
            Instantiate(column_up, new Vector3(6.62f, posx_up, 0f), Quaternion.identity);
            Instantiate(column_down, new Vector3(6.62f, posx_up - 7.0524f, 0f), Quaternion.identity);
            Instantiate(add_points, new Vector3(7.98f, 0.9955f, 0f), Quaternion.identity);
        }
    }

    IEnumerator ClassicSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.15f);
            posx_up = Random.Range(1.47f, 5.42f);
            Instantiate(column_up, new Vector3(6.62f, posx_up, 0f), Quaternion.identity);
            Instantiate(column_down, new Vector3(6.62f, posx_up - 7.0524f, 0f), Quaternion.identity);
            Instantiate(add_points, new Vector3(7.98f, 0.9955f, 0f), Quaternion.identity);
        }
    }
}
