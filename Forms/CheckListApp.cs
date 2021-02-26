using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CheckList.TaskSpecifics.Interface;
using CLTask = CheckList.TaskSpecifics.Class.Task;
using CheckList.TasksManegement;

namespace CheckList
{
    public partial class CheckListApp: Form
    {
        private readonly TasksManager tasksManager;
        private readonly ITaskGroup tasks;
        private CLTask taskToBeRemoved;
        
        public CheckListApp(TasksManager tasksManager, ITaskGroup tasks)
        {
            InitializeComponent();
            this.tasksManager = tasksManager;
            this.tasks = tasks;
            RefreshTasksListDataGridRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tasks.SetData(tasksManager.GetAllTasks());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string taskName = "TestTask";
            bool taskComplete = false;

            tasks.SetData(tasksManager.AddTask(new CLTask(taskName, taskComplete), tasks));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string taskName = "TestTask";
            bool taskComplete = true;

            tasks.SetData(tasksManager.SetTask(new CLTask(taskName, taskComplete), tasks));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string taskName = "TestTask";
            bool taskComplete = false;

            tasks.SetData(tasksManager.RemoveTask(new CLTask(taskName, taskComplete), tasks));
        }

        void RefreshTasksListDataGridRows()
        {
            TasksListDataGrid.Rows.Clear();
            foreach (CLTask task in this.tasks.tasks)
            {
                TasksListDataGrid.Rows.Add(task.title, task.finished);
            }
        }

        private void TasksListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                DataGridViewRow edittedRow = TasksListDataGrid.Rows[e.RowIndex];

                bool newTaskStatus = Convert.ToBoolean(edittedRow.Cells["TaskCompleted"].EditedFormattedValue);
                string taskName = Convert.ToString(edittedRow.Cells["TaskName"].Value);

                tasks.SetData(tasksManager.SetTask(new CLTask(taskName, newTaskStatus), tasks));

                RefreshTasksListDataGridRows();
            }
        }

        private void TasksListDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selecetedRows = TasksListDataGrid.SelectedRows;
            if(selecetedRows.Count > 0)
            {
                DataGridViewRow selectedRow = selecetedRows
                .Cast<DataGridViewRow>()
                .First();

                bool selectedTaskStatus = Convert.ToBoolean(selectedRow.Cells["TaskCompleted"].EditedFormattedValue);
                string selectedTaskName = Convert.ToString(selectedRow.Cells["TaskName"].Value);
                taskToBeRemoved = new CLTask(selectedTaskName, selectedTaskStatus);

                this.TaskNameToRemoveL.Text = selectedTaskName;
            }
        }

        private void RemoveSelectedTaskB_Click(object sender, EventArgs e)
        {
            tasks.SetData(tasksManager.RemoveTask(taskToBeRemoved, tasks));

            RefreshTasksListDataGridRows();
        }

        private void AddNewTaskB_Click(object sender, EventArgs e)
        {
            string newTaskName = this.NewTaskNameTB.Text;
            tasks.SetData(tasksManager.AddTask(new CLTask(newTaskName, false), tasks));

            RefreshTasksListDataGridRows();
        }

    }
}
