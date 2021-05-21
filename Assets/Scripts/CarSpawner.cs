using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlphaGame 
{
    public class CarSpawner : MonoBehaviour
    {

        public Vector3[] carSpawnPos = new Vector3[6];
        public Vector3 carSpawnPosition = new Vector3(0,0,0);
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            carSpawnPos[0] = carSpawnPosition + Vector3.right * 16*2;
            carSpawnPos[0] = carSpawnPosition + Vector3.right * 16 * 1;
            carSpawnPos[0] = carSpawnPosition;
            carSpawnPos[0] = carSpawnPosition + Vector3.right * 16 *(-1);
            carSpawnPos[0] = carSpawnPosition + Vector3.right * 16 * (-2);
            carSpawnPos[0] = carSpawnPosition + Vector3.right * 16 *(-3);
  
        }

    }
}
