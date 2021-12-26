using System.Collections;
using UnityEngine;

public class ArenaWall : MonoBehaviour
{
    const float INTENSITY = 3;
    const float TIME_TO_LOOP_COLORS = 10f;

    Color[] colors;
    int colorIndex;
    Color currentColor;
    Color nextColor;
    MaterialPropertyBlock _propBlock;
    float intensity;
    Renderer _renderer;

    void Awake ()
    {
        _renderer = GetComponent<Renderer>();
        _propBlock = new MaterialPropertyBlock();
        intensity = Mathf.Pow(2f, INTENSITY);

        colors = new Color[] {
            Color.green,
            Color.cyan,
            Color.magenta,
            Color.red,
        };
    }

    void Start ()
    {
        StartCoroutine(ColorChangeRoutine());
    }

    IEnumerator ColorChangeRoutine ()
    {
        while (true)
        {
            float t = 0;
            currentColor = colors[colorIndex % colors.Length];
            nextColor = colors[(colorIndex + 1) % colors.Length];
            while (t <= TIME_TO_LOOP_COLORS / colors.Length)
            {
                t += Time.deltaTime;
                _renderer.GetPropertyBlock(_propBlock);
                _propBlock.SetVector(
                    "_EmissionColor",
                    Color.Lerp(
                        currentColor,
                        nextColor,
                        t
                    ) * intensity
                );
                _renderer.SetPropertyBlock(_propBlock);
                yield return null;
            }
            colorIndex++;
        }
    }
}
