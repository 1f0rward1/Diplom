using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : MonoBehaviour
{   
    [SerializeField] private List<Lanka> lankas;
    private int[][] coordinates;
    private int[] lankaCurrentCoordIndex = new int[6];

    enum Axis 
    {
        AxisX,
        AxisY,
        AxisZ
    }

    [System.Serializable]
    struct Lanka 
    {
        public int id;
        public GameObject part;
        public Axis axis;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MooveLanka(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MooveLanka(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MooveLanka(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MooveLanka(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            MooveLanka(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6)) 
        {
            MooveLanka(5);
        }
    }

    public void SetCoordinates(int[][] arrays) 
    {
        coordinates = arrays;
        for (int i = 0; i < arrays.Length; i++) 
        {
            lankaCurrentCoordIndex[i] = 0;
        }
        DebugCoords();
    }

    private void DebugCoords() 
    {
        string data = "";
        for (int i = 0; i < 6; i++)
        {
            foreach (int num in coordinates[i])
            {
                data += (num + " | ");
                     
            }
            data += "\n";
        }
        Debug.Log(data);
        //MooveLanka(0);
    }

    private void MooveLanka(int lankaID) 
    {
        int coordID = lankaCurrentCoordIndex[lankaID];
        if (coordID < coordinates[lankaID].Length)         
        {
            Vector3 rotateTarget;
            Axis curAxis = lankas[lankaID].axis;
            //int coordID = lankaCurrentCoordIndex[lankaID];
            if (curAxis == Axis.AxisX)
            {
                rotateTarget = new Vector3(coordinates[lankaID][coordID], 0, 0);
            }
            else if (curAxis == Axis.AxisY)
            {
                rotateTarget = new Vector3(0, coordinates[lankaID][coordID], 0);
                Debug.Log(lankaID + " | " + coordID);
                Debug.Log(coordinates[lankaID][coordID]);
            }
            else
            {
                rotateTarget = new Vector3(0, 0, coordinates[lankaID][coordID]);
            }
            lankaCurrentCoordIndex[lankaID]++;
            lankas[lankaID].part.transform.Rotate(rotateTarget);
        }
        
    }
}
