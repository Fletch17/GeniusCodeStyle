using UnityEngine;

public class PointFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _mainPoint;

    private Transform[] _points;
    private int _curentPointIndex;

    private void Start()
    {
        _points = new Transform[_mainPoint.childCount];

        for (int i = 0; i < _mainPoint.childCount; i++)
        {
            _points[i] = _mainPoint.GetChild(i).GetComponent<Transform>();
        }
    }
 
    private void Update()
    {
        var targetPoint = _points[_curentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == targetPoint.position)
        {
            IncrementAndWrapIndex();
        }
    }

    private void IncrementAndWrapIndex()
    {
        _curentPointIndex++;

        if (_curentPointIndex >= _points.Length)
        {
            _curentPointIndex = 0;
        } 
    }
}