using System.Collections;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public void HitStopMethod(float time, float scale)
    {
        StartCoroutine(HitStop(time, scale));
    }

    IEnumerator HitStop(float time, float scale)
    {
        Time.timeScale = scale;
        yield return new WaitForSeconds(time);
    }
}
