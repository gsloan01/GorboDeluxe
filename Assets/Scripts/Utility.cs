using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public static class Utility 
{


    /// <summary>
    /// Gets the nearest GameObject of a type from a certain point.
    /// </summary>
    /// <param name="type">Determines what type to look for (i.e. Enemy)</param>
    /// <param name="point">This is the point from which distance is measured</param>
    /// <param name="maxRange">The farthest that will be counted. Default is infinite range</param>
    /// <returns>Returns the component closest to that point found</returns>
    public static T GetNearest<T>(Vector3 point, List<GameObject> exclude = null,  float maxRange = float.MaxValue) where T : Component
    {
        T found = null;
        IEnumerable<T> potential = GetAllInRange<T>(point, maxRange, exclude);
        if (potential.Count() == 0) return found;
        float closestDistance = float.MaxValue;
        foreach (T current in potential)
        {
            float dist = Vector3.Distance(point, current.transform.position);
            if (dist < closestDistance && dist < maxRange)
            {
                closestDistance = dist;
                found = current;
            }
        }
        return found;
    }

    public static T GetNearestInList<T>(Vector3 point, List<T> objects) where T : Component
    {
        T found = null;
        
        if (objects == null || objects.Count() == 0  ) return found;
        float closestDistance = float.MaxValue;
        foreach (T current in objects)
        {
            float dist = Vector3.Distance(point, current.transform.position);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                found = current;
            }
        }
        return found;
    }

    public static IEnumerable<T> GetAllInRange<T>(Vector3 point,  float maxRange = float.MaxValue, List<GameObject> exclude = null) where T : Component
    {
        return GameObject.FindObjectsOfType<T>().Where(g => Vector3.Distance(g.gameObject.transform.position, point) <= maxRange);
    }

    public static Quaternion GetLookRotationFromVec2(Vector2 v)
    {
        return Quaternion.LookRotation(new Vector3(v.x, 0, v.y), Vector3.up);
    }

}
