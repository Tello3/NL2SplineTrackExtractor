using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NL2SplineTrackExtractor
{
    public partial class Form1 : Form
    {
        //Data
        private string inputFilePath;
        private string outputFolderPath;
        private List<float>[] position;
        private List<float>[] left;
        private List<float>[] up;
        
        //Split
        private List<int> splitPoints;
        private SplitTypes splitType;
        //Cut by nodes
        private int nodesPerSplit;
        //Cut into pieces
        private int numPieces;

        private float deg2Rad = (float)Math.PI / 180f;


        //Scaling
        private float scale = 1;
        private float topScale = 1;
        private float bottomScale=1;
        private float leftScale = 1;
        private float rightScale = 1;
        private bool scaleAffectDistances = true;
        private bool scaleAffectOffset = true;
        //Rotation
        private float xRotation;
        private float yRotation;
        private float zRotation;
        //Offset
        private float xOffset;
        private float yOffset;
        private float zOffset;

        //Misc
        private IFormatProvider usFormat = new CultureInfo("en-US"); //this is used to make sure the floats are read and written with a decimal point

        public enum Axis
        {
            x= 0, y=1, z=2,
        }
        public enum SplitTypes
        {
            none = 0,
            nodes = 1,
            pieces = 2,
        }
        public Form1()
        {
            InitializeComponent();
            splitTypeSelector.Items.AddRange(new string[] { "Dont't split", "Split after x nodes", "Split into x pieces" });
            splitTypeSelector.SelectedIndex = 0;
            nodesPerSplitSelector.Minimum = 1;
            piecesSelector.Minimum = 1;
            this.ActiveControl = inputPathChangeBtn;
            Debug.WriteLine(deg2Rad);
        }



        private bool loadData()
        {
            if(inputFilePath== null)
            {
                MessageBox.Show("Please select an input file", "No input file selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            try
            {
                IEnumerable<string> lines = File.ReadLines(inputFilePath);
                position = new List<float>[] { new List<float>(), new List<float>(), new List<float>() };
                left = new List<float>[] { new List<float>(), new List<float>(), new List<float>() };
                up = new List<float>[] { new List<float>(), new List<float>(), new List<float>() };
                lines = lines.Skip(1); //Headers;
                foreach (string line in lines)
                {
                    addLineToData(line);
                }
            }
            catch (IOException e)
            {
                MessageBox.Show($"Error while loading the input file: {e.Message}", "Error while loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private int getNumPointsPerSpline()
        {
            if (inputFilePath == null)
            {
                MessageBox.Show("Please select an input file", "No input file selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            try
            {
                IEnumerable<string> lines = File.ReadLines(inputFilePath);
                return lines.Count() - 1;//-1 for headers
            }
            catch (IOException e)
            {
                MessageBox.Show($"Error while loading the input file: {e.Message}", "Error while loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
        private void addLineToData(string line)
        {
            string[] values = line.Split('\t');
            float normalScale = scaleAffectDistances ? scale : 1;
            float[] floatValues = values.Select<string, float>(s => float.Parse(s, usFormat)).ToArray();
                                                                        //0: No.
            position[((int)Axis.x)].Add(floatValues[1] * scale);        //1: posx
            position[((int)Axis.y)].Add(floatValues[2] * scale);        //2: posy
            position[((int)Axis.z)].Add(floatValues[3] * scale);        //3: posz
                                                                        //4: frontx
                                                                        //5: fronty
                                                                        //6: frontz
            left[((int)Axis.x)].Add(floatValues[7] * normalScale);      //7: leftx
            left[((int)Axis.y)].Add(floatValues[8] * normalScale);      //8: lefty
            left[((int)Axis.z)].Add(floatValues[9] * normalScale);      //9: leftz
            up[((int)Axis.x)].Add(floatValues[10] * normalScale);       //10: upx
            up[((int)Axis.y)].Add(floatValues[11] * normalScale);       //11: upy
            up[((int)Axis.z)].Add(floatValues[12] * normalScale);       //12: upz
        }

        private void calculateSplines()
        {
            caluclateBtn.Enabled = false;
            inputPathTextBox.Enabled = false;
            inputPathChangeBtn.Enabled = false;
            outputPathChangeBtn.Enabled = false;
            outputPathTextbox.Enabled = false;

            if (Directory.Exists(outputFolderPath))
            {
                if (loadData())
                {
                    findSplitPoints();
                    extractTrackSplines();

                    DialogResult result = MessageBox.Show($"Extraction finished without errors! \nDo you want to open the output folder?", "Extraction finished!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        Process.Start(outputFolderPath);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a valid output folder", "Invalid output directory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            caluclateBtn.Enabled = true;
            inputPathTextBox.Enabled = true;
            inputPathChangeBtn.Enabled = true;
            outputPathChangeBtn.Enabled = true;
            outputPathTextbox.Enabled = true;
        }

        private void extractTrackSplines()
        {
            for (int i = 0; i < splitPoints.Count - 1; i++)
            {
                string currentPath = outputFolderPath + "\\Track" + i;
                Directory.CreateDirectory(currentPath);
                int from = splitPoints[i];
                int to = splitPoints[i + 1];
                if (centerChkbx.Checked)
                {
                    extractCenter(from, to, currentPath);
                }
                if (topChkbx.Checked)
                {
                    extractTop(from, to, currentPath);
                }
                if (bottomChkbx.Checked)
                {
                    extractBottom(from, to, currentPath);
                }
                if (leftChkbx.Checked)
                {
                    extractLeft(from, to, currentPath);
                }
                if (rightChkbx.Checked)
                {
                    extractRight(from, to, currentPath);
                }
            }
        }

        #region Extraction
        private void extractRight(int from, int to, string savePath)
        {
            string lines = "";

            for(int i = from; i <= to; i++)
            {
                float x = position[((int)Axis.x)][i] - left[((int)Axis.x)][i] * rightScale;
                float y = position[((int)Axis.y)][i] - left[((int)Axis.y)][i] * rightScale;
                float z = position[((int)Axis.z)][i] - left[((int)Axis.z)][i] * rightScale;
                rotateAndOffset(x, y, z, out float newX, out float newY, out float newZ);
                lines += newX.ToString(usFormat) + ",";
                lines += newY.ToString(usFormat) + ",";
                lines += newZ.ToString(usFormat);
                lines += "\n";
            }
            File.WriteAllText(savePath+"\\Right.csv", lines);
        }

        private void extractCenter(int from, int to, string savePath)
        {
            string lines = "";

            for (int i = from; i <= to; i++)
            {
                float x = position[((int)Axis.x)][i]; 
                float y = position[((int)Axis.y)][i];
                float z = position[((int)Axis.z)][i];
                rotateAndOffset(x, y, z, out float newX, out float newY, out float newZ);
                lines += newX.ToString(usFormat) + ",";
                lines += newY.ToString(usFormat) + ",";
                lines += newZ.ToString(usFormat);
                lines += "\n";
            }
            File.WriteAllText(savePath + "\\Center.csv", lines);
        }

        private void extractLeft(int from, int to, string savePath)
        {
            string lines = "";

            for (int i = from; i <= to; i++)
            {
                float x = position[((int)Axis.x)][i] + left[((int)Axis.x)][i] * leftScale; 
                float y = position[((int)Axis.y)][i] + left[((int)Axis.y)][i] * leftScale;
                float z = position[((int)Axis.z)][i] + left[((int)Axis.z)][i] * leftScale;
                rotateAndOffset(x, y, z, out float newX, out float newY, out float newZ);
                lines += newX.ToString(usFormat) + ",";
                lines += newY.ToString(usFormat) + ",";
                lines += newZ.ToString(usFormat);
                lines += "\n";
            }
            File.WriteAllText(savePath + "\\Left.csv", lines);
        }

        private void extractTop(int from, int to, string savePath)
        {
            string lines = "";

            for (int i = from; i <= to; i++)
            {
                float x = position[((int)Axis.x)][i] + up[((int)Axis.x)][i] * topScale;
                float y = position[((int)Axis.y)][i] + up[((int)Axis.y)][i] * topScale;
                float z = position[((int)Axis.z)][i] + up[((int)Axis.z)][i] * topScale;
                rotateAndOffset(x, y, z, out float newX, out float newY, out float newZ);
                lines += newX.ToString(usFormat) + ",";
                lines += newY.ToString(usFormat) + ",";
                lines += newZ.ToString(usFormat);
                lines += "\n";
            }
            File.WriteAllText(savePath + "\\Top.csv", lines);
        }

        private void extractBottom(int from, int to, string savePath)
        {
            string lines = "";

            for (int i = from; i <= to; i++)
            {
                float x = position[((int)Axis.x)][i] - up[((int)Axis.x)][i] * bottomScale;
                float y = position[((int)Axis.y)][i] - up[((int)Axis.y)][i] * bottomScale;
                float z = position[((int)Axis.z)][i] - up[((int)Axis.z)][i] * bottomScale;
                rotateAndOffset(x,  y, z, out float newX, out float newY, out float newZ);
                lines += newX.ToString(usFormat) + ",";
                lines += newY.ToString(usFormat) + ",";
                lines += newZ.ToString(usFormat);
                lines += "\n";
            }
            File.WriteAllText(savePath + "\\Bottom.csv", lines);
        }

        private void rotateAndOffset(float x, float y, float z, out float newX, out float newY, out float newZ)
        {
            //Rotation * deg2Rad
            // X Axis
            newX = x;
            newY = y * (float)Math.Cos(xRotation * deg2Rad) - z * (float)Math.Sin(xRotation * deg2Rad);
            newZ = y * (float)Math.Sin(xRotation * deg2Rad) + z * (float)Math.Cos(xRotation * deg2Rad);

            // Y Axis
            float oldX = newX;
            float oldY = newY;
            float oldZ = newZ;
            newX = oldX * (float)Math.Cos(yRotation * deg2Rad) + oldZ * (float)Math.Sin(yRotation * deg2Rad);
            newY = oldY;
            newZ = oldZ * (float)Math.Cos(yRotation * deg2Rad) - oldX * (float)Math.Sin(yRotation * deg2Rad);

            // Z Axis
            oldX = newX;
            oldY = newY;
            oldZ = newZ;
            newX = oldX * (float)Math.Cos(zRotation * deg2Rad) - oldY * (float)Math.Sin(zRotation * deg2Rad);
            newY = oldX * (float)Math.Sin(zRotation * deg2Rad) + oldY * (float)Math.Cos(zRotation * deg2Rad);
            newZ = oldZ;

            //Offsets
            newX += xOffset;
            newY += yOffset;
            newZ += zOffset;
        }

        #endregion

        #region SplitPoints
        private void findSplitPoints()
        {
            splitPoints = new List<int>();
            splitPoints.Add(0);

            switch (splitType)
            {
                case SplitTypes.none:
                    {
                        //dont split
                    }
                    break;
                case SplitTypes.nodes:
                    {
                        findSplitPointsDistance(nodesPerSplit);
                    }
                    break;
                case SplitTypes.pieces:
                    {
                        findSplitPointsDistance(position[0].Count / numPieces);
                    }
                    break;
            }
            splitPoints.Add(position[0].Count-1);
        }
        private void findSplitPointsDistance(int nodesPerSplit)
        {
            for (int i = nodesPerSplit-1; i < position[0].Count - nodesPerSplit; i += nodesPerSplit) {

                splitPoints.Add(i);
            }
        }
        #endregion

        #region UI

        #region Events
        private void inputPathChangeBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\Users\\%USER%";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    inputPathTextBox.Text = openFileDialog.FileName;
                    inputFilePath = openFileDialog.FileName;
                    UpdateNumSplinePoints();
                }
            }
        }

        private void inputPathTextBox_TextChanged(object sender, EventArgs e)
        {
            inputFilePath = ((TextBox)sender).Text;
        }

        private void caluclateBtn_Click(object sender, EventArgs e)
        {
            calculateSplines();
        }

        private void outputPathTextbox_TextChanged(object sender, EventArgs e)
        {
            outputFolderPath = ((TextBox)sender).Text;
        }

        private void outputPathChangeBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    outputPathTextbox.Text = fbd.SelectedPath;
                    outputFolderPath = fbd.SelectedPath;
                }
            }
        }

        private void splitTypeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            splitType = (SplitTypes)((ComboBox)sender).SelectedIndex;
            switch (splitType)
            {
                case SplitTypes.none:
                    {
                        xLabel.Visible = false;
                        nodesPerSplitSelector.Visible = false;
                        piecesSelector.Visible = false;
                    }
                    break;
                case SplitTypes.nodes:
                    {
                        xLabel.Visible = true;
                        nodesPerSplitSelector.Visible = true;
                        piecesSelector.Visible = false;
                    }
                    break;
                case SplitTypes.pieces:
                    {
                        xLabel.Visible = true;
                        nodesPerSplitSelector.Visible = false;
                        piecesSelector.Visible = true;
                    }
                    break;
            }
        }

        private void scalingTextbox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
                scale = value;
            
            
        }

        private void affectDistancesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            scaleAffectDistances = ((CheckBox)sender).Checked;
        }

        private void piecesSelector_ValueChanged(object sender, EventArgs e)
        {
            numPieces = (int)((NumericUpDown)sender).Value;
        }

        private void nodesPerSplitSelector_ValueChanged(object sender, EventArgs e)
        {
            nodesPerSplit = (int)((NumericUpDown)sender).Value;
        }

        private void inputPathTextBox_LostFocus(object sender, EventArgs e)
        {
            
            UpdateNumSplinePoints();
            
            
        }

        private void topDistanceTextBox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
                topScale = value / 10f;
            
            
        }

        private void rightDistanceTextBox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
                rightScale = value / 10f;
            
            
        }

        private void bottomDistanceTextBox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
                bottomScale = value / 10f;
            
            
        }

        private void leftDistanceTextBox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox) sender, out float value))
                leftScale = value / 10f;
            
            
        }

        private void affectOffsetCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            scaleAffectOffset = ((CheckBox)sender).Checked;
        }

        private void xOffsetTextbox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
                xOffset = value;
            
            
        }

        private void yOffsetTextbox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
                yOffset = value;
            
            
        }

        private void zOffsetTextbox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
                zOffset = value;
            
            
        }

        private void xRotationTextbox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
            {
                if(xRotation != value)
                {
                    xRotation = value > 360 ? 360 : value < 0 ? 0 : value;
                    xRotationTextbox.Text = xRotation.ToString(usFormat);
                }
            }
            
            
        }

        private void yRotationTextbox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
            {
                if (yRotation != value)
                {
                    yRotation = value > 360 ? 360 : value < 0 ? 0 : value;
                    yRotationTextbox.Text = yRotation.ToString(usFormat);
                }
            }
            
            
        }

        private void zRotationTextbox_LostFocus(object sender, EventArgs e)
        {
            
            if (TryParseNumberFromTextbox((TextBox)sender, out float value))
            {
                if (zRotation != value)
                {
                    zRotation = value > 360 ? 360 : value < 0 ? 0 : value;
                    zRotationTextbox.Text = zRotation.ToString(usFormat);
                }
            }
            
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            if(sender is TextBox)
                ((TextBox)sender).SelectAll();
        }

        private void textField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = null;//revoke focus
                e.Handled = true;

            }
        }

        #endregion
        private void UpdateNumSplinePoints()
        {
            int num = getNumPointsPerSpline();
            numSplinePointsLabel.Text = num >= 0 ? num.ToString() : "N/A";

            nodesPerSplitSelector.Maximum = num;
            piecesSelector.Maximum = num;
        }
        private bool TryParseNumberFromTextbox(TextBox textBox, out float value)
        {
            if (float.TryParse(textBox.Text.Trim(), NumberStyles.Number, usFormat, out value))
            {
                return true;
            }
            else
            {
                MessageBox.Show("The number you entered wasn't valid (make sure to use a decimal point and no comma)", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        #endregion

        
    }
}
