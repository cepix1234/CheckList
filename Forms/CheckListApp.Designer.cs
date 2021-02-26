
namespace CheckList
{
    partial class CheckListApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TasksListPanel = new System.Windows.Forms.Panel();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.RemoveSelectedTaskB = new System.Windows.Forms.Button();
            this.TaskNameToRemoveL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AddNewTaskB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NewTaskNameTB = new System.Windows.Forms.TextBox();
            this.TasksListDataGrid = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskCompleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TasksListPanel.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TasksListDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TasksListPanel
            // 
            this.TasksListPanel.Controls.Add(this.GroupBox2);
            this.TasksListPanel.Controls.Add(this.groupBox1);
            this.TasksListPanel.Controls.Add(this.TasksListDataGrid);
            this.TasksListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TasksListPanel.Location = new System.Drawing.Point(0, 0);
            this.TasksListPanel.Name = "TasksListPanel";
            this.TasksListPanel.Size = new System.Drawing.Size(567, 286);
            this.TasksListPanel.TabIndex = 4;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.RemoveSelectedTaskB);
            this.GroupBox2.Controls.Add(this.TaskNameToRemoveL);
            this.GroupBox2.Controls.Add(this.label2);
            this.GroupBox2.Location = new System.Drawing.Point(313, 98);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(194, 80);
            this.GroupBox2.TabIndex = 2;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Remove task";
            // 
            // RemoveSelectedTaskB
            // 
            this.RemoveSelectedTaskB.Location = new System.Drawing.Point(6, 47);
            this.RemoveSelectedTaskB.Name = "RemoveSelectedTaskB";
            this.RemoveSelectedTaskB.Size = new System.Drawing.Size(132, 23);
            this.RemoveSelectedTaskB.TabIndex = 2;
            this.RemoveSelectedTaskB.Text = "Remove selected task";
            this.RemoveSelectedTaskB.UseVisualStyleBackColor = true;
            this.RemoveSelectedTaskB.Click += new System.EventHandler(this.RemoveSelectedTaskB_Click);
            // 
            // TaskNameToRemoveL
            // 
            this.TaskNameToRemoveL.AutoSize = true;
            this.TaskNameToRemoveL.Location = new System.Drawing.Point(72, 23);
            this.TaskNameToRemoveL.Name = "TaskNameToRemoveL";
            this.TaskNameToRemoveL.Size = new System.Drawing.Size(0, 13);
            this.TaskNameToRemoveL.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Task name :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AddNewTaskB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NewTaskNameTB);
            this.groupBox1.Location = new System.Drawing.Point(313, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 80);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add new task";
            // 
            // AddNewTaskB
            // 
            this.AddNewTaskB.Location = new System.Drawing.Point(6, 45);
            this.AddNewTaskB.Name = "AddNewTaskB";
            this.AddNewTaskB.Size = new System.Drawing.Size(98, 23);
            this.AddNewTaskB.TabIndex = 2;
            this.AddNewTaskB.Text = "Add new task";
            this.AddNewTaskB.UseVisualStyleBackColor = true;
            this.AddNewTaskB.Click += new System.EventHandler(this.AddNewTaskB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Task name:";
            // 
            // NewTaskNameTB
            // 
            this.NewTaskNameTB.Location = new System.Drawing.Point(75, 19);
            this.NewTaskNameTB.Name = "NewTaskNameTB";
            this.NewTaskNameTB.Size = new System.Drawing.Size(119, 20);
            this.NewTaskNameTB.TabIndex = 0;
            // 
            // TasksListDataGrid
            // 
            this.TasksListDataGrid.AllowUserToAddRows = false;
            this.TasksListDataGrid.AllowUserToDeleteRows = false;
            this.TasksListDataGrid.AllowUserToOrderColumns = true;
            this.TasksListDataGrid.AllowUserToResizeColumns = false;
            this.TasksListDataGrid.AllowUserToResizeRows = false;
            this.TasksListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TasksListDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.TaskCompleted});
            this.TasksListDataGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.TasksListDataGrid.Location = new System.Drawing.Point(0, 0);
            this.TasksListDataGrid.MultiSelect = false;
            this.TasksListDataGrid.Name = "TasksListDataGrid";
            this.TasksListDataGrid.ShowCellErrors = false;
            this.TasksListDataGrid.ShowCellToolTips = false;
            this.TasksListDataGrid.ShowEditingIcon = false;
            this.TasksListDataGrid.ShowRowErrors = false;
            this.TasksListDataGrid.Size = new System.Drawing.Size(307, 286);
            this.TasksListDataGrid.TabIndex = 0;
            this.TasksListDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TasksListDataGrid_CellContentClick);
            this.TasksListDataGrid.SelectionChanged += new System.EventHandler(this.TasksListDataGrid_SelectionChanged);
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Task name";
            this.TaskName.Name = "TaskName";
            // 
            // TaskCompleted
            // 
            this.TaskCompleted.HeaderText = "Task completed";
            this.TaskCompleted.Name = "TaskCompleted";
            // 
            // CheckListApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 286);
            this.Controls.Add(this.TasksListPanel);
            this.Name = "CheckListApp";
            this.Text = "Check list";
            this.TasksListPanel.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TasksListDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel TasksListPanel;
        private System.Windows.Forms.DataGridView TasksListDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TaskCompleted;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddNewTaskB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NewTaskNameTB;
        private System.Windows.Forms.GroupBox GroupBox2;
        private System.Windows.Forms.Label TaskNameToRemoveL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RemoveSelectedTaskB;
    }
}

