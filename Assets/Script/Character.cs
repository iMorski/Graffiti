using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform TestPointStart;
    [SerializeField] private Transform TestPointFinish;

    private List<Transform> PointFoundGroup = new ();
    private List<Transform> PointCheckedGroup = new ();

    private void Start()
    {
        CalculatePath(TestPointStart, TestPointFinish);
    }

    private List<Transform> CalculatePath(Transform PointStart, Transform PointFinish)
    {
        List<Transform> PointGroup = new ();

        PointFoundGroup.Add(PointStart);

        while (PointFoundGroup.Count != PointCheckedGroup.Count)
        {
            int PointFoundIndex = 0;

            if (PointCheckedGroup.Contains(PointFoundGroup[PointFoundIndex]))
            {
                for (int i = 1; i < PointFoundGroup.Count; i++)
                {
                    if (!PointCheckedGroup.Contains(PointFoundGroup[i]))
                    {
                        PointFoundIndex = i;
                    }
                }
            }
            
            for (int i = 1; i < PointFoundGroup.Count; i++)
            {
                if (!PointCheckedGroup.Contains(PointFoundGroup[i]) && PointFoundGroup[i].GetComponent<PathPoint>().DistanceSum <
                    PointFoundGroup[PointFoundIndex].GetComponent<PathPoint>().DistanceSum)
                {
                    PointFoundIndex = i;
                }
            }
            
            Debug.Log(PointFoundGroup[PointFoundIndex].position);
            Debug.Log(PointFoundGroup.Count + " " + PointCheckedGroup.Count);

            if (!(PointFoundGroup[PointFoundIndex] != PointFinish))
            {
                Debug.Log("Found Finish Point! " + PointFoundGroup[PointFoundIndex].position);
                
                
                PointGroup.Add(PointFoundGroup[PointFoundIndex]);
                
                PointGroup.Add(PointFoundGroup[PointFoundIndex].GetComponent<PathPoint>().Previous);
                
                PointGroup.Add(PointFoundGroup[PointFoundIndex].GetComponent<PathPoint>().Previous);
                
                break;
            }

            GetPointNeighbours(PointFoundGroup[PointFoundIndex]);
        }
        
        void GetPointNeighbours(Transform Point)
        {
            PointCheckedGroup.Add(Point);
        
            Point.GetComponent<PathPoint>().SetGroupCheckedColor();
        
            for (int i = 0; i < PathManager.PathPointAvailableGroup.Count; i++)
            {
                Transform PointAvailable = PathManager.PathPointAvailableGroup[i];
            
                if (!PointCheckedGroup.Contains(PointAvailable) && !PointFoundGroup.Contains(PointAvailable) &&
                    Vector3.Distance(Point.position, PointAvailable.position) < 2.0f)
                {
                    float PointAvailableDistanceToStart = Vector3.Distance(PointAvailable.position, PointStart.position);
                    float PointAvailableDistanceToFinish = Vector3.Distance(PointAvailable.position, PointFinish.position);

                    PathPoint PointAvailablePathPoint = PointAvailable.GetComponent<PathPoint>();
                
                    PointAvailablePathPoint.SetDistanceToStart(PointAvailableDistanceToStart);
                    PointAvailablePathPoint.SetDistanceToFinish(PointAvailableDistanceToFinish);
                    PointAvailablePathPoint.SetDistanceSum(PointAvailableDistanceToStart + PointAvailableDistanceToFinish);
                    PointAvailablePathPoint.SetPrevious(Point);
                
                    PointFoundGroup.Add(PointAvailable);
                
                    PointAvailablePathPoint.SetGroupFoundColor();
                }
            }
        }

        return PointGroup;
    }
}
