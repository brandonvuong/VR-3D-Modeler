using System;
using System.IO;
using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine.Networking;
using Oculus.Interaction.Grab;
using Oculus.Interaction.GrabAPI;
using Oculus.Interaction.Input;

namespace Oculus.Interaction.HandPosing
{
    public class DataCollection : MonoBehaviour
    {
        
        static DataCollection instance;

        [Header("Participant Index (e.g., P0)")]
        public string _participant = "P0"; // type in P0, P1,P2 ... to help you distinguish data from different users

        [Header("Enable Logging")] 
        public bool enable = true; // this script only collects data when enable is true
        [SerializeField] private HandGrabInteractor handGrab; // drag the dominant hand into this blank in the inspector
        
        [SerializeField] private GameObject cube; // drag the target cube into this blank in the inspector
        [SerializeField] private GameObject targetCube;

        public GameObject cubeObject;

        private int counter = 0; //count how many datapoint we have collected
        private int i = 0; //index for 3 different sizes (W)
        private int j = 0; //index for 3 different distances (D)
        private float[] distances = {0.25f, 0.5f, 1.0f};
        private float[] sizes = { 0.1f, 0.2f, 0.5f };
        private bool isGrabbed = false; // if the object is grabbed this frame, isGrabbed is true
        private bool wasGrabbed = false; // if the object was grabbed last frame, wasGrabbed is true
        private bool isStart = false; // true when starting to grab
        private bool isEnd = false; // true when starting to release
        private float grabTime = Mathf.Infinity; // elapsed time of moving the cube from point A to point B
        private float grabDistance = Mathf.Infinity; // the distance between point A to point B
        private float grabSize = Mathf.Infinity; // the size of the cube
        private Vector3 initialPos; // the initial position of the cube
        private float initialTime; // the initial timestamp of user interaction (moving the cube from A to B)
        /*
        This template script only creates one cube. To investigate Fitts' Law, 
        we need to create many more cubes of various sizes, and move them to various distances.
        
        Please add variables here as per your need.  
        */

        private StreamWriter _writer; // to write data into a file
        private string _filename; // the name of the file

        // Ensure this script will run across scenes. Do not delete it.
        private void Awake()
        {
            
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else{
                instance = this;
                DontDestroyOnLoad(gameObject);
            }

        }

        // Save all data into the file when we quit the app
        private void OnApplicationQuit() {
            Debug.Log("On application quit");
            if (_writer != null) {
                _writer.Flush();
                _writer.Close();
                _writer.Dispose();
                _writer = null;
            }
        }
        
        // Save all data into the file when we pause the app
        private void OnApplicationPause(bool pauseStatus)
        {
            Debug.Log("On application pause");
            if (_writer != null) {
                _writer.Flush();
                _writer.Close();
                _writer.Dispose();
                _writer = null;
            }
        }
        
        private void Start()
        {
            Debug.Log("start");
            // Create a csv file to save the data
            string filename = $"{_participant}-{Now}.csv";
            string path = Path.Combine(Application.persistentDataPath, filename); 
            // if you run it in the Unity Editor on Windows, the path is %userprofile%\AppData\LocalLow\<companyname>\<productname>
            // if you run it on Mac, the path is the ~/Library/Application Support/company name/product name
            // if you run it on a standalone VR headset, the path is Oculus/Android/data/<packagename>/files
            // reference here: https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html
            _writer = new StreamWriter(path);
            string msg = $"grabTime" +
                        $"grabSize" +
                        $"grabDistance";
            _writer.WriteLine(msg);
            Debug.Log(msg);
            _writer.Flush();

            cube.transform.position = new Vector3(-0.5f, cube.transform.position.y, cube.transform.position.z);
            Vector3 spawnPosition = new Vector3(
                        cube.transform.position.x + distances[j],
                        cube.transform.position.y,
                        cube.transform.position.z);
            targetCube = Instantiate(cubeObject, spawnPosition, Quaternion.identity);
        }

        void Update()
        {
            Debug.Log("running update");
            // only collect data when enable is true
            if (enable == false) return;
            Debug.Log("running");
            
            // read the cube size
            grabSize = cube.transform.localScale.x;

            // read the grab status
            isGrabbed = (InteractorState.Select == handGrab.State);
            Debug.Log("isGrabbed: "+ isGrabbed);
            isStart = !wasGrabbed && isGrabbed;
            // print("isStart: "+ isStart);
            isEnd = wasGrabbed && !isGrabbed;
            // print("isEnd: "+ isEnd);

            // start counting time and distance once a user grabs the cube
            if (isStart){
                initialPos = cube.transform.position;
                initialTime = Time.time;
            }
            // stop counting time and distance once a user releases the cube
            if (isEnd){
                float endPos = cube.transform.position.x;
                grabDistance = Mathf.Abs(endPos - initialPos.x);
                grabTime = Time.time - initialTime;
                if (Mathf.Abs(cube.transform.position.x - targetCube.transform.position.x) < 0.2 * grabSize)
                {
                    WriteToFile(grabTime, grabSize, grabDistance);
                    Debug.Log("new data collected");
                    counter++;
                }
                if(counter > 9)
                {
                    j++;
                    if(j > 2) { j = 0; i++;
                        Vector3 scale = new Vector3(sizes[i], 0.1f, 0.1f);
                        cube.transform.localScale = scale; 
                        targetCube.transform.localScale = scale;
                    }
                    if(i > 2) { Debug.LogErrorFormat("All data collected!"); }
                    else { targetCube.transform.position = new Vector3(
                        initialPos.x + distances[j],
                        cube.transform.position.y,
                        cube.transform.position.z);
                    }
                    counter = 0;
                }

                cube.transform.position = initialPos;
            }   

            wasGrabbed = isGrabbed;
            
        }
        
        // write T, W, D into the file.
        private void WriteToFile(float grabTime, float grabSize, float grabDistance) {
            if (_writer == null) return;
            
            string msg = $"{grabTime}," +
                        $"{grabSize}," +
                        $"{grabDistance}";
            _writer.WriteLine(msg);
            Debug.Log("test msg: "+msg);
            _writer.Flush();
        }
        
        // generate the current timestamp for filename
        private double Now {
            get {
                System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
                return (System.DateTime.UtcNow - epochStart).TotalMilliseconds;
            }
        }
    
    }
}