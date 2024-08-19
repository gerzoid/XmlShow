using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using XMLViewer2.Models;

namespace XMLViewer2.Classes
{
    public class Searcher
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
                if (model != null)
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

            if (startSearching)
            {
                bool finded = false;
                if (model.isAttribute && (model.attribute.InnerText.Contains(searchTerm) || model.attribute.Name.Contains(searchTerm)))
                    finded = true;
                if (!finded && model?.node?.FirstChild?.NodeType != XmlNodeType.Element && (model?.node?.InnerText.Contains(searchTerm) ?? false))
                    finded = true;
                if (!finded && (model?.node?.Name?.Contains(searchTerm) ?? false) ||
                    (model?.attribute?.Name?.Contains(searchTerm) ?? false))
                    finded = true;
                if (finded)
                {
                    _lastFoundNode = model; // Сохраняем текущий найденный узел
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
                    if (findedModel != null)
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
            catch (OperationCanceledException)
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
            if (model == null)
            {
                MessageBox.Show("Элемент не найден.");
            }
            return model;
        }

        public async Task<ModelXML?> SearchNextAsync(TreeListView treeListView)
        {
            if (_lastFoundNode == null)
            {
                MessageBox.Show("Запустите поиск перед использованием 'Поиск далее'.");
                return null;
            }

            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();
            var cancelationToken = _cancellationTokenSource.Token;

            try
            {
                return await Task.Run(() => FindNextNode(treeListView, _currentSearchTerm), cancelationToken);
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Поиск отменен");
            }
            finally
            {
                if (_cancellationTokenSource != null) 
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
            return null;
        }
    }
}
