using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WordleSolver.Models
{
    public partial class SequenceSlot : UserControl
    {
        public SequenceSlot()
        {
            InitializeComponent();
        }

        private void SequenceSlot_Load(object sender, EventArgs e)
        {

        }

        private void callStateSwitch()
        {
            switch ((int)currentState)
            {
                case 0:
                    currentState = SlotState.CLCP;
                    break;
                case 1:
                    currentState = SlotState.CLWP;
                    break;
                case 2:
                    currentState = SlotState.WLWP;
                    break;
                default:
                    currentState = SlotState.DEFAULT;
                    break;
            }
        }

        public void disableStateRepresentation()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativeDirectory = Path.Combine(currentDirectory, "..\\..\\Assets\\");

            string assetDirectory;
            Image stateRepresentation;

            switch ((int)currentState)
            {
                case 0:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "DEFAULT_DISABLED.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
                case 1:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "CLCP_DISABLED.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
                case 2:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "CLWP_DISABLED.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
                case 3:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "WLWP_DISABLED.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
                default:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "DEFAULT_DISABLED.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
            }

            this.updateable = false;
            this.DisableTyping();
            this.BackgroundImage = stateRepresentation;
        }

        public void updateStateRepresentation()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativeDirectory = Path.Combine(currentDirectory, "..\\..\\Assets\\");

            string assetDirectory;
            Image stateRepresentation;

            switch ((int)currentState)
            {
                case 0:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "DEFAULT_STATE.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
                case 1:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "CLCP_STATE.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
                case 2:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "CLWP_STATE.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
                case 3:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "WLWP_STATE.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
                default:
                    assetDirectory = Path.GetFullPath(relativeDirectory + "DEFAULT_STATE.png");
                    stateRepresentation = new Bitmap(assetDirectory);
                    break;
            }

            this.updateable = true;
            this.BackgroundImage = stateRepresentation;
        }

        public SlotState getStateEnum()
        {
            return this.currentState;
        }

        public string getState()
        {
            return this.currentState.ToString();
        }

        public void setState(SlotState state)
        {
            this.currentState = state;
        }

        public string getValue()
        {
            return (this.slotInput.getLabelValue() != "" ? this.slotInput.getLabelValue() : "%");
        }

        public void setValue(string value)
        {
            this.slotInput.Visible = true;
            this.slotInput.setLabelValue(value);
        }

        public void DisableTyping()
        {
            this.slotInput.HideInput();
            this.updateable = false;
        }

        // SOmething here
        public void EnableTyping()
        {
            this.slotInput.ShowInput();
            this.updateable = true;
        }
    }
}
