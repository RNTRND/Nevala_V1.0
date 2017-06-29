using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nevala
{
    public class ViewModel
    {

        #region Commands 
        public ICommand ZooomInCommand { get; set; }
        public ICommand ZoomOutCommand { get; set; }
        public ICommand LineNumbersCommand { get; set; }
        public ICommand WordWrapCommand { get; set; }
        public ICommand FoldCommand { get; set; }
        public ICommand UnFoldCommand { get; set; }
        public ICommand FoldAllCommand { get; set; }
        public ICommand UnFoldAllCommand { get; set; }
        #endregion

        #region Private Properties
        private Document Document { get; set; }
        private Init init { get; set; }
        #endregion

        #region Constructor
        public ViewModel(Document document)
        {
            Document = document;
            ZooomInCommand = new RelayCommand(ZoomIn);
            ZoomOutCommand = new RelayCommand(ZoomOut);
            LineNumbersCommand = new RelayCommand(LineNumbers);
            WordWrapCommand = new RelayCommand(WordWrap);
            FoldCommand = new RelayCommand(Fold);
            UnFoldCommand = new RelayCommand(Unfold);
            FoldAllCommand = new RelayCommand(FoldAll);
            UnFoldAllCommand = new RelayCommand(UnFoldAll);
        }

        #endregion

        #region ZoomIn
        private void ZoomIn()
        {
            init = new Init(Document);
            init.zoomIn();
        }
        #endregion

        #region ZoomOut
        private void ZoomOut()
        {
            init = new Init(Document);
            init.zoomOut();
        }
        #endregion

        #region Line Numbers
        private void LineNumbers()
        {
            init = new Init(Document);
            init.lineNumbers();
        }
        #endregion

        #region WordWrap
        private void WordWrap()
        {
            init = new Init(Document);
            init.wordWrap();
        }
        #endregion

        #region Fold
        private void Fold()
        {
            init = new Init(Document);
            init.fold();
        }
        #endregion

        #region Unfold
        private void Unfold()
        {
            init = new Init(Document);
            init.unfold();
        }
        #endregion

        #region Fold All
        private void FoldAll()
        {
            init = new Init(Document);
            init.foldAll();
        }
        #endregion

        #region Unfold All
        private void UnFoldAll()
        {
            init = new Init(Document);
            init.unfoldAll();
        }
        #endregion

        
    }
}
