using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AlphaGame
{
    public class MoveScriptsMotor : MonoBehaviour
    {
        public WheelCollider sağÖnTekerlek, solÖnTekerlek, sağArkaTekerlek, solArkaTekerlek;
        public Rigidbody rb;
        public float motorSpeed, maxSpeed, turnSpeed, breakSpeed;
        public MapInfinitySystem mapInfinitySystem;
        float speed = 0, deltaVelocity, acceleration, lastVelocity = 0;
        public bool transportBarrier;
        private float cameraPosFromPlayer_z = -1.398292f, cameraCut = 300f;
        public AudioSource audioSource;
        public Transform initialTransform;
        [SerializeField] private GameObject[] carPrafabs;
        [HideInInspector]public Collider traficcarCollider;
        [HideInInspector]public Transform traficCarTransform;

        private void Start()
        {
            audioSource.volume = 0.7f;
            audioSource.Play();
            initialTransform = this.transform;
            traficCarTransform.position = this.transform.position;
            traficCarTransform.position = new Vector3(0,20, this.transform.position.z + 100);
            SpawnCar(GameManager.singleton.currentCarIndex);

        }
        public void SpawnCar(int Index)
        {
            GameObject traficCar = Instantiate(carPrafabs[Index], traficCarTransform);
            traficcarCollider = traficCar.GetComponent<Collider>();
            traficcarCollider.isTrigger = true;
        }
        void Update()
        {
            #region acceleration calculations
            speed = rb.velocity.magnitude;
            deltaVelocity = speed - lastVelocity;
            acceleration = (deltaVelocity / Time.deltaTime);
            lastVelocity = speed;
            Debug.Log(rb.velocity.magnitude);
            #endregion
            //reset car transform
            if (Input.GetKeyDown(KeyCode.R)) 
            {
                StartCoroutine(ResetTransform());
            }

            //ilerle ve dur
            if (speed < maxSpeed)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //hızlanmayı düzelt.
                {
                    rb.AddForce(rb.transform.forward * 2000);
                }
            }
            if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
            {
                if (rb.velocity.magnitude >= 20)
                {
                    rb.AddForce(-rb.transform.forward * 3000);
                }
                else if (rb.velocity.magnitude < 20 && rb.velocity.magnitude > 10)
                {
                    rb.AddForce(-rb.transform.forward * 1000);
                }
                else if (rb.velocity.magnitude < 10 && rb.velocity.magnitude > 0)
                {
                    rb.AddForce(-rb.transform.forward * 300);
                }
                else if ((int)rb.velocity.magnitude == 0)
                {
                    rb.velocity = Vector3.zero;
                }
                if ((int)rb.velocity.magnitude == 0)
                {
                    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                    {

                        audioSource.Play();
                        audioSource.volume = 0.3f;
                    }
                }
            }
            if (Input.GetKey(KeyCode.Space))
            {
                sağArkaTekerlek.brakeTorque = breakSpeed;
                solArkaTekerlek.brakeTorque = breakSpeed;
                Debug.LogWarning("Brake Pressed");
            }
            else
            {
                sağArkaTekerlek.brakeTorque = 0f;
                solArkaTekerlek.brakeTorque = 0f;
            }
            //sağa sola dön ve git
            sağÖnTekerlek.steerAngle = turnSpeed * Input.GetAxisRaw("Horizontal");
            solÖnTekerlek.steerAngle = turnSpeed * Input.GetAxisRaw("Horizontal");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!transportBarrier)
            {
                if (other.tag == "TriggerOne")
                {
                    mapInfinitySystem.MapAdd(1);
                    transportBarrier = true;
                }
                if (other.tag == "TriggerTwo")
                {
                    mapInfinitySystem.MapAdd(2);
                    transportBarrier = true;
                }
                if (other.tag == "TriggerThree")
                {
                    mapInfinitySystem.MapAdd(3);
                    transportBarrier = true;
                }
                if (other.tag == "TriggerFour")
                {
                    mapInfinitySystem.MapAdd(4);
                    transportBarrier = true;
                }
                if (other.tag == "TriggerFive")
                {
                    mapInfinitySystem.MapAdd(5);
                    transportBarrier = true;
                }
            }
            if (other.tag == "TrafficCar")
            {
                if (GameManager.singleton.gameInfo == GameInfo.PLAYING)
                {
                    StartCoroutine(ResetTransform());
                }
            }

        }
        public IEnumerator ResetTransform()
        {
            yield return new WaitForSeconds(2.0f);
            transform.position = new Vector3(initialTransform.position.x, initialTransform.position.y, transform.position.z);
            transform.rotation = initialTransform.rotation;
        }
    }
}
