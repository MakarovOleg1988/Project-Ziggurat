using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
	[RequireComponent(typeof(Animator))]
	public class UnitEnvironment : MonoBehaviour
	{
		[SerializeField] public static Animator _animator;
		[SerializeField] private Collider _collider;

        public static void Moving(float valueX)
		{
			_animator.SetFloat("Movement", valueX);
		}

		public static void FastAttack()
		{
			_animator.SetTrigger("Fast");
		}

		public void Die(string key)
		{
			_animator.SetTrigger("Die");
			Destroy(this);
		}

		//Вызывается внутри анимаций для переключения атакующего коллайдера
		private void AnimationEventCollider_UnityEditor(int isActivity)
		{
			_collider.enabled = isActivity != 0;
		}

		//Вызывается внутри анимаций для оповещения об окончании анимации
		private void AnimationEventEnd_UnityEditor(string result)
		{
			//В конце анимации смерти особый аргумент и своя логика обработки
			if (result == "die") Destroy(gameObject);
		}
	}
}
