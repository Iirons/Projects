using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Projects.BL.Services;
using Projects.BL.DTO;
using AutoMapper;
using Projects.PL.Models;

namespace Projects.PL
{
    public partial class Form1 : Form
    {
        IProjectsService ps;
        List<ProjectModel> pm;
        public Form1(IProjectsService service)
        {
            this.ps = service;
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            int index;
            using (var form = new AddForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    dataGridView1.Rows.Add();
                    index = dataGridView1.Rows.Count - 1;
                    dataGridView1[0, index].Value = form.ReturnValue1;
                    dataGridView1[1, index].Value = form.ReturnValue2;
                    dataGridView1[2, index].Value = form.ReturnValue3;
                    dataGridView1[3, index].Value = form.ReturnValue4;
                    dataGridView1[4, index].Value = form.ReturnValue5;
                    dataGridView1[5, index].Value = form.ReturnValue6;

                }
                else
                {
                    return;
                }
            }
            index = dataGridView1.Rows.Count - 1;
            ProjectDTO project = new ProjectDTO(
                    Convert.ToInt32(dataGridView1[0, index].Value),
                    dataGridView1[1, index].Value.ToString(),
                    Convert.ToInt32(dataGridView1[2, index].Value),
                    dataGridView1[3, index].Value.ToString(),
                    Convert.ToDateTime(dataGridView1[4, index].Value),
                    Convert.ToDateTime(dataGridView1[5, index].Value));
            ps.CreateProject(project);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow r in dataGridView1.SelectedRows)
            {
                ps.DeleteProject(Convert.ToInt32(r.Cells[0].Value));
                dataGridView1.Rows.RemoveAt(r.Index);
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                ProjectDTO project = new ProjectDTO(
                    Convert.ToInt32(dataGridView1[0,r.Index].Value),
                    dataGridView1[1, r.Index].Value.ToString(),
                    Convert.ToInt32(dataGridView1[2, r.Index].Value),
                    dataGridView1[3, r.Index].Value.ToString(),
                    Convert.ToDateTime(dataGridView1[4, r.Index].Value),
                    Convert.ToDateTime(dataGridView1[5, r.Index].Value));
                ps.ChangeProject(project);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IEnumerable<ProjectDTO> projects = ps.GetProjects();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProjectDTO, ProjectModel>()).CreateMapper();
            pm = mapper.Map<IEnumerable<ProjectDTO>, List<ProjectModel>>(projects);
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Visible=false;
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Description";
            dataGridView1.Columns[3].Name = "ManagerId";
            dataGridView1.Columns[4].Name = "Start Date";
            dataGridView1.Columns[5].Name = "End Date";
            dataGridView1.RowCount = projects.Count();
            int i = 0;
            foreach (ProjectDTO project in projects)
            {
                dataGridView1[0, i].Value = project.Id;
                dataGridView1[1, i].Value = project.Name;
                dataGridView1[2, i].Value = project.Description;
                dataGridView1[3, i].Value = project.ManagerId;
                dataGridView1[4, i].Value = project.ProjectStart;
                dataGridView1[5, i].Value = project.ProjectEnd;
                i++;
            }

        }
    }
}
