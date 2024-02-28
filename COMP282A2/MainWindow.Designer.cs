namespace COMP282A2
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Main_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.Right_Top = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_Right = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.First_X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First_Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Second_X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Second_Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_remove = new System.Windows.Forms.Button();
            this.button_find_intersection = new System.Windows.Forms.Button();
            this.button_color = new System.Windows.Forms.Button();
            this.pictureBox_LEFT = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Main_Panel.SuspendLayout();
            this.Right_Top.SuspendLayout();
            this.Panel_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LEFT)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_Panel
            // 
            resources.ApplyResources(this.Main_Panel, "Main_Panel");
            this.Main_Panel.Controls.Add(this.Right_Top, 1, 0);
            this.Main_Panel.Controls.Add(this.pictureBox_LEFT, 0, 0);
            this.Main_Panel.Name = "Main_Panel";
            // 
            // Right_Top
            // 
            resources.ApplyResources(this.Right_Top, "Right_Top");
            this.Right_Top.Controls.Add(this.Panel_Right, 0, 0);
            this.Right_Top.Name = "Right_Top";
            // 
            // Panel_Right
            // 
            resources.ApplyResources(this.Panel_Right, "Panel_Right");
            this.Panel_Right.Controls.Add(this.dataGridView1, 0, 1);
            this.Panel_Right.Controls.Add(this.button_remove, 2, 0);
            this.Panel_Right.Controls.Add(this.button_find_intersection, 0, 2);
            this.Panel_Right.Controls.Add(this.button_color, 0, 0);
            this.Panel_Right.Name = "Panel_Right";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.First_X,
            this.First_Y,
            this.Second_X,
            this.Second_Y,
            this.Color_column});
            this.Panel_Right.SetColumnSpan(this.dataGridView1, 5);
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // First_X
            // 
            resources.ApplyResources(this.First_X, "First_X");
            this.First_X.Name = "First_X";
            // 
            // First_Y
            // 
            resources.ApplyResources(this.First_Y, "First_Y");
            this.First_Y.Name = "First_Y";
            // 
            // Second_X
            // 
            resources.ApplyResources(this.Second_X, "Second_X");
            this.Second_X.Name = "Second_X";
            // 
            // Second_Y
            // 
            resources.ApplyResources(this.Second_Y, "Second_Y");
            this.Second_Y.Name = "Second_Y";
            // 
            // Color_column
            // 
            resources.ApplyResources(this.Color_column, "Color_column");
            this.Color_column.Name = "Color_column";
            this.Color_column.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // button_remove
            // 
            this.button_remove.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.button_remove, "button_remove");
            this.button_remove.Name = "button_remove";
            this.button_remove.UseVisualStyleBackColor = false;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_find_intersection
            // 
            this.button_find_intersection.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Panel_Right.SetColumnSpan(this.button_find_intersection, 2);
            resources.ApplyResources(this.button_find_intersection, "button_find_intersection");
            this.button_find_intersection.Name = "button_find_intersection";
            this.button_find_intersection.UseVisualStyleBackColor = false;
            this.button_find_intersection.Click += new System.EventHandler(this.button_find_intersection_Click);
            // 
            // button_color
            // 
            this.button_color.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button_color.ForeColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.button_color, "button_color");
            this.button_color.Name = "button_color";
            this.button_color.UseVisualStyleBackColor = false;
            this.button_color.Click += new System.EventHandler(this.button_color_Click);
            // 
            // pictureBox_LEFT
            // 
            this.pictureBox_LEFT.BackColor = System.Drawing.Color.White;
            this.pictureBox_LEFT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBox_LEFT, "pictureBox_LEFT");
            this.pictureBox_LEFT.Name = "pictureBox_LEFT";
            this.pictureBox_LEFT.TabStop = false;
            this.pictureBox_LEFT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_LEFT_mousedown);
            this.pictureBox_LEFT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_LEFT_mouseup);
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.Main_Panel);
            this.Name = "MainWindow";
            this.Main_Panel.ResumeLayout(false);
            this.Right_Top.ResumeLayout(false);
            this.Panel_Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LEFT)).EndInit();
            this.ResumeLayout(false);

        }

        private void PictureBox_LEFT_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void PictureBox_LEFT_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.SplitContainer main_spilit;
        private System.Windows.Forms.TableLayoutPanel Main_Panel;
        private System.Windows.Forms.TableLayoutPanel Panel_Right;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Button button_find_intersection;
        private System.Windows.Forms.TableLayoutPanel Right_Top;
        private System.Windows.Forms.PictureBox pictureBox_LEFT;
        private System.Windows.Forms.Button button_color;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_X;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Second_X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Second_Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Color_column;
    }
}

