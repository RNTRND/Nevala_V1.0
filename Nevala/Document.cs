using Nevala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nevala
{
    public class Document
    {
        public DocumentForm ActiveDocument
        {
            get
            {

                return ((MainWindow)System.Windows.Application.Current.MainWindow).documentsRoot.Children.FirstOrDefault(c => c.Content == ((MainWindow)System.Windows.Application.Current.MainWindow).dockPanel.ActiveContent) as DocumentForm;
            }
        }

        public IEnumerable<DocumentForm> Documents
        {
            get { return ((MainWindow)System.Windows.Application.Current.MainWindow).documentsRoot.Children.Cast<DocumentForm>(); }
        }
    }
}
