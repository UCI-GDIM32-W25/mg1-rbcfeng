using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _plantPrefab;
    [SerializeField] private int _numSeeds = 5; 
    [SerializeField] private PlantCountUI _plantCountUI;

    private int _numSeedsLeft;
    private int _numSeedsPlanted;

    private void Start ()
    {
        _numSeedsLeft = _numSeeds;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _numSeedsLeft > 0)
        {
            PlantSeed();
        }

        if (Input.GetKey(KeyCode.W))
        {
            _playerTransform.Translate(Vector3.up * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _playerTransform.Translate(Vector3.down * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playerTransform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerTransform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
    }

    public void PlantSeed ()
    {
       Instantiate(_plantPrefab, _playerTransform.position, Quaternion.identity);
         _numSeedsPlanted++;
         _numSeedsLeft = _numSeeds - _numSeedsPlanted;
       _plantCountUI.UpdateSeeds(_numSeedsLeft, _numSeedsPlanted);
    }
}
