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

                tasks.SetData(tasksManager.SetTask(GetTaskFromRow(edittedRow), tasks));

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

                taskToBeRemoved = GetTaskFromRow(selectedRow);

                this.TaskNameToRemoveL.Text = taskToBeRemoved.title;
            }
        }

        private void RemoveSelectedTaskB_Click(object sender, EventArgs e)
        {
            tasks.SetData(tasksManager.RemoveTask(taskToBeRemoved, tasks));

            RefreshTasksListDataGridRows();
            this.TaskNameToRemoveL.Text = "";
        }

        private void AddNewTaskB_Click(object sender, EventArgs e)
        {
            string newTaskName = this.NewTaskNameTB.Text;
            tasks.SetData(tasksManager.AddTask(new CLTask(newTaskName, false), tasks));

            RefreshTasksListDataGridRows();
        }

        CLTask GetTaskFromRow (DataGridViewRow row)
        {
            bool taskStatus = Convert.ToBoolean(row.Cells["TaskCompleted"].EditedFormattedValue);
            string taskName = Convert.ToString(row.Cells["TaskName"].Value);
            return new CLTask(taskName, taskStatus);
        }
    }
}
