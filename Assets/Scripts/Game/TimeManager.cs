using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float slowdownFactor = 0.02f;
    public float slowdownDuration = 1f;

    private void Update()
    {
        Time.timeScale += (1f / slowdownDuration) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void SlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        Debug.Log(Time.timeScale);
    }
}
