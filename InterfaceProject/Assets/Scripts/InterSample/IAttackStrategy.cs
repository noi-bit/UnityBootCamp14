using System;
using System.Collections.Generic;
using UnityEngine;


public interface IAttackStrategy //함수 내용을 구현하진 않고 그 'Attack' 이름만 전달
{                                //이걸 상속받은 객체는 Attack이라는 함수를 구현해야함
    void Attack(GameObject target); //{} <- 본문선언 XXX
}                                   //어떠한 값이 '선언'되면 XXX

public interface IDamageinput
{
    void Attack(GameObject target);
    void Damage(GameObject target, int damage);
}