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
using System.Drawing.Drawing2D;

namespace Photo_To_Blueprint
{
    public partial class Form1 : Form
    {
        public Bitmap currentImage;

        public StringBuilder currentBuilder = new StringBuilder();

        public string fileName = "", originPath = "";

        public bool countNeeded = false, intercontrol = false;

        public int pixelCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var fileContent = string.Empty;
                var filePath = string.Empty;

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 0;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                        try
                        {
                            Bitmap image = new Bitmap(Bitmap.FromFile(filePath));
                            currentImage = new Bitmap(image);
                            SetPictureBox(image);
                            pixelCount = currentImage.Width * currentImage.Height;
                            countNeeded = true;
                            timer1.Enabled = true;
                            timer1.Start();
                            originPath = filePath;
                            UpdateImageStats();
                        }
                        catch
                        {
                            MessageBox.Show("Something went wrong with that picture, pick another");
                        }
                    }
                }
            }
            catch { MessageBox.Show("Something went wrong opening an image, try again"); }
        }

        public void SetPictureBox(Bitmap image)
        {
            try
            {
                pictureBox1.Image = new Bitmap(image);
            }
            catch { }
        }

        public void UpdateImageStats(double givenRatio = -1)
        {
            double ratio = givenRatio;
            int total = currentImage.Width * currentImage.Height;
            if (ratio == -1)
                ratio = (double)numericUpDownResize.Value / 100.0;
            labelImageHeight.Text = $"Height: {currentImage.Height}";
            labelImageWidth.Text = $"Width: {currentImage.Width}";
            labelImageCount.Text = $"Blocks: {pixelCount}";
            if (pixelCount < total)
                labelImageCount.Text += $" -({total - pixelCount} excluded)";
            int x = (int)((double)currentImage.Width * ratio), y = (int)((double)currentImage.Height * ratio);
            labelResizeHeight.Text = $"Height: {y}";
            labelResizeWidth.Text = $"Width: {x}";
            labelResizeBlocks.Text = $"Blocks: {(int)((double)pixelCount * ratio)}";
        }

        public void GenerateBlueprint()
        {
            string appdataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SpaceEngineers\Blueprints\local";
            string blueprintDirectory = appdataDirectory + $"\\{textBoxShipName.Text}";

            try
            {

                if (Directory.Exists(blueprintDirectory))
                {
                    DialogResult dr = MessageBox.Show("Overwrite Existing Blueprint?", $"Blueprint {textBoxShipName.Text} already exists, delete existing blueprint?", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            Directory.Delete(blueprintDirectory, true);
                            break;
                        case DialogResult.No:
                            return;
                    }
                }
            }
            catch { MessageBox.Show("An error occurred either checking if the folder exists or trying to delete it"); }

            try
            {
                Directory.CreateDirectory(blueprintDirectory);
            }
            catch
            {
                MessageBox.Show("An error occurred creating the blueprint directory. Cancelling generation.");
                return;
            }

            try
            {
                currentImage.Save(blueprintDirectory + @"\thumb.png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch
            {
                MessageBox.Show("An error occurred creating the thumbnail. Continuing with generation.");
            }


            fileName = blueprintDirectory + @"\bp.sbc";

            bool success = false;

            try
            {
                using (StreamWriter currentWriter = File.CreateText(fileName))
                {
                    currentWriter.AutoFlush = true;

                    currentWriter.Write(StartBlueprint(textBoxShipName.Text, textBoxUserName.Text));

                    Color pixelColor, excludeColor = NumericColor();

                    Vector2 vector = new Vector2();

                    int max = currentImage.Width * currentImage.Height;

                    for (int x = 0; x < currentImage.Width; x++)
                    {
                        for (int y = currentImage.Height - 1; y >= 0; y--)
                        {
                            pixelColor = currentImage.GetPixel(x, y);
                            if (pixelColor != Color.Empty && ColorDifference(pixelColor, excludeColor) > (int)numericUpDownColorThreshold.Value)
                            {
                                vector.x = x + (currentImage.Width / 2);
                                vector.y = y - currentImage.Height;
                                if (radioButtonLargeGrid.Checked)
                                    currentWriter.Write(GenerateBlock(vector, pixelColor));
                                else
                                    currentWriter.Write(GenerateBlock(vector, pixelColor, "SmallBlockArmorBlock"));
                            }
                        }
                    }
                    currentWriter.Write(FinishBlueprint(textBoxShipName.Text));

                    currentWriter.Close();
                    success = true;
                }

                MessageBox.Show("Success");
            }
            catch { }
            if (!success) MessageBox.Show("Error opening file");
        }

        public double ColorDifference(Color colorA, Color colorB)
        {
            return Math.Abs(colorA.R - colorB.R) + Math.Abs(colorA.G - colorB.G) + Math.Abs(colorA.B - colorB.B);
        }

        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;

            hue /= 360.0;
            saturation -= 0.8;
            value -= 0.45;
        }

        public string StartBlueprint(string shipName = "Ship", string userName = "Name")
        {
            Random rnd = new Random();
            StringBuilder currentBuilder = new StringBuilder();

            currentBuilder.AppendLine("<?xml version=\"1.0\"?>");
            currentBuilder.AppendLine("<Definitions xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
            currentBuilder.AppendLine("  <ShipBlueprints>");
            currentBuilder.AppendLine("    <ShipBlueprint xsi:type=\"MyObjectBuilder_ShipBlueprintDefinition\">");
            currentBuilder.AppendLine($"      <Id Type=\"MyObjectBuilder_ShipBlueprintDefinition\" Subtype=\"{shipName}\" />");
            currentBuilder.AppendLine($"      <DisplayName>{userName }</DisplayName>");
            currentBuilder.AppendLine("      <CubeGrids>");
            currentBuilder.AppendLine("        <CubeGrid>");
            currentBuilder.AppendLine("          <SubtypeName />");
            currentBuilder.AppendLine($"          <EntityId>{rnd.Next(10000000, 99999999)}{rnd.Next(10000000, 99999999)}{rnd.Next(1, 9)}</EntityId>");
            currentBuilder.AppendLine("          <PersistentFlags>CastShadows InScene</PersistentFlags>");
            currentBuilder.AppendLine("          <PositionAndOrientation>");
            currentBuilder.AppendLine("            <Position x=\"0\" y=\"0\" z=\"0\" />");
            currentBuilder.AppendLine("            <Forward x=\"0\" y=\"0\" z=\"1\" />");
            currentBuilder.AppendLine("            <Up x=\"0\" y=\"1\" z=\"0\" />");
            currentBuilder.AppendLine("            <Orientation>");
            currentBuilder.AppendLine("              <X>0</X>");
            currentBuilder.AppendLine("              <Y>0</Y>");
            currentBuilder.AppendLine("              <Z>1</Z>");
            currentBuilder.AppendLine("              <W>0</W>");
            currentBuilder.AppendLine("            </Orientation>");
            currentBuilder.AppendLine("          </PositionAndOrientation>");
            if (radioButtonLargeGrid.Checked)
                currentBuilder.AppendLine("          <GridSizeEnum>Large</GridSizeEnum>");
            else
                currentBuilder.AppendLine("          <GridSizeEnum>Small</GridSizeEnum>");
            currentBuilder.AppendLine("          <CubeBlocks>");

            return currentBuilder.ToString();
        }

        public string FinishBlueprint(string shipName = "Ship")
        {
            StringBuilder currentBuilder = new StringBuilder();

            currentBuilder.AppendLine("          </CubeBlocks>");
            currentBuilder.AppendLine($"          <DisplayName>{shipName}</DisplayName>");
            currentBuilder.AppendLine("          <DestructibleBlocks>true</DestructibleBlocks>");
            currentBuilder.AppendLine("          <IsRespawnGrid>false</IsRespawnGrid>");
            currentBuilder.AppendLine("          <LocalCoordSys>0</LocalCoordSys>");
            currentBuilder.AppendLine("          <TargetingTargets />");
            currentBuilder.AppendLine("        </CubeGrid>");
            currentBuilder.AppendLine("      </CubeGrids>");
            currentBuilder.AppendLine("      <EnvironmentType>None</EnvironmentType>");
            currentBuilder.AppendLine("      <WorkshopId>0</WorkshopId>");
            currentBuilder.AppendLine("      <OwnerSteamId>0</OwnerSteamId>");
            currentBuilder.AppendLine("      <Points>0</Points>");
            currentBuilder.AppendLine("    </ShipBlueprint>");
            currentBuilder.AppendLine("  </ShipBlueprints>");
            currentBuilder.Append("</Definitions>");

            return currentBuilder.ToString();
        }

        public string GenerateBlock(Vector2 vector2, Color color, string subType = "LargeBlockArmorBlock")
        {
            double hue = 0, saturation = 0, value = 0;
            ColorToHSV(color, out hue, out saturation, out value);

            StringBuilder builder = new StringBuilder();
            builder.AppendLine("            <MyObjectBuilder_CubeBlock xsi:type=\"MyObjectBuilder_CubeBlock\">");
            builder.AppendLine($"               <SubtypeName>{subType}</SubtypeName>");
            builder.AppendLine($"               <Min x=\"{vector2.x.ToString("N0")}\" y=\"{vector2.y.ToString("N0")}\" z=\"{0}\" />");
            builder.AppendLine($"               <ColorMaskHSV x=\"{hue}\" y=\"{saturation}\" z=\"{value}\" />");
            builder.AppendLine($"               <BuiltBy>100000000000000000</BuiltBy>");
            builder.AppendLine("            </MyObjectBuilder_CubeBlock>");
            return builder.ToString();
        }

        public bool ImageGood()
        {
            try
            {
                return currentImage != null && currentImage.Width > 0 && currentImage.Height > 0;
            }
            catch { return false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ImageGood())
                {
                    if (textBoxShipName.Text.Length == 0)
                    {
                        Random rnd = new Random();
                        textBoxShipName.Text = $"Ship {rnd.Next(4200, 69000)}";
                    }
                    if (textBoxUserName.Text.Length == 0)
                        textBoxUserName.Text = "Engineer";
                    GenerateBlueprint();
                }
                else MessageBox.Show("Please choose an image");
            }
            catch { MessageBox.Show("Something went generating the blueprint, try again"); }
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void stretchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void autoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                if (!intercontrol)
                {
                    if (ImageGood())
                    {
                        labelResize.Text = $"Resize Percentage: {(((double)trackBar1.Value / (double)trackBar1.Maximum) * 100.0).ToString("N1")}%";
                        UpdateImageStats((double)trackBar1.Value / (double)trackBar1.Maximum);
                    }
                    else trackBar1.Value = trackBar1.Maximum;
                    intercontrol = true;
                    numericUpDownResize.Value = (decimal)(((double)trackBar1.Value / (double)trackBar1.Maximum) * 100.0);
                    intercontrol = false;
                }
            }
            catch { MessageBox.Show("Something went wrong chaning the resize values, try agagin"); }
        }

        private void numericUpDownResize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!intercontrol)
                {
                    if (ImageGood())
                    {
                        labelResize.Text = $"Resize Percentage: {numericUpDownResize.Value.ToString("N1")}%";
                        UpdateImageStats();
                    }
                    else numericUpDownResize.Value = 100;
                    intercontrol = true;
                    trackBar1.Value = Math.Min(trackBar1.Maximum, (int)((double)trackBar1.Maximum * ((double)numericUpDownResize.Value / 100.0)));
                    intercontrol = false;
                }
            }
            catch { MessageBox.Show("Something went wrong chaning the resize values, try agagin"); }
        }

        public void Recount()
        {
            try
            {
                pixelCount = currentImage.Width * currentImage.Height;
                timer1.Enabled = true;
                timer1.Stop();
                timer1.Enabled = false;
                timer1.Enabled = true;
                timer1.Start();
                countNeeded = true;
                if (backgroundWorker1.IsBusy && !backgroundWorker1.CancellationPending) backgroundWorker1.CancelAsync();
                else RefreshWorker();
            }
            catch { MessageBox.Show("Something went wrong counting pixels"); }
        }

        public void RefreshWorker()
        {
            try
            {
                backgroundWorker1.Dispose();
            }
            catch { }
            try
            {
                backgroundWorker1 = new BackgroundWorker();
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
                backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ImageGood())
                {
                    double ratio = (double)numericUpDownResize.Value / 100.0;
                    Bitmap image = new Bitmap(currentImage);
                    if (!checkBox1.Checked)
                        image = AltResizeBitmap(image, (int)((double)image.Width * ratio), (int)((double)image.Height * ratio));
                    else
                        image = ResizeBitmap(image, (int)((double)image.Width * ratio), (int)((double)image.Height * ratio));
                    currentImage = new Bitmap(image);
                    SetPictureBox(image);
                    trackBar1.Value = trackBar1.Maximum;
                    labelResize.Text = "Resize Percentage: 100.0 %";
                    UpdateImageStats();
                    Recount();
                }
                else MessageBox.Show("Please choose an image");
            }
            catch { MessageBox.Show("Something went wrong resizing the image, try again"); }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            switch (domainUpDown1.SelectedItem)
            {
                case "White":
                    numericUpDownRed.Value = 255;
                    numericUpDownGreen.Value = 255;
                    numericUpDownBlue.Value = 255;
                    break;
                case "Black":
                    numericUpDownRed.Value = 0;
                    numericUpDownGreen.Value = 0;
                    numericUpDownBlue.Value = 0;
                    break;
                case "Red":
                    numericUpDownRed.Value = 255;
                    numericUpDownGreen.Value = 0;
                    numericUpDownBlue.Value = 0;
                    break;
                case "Green":
                    numericUpDownRed.Value = 0;
                    numericUpDownGreen.Value = 255;
                    numericUpDownBlue.Value = 0;
                    break;
                case "Blue":
                    numericUpDownRed.Value = 0;
                    numericUpDownGreen.Value = 0;
                    numericUpDownBlue.Value = 255;
                    break;
                case "Yellow":
                    numericUpDownRed.Value = 255;
                    numericUpDownGreen.Value = 255;
                    numericUpDownBlue.Value = 0;
                    break;
                case "Pink":
                    numericUpDownRed.Value = 255;
                    numericUpDownGreen.Value = 0;
                    numericUpDownBlue.Value = 255;
                    break;
            }
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        public Color NumericColor()
        {
            return Color.FromArgb((int)numericUpDownRed.Value, (int)numericUpDownGreen.Value, (int)numericUpDownBlue.Value);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (ImageGood())
                {
                    Bitmap image = new Bitmap(currentImage);
                    int pixelTotal = pixelCount, currentPixel = 1, currentPercent = 0, tempPercent = -1, threshold = (int)numericUpDownColorThreshold.Value;
                    Color removalColor = NumericColor();
                    for (int x = 0; x < image.Width && !backgroundWorker1.CancellationPending; x++)
                    {
                        for (int y = 0; y < image.Height && !backgroundWorker1.CancellationPending; y++)
                        {
                            Color color = image.GetPixel(x, y);
                            if (color == Color.Empty || (threshold > -1 && ColorDifference(removalColor, color) <= threshold))
                                pixelCount--;
                            currentPixel++;
                            tempPercent = (int)(((double)currentPixel / (double)pixelTotal) * 100.0);
                            if (tempPercent != currentPercent)
                            {
                                currentPercent = tempPercent;
                                if (currentPercent >= 0 && currentPercent <= 100)
                                    backgroundWorker1.ReportProgress(currentPercent);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
                UpdateImageStats();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ImageGood() && countNeeded)
            {
                if (backgroundWorker1.IsBusy)
                {
                    if (!backgroundWorker1.CancellationPending)
                        backgroundWorker1.CancelAsync();
                }
                else
                {
                    RefreshWorker();
                    backgroundWorker1.RunWorkerAsync();
                    countNeeded = false;
                    timer1.Stop();
                    timer1.Enabled = false;
                }
            }
        }

        private void numericUpDownRed_ValueChanged(object sender, EventArgs e)
        {
            Recount();
        }

        private void numericUpDownGreen_ValueChanged(object sender, EventArgs e)
        {
            Recount();
        }

        private void numericUpDownBlue_ValueChanged(object sender, EventArgs e)
        {
            Recount();
        }

        private void numericUpDownColorThreshold_ValueChanged(object sender, EventArgs e)
        {
            Recount();
        }

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    try
                    {
                        Bitmap image = new Bitmap(pictureBox1.Image);

                        double dX = e.X, dY = e.Y;

                        dX = dX * ((double)image.Width / (double)pictureBox1.Width);
                        dY = dY * ((double)image.Height / (double)pictureBox1.Height);

                        int x = (int)Math.Floor(dX), y = (int)Math.Floor(dY);

                        if (x > 0 && x < image.Width && y > 0 && y < image.Height)
                        {
                            Color color = image.GetPixel(x, y);
                            labelColor.Text = $"Color: {color.R}:{color.G}:{color.B}:{color.A}";
                        }
                        else labelColor.Text = "Color: ";
                    }
                    catch { labelColor.Text = "Color: "; }
                }
                else labelColor.Text = "Color: ";
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Recount();
        }

        public Bitmap AltResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap image;
            using (Image src = bmp)
            using (Bitmap dst = new Bitmap(width, height))
            using (Graphics g = Graphics.FromImage(dst))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(src, 0, 0, dst.Width, dst.Height);
                image = new Bitmap(dst);
            }
            return image;
        }
    }


    public class Vector2
    {
        public double x = 0, y = 0;

        public static Vector2 operator *(Vector2 vectorA, double divisor)
        {
            Vector2 vector = new Vector2();
            vector.x = vectorA.x / divisor;
            vector.y = vectorA.y / divisor;
            return vector;
        }

        public static Vector2 operator /(Vector2 vectorA, double multiplier)
        {
            Vector2 vector = new Vector2();
            vector.x = vectorA.x * multiplier;
            vector.y = vectorA.y * multiplier;
            return vector;
        }

        public static Vector2 operator -(Vector2 vectorA, Vector2 vectorB)
        {
            Vector2 vector = new Vector2();
            vector.x = vectorA.x - vectorB.x;
            vector.y = vectorA.y - vectorB.y;
            return vector;
        }

        public static Vector2 operator +(Vector2 vectorA, Vector2 vectorB)
        {
            Vector2 vector = new Vector2();
            vector.x = vectorA.x + vectorB.x;
            vector.y = vectorA.y + vectorB.y;
            return vector;
        }
    }
}
