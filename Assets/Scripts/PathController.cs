using UnityEngine;

public enum PathMovementStyle
{
    Continuous,
    Slerp,
    Lerp,
}
public class PathController : MonoBehaviour
{
    public float MovementSpeed;
    public Transform PathContainer;

    public PathMovementStyle MovementStyle;
    public bool LoopThroughPoints;
    public bool StartAtFirstPointOnAwake;

    private Transform[] _points;

    private int _currentTargetIdx;

    private void Awake()
    {
        _points = PathContainer.GetComponentsInChildren<Transform>();
        if (StartAtFirstPointOnAwake)
        {
            transform.position = _points[0].position;
        }
    }

    private void Update()
    {
        if (_points == null || _points.Length == 0) return;
        var distance = Vector3.Distance(transform.position, _points[_currentTargetIdx].position);
        if (Mathf.Abs(distance) < 0.1f)
        {
            _currentTargetIdx++;
            if (_currentTargetIdx >= _points.Length)
            {
                _currentTargetIdx = LoopThroughPoints ? 0 : _points.Length - 1;
            }
        }
        switch (MovementStyle)
        {
            default:
            case PathMovementStyle.Continuous:
                transform.position = Vector3.MoveTowards(transform.position, _points[_currentTargetIdx].position, MovementSpeed * Time.deltaTime);
                break;
            case PathMovementStyle.Lerp:
                transform.position = Vector3.Lerp(transform.position, _points[_currentTargetIdx].position, MovementSpeed * Time.deltaTime);
                break;
            case PathMovementStyle.Slerp:
                transform.position = Vector3.Slerp(transform.position, _points[_currentTargetIdx].position, MovementSpeed * Time.deltaTime);
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_points == null || _points.Length == 0) return;
        var idx = 0;
        foreach (var point in _points)
        {
            Gizmos.color = Color.yellow;
            if (idx < _currentTargetIdx)
            {
                Gizmos.color = Color.red;
            }

            if (idx > _currentTargetIdx)
            {
                Gizmos.color = Color.green;
            }

            Gizmos.DrawWireSphere(point.position, 1f);
            idx++;
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, _points[_currentTargetIdx].position);
    }
}