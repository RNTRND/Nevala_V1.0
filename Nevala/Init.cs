using ScintillaNET;
using ScintillaNET.WPF;
using ScintillaNET_FindReplaceDialog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Drawing;

namespace Nevala
{
    public class Init
    {
       
        #region Fields

        private const string NEW_DOCUMENT_TEXT = "Untitled";
        private const int LINE_NUMBERS_MARGIN_WIDTH = 30; // TODO - don't hardcode this

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0xe8e9ef;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0x000000;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;

        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = false;

        private static int _newDocumentCount;
        
        private const string ProductName = "Nevala";
        private Document Document { get; set; }
        private FindReplace MyFindReplace;
       
        #endregion Fields

        #region Constructors
        public Init(Document document)
        {
            Document = document;
            //Call Find Replace or find an alternative
           // NewDocument();
        }
        #endregion

        #region Methods

        private void InitBookmarkMargin(ScintillaWPF ScintillaNet)
        {
            //TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = ScintillaNet.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = ScintillaNet.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);
        }

        private void InitCodeFolding(ScintillaWPF ScintillaNet)
        {
            ScintillaNet.SetFoldMarginColor(true, IntToMediaColor(BACK_COLOR));
            ScintillaNet.SetFoldMarginHighlightColor(true, IntToMediaColor(BACK_COLOR));

            // Enable code folding
            ScintillaNet.SetProperty("fold", "1");
            ScintillaNet.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            ScintillaNet.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            ScintillaNet.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            ScintillaNet.Margins[FOLDING_MARGIN].Sensitive = true;
            ScintillaNet.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                ScintillaNet.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                ScintillaNet.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            ScintillaNet.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            ScintillaNet.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            ScintillaNet.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            ScintillaNet.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            ScintillaNet.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            ScintillaNet.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            ScintillaNet.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            ScintillaNet.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private void InitColors(ScintillaWPF ScintillaNet)
        {
            ScintillaNet.CaretForeColor = Colors.Black;
            ScintillaNet.SetSelectionBackColor(true, IntToMediaColor(0xffee00));

            //FindReplace.Indicator.ForeColor = System.Drawing.Color.DarkOrange;
        }

        private void InitNumberMargin(ScintillaWPF ScintillaNet)
        {
            ScintillaNet.Styles[ScintillaNET.Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            ScintillaNet.Styles[ScintillaNET.Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            ScintillaNet.Styles[ScintillaNET.Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            ScintillaNet.Styles[ScintillaNET.Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);

            var nums = ScintillaNet.Margins[NUMBER_MARGIN];
            nums.Width = LINE_NUMBERS_MARGIN_WIDTH;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            ScintillaNet.MarginClick += TextArea_MarginClick;
        }

        private void InitSyntaxColoring(ScintillaWPF ScintillaNet)
        {
            // Configure the default style
            ScintillaNet.StyleResetDefault();
            ScintillaNet.Styles[ScintillaNET.Style.Default].Font = "Consolas";
            ScintillaNet.Styles[ScintillaNET.Style.Default].Size = 10;
            ScintillaNet.Styles[ScintillaNET.Style.Default].BackColor = IntToColor(0xFFFFFF);
            ScintillaNet.Styles[ScintillaNET.Style.Default].ForeColor = IntToColor(0x000000);
            ScintillaNet.StyleClearAll();

            // Configure the Python lexer styles
            ScintillaNet.Styles[ScintillaNET.Style.Python.Default].ForeColor = System.Drawing.Color.Black;
            ScintillaNet.Styles[ScintillaNET.Style.Python.CommentLine].ForeColor = System.Drawing.Color.Red; 
            ScintillaNet.Styles[ScintillaNET.Style.Python.CommentLine].Italic = true;
            ScintillaNet.Styles[ScintillaNET.Style.Python.Number].ForeColor = System.Drawing.Color.FromArgb(0x00, 0x7F, 0x7F);
            ScintillaNet.Styles[ScintillaNET.Style.Python.String].ForeColor = System.Drawing.Color.LightBlue;
            ScintillaNet.Styles[ScintillaNET.Style.Python.Character].ForeColor = System.Drawing.Color.Silver;
            ScintillaNet.Styles[ScintillaNET.Style.Python.Word].ForeColor = System.Drawing.Color.FromArgb(0x00, 0x00, 0x7F);
            ScintillaNet.Styles[ScintillaNET.Style.Python.Word].Bold = true;
            ScintillaNet.Styles[ScintillaNET.Style.Python.Triple].ForeColor = System.Drawing.Color.DarkRed;
            ScintillaNet.Styles[ScintillaNET.Style.Python.TripleDouble].ForeColor = System.Drawing.Color.FromArgb(0x7F, 0x00, 0x00);
            ScintillaNet.Styles[ScintillaNET.Style.Python.ClassName].ForeColor = System.Drawing.Color.FromArgb(0x00, 0x00, 0xFF);
            ScintillaNet.Styles[ScintillaNET.Style.Python.ClassName].Bold = true;
            ScintillaNet.Styles[ScintillaNET.Style.Python.DefName].ForeColor = System.Drawing.Color.FromArgb(0x00, 0x7F, 0x7F);
            ScintillaNet.Styles[ScintillaNET.Style.Python.DefName].Bold = true;
            ScintillaNet.Styles[ScintillaNET.Style.Python.Operator].Bold = true;
            ScintillaNet.Styles[ScintillaNET.Style.Python.CommentBlock].ForeColor = System.Drawing.Color.FromArgb(0x7F, 0x7F, 0x7F);
            ScintillaNet.Styles[ScintillaNET.Style.Python.CommentBlock].Italic = true;
            ScintillaNet.Styles[ScintillaNET.Style.Python.StringEol].ForeColor = System.Drawing.Color.FromArgb(0x00, 0x00, 0x00);
            ScintillaNet.Styles[ScintillaNET.Style.Python.StringEol].BackColor = System.Drawing.Color.FromArgb(0xE0, 0xC0, 0xE0);
            ScintillaNet.Styles[ScintillaNET.Style.Python.StringEol].FillLine = true;
            ScintillaNet.Styles[ScintillaNET.Style.Python.Word2].ForeColor = System.Drawing.Color.FromArgb(0x40, 0x70, 0x90);
            ScintillaNet.Styles[ScintillaNET.Style.Python.Decorator].ForeColor = System.Drawing.Color.FromArgb(0x80, 0x50, 0x00);

            ScintillaNet.Lexer = Lexer.Python; ;
                                             
            ScintillaNet.SetKeywords(0, "False None True and as assert break class continue def del elif else except finally for from global if import in is lambda nonlocal not or pass raise return try while with yield cdef cimport cpdef");
            //ScintillaNet.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");
        }

        /// <summary>
        /// Converts a Win32 colour to a Drawing.Color
        /// </summary>
        /// <param name="rgb">A Win32 color.</param>
        /// <returns>A System.Drawing color.</returns>
        public static System.Drawing.Color IntToColor(int rgb)
        {
            return System.Drawing.Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        /// <summary>
        /// Converts a Win32 colour to a Media Color
        /// </summary>
        /// <param name="rgb">A Win32 color.</param>
        /// <returns>A System.Media color.</returns>
        public static System.Windows.Media.Color IntToMediaColor(int rgb)
        {
            return System.Windows.Media.Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void MyFindReplace_KeyPressed(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            ScintillaNet_KeyDown(sender, e);
        }

        public DocumentForm NewDocument()
        {
            DocumentForm doc = new DocumentForm();
            SetScintillaToCurrentOptions(doc);
            doc.Title = String.Format(CultureInfo.CurrentCulture, "{0}{1}", NEW_DOCUMENT_TEXT, ++_newDocumentCount);
            ((MainWindow)System.Windows.Application.Current.MainWindow).documentsRoot.Children.Add(doc);
            doc.DockAsDocument();
            doc.IsActive = true;

            return doc;
        }

        public void OpenFile()
        {
            bool? res = ((MainWindow)System.Windows.Application.Current.MainWindow).openFileDialog.ShowDialog();
            if (res == null || !(bool)res)
                return;

            foreach (string filePath in ((MainWindow)System.Windows.Application.Current.MainWindow).openFileDialog.FileNames)
            {
                // Ensure this file isn't already open
                bool isOpen = false;
                foreach (DocumentForm documentForm in Document.Documents)
                {
                    if (filePath.Equals(documentForm.FilePath, StringComparison.OrdinalIgnoreCase))
                    {
                        documentForm.IsActive = true;
                        isOpen = true;
                        break;
                    }
                }

                // Open the files
                if (!isOpen)
                    OpenFile(filePath);
            }
        }

        private DocumentForm OpenFile(string filePath)
        {
            DocumentForm doc = new DocumentForm();
            doc.Scintilla.Text = File.ReadAllText(filePath);
            SetScintillaToCurrentOptions(doc);
            //doc.Scintilla.UndoRedo.EmptyUndoBuffer();
            //doc.Scintilla.Modified = false;
            doc.Title = Path.GetFileName(filePath);
            doc.FilePath = filePath;
            ((MainWindow)System.Windows.Application.Current.MainWindow).documentsRoot.Children.Add(doc);
            doc.DockAsDocument();
            doc.IsActive = true;
            //incrementalSearcher.Scintilla = doc.Scintilla;

            return doc;
        }
    
        private void SetScintillaToCurrentOptions(DocumentForm doc)
        {
            ScintillaWPF ScintillaNet = doc.Scintilla;
            ScintillaNet.KeyDown += ScintillaNet_KeyDown;

            // INITIAL VIEW CONFIG
            ScintillaNet.WrapMode = WrapMode.None;
            ScintillaNet.IndentationGuides = IndentView.LookBoth;

            // STYLING
            InitColors(ScintillaNet);
            InitSyntaxColoring(ScintillaNet);

            // NUMBER MARGIN
            InitNumberMargin(ScintillaNet);

            // BOOKMARK MARGIN
            InitBookmarkMargin(ScintillaNet);

            // CODE FOLDING MARGIN
            InitCodeFolding(ScintillaNet);

            // DRAG DROP
            // TODO - Enable InitDragDropFile
            //InitDragDropFile();

            // INIT HOTKEYS
            // TODO - Enable InitHotkeys
            //InitHotkeys(ScintillaNet);
            #region Uncomment Later
            //// Turn on line numbers?
            //if (lineNumbersMenuItem.IsChecked)
            //    doc.Scintilla.Margins[NUMBER_MARGIN].Width = LINE_NUMBERS_MARGIN_WIDTH;
            //else
            //    doc.Scintilla.Margins[NUMBER_MARGIN].Width = 0;

            //// Turn on white space?
            //if (whitespaceMenuItem.IsChecked)
            //    doc.Scintilla.ViewWhitespace = WhitespaceMode.VisibleAlways;
            //else
            //    doc.Scintilla.ViewWhitespace = WhitespaceMode.Invisible;

            //// Turn on word wrap?
            //if (wordWrapMenuItem.IsChecked)
            //    doc.Scintilla.WrapMode = WrapMode.Word;
            //else
            //    doc.Scintilla.WrapMode = WrapMode.None;

            //// Show EOL?
            //doc.Scintilla.ViewEol = endOfLineMenuItem.IsChecked;

            //// Set the zoom
            //doc.Scintilla.Zoom = _zoomLevel;
        #endregion
        }

        private void ScintillaNet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == System.Windows.Forms.Keys.F)
            {
                MyFindReplace.ShowFind();
                e.SuppressKeyPress = true;
            }
            else if (e.Shift && e.KeyCode == System.Windows.Forms.Keys.F3)
            {
                MyFindReplace.Window.FindPrevious();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F3)
            {
                MyFindReplace.Window.FindNext();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == System.Windows.Forms.Keys.H)
            {
                MyFindReplace.ShowReplace();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == System.Windows.Forms.Keys.I)
            {
                MyFindReplace.ShowIncrementalSearch();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == System.Windows.Forms.Keys.G)
            {
                GoTo MyGoTo = new GoTo((Scintilla)sender);
                MyGoTo.ShowGoToDialog();
                e.SuppressKeyPress = true;
            }
        }

        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            ScintillaNET.WPF.ScintillaWPF TextArea = Document.ActiveDocument.Scintilla;

            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = TextArea.Lines[TextArea.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        private static Visibility Toggle(Visibility v)
        {
            if (v == Visibility.Visible)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }   

        public void lineNumbers()
        {
            // Toggle the line numbers margin for all documents
            ((MainWindow)System.Windows.Application.Current.MainWindow).lineNumbersMenuItem.IsChecked = !((MainWindow)System.Windows.Application.Current.MainWindow).lineNumbersMenuItem.IsChecked;
            foreach (DocumentForm docForm in Document.Documents)
            {
                if (((MainWindow)System.Windows.Application.Current.MainWindow).lineNumbersMenuItem.IsChecked)
                    docForm.Scintilla.Margins[NUMBER_MARGIN].Width = LINE_NUMBERS_MARGIN_WIDTH;
                else
                    docForm.Scintilla.Margins[NUMBER_MARGIN].Width = 0;
            }
        }

        #region Folding
        public void fold()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.Lines[Document.ActiveDocument.Scintilla.CurrentLine].FoldLine(FoldAction.Contract);
        }

        public void unfold()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.Lines[Document.ActiveDocument.Scintilla.CurrentLine].FoldLine(FoldAction.Expand);
        }

        public void foldAll()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.FoldAll(FoldAction.Contract);
        }

        public void unfoldAll()
        {
            if (Document.ActiveDocument != null)
                Document.ActiveDocument.Scintilla.FoldAll(FoldAction.Expand);
        }
        #endregion

        #region Bookmarks

        public void ToggleBookmark()
        {
            Line currentLine = Document.ActiveDocument.Scintilla.Lines[Document.ActiveDocument.Scintilla.CurrentLine];
            const uint mask = (1 << BOOKMARK_MARKER);
            uint markers = currentLine.MarkerGet();
            if ((markers & mask) > 0)
            {
                currentLine.MarkerDelete(BOOKMARK_MARKER);
            }
            else
            {
                currentLine.MarkerAdd(BOOKMARK_MARKER);
            }
        }

        public void PreviousBookmark()
        {
            //	 I've got to redo this whole FindNextMarker/FindPreviousMarker Scheme
            int lineNumber = Document.ActiveDocument.Scintilla.Lines[Document.ActiveDocument.Scintilla.CurrentLine - 1].MarkerPrevious(1 << BOOKMARK_MARKER);
            if (lineNumber != -1)
                Document.ActiveDocument.Scintilla.Lines[lineNumber].Goto();
        }

        public void NextBookmark()
        {
            //	 I've got to redo this whole FindNextMarker/FindPreviousMarker Scheme
            int lineNumber = Document.ActiveDocument.Scintilla.Lines[Document.ActiveDocument.Scintilla.CurrentLine + 1].MarkerNext(1 << BOOKMARK_MARKER);
            if (lineNumber != -1)
                Document.ActiveDocument.Scintilla.Lines[lineNumber].Goto();
        }

        public void ClearBookmarks()
        {
            Document.ActiveDocument.Scintilla.MarkerDeleteAll(BOOKMARK_MARKER);
        }

        #endregion //Bookmarks

        #region WordWrap
        public void wordWrap()
        {
            // Toggle word wrap for all open files
            ((MainWindow)System.Windows.Application.Current.MainWindow).wordWrapMenuItem.IsChecked = !((MainWindow)System.Windows.Application.Current.MainWindow).wordWrapMenuItem.IsChecked;
            foreach (DocumentForm doc in Document.Documents)
            {
                if (((MainWindow)System.Windows.Application.Current.MainWindow).wordWrapMenuItem.IsChecked)
                    doc.Scintilla.WrapMode = WrapMode.Word;
                else
                    doc.Scintilla.WrapMode = WrapMode.None;
            }
        }
        #endregion

        #region Zoom
        private static int _zoomLevel;

        private void UpdateAllScintillaZoom()
        {
            // Update zoom level for all files
            // TODO - DocumentsSource is null. This is probably supposed to zoom all windows, not just the document style windows.
            //foreach (DocumentForm doc in dockPanel.DocumentsSource)
            //    doc.Scintilla.Zoom = _zoomLevel;

            // TODO - Ideally remove this once the zoom for all windows is working.
            foreach (DocumentForm doc in ((MainWindow)System.Windows.Application.Current.MainWindow).documentsRoot.Children)
                doc.Scintilla.Zoom = _zoomLevel;
        }

        public void zoomIn()
        {
            // Increase the zoom for all open files
            _zoomLevel++;
            UpdateAllScintillaZoom();
        }

        public void zoomOut()
        {
            _zoomLevel--;
            UpdateAllScintillaZoom();
        }
        #endregion
        #endregion Methods
    }
}
