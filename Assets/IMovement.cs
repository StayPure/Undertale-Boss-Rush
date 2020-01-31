using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement 
{
    void Move(GameObject entity);
}

public class LinearMovement : IMovement
{
    public void Move(GameObject go)
    {
        go.transform.Translate(Time.deltaTime * 0f, .01f, 0f);
    }
}

public class reverseLinearMovement : IMovement
{
    public void Move(GameObject go)
    {
        go.transform.Translate(Time.deltaTime * 0f, -.01f, 0f);
    }
}

public class SinMovement : IMovement
{
    private const float amplitude = .009f; //.2f
    private const float frequency = .9f; //.7f

    public void Move(GameObject go)
    {
        float xMovement = amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time)/*  - Mathf.Sin(2* Mathf.PI * frequency * (Time.time - Time.deltaTime))*/);
        go.transform.Translate(xMovement, -Time.deltaTime * .7f, 0f);
    }
}

public class reverseSinMovement : IMovement
{
    private const float amplitude = .009f; //.2f
    private const float frequency = .9f; //.7f

    public void Move(GameObject go)
    {
        float xMovement = amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time)/* - Mathf.Sin(2* Mathf.PI * frequency * (Time.time - Time.deltaTime))*/);
        go.transform.Translate(-1 * xMovement, -Time.deltaTime * .7f, 0f);
    }
}

public class SenoidalMovement : IMovement
{
    private const float amplitude = .25f; //.2f
    private const float frequency = .3f; //.7f

    public void Move(GameObject go)
    {
        float xMovement = amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2* Mathf.PI * frequency * (Time.time - Time.deltaTime)));
        go.transform.Translate(xMovement, -Time.deltaTime * .3f, 0f);
    }
}

public class reverseSenoidalMovement : IMovement
{
    private const float amplitude = .25f;
    private const float frequency = .3f;

    public void Move(GameObject go)
    {
        float xMovement = amplitude * (Mathf.Sin(2 * Mathf.PI * frequency * Time.time) - Mathf.Sin(2* Mathf.PI * frequency * (Time.time - Time.deltaTime)));
        go.transform.Translate(-1 * xMovement, -Time.deltaTime * .3f, 0f);
    }
}

