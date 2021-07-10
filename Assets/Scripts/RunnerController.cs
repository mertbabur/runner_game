using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    [SerializeField] private float _firstLine; // en sol kısım
    [SerializeField] private float _secondLine; // orta kısım
    [SerializeField] private float _thirdLine; // en sağ kısım

    [SerializeField] private float _characterY; // karakterin position degerinin y'sini tutar

    [SerializeField] private float _moveThresholds; // dokunmatiği algılamak için eşik değeri --> x ekseni için.
    [SerializeField] private float _swipeThresholds; // dokunmatiği algılamak için eşik değeri --> y ekseni için. --> zıplamak için
    [SerializeField] private float _swipeSpeed; // y eksenindeki hareket hızı

    [SerializeField] private float _forceSpeed; // zıplama kuvveti

    [SerializeField]private bool _isGround = true; // karakter yerde mi?
    
    private float _lastMoveTime; // son hareket zamanı
    private Vector3 moveTo; // gidilecek position

    enum Lane
    {
        First,
        Second,
        Third
    }
    
    private Lane _lane = Lane.Second;

    private Rigidbody _runnerRB;
    [SerializeField] private float _moveSpeed; // x ekseni boyunca hareket hızı

    private bool _isStartGame = false; // oyun başlayıp başlamadığını tutar;    
        
        
    
    private void Awake()
    {
        _runnerRB = GetComponent<Rigidbody>(); // rigidbody al
    }

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            // ekrana dokunuldu mu?
            Touch touch = Input.touches[0];
            float movePowY = touch.deltaPosition.normalized.y; // y ekseni için değer al
            MoveToVertically(movePowY); // dikey yönlü hareket
        }

        if (_isStartGame)
        {
            MoveToForward(); // z ekseni boyunca hareket et
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) // ekrana dokunuldu mu?
        {
            Touch touch = Input.touches[0];
            float movePowX = touch.deltaPosition.normalized.x; // x ekseni için değer al
            MoveToHorizontally(movePowX); // yatay yönlü hareket
        }
        Move(moveTo);
    }

    /**
     * Karakteri istediğimiz konuma smooth şekilde hareket ettirir.
     */
    private void Move(Vector3 moveTo)
    {
        moveTo = new Vector3(moveTo.x,_characterY,transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, moveTo, Time.deltaTime * _swipeSpeed);
    }

    /**
     * Karakterin velocitysini değiştirerek z yönünde hareket ettirir.
     */
    private void MoveToForward()
    {
        _runnerRB.velocity = transform.forward * (Time.deltaTime * _moveSpeed);
    }

    /**
     * Yatay yönlü hareket
     */
    private void MoveToHorizontally(float movePow)
    {
        if (Mathf.Abs(movePow) > _moveThresholds && Time.time - _lastMoveTime >= _swipeThresholds) // Eşik değeri ve son basma üzerinden yeterli zaman geçildi ise
        {
            _lastMoveTime = Time.time; // son zamanı güncelle
            if (movePow < 0) // sola hareket
            {
                switch (_lane)
                {
                    case Lane.First: // en soldayız sola hareket etmez.
                        break;
                    case Lane.Second:
                        moveTo = new Vector3(_firstLine, _characterY, transform.position.z); // ortadaysak first'e git
                        _lane = Lane.First;
                        break;
                    case Lane.Third: // en sağdaysak second'a git
                        moveTo = new Vector3(_secondLine, _characterY, transform.position.z);
                        _lane = Lane.Second;
                        break;
                }
            }

            if (movePow > 0)
            {
                switch (_lane)
                {
                    case Lane.First: //en soldaysak second'a git
                        moveTo = new Vector3(_secondLine, _characterY, transform.position.z);
                        _lane = Lane.Second;
                        break;
                    case Lane.Second: //ortadaysak third'e git
                        moveTo = new Vector3(_thirdLine, _characterY, transform.position.z);
                        _lane = Lane.Third;
                        break;
                    case Lane.Third: // en sağdaysak sağa hareket etmez
                        break;
                }
            }
        }
    }

    /**
     * Dikey yönlü hareket
     */
    private void MoveToVertically(float movePow)
    {
        if (Mathf.Abs(movePow) > _moveThresholds && Time.time - _lastMoveTime >= _swipeThresholds) // Eşik değeri ve son basma üzerinden yeterli zaman geçildi ise
        {
            _lastMoveTime = Time.time; // son zamanı güncelle
            if (movePow > 0 && _isGround) // yukarı kaydırdıysak ve zemine temas ediyorsak zıpla
            {
                _runnerRB.AddForce(transform.up * (_forceSpeed * Time.deltaTime),ForceMode.Impulse);
                gameObject.GetComponent<RunnerController>().enabled = false;
                _isGround = false;
            }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground") // zemine tekrar çarparsak 
        {
            _isGround = true;
            gameObject.GetComponent<RunnerController>().enabled = true;

        }

    }
    
    /**
     * Oyunu başlatır
     */
    public void SetStartGame()
    {
        _isStartGame = true;
    }

    /**
     * _isStartGame i false yapar
     */
    public void SetStopGame()
    {
        _isStartGame = false;
    }
}
