﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nevala
{
    public class FileViewModel
    {
         
        #region Commands
        public ICommand NewCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SaveFileAsCommand { get; set; }
        public ICommand SaveAllCommand { get; set; } 
        public ICommand CloseCommand { get; set; }
        public ICommand CloseAllCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand DockPanelContentChanged { get; set; }
        public ICommand WindowLoaded { get; set; }
        #endregion //Commands

        #region Private Properties
        private Document Document { get; set; }
        private Init init { get; set; }
        public object MyFindReplace { get; private set; }
        #endregion //Private Properties

        #region Constructor

        public FileViewModel(Document document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            OpenCommand = new RelayCommand(OpenFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveFileAsCommand = new RelayCommand(SaveFileAs);
            SaveAllCommand = new RelayCommand(SaveAllFiles);
            CloseCommand = new RelayCommand(CloseFile);
            CloseAllCommand = new RelayCommand(CloseAllFiles);
            ExitCommand = new RelayCommand(ExitApplication);
            DockPanelContentChanged = new RelayCommand(DockPanelActiveContentChanged);
            WindowLoaded = new RelayCommand(OnWindowLoaded);
            //CheckIsNull = new RelayCommand(IfNull);
        }

        #endregion

        #region New 
        private void NewFile()
        {
            init = new Init(Document);
            init.NewDocument();
        }
        #endregion //New

        #region Open
        private void OpenFile()
        {
            init = new Init(Document);
            init.OpenFile();
        }
        #endregion //Open
        
        #region Save    
        private void SaveFile()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Save();
        }
        #endregion //Save

        #region Save As
        private void SaveFileAs()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.SaveAs();
        }
        #endregion //Save As

        #region Save All
        private void SaveAllFiles()
        {
            foreach (DocumentForm doc in Document.Documents)
                doc.Save();
        }
        #endregion //Save All

        #region Close
        private void CloseFile()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).documentsRoot.Children.Remove(Document.ActiveDocument);
            if (((MainWindow)System.Windows.Application.Current.MainWindow).documentsRoot.Children.Count() == 0)
                NewFile();
        }
        #endregion //Close

        #region Close All
        private void CloseAllFiles()
        {      
            try
            {
                foreach (DocumentForm doc in Document.Documents)
                    ((MainWindow)System.Windows.Application.Current.MainWindow).documentsRoot.Children.Remove(doc);
            }
            catch
            {
                if (Document.Documents.Count() == 1)
                    CloseFile();
                else if (Document.Documents.Count() > 1)
                    CloseAllFiles();
                else
                    NewFile();
            }
                     
        }
        #endregion //Close All

        #region Exit
        private void ExitApplication()
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).Close();
        }
        #endregion //Exit

        #region Dock Panel Content Changed
        public void DockPanelActiveContentChanged()
        {
            if (Document.ActiveDocument != null)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Title = String.Format(CultureInfo.CurrentCulture, "{0} - {1}", Document.ActiveDocument.Title, Program.Title);  
                //MyFindReplace.Scintilla = Document.ActiveDocument.Scintilla.Scintilla;
                //Document.ActiveDocument.FindReplace = MyFindReplace;
            }
            else
                ((MainWindow)System.Windows.Application.Current.MainWindow).Title = Program.Title;
        }
        #endregion // Dock Panel Content Changed

        //#region If no document is open

        //private void IfNull()
        //{
        //    if (Document.Documents == null)
        //        NewFile();
        //}

        //#endregion //If no document is open

        #region On Window Loaded
        private void OnWindowLoaded()
        {
            NewFile();
        }
        #endregion // On Window Loaded

    }
}