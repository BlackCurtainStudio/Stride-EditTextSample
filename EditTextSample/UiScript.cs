using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using Stride.UI.Controls;
using Stride.UI;
using Irony.Parsing;
using SharpDX.DXGI;

namespace EditTextSample
{
    public class UiScript : SyncScript
    {
		public bool uiEnabled = false;
        public UIComponent uiComp;
		private EditText uiInput;

		public override void Start()
		{
			if (uiComp != null && uiInput == null)
			{
				uiInput = uiComp.Page.RootElement.FindVisualChildOfType<EditText> ("MyEditText");
			}

			try
			{
				if (uiInput != null)
				{
					uiInput.Select (0, 0);
					uiInput.IsSelectionActive = false;
					//uiInput.IsEnabled = false;
					//uiInput.IsReadOnly = true;
				}
			}
			catch (Exception e)
			{
				Log.Error (e.Message);
				Log.Error (e.StackTrace);
			}

			ToggleUI ();
		}
		public override void Update()
        {
			if (Input.IsKeyReleased (Keys.Return))
			{
				uiEnabled = !uiEnabled;
				ToggleUI ();
			}
		}

		void ToggleUI ()
		{
			if(uiComp == null)
				return;

			Log.Info("ToggleUI: " + uiEnabled);

			try
			{
				uiComp.Enabled = uiEnabled;

				if (uiComp.Enabled)
				{
					if (uiInput == null)
					{
						uiInput = uiComp.Page.RootElement.FindVisualChildOfType<EditText> ("MyEditText");
					}

					if(uiInput != null)
					{
						uiInput.IsSelectionActive = uiEnabled;
					}
				}
			}
			catch (Exception e)
			{
				Log.Error (e.Message);
				Log.Error (e.StackTrace);
			}
		}
    }
}
