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

		public void Die(string result)
		{
			_animator.SetTrigger("Die");
		}

		//Вызывается внутри анимаций для переключения атакующего коллайдера
		private void AnimationEventCollider(int isActivity)
		{
			_collider.enabled = isActivity != 0;
		}

		public void AnimationEventEnd(string result)
		{
			if (result == "Die") Destroy(gameObject);
		}
	}
}
