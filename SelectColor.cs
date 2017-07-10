using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageComboBox;

namespace DocumentContructor
{
    public class SelectColor : ImageComboBox.ImageComboBox
    {
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;

        public SelectColor() : base()
        {
            InitializeComponent();
            ImageList = imageList1;
            for (int i = 0; i < ImageList.Images.Count; i++)
            {
                ImageComboBoxItem item = new ImageComboBoxItem(i, ImageList.Images.Keys[i], 0);
                Items.Add(item);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectColor));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AliceBlue");
            this.imageList1.Images.SetKeyName(1, "AntiqueWhite");
            this.imageList1.Images.SetKeyName(2, "Aqua");
            this.imageList1.Images.SetKeyName(3, "Aquamarine");
            this.imageList1.Images.SetKeyName(4, "Azure");
            this.imageList1.Images.SetKeyName(5, "Beige");
            this.imageList1.Images.SetKeyName(6, "Bisque");
            this.imageList1.Images.SetKeyName(7, "Black");
            this.imageList1.Images.SetKeyName(8, "BlanchedAlmond");
            this.imageList1.Images.SetKeyName(9, "Blue");
            this.imageList1.Images.SetKeyName(10, "BlueViolet");
            this.imageList1.Images.SetKeyName(11, "Brown");
            this.imageList1.Images.SetKeyName(12, "CadetBlue");
            this.imageList1.Images.SetKeyName(13, "Chartreus");
            this.imageList1.Images.SetKeyName(14, "Chocolate");
            this.imageList1.Images.SetKeyName(15, "Coral");
            this.imageList1.Images.SetKeyName(16, "CornflowerBlue");
            this.imageList1.Images.SetKeyName(17, "Cornsilk");
            this.imageList1.Images.SetKeyName(18, "Crimson");
            this.imageList1.Images.SetKeyName(19, "Cyan");
            this.imageList1.Images.SetKeyName(20, "DarkBlue");
            this.imageList1.Images.SetKeyName(21, "DarkCyan");
            this.imageList1.Images.SetKeyName(22, "DarkGoldenrod");
            this.imageList1.Images.SetKeyName(23, "BurlyWood");
            this.imageList1.Images.SetKeyName(24, "DarkGray");
            this.imageList1.Images.SetKeyName(25, "DarkGreen");
            this.imageList1.Images.SetKeyName(26, "DarkKhaki");
            this.imageList1.Images.SetKeyName(27, "DarkMagenta");
            this.imageList1.Images.SetKeyName(28, "DarkOliveGreen");
            this.imageList1.Images.SetKeyName(29, "DarkOrange");
            this.imageList1.Images.SetKeyName(30, "DarkOrchid");
            this.imageList1.Images.SetKeyName(31, "DarkRed");
            this.imageList1.Images.SetKeyName(32, "DarkSalmon");
            this.imageList1.Images.SetKeyName(33, "DarkSeaGreen");
            this.imageList1.Images.SetKeyName(34, "DarkSlateBlue");
            this.imageList1.Images.SetKeyName(35, "DarkSlateGray");
            this.imageList1.Images.SetKeyName(36, "DarkTurquoise");
            this.imageList1.Images.SetKeyName(37, "DarkViolet");
            this.imageList1.Images.SetKeyName(38, "DeepPink");
            this.imageList1.Images.SetKeyName(39, "DeepSkyBlue");
            this.imageList1.Images.SetKeyName(40, "DimGray");
            this.imageList1.Images.SetKeyName(41, "DodgerBlue");
            this.imageList1.Images.SetKeyName(42, "Firebrick");
            this.imageList1.Images.SetKeyName(43, "FloralWhite");
            this.imageList1.Images.SetKeyName(44, "ForestGreen");
            this.imageList1.Images.SetKeyName(45, "Fuchsia");
            this.imageList1.Images.SetKeyName(46, "Gainsboro");
            this.imageList1.Images.SetKeyName(47, "GhostWhite");
            this.imageList1.Images.SetKeyName(48, "Gold");
            this.imageList1.Images.SetKeyName(49, "Goldenrod");
            this.imageList1.Images.SetKeyName(50, "Gray");
            this.imageList1.Images.SetKeyName(51, "Green");
            this.imageList1.Images.SetKeyName(52, "GreenYellow");
            this.imageList1.Images.SetKeyName(53, "Honeydew");
            this.imageList1.Images.SetKeyName(54, "HotPink");
            this.imageList1.Images.SetKeyName(55, "IndianRed");
            this.imageList1.Images.SetKeyName(56, "Indigo");
            this.imageList1.Images.SetKeyName(57, "Ivory");
            this.imageList1.Images.SetKeyName(58, "Khaki");
            this.imageList1.Images.SetKeyName(59, "Lavender");
            this.imageList1.Images.SetKeyName(60, "LavenderBlush");
            this.imageList1.Images.SetKeyName(61, "LawnGreen");
            this.imageList1.Images.SetKeyName(62, "LemonChiffon");
            this.imageList1.Images.SetKeyName(63, "LightBlue");
            this.imageList1.Images.SetKeyName(64, "LightCoral");
            this.imageList1.Images.SetKeyName(65, "LightCyan");
            this.imageList1.Images.SetKeyName(66, "LightGoldenrodYellow");
            this.imageList1.Images.SetKeyName(67, "LightGray");
            this.imageList1.Images.SetKeyName(68, "LightGreen");
            this.imageList1.Images.SetKeyName(69, "LightPink");
            this.imageList1.Images.SetKeyName(70, "LightSalmon");
            this.imageList1.Images.SetKeyName(71, "LightSeaGreen");
            this.imageList1.Images.SetKeyName(72, "LightSkyBlue");
            this.imageList1.Images.SetKeyName(73, "LightSlateGray");
            this.imageList1.Images.SetKeyName(74, "LightSteelBlue");
            this.imageList1.Images.SetKeyName(75, "LightYellow");
            this.imageList1.Images.SetKeyName(76, "Lime");
            this.imageList1.Images.SetKeyName(77, "LimeGreen");
            this.imageList1.Images.SetKeyName(78, "Linen");
            this.imageList1.Images.SetKeyName(79, "Magenta");
            this.imageList1.Images.SetKeyName(80, "Maroon");
            this.imageList1.Images.SetKeyName(81, "MediumAquamarine");
            this.imageList1.Images.SetKeyName(82, "MediumBlue");
            this.imageList1.Images.SetKeyName(83, "MediumOrchid");
            this.imageList1.Images.SetKeyName(84, "MediumPurple");
            this.imageList1.Images.SetKeyName(85, "MediumSeaGreen");
            this.imageList1.Images.SetKeyName(86, "MediumSlateBlue");
            this.imageList1.Images.SetKeyName(87, "MediumSpringGreen");
            this.imageList1.Images.SetKeyName(88, "MediumTurquoise");
            this.imageList1.Images.SetKeyName(89, "MediumVioletRed");
            this.imageList1.Images.SetKeyName(90, "MidnightBlue");
            this.imageList1.Images.SetKeyName(91, "MintCream");
            this.imageList1.Images.SetKeyName(92, "MistyRose");
            this.imageList1.Images.SetKeyName(93, "Moccasin");
            this.imageList1.Images.SetKeyName(94, "NavajoWhite");
            this.imageList1.Images.SetKeyName(95, "Navy");
            this.imageList1.Images.SetKeyName(96, "OldLace");
            this.imageList1.Images.SetKeyName(97, "Olive");
            this.imageList1.Images.SetKeyName(98, "OliveDrab");
            this.imageList1.Images.SetKeyName(99, "Orange");
            this.imageList1.Images.SetKeyName(100, "OrangeRed");
            this.imageList1.Images.SetKeyName(101, "Orchid");
            this.imageList1.Images.SetKeyName(102, "PaleGoldenrod");
            this.imageList1.Images.SetKeyName(103, "PaleGreen");
            this.imageList1.Images.SetKeyName(104, "PaleTurquoise");
            this.imageList1.Images.SetKeyName(105, "PaleVioletRed");
            this.imageList1.Images.SetKeyName(106, "PapayaWhip");
            this.imageList1.Images.SetKeyName(107, "PeachPuff");
            this.imageList1.Images.SetKeyName(108, "Peru");
            this.imageList1.Images.SetKeyName(109, "Pink");
            this.imageList1.Images.SetKeyName(110, "Plum");
            this.imageList1.Images.SetKeyName(111, "PowderBlue");
            this.imageList1.Images.SetKeyName(112, "Purple");
            this.imageList1.Images.SetKeyName(113, "Red");
            this.imageList1.Images.SetKeyName(114, "RosyBrown");
            this.imageList1.Images.SetKeyName(115, "RoyalBlue");
            this.imageList1.Images.SetKeyName(116, "SaddleBrown");
            this.imageList1.Images.SetKeyName(117, "Salmon");
            this.imageList1.Images.SetKeyName(118, "SandyBrown");
            this.imageList1.Images.SetKeyName(119, "SeaGreen");
            this.imageList1.Images.SetKeyName(120, "SeaShell");
            this.imageList1.Images.SetKeyName(121, "Sienna");
            this.imageList1.Images.SetKeyName(122, "Silver");
            this.imageList1.Images.SetKeyName(123, "SkyBlue");
            this.imageList1.Images.SetKeyName(124, "SlateBlue");
            this.imageList1.Images.SetKeyName(125, "SlateGray");
            this.imageList1.Images.SetKeyName(126, "Snow");
            this.imageList1.Images.SetKeyName(127, "SpringGreen");
            this.imageList1.Images.SetKeyName(128, "SteelBlue");
            this.imageList1.Images.SetKeyName(129, "Tan");
            this.imageList1.Images.SetKeyName(130, "Teal");
            this.imageList1.Images.SetKeyName(131, "Thistle");
            this.imageList1.Images.SetKeyName(132, "Tomato");
            this.imageList1.Images.SetKeyName(133, "Transparent");
            this.imageList1.Images.SetKeyName(134, "Turquoise");
            this.imageList1.Images.SetKeyName(135, "Wheat");
            this.imageList1.Images.SetKeyName(136, "White");
            this.imageList1.Images.SetKeyName(137, "WhiteSmoke");
            this.imageList1.Images.SetKeyName(138, "Violet");
            this.imageList1.Images.SetKeyName(139, "Yellow");
            this.imageList1.Images.SetKeyName(140, "YellowGreen");
            this.ResumeLayout(false);

        }
    }
}
