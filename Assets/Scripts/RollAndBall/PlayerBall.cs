using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
	/// <summary>
	/// �̵� �ӵ� ����
	/// </summary>
	[SerializeField] private float _speed = 3f;
	/// <summary>
	/// ���� ���� ����
	/// </summary>
	[SerializeField] private float _jumpRange = 5.0f;
	/// <summary>
	/// ���� �ִ� Ƚ��
	/// </summary>
	[SerializeField] private int _maxJumpCount = 2;

	private Rigidbody _rigidbody;
	private int _jumpCount = 0;

    void Start()
	{ 
        _rigidbody = GetComponent<Rigidbody>();
    }

	private void Update()
	{
		Jump();
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		Move();
	}

	/// <summary>
	/// ĳ���͸� �̵���Ű�� �Լ�
	/// AddForce(�̵� ���� * �ӵ�, ForceMode.Force);
	/// </summary>
	private void Move()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");

		// Rigidbody.AddForce �Լ��� Ư�� ����(Vector)���� 
		// ������Ʈ�� ���� ���ϴ� �Լ��Դϴ�.
		_rigidbody.AddForce(new Vector3(horizontal, 0, vertical) * _speed, ForceMode.Force);
	}

	/// <summary>
	/// ĳ���͸� ������Ű�� �Լ�
	/// AddForce(���� ���� ����, ForceMode.Impulse);
	/// </summary>
	private void Jump()
	{
		if (Input.GetButtonDown("Jump") && _jumpCount < _maxJumpCount)
		{
			_jumpCount++;
			_rigidbody.AddForce(new Vector3(0, _jumpRange, 0), ForceMode.Impulse);
		}
	}

	/// <summary>
	/// ���̶� �ε�ġ�� ���� ī��Ʈ�� 0���� �ʱ�ȭ�ϴ� �Լ�
	/// </summary>
	/// <param name="collision"></param>
	private void OnCollisionEnter(Collision collision)
	{
		// Ground �±׷� ������ ���� ������Ʈ�� �浹�� ���� 
		// _jumpCount = 0���� �ʱ�ȭ�մϴ�.
		if (collision.gameObject.CompareTag("Ground"))
		{
			_jumpCount = 0;
			Debug.Log("OnCollisionEnter");
		}
	}
}