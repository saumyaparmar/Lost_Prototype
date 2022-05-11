using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EyePuzzleScript : MonoBehaviour
{
    public List<Transform> Puzzles = new List<Transform>();
    public List<Transform> CorrectPositions;

    private List<int> Completed = new List<int>();
    private List<Transform> PuzzlesCopy = new List<Transform>();
    

    private void Awake()
    {
        foreach (Transform puz in Puzzles)
        {
            CorrectPositions.Add(puz);
            PuzzlesCopy.Add(puz);
        }
    }
    
    void Start()
    {     
        //print("Size of Puzzle: "+PuzzlesCopy.Count);
        for (int puzind = 0; puzind < PuzzlesCopy.Count-1; ++puzind)
        {
            int t_ind=0;
            bool flag = false;
            while (!flag)
            {
                if (CheckCompleted(puzind))
                {
                    flag = true;
                }
                else
                {
                    int ind = Random.Range(0, Puzzles.Count);
                    if (puzind != ind && !CheckCompleted(ind))
                    {
                        flag = true;
                        t_ind = ind;
                    }
                }
            }


            Transform temp_obj = PuzzlesCopy[puzind],temp_obj2=PuzzlesCopy[t_ind];
            Vector3 tempPosition =  PuzzlesCopy[puzind].position;
            Quaternion tempRotation = PuzzlesCopy[puzind].rotation;

            temp_obj.position = temp_obj2.position;
            temp_obj.rotation = temp_obj2.rotation;

            temp_obj2.position = tempPosition;
            temp_obj.rotation = tempRotation;
            Completed.Add(puzind);
            //print("Assigning "+t_ind+" to "+puzind);
        }
        
        //print("Done reassigning");
        PuzzlesCopy.Clear();
        Puzzles.Clear();
    }

    bool CheckCompleted(int indToCheck)
    {
        for (int i=0;i<Completed.Count;++i)
        {
            if (indToCheck==Completed[i])
            {
                return true;
            }
        }

        Completed.Add(indToCheck);
        return false;
    }   
}