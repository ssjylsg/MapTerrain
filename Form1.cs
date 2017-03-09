using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapTerrain
{
    public partial class Form1 : Form
    {
        private TerrainHelper helper;
        public Form1()
        {
            InitializeComponent();
            this.helper = new TerrainHelper(@"D:\terrain");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //for (int j = 99; j < 102; j++)
            //{
            //    for (int i = 44; i < 47; i++)
            //    {
            //        helper.DownLoad(6, j, i);
            //    }
            //}

        // helper.DownLoad();

            //new ImageDownHelper().DownLoad();

            helper.DownLoadCell((int)xmin.Value, (int)ymin.Value, (int)xmax.Value, (int)ymax.Value, (int)zoom.Value);

        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xmin = new System.Windows.Forms.NumericUpDown();
            this.xmax = new System.Windows.Forms.NumericUpDown();
            this.ymin = new System.Windows.Forms.NumericUpDown();
            this.ymax = new System.Windows.Forms.NumericUpDown();
            this.zoom = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.xmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ymin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ymax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "z";
            // 
            // xmin
            // 
            this.xmin.Location = new System.Drawing.Point(66, 42);
            this.xmin.Name = "xmin";
            this.xmin.Size = new System.Drawing.Size(120, 21);
            this.xmin.TabIndex = 4;
            this.xmin.Maximum = int.MaxValue;
            // 
            // xmax
            // 
            this.xmax.Location = new System.Drawing.Point(239, 40);
            this.xmax.Name = "xmax";
            this.xmax.Size = new System.Drawing.Size(120, 21);
            this.xmax.TabIndex = 5;
            this.xmax.Maximum = int.MaxValue;
            // 
            // ymin
            // 
            this.ymin.Location = new System.Drawing.Point(66, 90);
            this.ymin.Name = "ymin";
            this.ymin.Size = new System.Drawing.Size(120, 21);
            this.ymin.TabIndex = 6;
            this.ymin.Maximum = int.MaxValue;
            // 
            // ymax
            // 
            this.ymax.Location = new System.Drawing.Point(239, 88);
            this.ymax.Name = "ymax";
            this.ymax.Size = new System.Drawing.Size(120, 21);
            this.ymax.TabIndex = 7;
            this.ymax.Maximum = int.MaxValue;
            // 
            // zoom
            // 
            this.zoom.Location = new System.Drawing.Point(66, 140);
            this.zoom.Name = "zoom";
            this.zoom.Size = new System.Drawing.Size(120, 21);
            this.zoom.TabIndex = 8;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(406, 306);
            this.Controls.Add(this.zoom);
            this.Controls.Add(this.ymax);
            this.Controls.Add(this.ymin);
            this.Controls.Add(this.xmax);
            this.Controls.Add(this.xmin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.xmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ymin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ymax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
    }
}
