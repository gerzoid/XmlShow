using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace XMLViewer2
{
    class Searcher
    {
        private ModelXML _lastFoundNode = null;
        private string _currentSearchTerm = null;
        private CancellationTokenSource _cancellationTokenSource;
        private ModelXML FindNextNode(TreeListView treeListView, string searchTerm)
        {            
            ModelXML? model = null;

            bool startSearching = _lastFoundNode == null;

            foreach (var root in treeListView.Roots)
            {
                model = SearchNodeRecursively(treeListView, root, searchTerm, ref startSearching);
                if (model!=null)
                    break;
            }

            if (model == null)
            {
                MessageBox.Show("Больше совпадений не найдено.");
                _lastFoundNode = null; // Сбрасываем состояние для нового поиска
            }

            return model;
        }

        private ModelXML? SearchNodeRecursively(TreeListView treeListView, object currentNode, string searchTerm, ref bool startSearching)
        {
            var model = currentNode as ModelXML;
            ModelXML findedModel = null;

            // Если это узел, с которого нужно продолжать поиск
            if (startSearching)
            {
                bool finded = false;
                if ((model.isAttribute) && (model.attribute.InnerText.Contains(searchTerm) || model.attribute.Name.Contains(searchTerm)))
                    finded = true;
                if (!finded && (model?.node?.FirstChild?.NodeType != XmlNodeType.Element) && (model?.node?.InnerText.Contains(searchTerm) ?? false))
                    finded = true;
                if (!finded && (model?.node?.Name?.Contains(searchTerm) ?? false) ||
                    (model?.attribute?.Name?.Contains(searchTerm) ?? false))
                    finded = true;
                // Проверяем поля модели на наличие искомого значения
                if (finded)
                {                    
                    _lastFoundNode = model; // Сохраняем текущий найденный узел
                    //ExpandAndSelectFoundNode(treeListView, model); // Разворачиваем и выделяем найденный узел
                    return model;
                }
            }
            else if (model == _lastFoundNode)
            {
                startSearching = true; // Начинаем поиск после последнего найденного узла
            }

            // Рекурсивно проверяем дочерние элементы
            if (treeListView.CanExpand(currentNode))
            {
                var children = treeListView.GetChildren(currentNode);
                foreach (var child in children)
                {
                    findedModel = SearchNodeRecursively(treeListView, child, searchTerm, ref startSearching);
                    if (findedModel!=null)
                    {
                        return findedModel;
                    }
                }
            }

            return null;
        }


        public async Task<ModelXML?> PerformSearchAsync(TreeListView treeListView, string searchTerm)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var cancelationToken = _cancellationTokenSource.Token;

            try
            {
                var res = await Task.Run(() => PerformSearch(treeListView, searchTerm), cancelationToken);
                return res;
            }
            catch(OperationCanceledException)
            {
                MessageBox.Show("Поиск отменен");
            }
            finally
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
            return null;
        }

        public ModelXML PerformSearch(TreeListView treeListView, string searchTerm)
        {          
            _currentSearchTerm = searchTerm;                        
            _lastFoundNode = null;  // Сбрасываем предыдущие результаты поиска

            var model = FindNextNode(treeListView, searchTerm);
            if (model==null)
            {
                MessageBox.Show("Элемент не найден.");
            }
            return model;
        }

        public ModelXML? SearchNext(TreeListView treeListView)
        {
            if (_lastFoundNode == null)
            {
                MessageBox.Show("Запустите поиск перед использованием 'Поиск далее'.");
                return null;
            }

            ModelXML? model = FindNextNode(treeListView, _currentSearchTerm);
            if ( model == null )
            {
                MessageBox.Show("Больше совпадений не найдено.");
            }
            return model;
        }
        private void ExpandAndSelectFoundNode(TreeListView treeListView, ModelXML foundNode)
        {
            // Получаем всех родителей узла
            var parents = GetParentNodes(treeListView, foundNode);

            // Разворачиваем родительские узлы
            foreach (var parent in parents)
            {
                treeListView.Expand(parent);
                System.Windows.Forms.Application.DoEvents();  // Обновляем интерфейс
            }

            // Выделяем и фокусируем найденный узел
            treeListView.SelectedObject = foundNode;
            treeListView.EnsureModelVisible(foundNode);
            treeListView.Focus();
        }

        private List<object> GetParentNodes(TreeListView treeListView, object node)
        {
            var parents = new List<object>();
            var current = node;

            while (current != null)
            {
                current = treeListView.GetParent(current);
                if (current != null)
                {
                    parents.Add(current);
                }
            }

            parents.Reverse();
            return parents;
        }

    }
}
