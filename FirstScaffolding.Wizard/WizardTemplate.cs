using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TemplateWizard;

namespace WizardScaffolding
{
    public class WizardTemplate : IWizard
    {
        private readonly DTE _dte;
        private ProjectItem _pastaTemp;
        private IEnumerable<Project> _solutionProjects;
        private string _entityName;
        private string _iocProject;
        private string _apiProject;
        private string _domainProject;
        private string _applicationProject;
        private string _repositoryProject;
        private string _solutionName;
        private string _partialSolutionDirectory;
        private string _solutionDirectory;
        public string _databaseEntity;
        public WizardTemplate()
        {
            _dte = (DTE)Package.GetGlobalService(typeof(DTE));
        }
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
            //throw new System.NotImplementedException();
        }

        public void ProjectFinishedGenerating(Project project)
        {
            //throw new System.NotImplementedException();
        }

        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            var item = Path.GetFileNameWithoutExtension(projectItem.Name);
            var pasta = string.Empty;
            var projeto = default(Project);

            // Domain layer
            if (item == _entityName)
            {
                projeto = GetProjectByName(_domainProject);
                pasta = "Entities";
            }
            else if (item == string.Concat(_entityName, "DomainService"))
            {
                projeto = GetProjectByName(_domainProject);
                pasta = "Services";
            }
            else if (item == string.Concat("I", _entityName, "DomainService"))
            {
                projeto = GetProjectByName(_domainProject);
                pasta = "Abstractions";
            }

            //Repository Layer
            else if (item == string.Concat("I", _entityName, "Repository"))
            {
                projeto = GetProjectByName(_domainProject);
                pasta = "Abstractions";
            }
            else if (item == string.Concat(_entityName, "Repository"))
            {
                projeto = GetProjectByName(_repositoryProject);
                pasta = "Repositories";
            }

            // Application Layer 
            else if (item == string.Concat(_entityName, "ViewModel"))
            {
                projeto = GetProjectByName(_applicationProject);
                pasta = "ViewModels";
            }
            else if (item == string.Concat(_entityName, "AppService"))
            {
                projeto = GetProjectByName(_applicationProject);
                pasta = "Services";
            }
            else if (item == string.Concat("I", _entityName, "AppService"))
            {
                projeto = GetProjectByName(_applicationProject);
                pasta = "Abstractions";
            }

            // API layer 
            else if (item == string.Concat(_entityName, "Controller"))
            {
                projeto = GetProjectByName(_apiProject);
                pasta = "Controllers";
            }

            projeto.AdicionaItemPasta(projectItem, pasta);
            _pastaTemp = (ProjectItem)projectItem.Collection.Parent;
        }

        public void RunFinished()
        {
            _pastaTemp?.Remove();
            _pastaTemp?.Delete();
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            //Seleciona projetos da solução
            _solutionProjects = _dte.Solution.SelecionaProjetos();

            //Passa os projetos da solução para o form
            var formInput = new FormInput(_solutionProjects.Select(p => p.Name));
            formInput.ShowDialog();

            _iocProject = formInput.IocProject;
            _apiProject = formInput.APIProject;
            _domainProject = formInput.DomainProject;
            _applicationProject = formInput.ApplicationProject;
            _repositoryProject = formInput.RepositoryProject;

            _entityName = replacementsDictionary["$safeitemname$"];
            _entityName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_entityName);

            SetParameters(replacementsDictionary);
        }

        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }

        Project GetProjectByName(string nomeProjeto)
        {
            return _solutionProjects.FirstOrDefault(it => it.Name == nomeProjeto);
        }

        void SetParameters(Dictionary<string, string> replacementsDictionary)
        {
            replacementsDictionary.Add("$Entity$", _entityName);
            replacementsDictionary.Add("$lowerEntity$", _entityName.ToLower());
            replacementsDictionary.Add("$ApplicationInterfacesNamespace$", string.Concat(_applicationProject, ".", "Abstractions"));
            replacementsDictionary.Add("$ApplicationViewModelsNamespace$", string.Concat(_applicationProject, ".", "ViewModels"));
            replacementsDictionary.Add("$ApplicationServicesNamespace$", string.Concat(_applicationProject, ".", "Services"));
            replacementsDictionary.Add("$DomainEntitiesNamespace$", string.Concat(_domainProject, ".", "Entities"));
            replacementsDictionary.Add("$DomainCoreModelsNamespace$", string.Concat(_domainProject, ".Core.", "Models"));
            replacementsDictionary.Add("$DomainInterfacesNamespace$", string.Concat(_domainProject, ".", "Abstractions"));
            replacementsDictionary.Add("$DomainServicesNamespace$", string.Concat(_domainProject, ".", "Services"));
            replacementsDictionary.Add("$RepositoryNamespace$", string.Concat(_repositoryProject, ".", "Repositories"));
            replacementsDictionary.Add("$WebAPINamespace$", string.Concat(_apiProject, ".", "Controllers"));
        }
    }
}
