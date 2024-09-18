using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    private GameInputs _gameInputs;
    public GameObject _1;
    public GameObject _2;
    public GameObject _3;
    public GameObject _mask;
    public GameObject _back;
    public GameObject _anykey;
    private Image backImg;
    public Sprite[] _backImg;
    public GameObject _Join;
    public Join _join;

    public bool iscan = true;

    private void Awake()
    {
        // Actionスクリプトのインスタンス生成
        _gameInputs = new GameInputs();

        _gameInputs.UI.Next.performed += OnNext;

        _gameInputs.Enable();
    }

    private void OnDestroy()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        _gameInputs?.Dispose();
    }

    private void OnNext(InputAction.CallbackContext context)
    {
        if (iscan == true)
        {
            Invoke("Change", 1.7f);

            var sequence = DOTween.Sequence();

            sequence.Append(_1.transform.DOLocalMoveX(170f, 2.5f));
            sequence.Join(_2.transform.DOLocalMoveX(170f, 2.5f).SetDelay(0.5f));
            sequence.Join(_3.transform.DOLocalMoveX(170f, 2.5f).SetDelay(0.5f));
            sequence.Join(_mask.transform.DOLocalMoveX(160f, 2.5f).SetDelay(0.5f));

            sequence.Play().OnComplete(() =>
            {
                this.gameObject.SetActive(false);
                _Join.SetActive(true);
                _join._canjoin = true;
            });

            iscan = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        backImg = _back.GetComponent<Image>();
        backImg.sprite = _backImg[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Change()
    {
        backImg.sprite = _backImg[1];
        _back.transform.SetSiblingIndex(0);
        _anykey.gameObject.SetActive(false);
    }
}
