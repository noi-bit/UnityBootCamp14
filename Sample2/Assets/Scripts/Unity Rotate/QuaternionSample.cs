using UnityEngine;
// Quaternion����
// Quaternion.identity = ȸ�� ����
// Quaternion.Euler(x,y,z) = ���Ϸ� �� -> ���ʹϿ� ��ȯ
// Quaternion.AngleAxis(angle, axis) = Ư�� �� ������ ȸ��
// Quaternion.LookRotation(forward, upward); = �ش� ���� ������ �ٶ󺸴� ȸ�� ���¿� ���� return
//                                   ��> default : Vector3.up
// forward : ȸ����ų ����(Vector 3)
// upward  : ������ �ٶ󺸰� ���� ���� �� �κ��� ����

// ȸ�� �� ����
// transform.rotation = Quaternion.Euler(x,y,z); -> ���� ������Ʈ�� ȸ�� ���� (x,y,z)�� �����մϴ�

// ȸ���� ���� ����
// Quaternion Lerp(from, to , t)                 : ���� ����
// Quaternion Slerp(from, to , t)                : ���� ���� ����
// Quaternion.RotateTowards(from, to, maxDegree) : ���� ������ŭ ���������� ȸ���� ó��

// transform.LookAt() vs Quaternion.LookRotation() : �� �� Ư�� ������ ���� �ϴ� �ڵ�
// 1. LookAt() : �߰� ȸ�� �����̳� ��� ��ư�, �������� ���� �������� transform.rotation�� �ڵ����� �������ִ� ���
//               (���ο��� Quaternion.LookRotation()�� ����ϴ� ���)(LookAt �� �߰����� �������۾� �ʿ� X)
//                --> �׳� �� �ٶ������ ���ڴ�!!!!!

// 2. LookRotation(direction) : ȸ�� ���� ����ϰ� �������� ������ ���� ����
//                              �ذ�� �� �������� ���� �߰����� ������ �ʿ��ϴ�
//                              --> ����� �������� �߰����� �۾����� ����� ó���Ϸ� ^^

public class QuaternionSample : MonoBehaviour
{
}
