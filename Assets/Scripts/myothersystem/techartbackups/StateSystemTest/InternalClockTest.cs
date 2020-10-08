using UnityEngine;
using UnityEngine.UI;
public class InternalClockTest : MonoBehaviour
{
    public static float gameTimer;
    public static int seconds = 0;
    int shaderId;


    [SerializeField] Text gametime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > gameTimer + 1)
        {
            gameTimer = Time.time;
            seconds++;
            //Debug.Log(seconds);
        }

        if (seconds == 60)
        {
            seconds = 0;
            // Debug.Log("Day Passed!");
        }
        shaderId = Shader.PropertyToID("Vector1_63F37651");
        if (shaderId != 0)
        {
            //  Debug.Log(shaderId);
        }
        // Shader.SetGlobalColor(shaderId, new Vector4(Time.time, 0, 0, 0));
        gametime.text = (seconds.ToString());

    }
}
