using EnvDTE;
using EnvDTE80;
using System.Collections.Generic;
using System.Linq;

namespace WizardScaffolding
{
    public static class WizardExtension
    {
        /// <summary>
        /// Seleciona um item de projeto como pasta ou classe ou qualquer tipo de item de projeto.
        /// </summary>
        /// <param name="projeto"></param>
        /// <param name="nome"> Nome do item a ser buscado </param>
        /// <param name="tipo"> Tipo do item a ser buscado. Exemplo: Classe e Pasta. </param>
        /// <returns></returns>
        public static ProjectItem SelecionaItemProjeto(this Project projeto, string nome, string tipo)
        {
            foreach (ProjectItem item in projeto.ProjectItems)
            {
                if (item.Name == nome && item.Kind == tipo)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Adiciona um item em uma pasta/subpasta. Profundidade máxima de duas pastas.
        /// </summary>
        /// <param name="projeto"></param>
        /// <param name="item"> Objeto a ser adicionado. </param>
        /// <param name="pastas"> Pasta/Subpasta onde o objeto deve ser adicionado. </param>
        public static void AdicionaItemPasta(this Project projeto, ProjectItem item, string pastas)
        {
            var pastaCollection = pastas.Split('.').ToList();
            var copyListaCollection = pastaCollection;

            /* Percorrendo a lista de pastas */
            foreach (var pasta in pastaCollection)
            {
                /* Verificando se a primeira pasta existe */
                var primeiraPasta = projeto.SelecionaItemProjeto(pasta, Constants.vsProjectItemKindPhysicalFolder);
                if (primeiraPasta != null)
                {
                    if (copyListaCollection.Count() > 1)
                    {

                        var posicaoPastaAtual = copyListaCollection.FindIndex(p => p == pasta);
                        var segundaPasta = projeto.SelecionaItemProjeto(copyListaCollection[posicaoPastaAtual + 1], Constants.vsProjectItemKindPhysicalFolder);
                        if (segundaPasta != null)
                        {
                            segundaPasta.ProjectItems.AddFromFileCopy(item.FileNames[0]);
                            break;
                        }
                        else
                        {
                            segundaPasta = primeiraPasta.ProjectItems.AddFolder(copyListaCollection[posicaoPastaAtual + 1]);
                            if (segundaPasta != null)
                            {
                                segundaPasta.ProjectItems.AddFromFileCopy(item.FileNames[0]);
                                break;
                            }
                        }
                    }
                    else
                    {
                        primeiraPasta.ProjectItems.AddFromFileCopy(item.FileNames[0]);
                    }
                }
                else /* Caso a primeira pasta não exista */
                {
                    primeiraPasta = projeto.ProjectItems.AddFolder(pasta);
                    if (primeiraPasta != null)
                    {
                        if (copyListaCollection.Count > 1) /* Caso seja para inserir o arquivo em uma pasta dentro de outra pasta */
                        {
                            var posicaoPastaAtual = copyListaCollection.FindIndex(p => p == pasta);
                            var segundaPasta = primeiraPasta.ProjectItems.AddFolder(copyListaCollection[posicaoPastaAtual + 1]);
                            if (segundaPasta != null)
                            {
                                segundaPasta.ProjectItems.AddFromFileCopy(item.FileNames[0]);
                                break;
                            }
                            else
                            {
                                segundaPasta = primeiraPasta.ProjectItems.AddFolder(copyListaCollection[posicaoPastaAtual + 1]);
                                if (segundaPasta != null)
                                {
                                    segundaPasta.ProjectItems.AddFromFileCopy(item.FileNames[0]);
                                    break;
                                }
                            }
                        }
                        else /* Caso seja para inserir o arquivo nesta pasta */
                        {
                            primeiraPasta.ProjectItems.AddFromFileCopy(item.FileNames[0]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Seleciona projetos da solution.
        /// </summary>
        /// <param name="solucao"></param>
        /// <returns></returns>
        public static IEnumerable<Project> SelecionaProjetos(this Solution solucao)
        {
            var projetoCollection = new List<Project>();
            foreach (Project item in solucao.Projects)
            {
                /* Se o projeto estiver dentro de uma solution folder pode ser que existam mais projetos */
                if (item.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                {
                    /* Adicionando todos projetos da solution folder */
                    projetoCollection.AddRange(SelecionaProjetosInSolutionFolder(item));
                }
                else
                {
                    projetoCollection.Add(item);
                }
            }
            return projetoCollection;
        }

        /// <summary>
        /// Seleciona projetos na dentro de uma Solution Folder.
        /// </summary>
        /// <param name="pastaSolucao"></param>
        /// <returns></returns>
        static IEnumerable<Project> SelecionaProjetosInSolutionFolder(Project pastaSolucao)
        {
            var projetoCollection = new List<Project>();
            foreach (ProjectItem item in pastaSolucao.ProjectItems)
            {
                if (item.SubProject != null)
                {
                    if (item.SubProject.Kind == ProjectKinds.vsProjectKindSolutionFolder)
                    {
                        projetoCollection.AddRange(SelecionaProjetosInSolutionFolder(item.SubProject));
                    }
                    else
                    {
                        projetoCollection.Add(item.SubProject);
                    }
                }
            }
            return projetoCollection;
        }
    }
}
