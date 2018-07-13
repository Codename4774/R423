using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using StatesDataLibrary.Classes.Models.LinesInfo;
using System.Windows.Shapes;
using StatesDataLibrary.Classes.Controllers;
using StatesDataLibrary.Classes.Models.SignalData;
using StatesDataLibrary.Classes.Services;
using static StatesDataLibrary.Classes.Models.SignalData.SignalPathLineState;

namespace R423.GUILinesInfoBuilder
{
    public partial class FormMain : Form
    {
        private SignalPathStates signalPaths;

        private List<Point> points;

        private Graphics graphics;

        private Pen pen;

        private int id;

        private Bitmap picture;

        public FormMain()
        {
            InitializeComponent();
        }

        private void ResetPoints(List<Point> points)
        {
            points.Clear();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LineStatesController.LineBase = new LinesBase();
            SignalPathStatesController.SignalPathStates = new SignalPathStates();
            SignalPathsController.SignalPaths = new SignalPaths();
            points = new List<Point>();
            picture = new Bitmap("scheme.png");
            graphics = pictureBoxImage.CreateGraphics();
            pen = new Pen(Color.BlueViolet);
            pen.Width = 3;

        }

        private void UpdateLineList()
        {
            listBoxLinesInfo.DataSource = LineStatesController.LineBase.LineBase.ToList();
        }

        private void UpdateLineStateList()
        {
            listBoxSignalPathState.DataSource = SignalPathStatesController.SignalPathStates.ToList();
        }

        private void UpdateSignalPathList()
        {
            listBoxSignalPath.DataSource = SignalPathsController.SignalPaths.Paths.ToList();
        }

        private void pictureBoxImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(new Point(e.X, e.Y));
            }
            else
            {
                if (e.Button == MouseButtons.Middle)
                {
                    ResetPoints(points);
                    Redraw();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (points.Count > 1)
                    {
                        LineStatesController.LineBase.LineBase.Add(++id, new LineInfo(LineInfo.CreatePolylineFromPointsList(points)));
                        ResetPoints(points);
                        Redraw();
                        UpdateLineList();
                    }
                }
            }
        }

        private void pictureBoxImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (points.Count > 0)
            {
                Redraw();
                Point[] drawablePoints = new Point[points.Count + 1];
                points.CopyTo(drawablePoints);
                drawablePoints[drawablePoints.Length - 1] = new Point(e.X, e.Y);
                DrawPolyLine(pen, drawablePoints);
            }
        }

        private void DrawPolyLine(Pen pen, Point[] points, int id = -1)
        {
            Brush brush = new SolidBrush(pen.Color);
            Font font = new Font(DefaultFont.FontFamily, 16);
            graphics.DrawLines(pen, points);
            graphics.DrawEllipse(new Pen(Color.Brown){Width = 10}, points.Last().X - 2, points.Last().Y - 2, 5, 5);
            if (id != -1)
            {
                graphics.DrawString(Convert.ToString(id), font, brush, points.Last().X, points.Last().Y);
            }
        }

        private void DrawPolyLine(Pen pen, Point[] points, DirectionEnum direction, int id = -1)
        {
            Brush brush = new SolidBrush(pen.Color);
            Point[] tempPoints = (Point[])points.Clone();
            Font font = new Font(DefaultFont.FontFamily, 18);
            switch (direction)
            {
                case DirectionEnum.Forward:
                    {
                    }
                    break;
                case DirectionEnum.Back:
                    {
                        tempPoints = tempPoints.Reverse().ToArray();
                    }
                    break;
            }
            graphics.DrawLines(pen, tempPoints);
            graphics.DrawEllipse(new Pen(pen.Color) { Width = 10 }, tempPoints.Last().X - 2, tempPoints.Last().Y - 2, 5, 5);
            if (id != -1)
            {
                graphics.DrawString(Convert.ToString(id), font, brush, points.Last().X, points.Last().Y);
            }
        }

        private void DrawExistingLines(LinesBase linesBase)
        {
            foreach (var lineInfo in linesBase.LineBase)
            {
                DrawExistingLine(pen, lineInfo);
            }
        }

        void DrawExistingLine(Pen pen, KeyValuePair<int, LineInfo> lineInfo)
        {
            LineInfo line = lineInfo.Value;
            DrawPolyLine(pen, LineInfo.GetPointsFromPolyline(line.PartOfLine).ToArray(), lineInfo.Key);
        }

        private void listBoxLinesInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox currListBox = (ListBox) sender;


            if (currListBox.SelectedIndex != -1)
            {
                DrawExistingLines(LineStatesController.LineBase);
                KeyValuePair<int, LineInfo> selectedElement = (KeyValuePair < int, LineInfo>) currListBox.SelectedItem;
                DrawExistingLine(new Pen(Color.Red) {Width = 3}, selectedElement);
                textBoxLineIndex.Text = Convert.ToString(selectedElement.Key);
            }
        }

        private void saveLinesInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confirm ?", "Save lines info", MessageBoxButtons.YesNo);
            if (! (dialog == DialogResult.Abort || dialog == DialogResult.Cancel || dialog == DialogResult.No) )
            {
                Serializer.SerializeLinesBase(LineStatesController.PathToFile, LineStatesController.LineBase);
            }
        }

        private void loadFilesInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confirm ?", "Load lines info", MessageBoxButtons.YesNo);
            if (!(dialog == DialogResult.Abort || dialog == DialogResult.Cancel || dialog == DialogResult.No))
            {
                LineStatesController.LineBase = new LinesBase(LineStatesController.PathToFile);
                id = GetLastIndex(LineStatesController.LineBase.LineBase);
                UpdateLineList();
                Redraw();
            }
        }

        private int GetLastIndex<T>(Dictionary<int, T> dictionary)
        {
            int result = 0;

            foreach (var element in dictionary)
            {
                if (result < element.Key)
                {
                    result = element.Key;
                }
            }
            return result;
        }

        private void buttonDeleteLinesInfo_Click(object sender, EventArgs e)
        {
            if (listBoxLinesInfo.SelectedIndex != -1)
            {
                LineStatesController.LineBase.LineBase.Remove(((KeyValuePair<int, LineInfo>) listBoxLinesInfo.SelectedItem).Key);
                UpdateLineList();
                Redraw();
                textBoxLineIndex.Clear();
            }
        }

        private void Redraw()
        {
            graphics.DrawImageUnscaledAndClipped(picture, new System.Drawing.Rectangle(new Point(0, 0), picture.Size));
            DrawExistingLines(LineStatesController.LineBase);
        }

        private void buttonSaveIndex_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLinesInfo.SelectedIndex != -1)
                {
                    int newValue = Convert.ToInt32(textBoxLineIndex.Text);
                    KeyValuePair<int, LineInfo> selectedElement = (KeyValuePair<int, LineInfo>)listBoxLinesInfo.SelectedItem;

                    if ((newValue < 0) || (LineStatesController.LineBase.LineBase.ContainsKey(newValue) && (newValue != selectedElement.Key)))
                    {
                        throw new Exception();
                    }
                    KeyValuePair<int, LineInfo> updatedElement = new KeyValuePair<int, LineInfo>(newValue, selectedElement.Value);
                    LineStatesController.LineBase.LineBase.Remove(selectedElement.Key);
                    LineStatesController.LineBase.LineBase.Add(updatedElement.Key, updatedElement.Value);
                    UpdateLineList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonReverse_Click(object sender, EventArgs e)
        {
            if (listBoxLinesInfo.SelectedIndex != -1)
            {
                KeyValuePair<int, LineInfo> selectedElement = (KeyValuePair<int, LineInfo>) listBoxLinesInfo.SelectedItem;
                selectedElement.Value.ReverseDirection();
                UpdateLineList();
                Redraw();
            }
        }

        private void buttonDeleteState_Click(object sender, EventArgs e)
        {
            if (listBoxSignalPathState.SelectedIndex != -1)
            {
                SignalPathStatesController.SignalPathStates.States.Remove(((KeyValuePair<int, SignalPathState>)listBoxSignalPathState.SelectedItem).Key);
                UpdateLineStateList();
                textBoxDrawableLines.Clear();
                textBoxNumberState.Clear();
            }
        }

        private void buttonAddState_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxNumberState.Text);
                SignalPathStatesController.AddSignalPathStateFromString(textBoxDrawableLines.Text, id, colorDialogStateColor.Color);
                UpdateLineStateList();
                textBoxNumberState.Clear();
                textBoxDrawableLines.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonAddPath_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxNumberPath.Text);
                SignalPathsController.AddSignalPathFromString(textBoxPathStates.Text, id);
                UpdateSignalPathList();
                textBoxNumberPath.Clear();
                textBoxPathStates.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBoxDrawableLines_TextChanged(object sender, EventArgs e)
        {

        }

        private void savePathStatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Serializer.SerializeSignalPathStatesList(SignalPathStatesController.PathToFile, SignalPathStatesController.SignalPathStates);
        }

        private void loadPathStatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignalPathStatesController.SignalPathStates = new SignalPathStates(SignalPathStatesController.PathToFile);
            UpdateLineStateList();
            Redraw();
        }

        private void buttonSaveState_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxNumberState.Text);
                if (SignalPathStatesController.SignalPathStates.States.ContainsKey(id))
                {
                    SignalPathStatesController.SignalPathStates.States.Remove(id);
                    SignalPathStatesController.AddSignalPathStateFromString(textBoxDrawableLines.Text, id, colorDialogStateColor.Color);
                    UpdateLineStateList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxSignalPathState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox currListBox = (ListBox)sender;


            if (currListBox.SelectedIndex != -1)
            {
                Redraw();
                DrawExistingLines(LineStatesController.LineBase);
                KeyValuePair<int, SignalPathState> selectedElement = (KeyValuePair<int, SignalPathState>)currListBox.SelectedItem;
                DrawSelectedState(selectedElement.Value);
                textBoxNumberState.Text = Convert.ToString(selectedElement.Key);
                textBoxDrawableLines.Text = selectedElement.Value.ToStringForEditing();
                colorDialogStateColor.Color = selectedElement.Value.drawableOnStateLine[0].Color;
                buttonSelectStateLineColor.BackColor = colorDialogStateColor.Color;
            }
        }

        private void DrawSelectedState(SignalPathState state)
        {
            try
            {
                foreach (var item in state.drawableOnStateLine)
                {
                    Pen pen = new Pen(item.Color) { Width = 3 };
                    LineInfo line = LineStatesController.GetLineByIndex(item.Index);

                    DrawPolyLine(pen, LineInfo.GetPointsFromPolyline(line.PartOfLine).ToArray(), item.Direction, item.Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DrawSelectedSignalPath(SignalPath path)
        {
            try
            { 
                foreach (var item in path.States)
                {
                    DrawSelectedState(SignalPathStatesController.SignalPathStates.States[item]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSelectStateLineColor_Click(object sender, EventArgs e)
        {
            if (colorDialogStateColor.ShowDialog() == DialogResult.OK)
            {
                buttonSelectStateLineColor.BackColor = colorDialogStateColor.Color;
            }
        }

        private void buttonSavePath_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxNumberPath.Text);
                if (SignalPathsController.SignalPaths.Paths.ContainsKey(id))
                {
                    SignalPathsController.SignalPaths.Paths.Remove(id);
                    SignalPathsController.AddSignalPathFromString(textBoxPathStates.Text, id);
                    UpdateSignalPathList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveSignalPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Serializer.SerializeSignalPathsList(SignalPathsController.PathToFile, SignalPathsController.SignalPaths);
        }

        private void loadSignalPathsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignalPathsController.SignalPaths = new SignalPaths(SignalPathsController.PathToFile);
            UpdateSignalPathList();
        }

        private void listBoxSignalPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox currListBox = (ListBox)sender;


            if (currListBox.SelectedIndex != -1)
            {
                Redraw();
                DrawExistingLines(LineStatesController.LineBase);
                KeyValuePair<int, SignalPath> selectedElement = (KeyValuePair<int, SignalPath>)currListBox.SelectedItem;
                DrawSelectedSignalPath(selectedElement.Value);
                textBoxNumberPath.Text = Convert.ToString(selectedElement.Key);
                textBoxPathStates.Text = selectedElement.Value.ToString();
            }
        }

        private void buttonDeletePath_Click(object sender, EventArgs e)
        {
            if (listBoxSignalPath.SelectedIndex != -1)
            {
                SignalPathsController.SignalPaths.Paths.Remove(((KeyValuePair<int, SignalPath>)listBoxSignalPath.SelectedItem).Key);
                UpdateSignalPathList();
                textBoxPathStates.Clear();
                textBoxNumberPath.Clear();
            }
        }

        private void panelImageContainer_Scroll(object sender, ScrollEventArgs e)
        {
            Redraw();
        }

        private void panelImageContainer_MouserWheel(object sender, MouseEventArgs e)
        {
            Redraw();
        }
    }
}
