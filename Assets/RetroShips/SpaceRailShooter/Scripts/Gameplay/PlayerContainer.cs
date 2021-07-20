using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace OneManEscapePlan.SpaceRailShooter.Scripts.Gameplay {

	public class PlayerContainer : MonoBehaviour {

		public int x = 0;
		public int y = 0;
		public int z = 6;

		[SerializeField] private PlayerSpacecraft playerSpacecraft;
		Vector3 speed;

		private void Start()
        {
			
		}

        private void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
				z = 15;
				

				
			}

            if (UnityEngine.Input.GetButton("Boost"))
            {
				z = 15;
				

			}

            else
            {
				z = 8;
            }
			speed = new Vector3(x, y, z);
		}

        void FixedUpdate() {
			if (playerSpacecraft != null) {
				transform.Translate(speed * Time.deltaTime, Space.Self);
			}
		}

		public PlayerSpacecraft PlayerSpacecraft {
			get {
				return playerSpacecraft;
			}

			set {
				playerSpacecraft = value;
			}
		}
	}

}
