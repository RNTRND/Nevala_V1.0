using ScintillaNET;
using ScintillaNET_FindReplaceDialog;
using System.Windows.Input;

namespace Nevala
{
    public class EditViewModel
    {
        #region Commands
        public ICommand UndoCommand { get; set; }
        public ICommand RedoCommand { get; set; }
        public ICommand CutCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        public ICommand PasteCommand { get; set; }
        public ICommand SelectLineCommand { get; set; }
        public ICommand SelectAllCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand IncrementalSearchCommand { get; set; }
        public ICommand FindCommand { get; set; }
        public ICommand ReplaceCommand { get; set; }
        public ICommand ToggleBookmarkCommand { get; set; }
        public ICommand PreviousBookmarkCommand { get;  set; }
        public ICommand NextBookmarkCommand { get;  set; }
        public ICommand ClearBookmarksCommand { get;  set; }
        public ICommand MakeUpperCaseCommand { get; set; }
        public ICommand MakeLowerCaseCommand { get; set; }
        #endregion Commands

        #region Properties
        private Document Document { get; set; }
        private Init init { get; set; }
        #endregion

        #region Constructor

        public EditViewModel(Document document)
        {
            Document = document;
            UndoCommand = new RelayCommand(Undo);
            RedoCommand = new RelayCommand(Redo);
            CutCommand = new RelayCommand(Cut);
            CopyCommand = new RelayCommand(Copy);
            PasteCommand = new RelayCommand(Paste);
            SelectLineCommand = new RelayCommand(SelectLine);
            SelectAllCommand = new RelayCommand(SelectAll);
            ClearCommand = new RelayCommand(Clear);
            IncrementalSearchCommand = new RelayCommand(IncrementalSearch);
            FindCommand = new RelayCommand(Find);
            ReplaceCommand = new RelayCommand(Replace);
            ToggleBookmarkCommand = new RelayCommand(ToggleBookmark);
            PreviousBookmarkCommand = new RelayCommand(PreviousBookmark);
            NextBookmarkCommand = new RelayCommand(NextBookmark);
            ClearBookmarksCommand = new RelayCommand(ClearBookmarks);
            MakeUpperCaseCommand = new RelayCommand(MakeUpperCase);
            MakeLowerCaseCommand = new RelayCommand(MakeLowerCase);

        }

        #endregion Constructor

        #region Undo
        private void Undo()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.Undo();
        }
        #endregion //Undo

        #region Redo
        private void Redo()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.Redo();
        }

        #endregion Redo

        #region Cut

        private void Cut()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.Cut();
        }
        #endregion Cut

        #region Copy
        private void Copy()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.Copy();
        }
        #endregion Copy

        #region Paste
        private void Paste()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.Paste();
        }

        #endregion Paste

        #region SelectLine
        private void SelectLine()
        {
            if (Document.ActiveDocument != null)
            {
                Line line = Document.ActiveDocument.Scintilla.Lines[Document.ActiveDocument.Scintilla.CurrentLine];
                Document.ActiveDocument.Scintilla.SetSelection(line.Position + line.Length, line.Position);
            }
           
        }
        #endregion selectLine

        #region SelectAll
        private void SelectAll()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.SelectAll();
        }
        #endregion selectAll

        #region Clear
        private void Clear()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.SetEmptySelection(0);
        }
        #endregion Clear

        #region Find and Replace

        private void IncrementalSearch()
        {
            Document.ActiveDocument.FindReplace.ShowIncrementalSearch();
        }

        private void Find()
        {
            Document.ActiveDocument.FindReplace.ShowFind();
        }

        private void Replace()
        {
            Document.ActiveDocument.FindReplace.ShowReplace();
        }
        #endregion Find and Replace

        #region Go_to
        private void Go_to()
        {
            GoTo MyGoTo = new GoTo(Document.ActiveDocument.Scintilla.Scintilla);
            MyGoTo.ShowGoToDialog();
        }
        #endregion goto

        #region Bookmarks
        private void ToggleBookmark()
        {
            init = new Init(Document);
            init.ToggleBookmark();
        }
        
        private void PreviousBookmark()
        {
            init = new Init(Document);
            init.PreviousBookmark();
        }

        private void NextBookmark()
        {
            init = new Init(Document);
            init.NextBookmark();
        }

        private void ClearBookmarks()
        {
            init = new Nevala.Init(Document);
            init.ClearBookmarks();
        }
        #endregion Bookmarks

        #region Advanced

        private void MakeUpperCase()
        {
            Document.ActiveDocument.Scintilla.ExecuteCmd(Command.Uppercase);
        }

        private void MakeLowerCase()
        {
            Document.ActiveDocument.Scintilla.ExecuteCmd(Command.Lowercase);
        }
        #endregion Advanced
    }
}



        