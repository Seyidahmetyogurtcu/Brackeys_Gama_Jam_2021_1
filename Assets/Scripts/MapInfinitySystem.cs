using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlphaGame
{
    public class MapInfinitySystem : MonoBehaviour
    {
        public GameObject mapOne, mapTwo, mapThree, mapFour, mapFive,backyardPlane;
        public GameObject Enemy1, Enemy2, Enemy3, Enemy4, Enemy5;
        public MoveScriptsMotor moveScriptsMotor;
        public void MapAdd(int type)
        {
            StartCoroutine(delay(type));
        }
        IEnumerator delay(int type)
        {
            yield return new WaitForSeconds(0.1f);
            if (type == 1)
            {
                mapOne.transform.position = new Vector3(0, 0, mapOne.transform.position.z + 500);
                backyardPlane.transform.position = new Vector3(0, 0, backyardPlane.transform.position.z + 100);
                Enemy1.SetActive(true);
                Enemy1.transform.position = new Vector3(Random.Range(-40f,40f),4, backyardPlane.transform.position.z+200);
            }
            else if (type == 2)
            {
                mapTwo.transform.position = new Vector3(0, 0, mapTwo.transform.position.z + 500);
                backyardPlane.transform.position = new Vector3(0, 0, backyardPlane.transform.position.z + 100);
                Enemy2.SetActive(true);
                Enemy2.transform.position = new Vector3(Random.Range(-40f, 40f), 4, backyardPlane.transform.position.z + 200);
            }
            else if (type == 3)
            {
                mapThree.transform.position = new Vector3(0, 0, mapThree.transform.position.z + 500);
                backyardPlane.transform.position = new Vector3(0, 0, backyardPlane.transform.position.z + 100);
                Enemy3.SetActive(true);
                Enemy3.transform.position = new Vector3(Random.Range(-40f, 40f), 4, backyardPlane.transform.position.z + 200);
            }
            else if (type == 4)
            {
                mapFour.transform.position = new Vector3(0, 0, mapFour.transform.position.z + 500);
                backyardPlane.transform.position = new Vector3(0, 0, backyardPlane.transform.position.z + 100);
                Enemy4.SetActive(true);
                Enemy4.transform.position = new Vector3(Random.Range(-40f, 40f), 4, backyardPlane.transform.position.z + 200);
            }
            else if (type == 5)
            {
                mapFive.transform.position = new Vector3(0, 0, mapFive.transform.position.z + 500);
                backyardPlane.transform.position = new Vector3(0, 0, backyardPlane.transform.position.z + 100);
                Enemy5.SetActive(true);
                Enemy5.transform.position = new Vector3(Random.Range(-40f, 40f), 4, backyardPlane.transform.position.z + 200);

            }
            moveScriptsMotor.transportBarrier = false;


        }
    }
}

