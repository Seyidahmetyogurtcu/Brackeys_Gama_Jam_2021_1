using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlphaGame
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager singleton;
        [HideInInspector] public GameInfo gameInfo = GameInfo.NONE;
        [HideInInspector] public int currentCarIndex = 0;
        void Awake()
        {
            if (singleton == null)
            {
                singleton = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

