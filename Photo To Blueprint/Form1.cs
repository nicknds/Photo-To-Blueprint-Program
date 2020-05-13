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

namespace Photo_To_Blueprint
{
    public partial class Form1 : Form
    {
        public Bitmap currentImage;

        public StringBuilder currentBuilder = new StringBuilder();

        public string fileName = "", originPath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                        currentImage = image;
                        pictureBox1.Image = image;
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

        public void UpdateImageStats()
        {
            labelImageHeight.Text = $"Height: {currentImage.Height}";
            labelImageWidth.Text = $"Width: {currentImage.Width}";
            labelImageCount.Text = $"Blocks: {currentImage.Height * currentImage.Width}";
            double ratio = (double)trackBar1.Value / (double)trackBar1.Maximum;
            int x = (int)((double)currentImage.Width * ratio), y = (int)((double)currentImage.Height * ratio);
            labelResizeHeight.Text = $"Height: {y}";
            labelResizeWidth.Text = $"Width: {x}";
            labelResizeBlocks.Text = $"Blocks: {x * y}";
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

                    Color pixelColor, excludeColor = Color.FromArgb((int)numericUpDownRed.Value, (int)numericUpDownGreen.Value, (int)numericUpDownBlue.Value);

                    Vector2 vector = new Vector2();

                    int max = currentImage.Width * currentImage.Height;

                    for (int x = 0; x < currentImage.Width; x++)
                    {
                        for (int y = currentImage.Height - 1; y >= 0; y--)
                        {
                            pixelColor = currentImage.GetPixel(x, y);
                            if (ColorDifference(pixelColor, excludeColor) > (int)numericUpDownColorThreshold.Value)
                            {
                                vector.x = x + (currentImage.Width / 2);
                                vector.y = y - currentImage.Height;
                                currentWriter.Write(GenerateBlock(vector, pixelColor));
                            }
                        }
                    }
                    currentWriter.Write(FinishBlueprint());

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
            currentBuilder.AppendLine("          <EntityId>110412045986969624</EntityId>");
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
            currentBuilder.AppendLine("          <GridSizeEnum>Large</GridSizeEnum>");
            currentBuilder.AppendLine("          <CubeBlocks>");

            return currentBuilder.ToString();
        }

        public string FinishBlueprint(string shipName = "Ship")
        {
            StringBuilder currentBuilder = new StringBuilder();

            currentBuilder.AppendLine("          </CubeBlocks>");
            currentBuilder.AppendLine($"          <DisplayName>{shipName}</DisplayName>");
            currentBuilder.AppendLine("          <OxygenAmount>");
            currentBuilder.AppendLine("            <float>0</float>");
            currentBuilder.AppendLine("          </OxygenAmount>");
            currentBuilder.AppendLine("          <DestructibleBlocks>true</DestructibleBlocks>");
            currentBuilder.AppendLine("          <IsRespawnGrid>false</IsRespawnGrid>");
            currentBuilder.AppendLine("          <LocalCoordSys>0</LocalCoordSys>");
            currentBuilder.AppendLine("          <TargetingTargets />");
            currentBuilder.AppendLine("        </CubeGrid>");
            currentBuilder.AppendLine("      </CubeGrids>");
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
            builder.AppendLine($"               <BuiltBy>144115188075855895</BuiltBy>");
            builder.AppendLine("            </MyObjectBuilder_CubeBlock>");
            return builder.ToString();
        }

        public bool ImageGood()
        {
            return currentImage != null && currentImage.Width > 0 && currentImage.Height > 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ImageGood())
            {
                if (textBoxShipName.Text.Length > 0)
                {
                    if (textBoxUserName.Text.Length > 0)
                    {
                        GenerateBlueprint();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a user name. It does not have to be your actual user name, it can be anything");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a ship name. If it is not unique then the other blueprint will be overwritten");
                }
            }
            else MessageBox.Show("Please choose an image");
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
            if (ImageGood())
            {
                labelResize.Text = $"Resize Percentage: {(((double)trackBar1.Value / (double)trackBar1.Maximum) * 100.0).ToString("N1")}%";
                UpdateImageStats();
            }
            else trackBar1.Value = trackBar1.Maximum;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ImageGood())
            {
                double ratio = (double)trackBar1.Value / (double)trackBar1.Maximum;
                currentImage = ResizeBitmap(currentImage, (int)((double)currentImage.Width * ratio), (int)((double)currentImage.Height * ratio));
                trackBar1.Value = trackBar1.Maximum;
                labelResize.Text = "Resize Percentage: 100.0 %";
                UpdateImageStats();
            }
            else MessageBox.Show("Please choose an image");
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

        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
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
