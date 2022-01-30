using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] private Transform PathPointGroup;
    [SerializeField] private Transform PathObstacleGroup;

    public static List<Transform> PathPointAvailableGroup = new ();
    public static Dictionary<List<Transform>, Transform> PaintPointAvailableGroup = new ();

    private void Awake()
    {
        int PathPointGroupCount = PathPointGroup.childCount;
        int PathObstacleGroupCount = PathObstacleGroup.childCount;
        
        for (int i = 0; i < PathPointGroupCount; i++)
        {
            Vector3 PathPointPosition = PathPointGroup.GetChild(i).position;
            
            bool PathPointInObstacle = false;
            
            for (int j = 0; j < PathObstacleGroupCount; j++)
            {
                Vector3 PathObstaclePosition = PathObstacleGroup.GetChild(j).position;
                
                if (!(PathPointPosition != new Vector3(PathObstaclePosition.x, 0.0f, PathObstaclePosition.z)))
                    PathPointInObstacle = true;
            }
            
            if (!PathPointInObstacle) PathPointAvailableGroup.Add(PathPointGroup.GetChild(i));
        }
        
        /*

        for (int i = 0; i < PathObstacleGroupCount; i++)
        {
            List<Transform> PathPointAroundObstacleGroup = new ();
            
            Transform PathObstacle = PathObstacleGroup.GetChild(i);

            for (int j = 0; j < PathPointAvailableGroup.Count; j++)
            {
                Transform PathPointAvailable = PathPointAvailableGroup[j];
                
                if (Vector3.Distance(PathObstacle.position, PathPointAvailable.position) < 2.0f)
                {
                    PathPointAroundObstacleGroup.Add(PathPointAvailable);
                }
            }
            
            if (PathPointAroundObstacleGroup.Any()) PaintPointAvailableGroup.Add(
                PathPointAroundObstacleGroup, PathObstacle);
        }
        
        */
    }
}