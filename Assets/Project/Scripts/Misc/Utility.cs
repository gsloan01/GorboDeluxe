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
        Collider[] colliders = Physics.OverlapSphere(point, maxRange);
        List<T> found = new List<T>();

        if (colliders.Length == 0 || colliders == null) return found;

        foreach(Collider c in colliders)
        {
            if (c.TryGetComponent<T>(out T component))
            {
                found.Add(component);
            }
        }

        return found;
    }

    public static Quaternion FaceTarget(GameObject target, Transform self)
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - self.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            return Quaternion.Slerp(self.rotation, lookRotation, Time.deltaTime * 5);
        }

         return Quaternion.identity;



    }

    public static Quaternion GetLookRotationFromVec2(Vector2 v)
    {
        return Quaternion.LookRotation(new Vector3(v.x, 0, v.y), Vector3.up);
    }
    /// <summary>
    /// Checks the percent of the current out of max and checks if it has the asked percent
    /// </summary>
    /// <param name="percent">Does it have at least this much?</param>
    /// <param name="current">Current value</param>
    /// <param name="max">Maximum value</param>
    /// <returns></returns>
    public static bool HasPercent(float percent, float current, float max)
    {
        if (current < max) throw new System.Exception();
        return percent <= current / max;
    }
}
