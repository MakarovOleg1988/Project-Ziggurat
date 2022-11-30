using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ziggurat
{
	[RequireComponent(typeof(Animator))]
	public class UnitEnvironment : MonoBehaviour
	{
		[SerializeField] protected Animator _animator;
		[SerializeField] private Collider _collider;


		public event EventHandler OnEndAnimation;

        public void Moving(float valueX)
		{
			_animator.SetFloat("Movement", valueX);
		}

		/// <summary>
		/// Вызывать для всех прочих, кроме хотьбы анимаций
		/// </summary>
		/// <param name="key"></param>
		public void StartAnimation(string key, float valueX)
		{
			_animator.SetFloat("Movement", valueX);
			_animator.SetTrigger(key);
		}

		//Вызывается внутри анимаций для переключения атакующего коллайдера
		public void AnimationEventCollider_UnityEditor(int isActivity)
		{
			_collider.enabled = isActivity != 0;
		}

		//Вызывается внутри анимаций для оповещения об окончании анимации
		private void AnimationEventEnd_UnityEditor(string result)
		{
			//В конце анимации смерти особый аргумент и своя логика обработки
			if (result == "die") Destroy(gameObject);
			OnEndAnimation.Invoke(null, null);
		}
	}
}
