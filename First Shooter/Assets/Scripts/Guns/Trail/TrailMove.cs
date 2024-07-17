using System.Collections;
using UnityEngine;

public class TrailMove : MonoBehaviour
{
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    public void MoveTrail(Vector3 endPoint)
    {
        StartCoroutine(MovingTrail(endPoint));
    }

    private IEnumerator MovingTrail(Vector3 endPoint)
    {
        float time = 0;
        Vector3 startPosition = _trailRenderer.transform.position;

        while (time < 1)
        {
            _trailRenderer.transform.position = Vector3.Lerp(startPosition, endPoint, time);
            time += Time.deltaTime / _trailRenderer.time;

            yield return null;
        }
        _trailRenderer.transform.position = endPoint;

        Destroy(_trailRenderer.gameObject, _trailRenderer.time);
    }
}
