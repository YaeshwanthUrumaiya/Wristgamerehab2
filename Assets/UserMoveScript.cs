using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMoveScript : MonoBehaviour
{
    // Variables to store the rotation speed and the current rotation angle
    public float rotationSpeed = 100.0f; // Adjust this value to change the speed of rotation
    public float maxRotationAngle = 80f;
    private float currentRotationZ = 0.0f;
    public int Score;
    public int lives = 3;
    public bool isGameOver = false;
    public UpdDataHander DataHander;
    public float MinAngle; 
    public float BMoveSpeedMultAngle;
    public float FMoveSpeedMultAngle;
    public float MoveSpeedMult = 1.5f;
    public float data;
    public int FrameCounterB = 0;
    public int FrameCounterF = 0;
    public float SumAngleB = 0f;
    public float SumAngleF = 0f;
    public float AvgAngleB;
    public float AvgAngleF;
    public DBHandler DBAPICaller;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize the current rotation Z value
        currentRotationZ = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver){
            Debug.Log("Game over, score: " + Score);
            AvgAngleB = (SumAngleB / FrameCounterB);
            AvgAngleF = (SumAngleF / FrameCounterF);

            DBAPICaller.valKEYData["avgbackrangeangle"] = AvgAngleB;
            DBAPICaller.valKEYData["avgfrontrangeangle"] = AvgAngleF;
            DBAPICaller.valKEYData["Score"] = Score;
            DBAPICaller.TriggerAPICall = true;

            isGameOver = false;

        }
        else{
            // Check for user input
            data = float.Parse(DataHander.data);
            if (data < 0 && data < MinAngle)
            {
                if(currentRotationZ < maxRotationAngle){
                    // Debug.Log("N");
                    if(BMoveSpeedMultAngle < (data * -1)){
                        currentRotationZ += (rotationSpeed * MoveSpeedMult) * Time.deltaTime;
                        // Debug.Log("Speed");
                    }
                    else{
                        currentRotationZ += rotationSpeed * Time.deltaTime;
                        // Debug.Log("Normal");
                    }
                }
                FrameCounterB += 1; 
                SumAngleB += (data * -1);
            }
            else if (data > 0 && data > MinAngle)
            {
                if(currentRotationZ > (maxRotationAngle * -1)){
                    // Debug.Log("P");
                    if(FMoveSpeedMultAngle < data){
                        currentRotationZ -= (rotationSpeed * MoveSpeedMult) * Time.deltaTime;
                        // Debug.Log("Speed");
                    }
                    else{
                        currentRotationZ -= rotationSpeed * Time.deltaTime;
                        // Debug.Log("Normal");
                    }
                }
                FrameCounterF += 1; 
                SumAngleF += data;
            }

            // Apply the new rotation to the GameObject
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentRotationZ);

        }
        
    }
}
