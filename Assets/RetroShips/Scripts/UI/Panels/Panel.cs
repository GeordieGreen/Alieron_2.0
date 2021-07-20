/// © 2018-2019 Kevin Foley
/// For distribution only on the Unity Asset Store
/// Terms/EULA: https://unity3d.com/legal/as_terms

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace OneManEscapePlan.Scripts.UI.Panels {

	[System.Serializable]
	public class PanelEvent : UnityEvent<Panel> { }

	/// <summary>
	/// Panel is a base class for GUI panels that can be opened and closed. Panels are generally intended to be
	/// single-instance objects created through a PanelManager.
	/// </summary>
	/// COMPLEXITY: Moderate
	/// CONCEPTS: Input, Inheritance, Coroutines
	[RequireComponent(typeof(RectTransform))]
	public class Panel : MonoBehaviour {

		[Tooltip("The control that starts out selected if we start the game with a joystick connected")]
		[SerializeField] protected Selectable defaultSelection;

		[Tooltip("If a name is given, the panel will close when the virtual button with this name is pressed")]
		[SerializeField] protected string closeButtonVirtualName;

		/// <summary>
		/// This event is invoked when the Panel is destroyed
		/// </summary>
		[DrawConnections(ColorName.Red)]
		[SerializeField] protected PanelEvent panelDestroyedEvent = new PanelEvent();
		public PanelEvent PanelDestroyedEvent { get { return panelDestroyedEvent; } }

		virtual protected void OnEnable() {
			//when the user is using a joystick, we need to select a default Button or other control so that
			//they can navigate the menu with the joystick. if there is no joystick connected, we don't want
			//to select a default button, because it will stay highlighted even when they move the mouse over
			//other buttons
			var joysticks = Input.GetJoystickNames();
			if (defaultSelection != null && joysticks.Length > 0 && !string.IsNullOrEmpty(joysticks[0])) {
				StartCoroutine(selectDefaultControl());
			}

			if (!string.IsNullOrEmpty(closeButtonVirtualName)) {
				StartCoroutine(waitForCloseInput());
			}
		}

		/// <summary>
		/// If we have entered a "closeButtonVirtualName", close the panel when the user presses that virtual button
		/// </summary>
		virtual protected IEnumerator waitForCloseInput() {
			//wait a short period before we listen for the close button. otherwise, one button press might close multiple layers
			//of nested panels
			yield return new WaitForSecondsRealtime(.1f);
			yield return new WaitUntil(() => Input.GetButtonDown(closeButtonVirtualName));
			Close();
		}

		virtual protected IEnumerator selectDefaultControl() {
			yield return new WaitForEndOfFrame();
			defaultSelection.Select();
		}

		/// <summary>
		/// Destroy this Panel instance
		/// </summary>
		virtual public void Close() {
			Destroy(gameObject);
		}

		virtual protected void OnDestroy() {
			panelDestroyedEvent.Invoke(this);
		}
    }
}
