using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WizardScaffolding
{
    public partial class FormInput : Form
    {
        private readonly IEnumerable<string> _projectCollection;
        public FormInput(IEnumerable<string> projectCollection)
        {
            InitializeComponent();
            _projectCollection = projectCollection;
        }

        public string RepositoryProject
        {
            get { return boxRepository.SelectedValue?.ToString(); }
        }

        public string IocProject
        {
            get { return boxIoC.SelectedValue?.ToString(); }
        }

        public string DomainProject
        {
            get { return boxDomain.SelectedValue?.ToString(); }
        }

        public string ApplicationProject
        {
            get { return boxApplication.SelectedValue?.ToString(); }
        }

        public string APIProject
        {
            get { return boxAPI.SelectedValue?.ToString(); }
        }

        private void FormInput_Load(object sender, EventArgs e)
        {
            boxAPI.DataSource = _projectCollection.ToList();
            boxAPI.SelectedItem = _projectCollection?.FirstOrDefault(p => p.Contains("API"));

            boxApplication.DataSource = _projectCollection.ToList();
            boxApplication.SelectedItem = _projectCollection?.FirstOrDefault(p => p.Contains("Application"));

            boxIoC.DataSource = _projectCollection.ToList();
            boxIoC.SelectedItem = _projectCollection?.FirstOrDefault(p => p.Contains("IoC"));

            boxDomain.DataSource = _projectCollection.ToList();
            boxDomain.SelectedItem = _projectCollection?.FirstOrDefault(p => p.Contains("Domain"));

            boxRepository.DataSource = _projectCollection.ToList();
            boxRepository.SelectedItem = _projectCollection?.FirstOrDefault(p => p.Contains("Reposi"));
        }
    }
}
